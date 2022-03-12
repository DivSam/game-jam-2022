using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPowerUp : PowerUp
{
    public override void TriggerConsumableEffect(GameObject player)
    {
        Debug.Log("Light Triggered");
    }
}
