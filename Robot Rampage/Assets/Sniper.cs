using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Gon
{
    // Update is called once per frame
    override protected void Update()
    {
        base.Update();
        if (Input.GetMouseButtonDown(0) && (Time.time - lastFireTime) > fireRate)
        {
            lastFireTime = Time.time;
            Fire();
        }
    }
}
