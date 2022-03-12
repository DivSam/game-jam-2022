using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPowerUp : PowerUp
{
    public float lightMultiplier = 3f;
    public float duration = 5f;
    public float originalSpotAngle;
    Light myLight;
    public override float TriggerConsumableEffect(GameObject player)
    {
        myLight = player.GetComponentInChildren<Light>();
        originalSpotAngle = myLight.spotAngle;
        myLight.spotAngle = originalSpotAngle * 3f;

        return duration;
    }

    public override void RemoveConsumableEffect(GameObject player)
    {
        myLight.spotAngle = originalSpotAngle;
    }
}
