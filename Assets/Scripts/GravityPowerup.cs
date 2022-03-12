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
        return duration;
    }

    public override void RemoveConsumableEffect(GameObject player)
    {
        Physics.gravity = new Vector3(0, originalGravity, 0);
    }
}
