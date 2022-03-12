using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public virtual void TriggerConsumableEffect(GameObject player)
    {
        Debug.Log("Consumable Triggered");
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggerConsumableEffect(other.gameObject);
        Destroy(gameObject);
    }
}
