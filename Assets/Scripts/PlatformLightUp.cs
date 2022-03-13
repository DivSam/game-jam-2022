using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLightUp : MonoBehaviour
{
    public Material darkMaterial;
    public Material lightMaterial;

    private bool contact;
    private MeshRenderer meshRenderer;
    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void OnCollisionStay(Collision collision)
    {
        contact = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        contact = false;
    }
    private void Update()
    {
        if (contact) meshRenderer.material = lightMaterial;
        else meshRenderer.material = darkMaterial;
    }
}
