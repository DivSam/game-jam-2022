using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPowerUp : PowerUp
{
    public float lightMultiplier = 1.5f;
    public float duration = 5f;
    public float originalSpotAngle;
    Light light;
    public override float TriggerConsumableEffect(GameObject player)
    {
        light = player.GetComponentInChildren<Light>();
        originalSpotAngle = light.spotAngle;
        light.spotAngle = originalSpotAngle * 1.5f;
        return duration;
    }

    public override void RemoveConsumableEffect(GameObject player)
    {
        light.spotAngle = originalSpotAngle;
    }

}
