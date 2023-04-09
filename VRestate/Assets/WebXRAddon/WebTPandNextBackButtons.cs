using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zinnia.Action;
using WebXR;

public class WebTPandNextBackButtons : MonoBehaviour
{

    public WebXRController controllerL;
    public WebXRController controllerR;
    public GameObject VRCamera;
     Vector3 lastposition;
     bool didteleport = false;
     bool onebyone = false;
 

    // Update is called once per frame
    void Update()
    {

        //Receive(controller.GetButton(WebXRController.ButtonTypes.));
        if (controllerL.GetButtonDown(WebXRController.ButtonTypes.ButtonA) && onebyone == false){
            lastposition = VRCamera.transform.position;
            VRCamera.transform.position =  new Vector3(this.gameObject.transform.position.x, 0.2f, this.gameObject.transform.position.z);
            didteleport = true;
            onebyone = true;
        }       
        if (controllerR.GetButtonDown(WebXRController.ButtonTypes.ButtonA) && didteleport && onebyone)
        {
            VRCamera.transform.position = lastposition;
            onebyone = false;
        }
    }
}
