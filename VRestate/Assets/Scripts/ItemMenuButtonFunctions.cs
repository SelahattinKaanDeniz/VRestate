using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMenuButtonFunctions : MonoBehaviour
{
    public GameObject BathroomMenuPanel;
    public GameObject KitchenMenuPanel;
    public GameObject ConstructionMenuPanel;
    public GameObject ItemMenuPanel;

    public  static string clickedButtonName = "";
    private string leftClickedButtonName;
    [SerializeField] private Camera mainCamera;

    public GameObject ObjectFollowsMouse;
    public GameObject Selected3DObject;
    public bool isButtonClicked = true;
    public GameObject CabinetBase1;
    public static Vector3 CabinetBase1Size; 
    public GameObject CabinetBase2;
    public static Vector3 CabinetBase2Size;
    public GameObject CabinetBaseCorner;
    public static Vector3 CabinetBaseCornerSize;
    public GameObject CabinetBaseSink;
    public static Vector3 CabinetBaseSinkSize;
    public GameObject CabinetTall;
    public static Vector3 CabinetTallSize;
    public GameObject CabinetWall1;
    public static Vector3 CabinetWall1Size;
    public GameObject CabinetWall2;
    public static Vector3 CabinetWall2Size;
    public GameObject cube;
    public GameObject InteractionCanvas;
    public int[] itemModelCount = new int[10];
    /* itemModelCount indexes:
     * 0 -> CabinetBase1
     * 1 -> CabinetBase2
     * 2 -> CabinetBaseCorner
     * 3 -> CabinetBaseSink
     * 4 -> CabinetTall
     * 5 -> CabinetBase1
     * 6 -> CabinetBase1
     * 7 -> CabinetBase1
     */
    private int cabinetbase1count = 0;
    private int cabinetbase2count = 0;
   
    Vector3 mousepos;
    public void Start()
    {
        CabinetBase1.transform.localScale = new Vector3(1f, 1f, 1f);
        CabinetBase1Size = CabinetBase1.GetComponent<MeshRenderer>().bounds.size;
        CabinetBase2.transform.localScale = new Vector3(1f, 1f, 1f);
        CabinetBase2Size = CabinetBase2.GetComponent<MeshRenderer>().bounds.size;
        CabinetBaseCorner.transform.localScale = new Vector3(1f, 1f, 1f);
        CabinetBaseCornerSize = CabinetBaseCorner.GetComponent<MeshRenderer>().bounds.size;
        CabinetBaseSink.transform.localScale = new Vector3(1f, 1f, 1f);
        CabinetBaseSinkSize = CabinetBaseSink.GetComponent<MeshRenderer>().bounds.size;
        CabinetTall.transform.localScale = new Vector3(1f, 1f, 1f);
        CabinetTallSize = CabinetTall.GetComponent<MeshRenderer>().bounds.size;
        CabinetWall1.transform.localScale = new Vector3(1f, 1f, 1f);
        CabinetWall1Size = CabinetWall1.GetComponent<MeshRenderer>().bounds.size;
        CabinetWall2.transform.localScale = new Vector3(1f, 1f, 1f);
        CabinetWall2Size = CabinetWall1.GetComponent<MeshRenderer>().bounds.size;
    }
    //Ana kategoriden Bathroom butonuna týklandýðýnda
    public void BathroomButtonClicked()
    {
        
        BathroomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
        
        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(1500f, 127f);
    }

    //Ana kategoriden Kitchen butonuna týklandýðýnda
    public void KitchenButtonClicked()
    {

        KitchenMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(3660f, 127f);
    }

    //Ana kategoriden Construction butonuna týklandýðýnda
    public void ConstructionButtonClicked()
    {

        ConstructionMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-2820f, 127f);
    }

    //Bathroom alt kategoriden Back butonuna týklandýðýnda
    public void BathroomBackButtonClicked()
    {
       
        BathroomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(1500f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Kitchen alt kategoriden Back butonuna týklandýðýnda
    public void KitchenBackButtonClicked()
    {

        KitchenMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(3660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Construction alt kategoriden Back butonuna týklandýðýnda
    public void ConstructionBackButtonClicked()
    {

        ConstructionMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-2820f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }


    //buton ismine göre bu metottan prefab oluþtur
    public void ItemMenuButtonsLeftClicked() 
    {
        leftClickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        for (int i = 0; i < itemModelCount.Length; i++)
        {
            itemModelCount[i] = 0;
        }

        if (leftClickedButtonName == "Cabinet_Base_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);               
            }
            if(isButtonClicked == false)
            {
                isButtonClicked =true;
            }

            ObjectFollowsMouse = Instantiate(CabinetBase1, new Vector3(4f, 2f, -18f), Quaternion.identity);
            
            itemModelCount[0]= 1;
        }
        else if (leftClickedButtonName == "Cabinet_Base_2")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(CabinetBase2, new Vector3(4f, 2f, -18f), Quaternion.identity);
            
            itemModelCount[1] = 1;
        }
        else if (leftClickedButtonName == "Cabinet_Base_Corner")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(CabinetBaseCorner, new Vector3(4f, 2f, -18f), Quaternion.identity);
            
            itemModelCount[2] = 1;
        }
        else if (leftClickedButtonName == "Cabinet_Base_Sink")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(CabinetBaseSink, new Vector3(4f, 2f, -18f), Quaternion.identity);
            
            itemModelCount[3] = 1;
        }
        else if (leftClickedButtonName == "Cabinet_Tall")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(CabinetTall, new Vector3(4f, 2f, -18f), Quaternion.identity);
           
            itemModelCount[4] = 1;
        }
        else if (leftClickedButtonName == "Cabinet_Wall_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(CabinetWall1, new Vector3(4f, 10f, -18f), Quaternion.identity);

            itemModelCount[5] = 1;
        }
        else if (leftClickedButtonName == "Cabinet_Wall_2")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(CabinetWall2, new Vector3(4f, 10f, -18f), Quaternion.identity);

            itemModelCount[6] = 1;
        }



    }
    /*public void CabinetBase1ButtonRightClicked()
    {
        //CabinetBase1.transform.localScale = new Vector3(5f, 5f, 5f);
        //CabinetBase1.transform.localScale = new Vector3(1f, 1f, 1f);
        clickedButtonName = "Cabinet_Base_1";
        Debug.Log(clickedButtonName);

    }*/
    public void ItemMenuButtonsRightClicked()
    {
        //CabinetBase1.transform.localScale = new Vector3(5f, 5f, 5f);
        //CabinetBase1.transform.localScale = new Vector3(1f, 1f, 1f);
        //clickedButtonName = EventSystem.current.currentSelectedGameObject.name;

        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);

        if (raycastResults.Count > 0)
        {
            int indexofbutton = 0;
            foreach (var go in raycastResults)
            {
                if (indexofbutton == 1)
                {
                     clickedButtonName = go.gameObject.name;
                }
                //Debug.Log(go.gameObject.name, go.gameObject);
                indexofbutton++;
            }
        }
        //clickedButtonName = "Cabinet_Base_2";
        Debug.Log(clickedButtonName);



    }
    public void Update()
    {
        bool foundcount = false;
        for (int i = 0; i < itemModelCount.Length; i++)
        {
            if (itemModelCount[i] == 1)
            {
                foundcount = true;
            }
        }
        //SEÇÝLEN OBJE OLUÞUP MOUSEU TAKÝP EDÝYOR
        if (foundcount)
        {
            InteractionCanvas.SetActive(false);
            Debug.Log(MouseInputUIBlocker.BlockedByUI + "  blockedbyUI");
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                //Debug.Log(raycastHit.point);
                if (ObjectFollowsMouse.name == "Cabinet_Wall_1(Clone)" || ObjectFollowsMouse.name == "Cabinet_Wall_2(Clone)")
                {
                    
                    ObjectFollowsMouse.transform.position = new Vector3 (raycastHit.point.x, raycastHit.point.y +1.5f, raycastHit.point.z);
                    
                }
                else
                {
                    ObjectFollowsMouse.transform.position = raycastHit.point;
                }
                
            }


            //Rotate
            if (MouseInputUIBlocker.BlockedByUI == false)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    ObjectFollowsMouse.transform.Rotate(0, 90f, 0, Space.Self);
                }
                if (Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    ObjectFollowsMouse.transform.Rotate(0, -90f, 0, Space.Self);
                }
                // Sol týk koyma
                if (Input.GetMouseButtonDown(0))
                {
                    //cabinetbase1count = 0;
                    ObjectFollowsMouse.AddComponent<BoxCollider>();
                                       
                    Debug.Log(ObjectFollowsMouse.GetComponent<MeshRenderer>().bounds.size);                    
                    Debug.Log(cube.GetComponent<MeshRenderer>().bounds.size);


                    isButtonClicked = false;
                    for (int i = 0; i < itemModelCount.Length; i++)
                    {
                        itemModelCount[i] = 0;
                    }
                    
                }
                // Sað týk delete
                if (Input.GetMouseButtonDown(1))
                {
                    //cabinetbase1count = 0;
                    for (int i = 0; i < itemModelCount.Length; i++)
                    {
                        itemModelCount[i] = 0;
                    }
                    Destroy(ObjectFollowsMouse);
                }
            }
            
        }
        else
        {
            // WORLD SPACETE CANVAS UI BUTTONA NASIL TIKLANILIR ONA BAK
            // BÜTÜN MODELLERE 3DModel TAG'I EKLE

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                //Debug.Log(raycastHit.point);
                if (Input.GetMouseButtonDown(0))
                {
                    if (raycastHit.collider.tag == "3DModel")
                    {
                        Selected3DObject = raycastHit.transform.gameObject;
                        Debug.Log(Selected3DObject);
                        InteractionCanvas.SetActive(true);
                       // InteractionCanvas.transform.SetParent(raycastHit.transform);
                       
                        InteractionCanvas.transform.position = new Vector3(raycastHit.transform.position.x, raycastHit.transform.position.y + raycastHit.transform.gameObject.GetComponent<MeshRenderer>().bounds.size.y + 0.7f, raycastHit.transform.position.z);

                    }
                   
                    else
                    {
                        if (MouseInputUIBlocker.BlockedByUI == false)
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                InteractionCanvas.SetActive(false);
                            }
                        }
                    }

                }
            }
        }
    }
}
