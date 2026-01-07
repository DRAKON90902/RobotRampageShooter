using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 30f;
    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DeathTimer");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Player>() != null && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
