using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int armor;
    public GameUI gameUI;
    private GunEquipper gunEquipper;
    private Ammo ammo;
    public Game game;
    public AudioClip playerDead;
    // Start is called before the first frame update
    void Start()
    {
        ammo = GetComponent<Ammo>();
        gunEquipper = GetComponent<GunEquipper>();
    }

    public void TakeDamage(int amount)
    {
        int healthDamage = amount;
        if(armor > 0)
        {
            int effectiveArmor = armor * 2;
            effectiveArmor -= healthDamage;
            if(effectiveArmor > 0)
            {
                armor = effectiveArmor / 2;
                gameUI.SetArmorText(armor);
                return;
            }

            armor = 0;
            gameUI.SetArmorText((int)armor);

        }

        health -= healthDamage;
        gameUI.SetHealthText(health);
        Debug.Log("Health is " +  health);

        if(health <= 0)
        {
            Debug.Log("GameOver");
            GetComponent<AudioSource>().PlayOneShot(playerDead);
            game.GameOver();
        }
    }

    void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, 2.68f, transform.position.z);
    }

    private void PickupHealth()
    {
        health += 50;
        if (health > 200) { health = 200; }
        gameUI.SetPickupText("Health picked up + 50 Health");
        gameUI.SetHealthText((int)health);
    }
    private void PickupArmor() { armor += 15; gameUI.SetPickupText("Armor picked up + 15 Armor"); gameUI.SetArmorText(armor); }
    private void PickupAssaultRifleAmmo() { ammo.AddAmmo(Constants.AssaultRifle, 50); gameUI.SetPickupText("+50 Assault Ammo"); if (gunEquipper.GetActiveWeapon().tag == Constants.AssaultRifle) { gameUI.SetAmmoText(ammo.getAmmo(Constants.AssaultRifle)); } }
    private void PickupPistolAmmo() { ammo.AddAmmo(Constants.Pistol, 20); gameUI.SetPickupText("+20 Pistol Ammo"); if (gunEquipper.GetActiveWeapon().tag == Constants.Pistol) { gameUI.SetAmmoText(ammo.getAmmo(Constants.Pistol)); } }
    private void PickupShotgunAmmo() { ammo.AddAmmo(Constants.Shotgun, 10); gameUI.SetPickupText("+10 Shotgun Ammo"); if (gunEquipper.GetActiveWeapon().tag == Constants.Shotgun) { gameUI.SetAmmoText(ammo.getAmmo(Constants.Shotgun)); } }
    private void PickupSniperAmmo() { ammo.AddAmmo(Constants.Sniper, 5); gameUI.SetPickupText("+5 Sniper Ammo"); if (gunEquipper.GetActiveWeapon().tag == Constants.Sniper) { gameUI.SetAmmoText(ammo.getAmmo(Constants.Sniper)); } }
    public void PickUpItem(int pickupType)
    {
        switch (pickupType)
        {
            case Constants.PickUpHealth:
                PickupHealth(); break;
            case Constants.PickUpArmor:
                PickupArmor(); break;
            case Constants.PickUpAssaultRifleAmmo:
                PickupAssaultRifleAmmo();
                break;
            case Constants.PickUpPistolAmmo:
                PickupPistolAmmo();
                break;
            case Constants.PickUpShotgunAmmo:
                PickupShotgunAmmo();
                break;
            case Constants.PickUpSniperAmmo:
                PickupSniperAmmo();
                break;
            default:
                Debug.LogError("bad pickup type: " + pickupType);
                break;
        }
    }

}
