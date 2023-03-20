using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButtons : MonoBehaviour
{

    //[SerializeField]               // World spaceteyse buralar açýlacak
    //private Transform mainCamera;  // World spaceteyse buralar açýlacak
    private ItemMenuButtonFunctions itemMenuFunctions;
    private ClientButtonFunctions clientMenuFunctions;
    bool client = false;
    //public GameObject cameraRig;  // World spaceteyse buralar açýlacak
    /*float minDistance = 2f;
    float maxDistance = 45f;

    float minScale = 1f;
    float maxScale = 4f;*/


    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        itemMenuFunctions = canvas.GetComponent<ItemMenuButtonFunctions>();
        clientMenuFunctions = canvas.GetComponent<ClientButtonFunctions>();
        
        if (itemMenuFunctions == null)
        {
            client = true;
        }
       
       
    }
    public void MoveButtonClicked()
    {
        if (client)
        {
            clientMenuFunctions.isButtonClicked = true;
            clientMenuFunctions.ObjectFollowsMouse = clientMenuFunctions.Selected3DObject;
            ClientButtonFunctions.buildingSystemObjectFollowMouse = clientMenuFunctions.ObjectFollowsMouse;
            int LayerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
            clientMenuFunctions.ObjectFollowsMouse.layer = LayerIgnoreRaycast;

            //Destroy(itemMenuFunctions.ObjectFollowsMouse.GetComponent<BoxCollider>());
            this.gameObject.SetActive(false);
            clientMenuFunctions.foundcount = true;

            MouseInputUIBlocker.BlockedByUI = false;
            IsMouseHoveringOnButton.onButton = false;
            clientMenuFunctions.Selected3DObject = null;
        }
        else
        {
            itemMenuFunctions.isButtonClicked = true;
            itemMenuFunctions.ObjectFollowsMouse = itemMenuFunctions.Selected3DObject;
            ItemMenuButtonFunctions.buildingSystemObjectFollowMouse = itemMenuFunctions.ObjectFollowsMouse;
            int LayerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
            itemMenuFunctions.ObjectFollowsMouse.layer = LayerIgnoreRaycast;

            //Destroy(itemMenuFunctions.ObjectFollowsMouse.GetComponent<BoxCollider>());
            this.gameObject.SetActive(false);
            itemMenuFunctions.foundcount = true;

            MouseInputUIBlocker.BlockedByUI = false;
            IsMouseHoveringOnButton.onButton = false;
            itemMenuFunctions.Selected3DObject = null;
        }
        
    }
    public void RotateButtonClicked()
    {
        if (client)
        {
            if (clientMenuFunctions.ObjectFollowsMouse.name == "Sofa_4(Clone)" || clientMenuFunctions.ObjectFollowsMouse.name == "Shelf_2(Clone)" || clientMenuFunctions.ObjectFollowsMouse.name == "Chair_2(Clone)" || clientMenuFunctions.ObjectFollowsMouse.name == "Chair_3(Clone)" 
                || clientMenuFunctions.ObjectFollowsMouse.name == "Fridge_2(Clone)"
                || clientMenuFunctions.ObjectFollowsMouse.name == "Dish_Washer(Clone)" || clientMenuFunctions.ObjectFollowsMouse.name == "Coffee_Table_2(Clone)")
            {
                clientMenuFunctions.Selected3DObject.transform.Rotate(0, 0, 90f, Space.Self); 
                MouseInputUIBlocker.BlockedByUI = false;
            }
            else
            {
                clientMenuFunctions.Selected3DObject.transform.Rotate(0, 90f, 0, Space.Self);
                MouseInputUIBlocker.BlockedByUI = false;
            }
        }
        else
        {
            itemMenuFunctions.Selected3DObject.transform.Rotate(0, 90f, 0, Space.Self);
            MouseInputUIBlocker.BlockedByUI = false;
        }
        
    }
    public void DeleteButtonClicked()
    {
        if (client)
        {
            Destroy(clientMenuFunctions.Selected3DObject);
            MouseInputUIBlocker.BlockedByUI = false;
            IsMouseHoveringOnButton.onButton = false;
            this.gameObject.SetActive(false);
        }
        else
        {
            Destroy(itemMenuFunctions.Selected3DObject);
            MouseInputUIBlocker.BlockedByUI = false;
            IsMouseHoveringOnButton.onButton = false;
            this.gameObject.SetActive(false);
        }
    }
        

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(mainCamera); // World spaceteyse buralar açýlacak
        if (this.gameObject.activeSelf == true)
        {
            Debug.Log("DrawingLine");
            //Debug.DrawLine(Vector3.zero, Vector3.one, Color.red, 10, false, 0.1f)
            //Debug.DrawLine(this.gameObject.transform.position, this.gameObject.transform.position - new Vector3(0f, this.gameObject.transform.position.y - itemMenuFunctions.Selected3DObject.GetComponent<MeshRenderer>().bounds.size.y,0f), Color.green);  // World spaceteyse buralar açýlacak

            if (client)
            {
                Debug.DrawLine(clientMenuFunctions.Selected3DObject.transform.position + new Vector3(0f, 6f, 0f), (clientMenuFunctions.Selected3DObject.transform.position 
                    + new Vector3(0f, 6f, 0f)) - new Vector3(0f, (clientMenuFunctions.Selected3DObject.transform.position.y + 6f) - clientMenuFunctions.Selected3DObject.GetComponent<MeshRenderer>().bounds.size.y, 0f), Color.green);
            }
            else
            {
                Debug.DrawLine(itemMenuFunctions.Selected3DObject.transform.position + new Vector3(0f, 6f, 0f), (itemMenuFunctions.Selected3DObject.transform.position 
                    + new Vector3(0f, 6f, 0f)) - new Vector3(0f, (itemMenuFunctions.Selected3DObject.transform.position.y + 6f) - itemMenuFunctions.Selected3DObject.GetComponent<MeshRenderer>().bounds.size.y, 0f), Color.green);
            }
            
        }
        //float mdistance =  Vector3.Distance(mainCamera.position, this.transform.position); // World spaceteyse buralar açýlacak
        //Debug.Log("mdistance " + mdistance);
        //float scale = Mathf.Lerp(minScale, maxScale, Mathf.InverseLerp(minDistance, maxDistance, mdistance)); // World spaceteyse buralar açýlacak
        //this.transform.localScale = new Vector3(scale, scale, scale); // World spaceteyse buralar açýlacak

    }


}
