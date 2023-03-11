using System.Collections;
using System.Collections.Generic;
using UnityEngine;



using UnityEngine;
using UnityEngine.EventSystems;

public class IsMouseHoveringOnButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool onButton = false;
    //Detect if the Cursor starts to pass over the GameObject
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //Output to console the GameObject's name and the following message
        Debug.Log("Cursor Entering " + name + " GameObject");
        onButton = true;
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //Output the following message with the GameObject's name
        Debug.Log("Cursor Exiting " + name + " GameObject");
        onButton = false;
    }
}
