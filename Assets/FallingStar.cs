using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStar : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInChildren<PlayerController>())
        {
            other.gameObject.GetComponentInChildren<PlayerController>().Die();
        }
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
