using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEquipper : MonoBehaviour
{
    public static string activeWeaponType;
    public GameObject pistol;
    public GameObject assaultRifle;
    public GameObject shotgun;
    public GameObject sniper;

    [SerializeField]
    GameUI gameUI;
    [SerializeField]
    Ammo ammo;

    GameObject activeGun;
    // Start is called before the first frame update
    void Start()
    {
        activeWeaponType = Constants.Pistol;
        activeGun = pistol;
    }

    private void LoadWeapon(GameObject weapon)
    {
        pistol.SetActive(false);
        assaultRifle.SetActive(false);
        shotgun.SetActive(false);
        sniper.SetActive(false);
        weapon.SetActive(true);
        activeGun = weapon;
        gameUI.SetAmmoText(ammo.getAmmo(activeGun.tag));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) { LoadWeapon(pistol); activeWeaponType = Constants.Pistol; gameUI.UpdateReticle(); }
        else if (Input.GetKeyDown("2")) {LoadWeapon(assaultRifle); activeWeaponType = Constants.AssaultRifle; gameUI.UpdateReticle(); }
        else if(Input.GetKeyDown("3"))  {LoadWeapon(shotgun); activeWeaponType = Constants.Shotgun; gameUI.UpdateReticle(); }
        else if (Input.GetKeyDown("4")) { LoadWeapon(sniper); activeWeaponType = Constants.Sniper; gameUI.UpdateReticle(); }
    }

    public GameObject GetActiveWeapon() { return activeGun; }
}
