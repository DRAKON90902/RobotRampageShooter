using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    public const string SceneBattle = "Battle";
    public const string SceneMenu = "MainMenu";
    public const string Pistol = "Pistol";
    public const string AssaultRifle = "Assault Rifle";
    public const string Shotgun = "Shotgun";
    public const string Sniper = "Sniper";
    public const string RedRobot = "RedRobot";
    public const string BlueRobot = "BlueRobot";
    public const string YellowRobot = "YellowRobot";
    public const string Game = "Game";
    public const int PickUpPistolAmmo = 1;
    public const int PickUpAssaultRifleAmmo = 2;
    public const int PickUpShotgunAmmo = 3;
    public const int PickUpHealth = 4;
    public const int PickUpArmor = 5;
    public const int PickUpSniperAmmo = 6;
    public const float CameraDefaultZoom = 60f;

    public static readonly int[] AllPickupTypes = new int[6]
    {
        PickUpPistolAmmo, PickUpAssaultRifleAmmo, PickUpShotgunAmmo, PickUpHealth, PickUpArmor, PickUpSniperAmmo,
    };
}
