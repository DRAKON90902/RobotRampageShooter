using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    GameUI gameUI;
    [SerializeField]
    private int pistolAmmo = 20;
    [SerializeField]
    private int shotgunAmmo = 80;
    [SerializeField]
    private int assaultRifleAmmo = 50;
    [SerializeField]
    private int sniperAmmo = 10;

    public Dictionary<string, int> tagToAmmo;

    void Awake()
    {
        tagToAmmo = new Dictionary<string, int> { { Constants.Pistol, pistolAmmo }, { Constants.Shotgun, shotgunAmmo }, { Constants.AssaultRifle, assaultRifleAmmo }, { Constants.Sniper, sniperAmmo} };
    }

    public void AddAmmo(string tag, int ammo)
    {
        if (!tagToAmmo.ContainsKey(tag)) Debug.LogError("Unrecongized weapon type" + tag);
        tagToAmmo[tag] += ammo;
    }

    public bool HasAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag)) Debug.LogError("Unrecongized weapon type" + tag);
        return tagToAmmo[tag] > 0;
    }

    public int getAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag)) Debug.LogError("Unrecongized weapon type" + tag);
        return tagToAmmo[tag];
    }

    public void ConsumeAmmo(string tag)
    {
        if (!tagToAmmo.ContainsKey(tag)) Debug.LogError("Unrecongized weapon type" + tag);
        tagToAmmo[tag]--;
        gameUI.SetAmmoText(tagToAmmo[tag]);
    }

}
