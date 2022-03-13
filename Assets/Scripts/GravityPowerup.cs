using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPowerup : PowerUp
{
    public float gravityModifier = 2f;
    public float duration = 5f;
    public float originalGravity = Physics.gravity.y;
    public override float TriggerConsumableEffect(GameObject player)
    {
        Physics.gravity = new Vector3(0, originalGravity/2, 0);
        //player.GetComponentInChildren<Light>().color = new Color(64f/255f, 164f/255f, 213f/255f);
        player.GetComponentInChildren<Light>().intensity = 10;
        return duration;
    }

    public override void RemoveConsumableEffect(GameObject player)
    {
        Physics.gravity = new Vector3(0, originalGravity, 0);
        //player.GetComponentInChildren<Light>().color = GameManager.Instance.originalLightColor;
        player.GetComponentInChildren<Light>().intensity = GameManager.Instance.originalLightIntensity;
    }
}
