using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportPlayer : MonoBehaviour
{
    // Reference to a visual teleport location indicator in the scene - appears when user presses the switch.
    public GameObject teleportVisual;

    // Reference to the player object. Could also get this object through transform.parent, but this option is a bit more flexible.
    public GameObject playerObj;

    private void Start()
    {
       // We start the scene by disabling the teleport visual, as we don't want the player to see it until the press their switch.
       teleportVisual.SetActive(false);
    }

    void Update()
    {
        // Check if the player has pressed the mouse button (also works for the headset switch).
        if (Input.GetMouseButton(0))
        {
            // Set the teleport visual to enabled.
            teleportVisual.SetActive(true);

            // We are going to raycast, which allows us to determine what object in the scene the user is looking at.
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                // If the object our ray has hit has a particular tag (as defined in this statement), we are going to do the following.
                if(hit.transform.tag == "teleportGround")
                {
                    // For debugging purposes - with the Play button on, check out the scene view to see where the Ray is casting.
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                    // Indicate in the Unity console whether the raycast hit something.
                    Debug.Log("Did Hit");

                    // Set the position of our teleport visual to the specific hit location of the raycast, while preserving the teleport visual's original y position.
                    teleportVisual.transform.position = new Vector3(hit.point.x, teleportVisual.transform.position.y, hit.point.z);
                }
            }
            else // If our raycast did not hit anything.
            {
                teleportVisual.SetActive(false);
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }

        // Check if the user has released the mouse button (or headset switch).
        if (Input.GetMouseButtonUp(0))
        {
            teleportVisual.SetActive(false);
            playerObj.transform.position = new Vector3(teleportVisual.transform.position.x, playerObj.transform.position.y, teleportVisual.transform.position.z);
        }
    }
}
