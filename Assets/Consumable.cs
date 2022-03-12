using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public virtual float TriggerConsumableEffect(GameObject player)
    {
        Debug.Log("Consumable Triggered");
        return 0;
    }

    public virtual void RemoveConsumableEffect(GameObject player)
    {
        Debug.Log("Consumable Removed");
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        StartCoroutine(TriggerEffectAndWait(other.gameObject));
    }

    IEnumerator TriggerEffectAndWait(GameObject player)
    {
        float duration = TriggerConsumableEffect(player);
        yield return new WaitForSeconds(duration);
        RemoveConsumableEffect(player);
        Destroy(gameObject);
    }
}
