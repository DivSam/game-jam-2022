using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    private bool canEnter = true;
    // Start is called before the first frame update
    public Transform GetDestination()
    {
        return destination;
    } 
    public void setCanEnter(bool b){
        canEnter = b;
    }
    public bool getCanEnter(){
        return canEnter;
    }
}
