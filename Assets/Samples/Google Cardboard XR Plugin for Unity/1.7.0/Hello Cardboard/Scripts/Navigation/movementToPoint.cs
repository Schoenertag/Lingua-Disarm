using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movementToPoint : MonoBehaviour
{
    // The player object.
    public GameObject playerObj;

    // The animated movement points the player can travel to.
    public GameObject movementPoint;

    // Animation time of the movementPoint target set by default here but can be adjusted in the inspector to make the animation faster or slower.
    public int animTime = 5;

    // Speed set by default here but can be adjusted in the Inspector.
    public float movementSpeed = 75;

    // Keeps track of whether the player is looking at a movementPoint target.
    private bool isLooking = false;

    // Checks whether a new movementPoint target should be setup.
    private bool setNew = false;

    // Helps us control the Coroutine animation.
    private Coroutine co;

    // Record the position of the movementPoint the player will travel to.
    private Vector3 movementPos;

    // We use a list to keep track of our movementPoint objects. Feel free to add more as needed, code adapts to smaller or larger list automatically.
    public List<GameObject> locations = new List<GameObject>();

    // Keep track of what movementPoint is active, which helps us determine where we are in the list.
    private int listTrack = 0;

    private void Start()
    {
        // We don't want the player to move when we first start the scene, so set movementPos to the player's position.
        movementPos = playerObj.transform.position;
    }

    // Animates our movementPoint targets in a separate thread.
    IEnumerator AnimateSliderOverTime(float seconds)
    {
        float animationTime = 0f;
        while (animationTime < seconds)
        {
            animationTime += Time.deltaTime;
            float lerpValue = animationTime / seconds;
            movementPoint.transform.GetComponent<Slider>().value = Mathf.Lerp(0f, 8f, lerpValue);          
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Here we track the status of the animation
        
        if (movementPoint.transform.GetComponent<Slider>().value == 8)
        {
            movementPos = movementPoint.transform.position;
            movementPoint.SetActive(false);
            setNew = true;
        }
        

        // Move towards the position of the movementPoint target.
        if (playerObj.transform.position != movementPos)
        {
            // Move our position a closer to the target.
            float step = movementSpeed * Time.deltaTime; // Calculate the distance to move.
            playerObj.transform.position = Vector3.MoveTowards(playerObj.transform.position, movementPos, step);
        }
        else if (setNew)
        {
            if(listTrack < (locations.Count - 1))
            {
                listTrack++;
            }
            else
            {
                listTrack = 0;
            }

            setNew = false;
            locations[listTrack].transform.gameObject.SetActive(true);
        }

        // We are going to raycast, which allows us to determine what object in the scene the user is looking at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            // If the object our ray has hit has a particular tag (as defined in this statement), we are going to do the following.
            if (hit.transform.tag == "movementPoint" && isLooking == false)
            {
                movementPoint = hit.transform.gameObject;

                // Start Slider animation.
                isLooking = true;
                co = StartCoroutine(AnimateSliderOverTime(animTime));

                // For debugging purposes - with the Play button on, check out the scene view to see where the Ray is casting.
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                // Indicate in the Unity console whether the raycast hit something.
                Debug.Log("Did Hit");
            }
        }
        else // If our raycast did not hit anything.
        {
            isLooking = false;
            if(co != null)
                StopCoroutine(co);

            // Reset the slider value.
            movementPoint.transform.GetComponent<Slider>().value = 0;

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
    }
}
