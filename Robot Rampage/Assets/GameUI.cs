using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    Sprite redReticle;
    [SerializeField]
    Sprite yellowReticle;
    [SerializeField]
    Sprite blueReticle;
    [SerializeField]
    Sprite sniperReticle;
    [SerializeField]
    Image reticle;
    [SerializeField]
    private Text ammoText;
    [SerializeField]
    private Text healthText;
    [SerializeField]
    private Text armorText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text pickupText;
    [SerializeField]
    private Text waveText;
    [SerializeField]
    private Text enemyText;
    [SerializeField]
    private Text waveClearText;
    [SerializeField]
    private Text newWaveText;
    [SerializeField]
    Player player;

    private void Start()
    {
        SetArmorText(player.armor);
        SetHealthText(player.health);
        SetAmmoText(player.GetComponent<Ammo>().getAmmo("Pistol"));
    }

    public void SetArmorText(int armor)
    {
        armorText.text = "Armor: " + armor;
    }
    public void SetHealthText(int armor)
    {
        armorText.text = "Health: " + armor;
    }
    public void SetAmmoText(int armor)
    {
        armorText.text = "Ammo: " + armor;
    }
    public void SetScoreText(int armor)
    {
        armorText.text = "Score: " + armor;
    }
    public void SetWaveText(int armor)
    {
        armorText.text = "Next Wave: " + armor;
    }
    public void SetEnemyText(int armor)
    {
        armorText.text = "Enemies: " + armor;
    }

    IEnumerator HideWaveClearBonus()
    {
        yield return new WaitForSeconds(2);
        waveClearText.GetComponent<Text>().enabled = false;
    }

    public void ShowWaveClearBonus()
    {
        waveClearText.GetComponent<Text>().enabled=true;
        StartCoroutine("HideWaveClearBonus");
    }
    IEnumerator HidePickupText()
    {
        yield return new WaitForSeconds(2);
        pickupText.GetComponent<Text>().enabled = false;
    }

    public void SetPickupText(string text)
    {
        waveClearText.GetComponent<Text>().enabled = true;
        pickupText.text = text;
        StopCoroutine("HidePickupText");
        StartCoroutine("HidePickupText");
    }
    IEnumerator HideNewWaveText()
    {
        yield return new WaitForSeconds(2);
        newWaveText.GetComponent<Text>().enabled = false;
    }

    public void ShowNewWaveText()
    {
        StartCoroutine("HideNewWaveText");
        newWaveText.GetComponent<Text>().enabled = true;

    }
    public void UpdateReticle()
    {
        switch(GunEquipper.activeWeaponType)
        {
            case Constants.Pistol: reticle.sprite = redReticle; break;
            case Constants.AssaultRifle: reticle.sprite = blueReticle; break;
            case Constants.Shotgun: reticle.sprite = yellowReticle; break;
            case Constants.Sniper: reticle.sprite = sniperReticle; break;
            default: return;
        }
    }
}
