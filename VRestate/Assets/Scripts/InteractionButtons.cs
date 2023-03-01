using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionButtons : MonoBehaviour
{

    [SerializeField]
    private Transform mainCamera;
    private ItemMenuButtonFunctions itemMenuFunctions;
    public GameObject cameraRig;
    float minDistance = 2f;
    float maxDistance = 45f;

    float minScale = 1f;
    float maxScale = 4f;

    
    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        itemMenuFunctions = canvas.GetComponent<ItemMenuButtonFunctions>();
    }
    public void MoveButtonClicked()
    {
        itemMenuFunctions.isButtonClicked = true;
        itemMenuFunctions.ObjectFollowsMouse = itemMenuFunctions.Selected3DObject;
        Destroy(itemMenuFunctions.ObjectFollowsMouse.GetComponent<BoxCollider>());
        this.gameObject.SetActive(false);
        if (itemMenuFunctions.Selected3DObject.name == "Cabinet_Base_1(Clone)")
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
        MouseInputUIBlocker.BlockedByUI = false;
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
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(mainCamera);
              
        float mdistance =  Vector3.Distance(mainCamera.position, this.transform.position);
        //Debug.Log("mdistance " + mdistance);
        float scale = Mathf.Lerp(minScale, maxScale, Mathf.InverseLerp(minDistance, maxDistance, mdistance));
        this.transform.localScale = new Vector3(scale, scale, scale);

    }

    
}
