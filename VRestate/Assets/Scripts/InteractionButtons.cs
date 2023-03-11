using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButtons : MonoBehaviour
{

    //[SerializeField]               // World spaceteyse buralar açýlacak
    //private Transform mainCamera;  // World spaceteyse buralar açýlacak
    private ItemMenuButtonFunctions itemMenuFunctions;
    //public GameObject cameraRig;  // World spaceteyse buralar açýlacak
    float minDistance = 2f;
    float maxDistance = 45f;

    float minScale = 1f;
    float maxScale = 4f;

    
    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        itemMenuFunctions = canvas.GetComponent<ItemMenuButtonFunctions>();
        Debug.Log(itemMenuFunctions + " ITEMMENUFUNCTIONS");
        Debug.Log(itemMenuFunctions.Selected3DObject + " ITEMMENUFUNCTIONS selected 3d object");
    }
    public void MoveButtonClicked()
    {
        itemMenuFunctions.isButtonClicked = true;
        itemMenuFunctions.ObjectFollowsMouse = itemMenuFunctions.Selected3DObject;
        ItemMenuButtonFunctions.buildingSystemObjectFollowMouse = itemMenuFunctions.ObjectFollowsMouse;
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        itemMenuFunctions.ObjectFollowsMouse.layer = LayerIgnoreRaycast;
           
        //Destroy(itemMenuFunctions.ObjectFollowsMouse.GetComponent<BoxCollider>());
        this.gameObject.SetActive(false);

        // itemModelCount yerine sadece bool foundcount kullanýlýyor

        /* if (itemMenuFunctions.Selected3DObject.name == "Cabinet_Base_1(Clone)")
        {
            itemMenuFunctions.itemModelCount[0] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Cabinet_Base_2(Clone)")
        {
            itemMenuFunctions.itemModelCount[1] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Cabinet_Base_Corner(Clone)")
        {
            itemMenuFunctions.itemModelCount[2] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Cabinet_Base_Sink(Clone)")
        {
            itemMenuFunctions.itemModelCount[3] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Cabinet_Tall(Clone)")
        {
            itemMenuFunctions.itemModelCount[4] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Cabinet_Wall_1(Clone)")
        {
            itemMenuFunctions.itemModelCount[5] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Cabinet_Wall_2(Clone)")
        {
            itemMenuFunctions.itemModelCount[6] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Stove(Clone)")
        {
            itemMenuFunctions.itemModelCount[15] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Floor(Clone)")
        {
            itemMenuFunctions.itemModelCount[20] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Bathtub(Clone)")
        {
            itemMenuFunctions.itemModelCount[30] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Shower(Clone)")
        {
            itemMenuFunctions.itemModelCount[31] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Sink(Clone)")
        {
            itemMenuFunctions.itemModelCount[32] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Toilet(Clone)")
        {
            itemMenuFunctions.itemModelCount[33] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Vanity_1(Clone)")
        {
            itemMenuFunctions.itemModelCount[34] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Vanity_3(Clone)")
        {
            itemMenuFunctions.itemModelCount[35] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "NewDoor1(Clone)")
        {
            itemMenuFunctions.itemModelCount[36] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "NewDoor2(Clone)")
        {
            itemMenuFunctions.itemModelCount[37] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "NewWindow2(Clone)")
        {
            itemMenuFunctions.itemModelCount[38] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Frame(Clone)")
        {
            itemMenuFunctions.itemModelCount[39] = 1;
        }
        else if (itemMenuFunctions.Selected3DObject.name == "Rail(Clone)")
        {
            itemMenuFunctions.itemModelCount[40] = 1;
        }*/
        itemMenuFunctions.foundcount = true;

        MouseInputUIBlocker.BlockedByUI = false;
        IsMouseHoveringOnButton.onButton = false;
        itemMenuFunctions.Selected3DObject = null;
    }
    public void RotateButtonClicked()
    {
        itemMenuFunctions.Selected3DObject.transform.Rotate(0, 90f, 0, Space.Self);
        MouseInputUIBlocker.BlockedByUI = false;
    }
    public void DeleteButtonClicked()
    {
        Destroy(itemMenuFunctions.Selected3DObject);
        MouseInputUIBlocker.BlockedByUI = false;
        IsMouseHoveringOnButton.onButton = false;
        this.gameObject.SetActive(false);
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
            Debug.DrawLine(itemMenuFunctions.Selected3DObject.transform.position + new Vector3 (0f,6f,0f), (itemMenuFunctions.Selected3DObject.transform.position + new Vector3(0f, 6f, 0f)) - new Vector3(0f, (itemMenuFunctions.Selected3DObject.transform.position.y+ 6f) - itemMenuFunctions.Selected3DObject.GetComponent<MeshRenderer>().bounds.size.y,0f), Color.green);
        }
        //float mdistance =  Vector3.Distance(mainCamera.position, this.transform.position); // World spaceteyse buralar açýlacak
        //Debug.Log("mdistance " + mdistance);
        //float scale = Mathf.Lerp(minScale, maxScale, Mathf.InverseLerp(minDistance, maxDistance, mdistance)); // World spaceteyse buralar açýlacak
        //this.transform.localScale = new Vector3(scale, scale, scale); // World spaceteyse buralar açýlacak

    }


}
