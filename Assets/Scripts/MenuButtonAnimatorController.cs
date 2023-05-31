using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonAnimatorController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    
{
    private Animator myAnim;
    void Start()
    {
        // Access the Animator component of the cube
        myAnim = gameObject.GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData anEventData)
    {
        // start animation
        Debug.Log("Mouse has entered");
        myAnim.SetTrigger("Active");
    }

    public void OnPointerExit(PointerEventData anEventData) 
    {
        // stop animation
        Debug.Log("Mouse has left the control");
        myAnim.SetTrigger("Inactive");
    }

    public void OnPointerClick(PointerEventData anEventData) 
    {
        // trigger press animation
        Debug.Log("Mouse is being clicked");
        //myAnim.ResetTrigger("Inactive");
        myAnim.SetTrigger("Click");
    }
}
