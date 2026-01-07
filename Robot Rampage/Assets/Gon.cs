using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gon : MonoBehaviour
{
    public float fireRate;
    [SerializeField]
    protected float lastFireTime;

    public Ammo ammo;
    public AudioClip liveFire;
    public AudioClip dryFire;

    public float zoomFactor;
    public int range;
    public int damage;
    private float zoomFOV;
    private float zoomSpeed = 6;
    public string name = "";
    public GameObject flashSpawn;
    public GameObject flashToSpawn;
    private GameObject flash;
    // Start is called before the first frame update
    void Start()
    {
        zoomFOV = Constants.CameraDefaultZoom/zoomFactor;
        lastFireTime = Time.time - 10;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomFOV, zoomSpeed*Time.deltaTime);
        }
        else { Camera.main.fieldOfView = Constants.CameraDefaultZoom; }
    }

    private void ProcessHit(GameObject hitObject)
    {
        if(hitObject.GetComponent<Player>() != null)
        {
            hitObject.GetComponent<Player>().TakeDamage(damage);
        }
        if(hitObject.GetComponent<Robot>() != null)
        {
            hitObject.GetComponent<Robot>().TakeDamage(damage);
        }
    }

    protected void Fire()
    {
        if (!ammo.HasAmmo(tag))
        {
            GetComponent<AudioSource>().PlayOneShot(dryFire); return;
        }
        else if (ammo.HasAmmo(tag))
        {
            GetComponent<AudioSource>().PlayOneShot(liveFire); ammo.ConsumeAmmo(tag);
        }
        flash = Instantiate(flashToSpawn, flashSpawn.transform.position, flashSpawn.transform.rotation);
        GetComponentInChildren<Animator>().Play(name + "Shoot");

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, range))
        {
            ProcessHit(hit.collider.gameObject);
        }
    }
}
