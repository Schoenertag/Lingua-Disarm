using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBombButton : MonoBehaviour
{
    private Renderer brenderer;
    private bool state;

    private void Start()
    {
        brenderer = gameObject.GetComponent<Renderer>();
        state = false;
    }

    public void Toggle()
    {
        if (state)
        {
            brenderer.material.SetColor("_EmissionColor", Color.red);
            state = false;
        }
        else
        {
            brenderer.material.SetColor("_EmissionColor", Color.green);
            state = true;
        }
    }
}