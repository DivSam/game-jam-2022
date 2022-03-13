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
        //player.GetComponentInChildren<Light>().color = new Color(240f/255f, 86f/255f, 88f/255f);
        player.GetComponentInChildren<Light>().intensity = 10;


        return duration;
    }

    public override void RemoveConsumableEffect(GameObject player)
    {
        myLight.spotAngle = originalSpotAngle;
        //player.GetComponentInChildren<Light>().color = GameManager.Instance.originalLightColor;
        player.GetComponentInChildren<Light>().intensity = GameManager.Instance.originalLightIntensity;

    }
}
