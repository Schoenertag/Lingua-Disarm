using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class moveToPoint : MonoBehaviour, IPointerEnterHandler

{
    public GameObject playerObj;

    public GameObject movementPoint;

    public float movementSpeed = 75;
    // Start is called before the first frame update

    public void OnPointerEnter(PointerEventData anEventData)
    {
        
        Debug.Log("Mouse has entered");
    }
    
}
