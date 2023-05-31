using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoRun : MonoBehaviour
{
    // We use the variable to toggle player movement.
    bool isMoving = false;

    // Set the movement speed. Can also be set in the Inspector under the this script's component.
    public float movementSpeed = 75;

    // Update is called once per frame.
    void Update()
    {
        // If the mouse button (or headset switch) is pressed, toggle the isMoving variable.
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = isMoving ? false : true;
        }

        // If the isMoving variable is true, we move the object this script is attached in the direction the main camera is facing (the XR camera) at the speed set in the movementSpeed variable.
        if(isMoving)
            transform.position += new Vector3(Camera.main.transform.forward.x * Time.deltaTime * movementSpeed, 0, Camera.main.transform.forward.z * Time.deltaTime * movementSpeed);
    }
}
