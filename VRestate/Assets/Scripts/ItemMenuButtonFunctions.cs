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
    public GameObject cameraRig;
    Vector3 camerarigpos;
    Quaternion camerarigrotation;
    Vector3 cameraZoom;
    Vector3 camerapos;
    public float movementSpeed;
    public float movementTime;
    public float cameraRotationAmount;
    //public Vector3 cameraZoomAmount;

    Vector3 dragStartPosition;
    Vector3 dragCurrentPosition;

    Vector3 rotateStartPosition;
    Vector3 rotateCurrentPosition;




    public float cameraScrollSpeed = 20f;
    
    public float panBorderThickness = 10f;
    public Vector2 panLimit;
    public float cameraMinY = 3f;
    public float cameraMaxY = 30f;

    
   

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
        camerarigpos = cameraRig.transform.position;
        camerarigrotation = cameraRig.transform.rotation;
        cameraZoom = mainCamera.transform.localPosition;
        camerapos = mainCamera.transform.localPosition;


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
        //KAMERA HAREKET ETMESÝ
        if (Input.GetKey(KeyCode.UpArrow))
        {
            camerarigpos += (cameraRig.transform.forward * movementSpeed);
        }
            
        if (Input.GetKey(KeyCode.DownArrow))
        {
            camerarigpos += (cameraRig.transform.forward * -movementSpeed);
        }
               
        if (Input.GetKey(KeyCode.RightArrow))
        {
            camerarigpos += (cameraRig.transform.right * movementSpeed);
        }
                   
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            camerarigpos += (cameraRig.transform.right *- movementSpeed);
        }

        //KAMERA DÖNDÜRMESÝ
        if (Input.GetKey(KeyCode.Q))
        {
            camerarigrotation *= Quaternion.Euler(Vector3.up * -cameraRotationAmount);
            //camerarigrotation *= Quaternion.AngleAxis(-cameraRotationAmount, transform.up);
        }
        if (Input.GetKey(KeyCode.E))
        {
            camerarigrotation *= Quaternion.Euler(Vector3.up * cameraRotationAmount);
            //camerarigrotation *= Quaternion.AngleAxis(cameraRotationAmount, transform.up);
        }

        //Mouse üzerinden hareket etme ve rotation yapýlmasý
        if (MouseInputUIBlocker.BlockedByUI == false)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                float entry;
                Plane plane = new Plane(Vector3.up, Vector3.zero);
                if (plane.Raycast(ray, out entry))
                {
                    dragStartPosition = ray.GetPoint(entry);
                }
            }
            if (Input.GetMouseButton(1))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                float entry;
                Plane plane = new Plane(Vector3.up, Vector3.zero);
                if (plane.Raycast(ray, out entry))
                {
                    dragCurrentPosition = ray.GetPoint(entry);
                    camerarigpos = cameraRig.transform.position + dragStartPosition - dragCurrentPosition;
                }
            }
            if (Input.GetMouseButtonDown(2))
            {
                rotateStartPosition = Input.mousePosition;
            }
            if (Input.GetMouseButton(2))
            {
                rotateCurrentPosition = Input.mousePosition;
                Vector3 difference = rotateStartPosition - rotateCurrentPosition;
                rotateStartPosition = rotateCurrentPosition;
                camerarigrotation *= Quaternion.Euler(Vector3.up * (-difference.x /5f));
            }
        }
        //KAMERA HAREKET ETMESÝ (MOUSE ÝLE)
        /*if (MouseInputUIBlocker.BlockedByUI == false)
        {
            if (Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                camerarigpos += (cameraRig.transform.forward * movementSpeed);
            }

            if (Input.mousePosition.y <= panBorderThickness)
            {
                camerarigpos += (cameraRig.transform.forward * -movementSpeed);
            }

            if (Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                camerarigpos += (cameraRig.transform.right * movementSpeed);
            }

            if (Input.mousePosition.x <= panBorderThickness)
            {
                camerarigpos += (cameraRig.transform.right * -movementSpeed);
            }
        }*/
        //KAMERANIN SINIRLARI
        camerarigpos.x = Mathf.Clamp(camerarigpos.x, -panLimit.x, panLimit.x);
        cameraZoom.y = Mathf.Clamp(cameraZoom.y, cameraMinY, cameraMaxY);
        camerarigpos.z = Mathf.Clamp(camerarigpos.z, -panLimit.y-30, panLimit.y-40);

        //cameraRig.transform.position = Vector3.Lerp(cameraRig.transform.position, camerarigpos, Time.deltaTime * movementTime);
        cameraRig.transform.position = camerarigpos;
        cameraRig.transform.rotation = Quaternion.Lerp(camerarigrotation, cameraRig.transform.rotation,  Time.deltaTime * movementTime );
        

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


            // KAMERANIN YAKINLAÞTIRILIP UZAKLAÞTIRILABÝLMESÝ  BURA ÝÇÝN YENÝ VÝDEOYA BAK
            if (MouseInputUIBlocker.BlockedByUI == false)
            {
                 float camerascroll = Input.GetAxis("Mouse ScrollWheel");
                 cameraZoom.y -= camerascroll* cameraScrollSpeed* 100f* Time.deltaTime;
                 mainCamera.transform.localPosition = cameraZoom;
            }


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
