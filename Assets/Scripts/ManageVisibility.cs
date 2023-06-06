using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManageVisibility : MonoBehaviour
{
    private MeshRenderer mesh;
    private BoxCollider bcollider;

    private void Start()
    {
        mesh = gameObject.GetComponent<MeshRenderer>();
        bcollider = gameObject.GetComponent<BoxCollider>();
    }

    public void Enable()
    {
        Debug.Log("Hello");
        mesh.enabled = true;
        bcollider.enabled = true;
    }

    public void Disable()
    {
        Debug.Log("Goodbye");
        mesh.enabled = false;
        bcollider.enabled = false;
    }

    public void Toggle()
    {
        mesh.enabled ^= true;
        bcollider.enabled ^= true;
    }
}