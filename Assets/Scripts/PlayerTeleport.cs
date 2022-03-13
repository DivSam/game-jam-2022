using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject currentTeleporter;

    // Update is called once per frame
    void Update()
    {
        if (currentTeleporter != null && currentTeleporter.GetComponent<Teleporter>().getCanEnter())
        {
            currentTeleporter.GetComponent<Teleporter>().GetDestination().gameObject.GetComponent<Teleporter>().setCanEnter(false);
            transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Teleporter")){
            currentTeleporter = collision.gameObject;
        }
    }
    private void OnTriggerExit(Collider collision){
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter){
                currentTeleporter.GetComponent<Teleporter>().setCanEnter(true);
                currentTeleporter = null;
            }
        }
    }
}
