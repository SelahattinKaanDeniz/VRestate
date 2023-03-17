using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClientButtonFunctions : MonoBehaviour
{
    public GameObject BathroomMenuPanel;
    public GameObject KitchenMenuPanel;
    public GameObject LivingRoomMenuPanel;
    public GameObject StudyRoomMenuPanel;
    public GameObject BedRoomMenuPanel;
    public GameObject DecorationMenuPanel;
    public GameObject LampMenuPanel;
    public GameObject DiningRoomMenuPanel;

    public GameObject ItemMenuPanel;

    /// <summary>
    /// //
    /// </summary>

    public SizeMenuFunctions sizeMenu;
    public GameObject settingsMenu;
    public MeshRenderer rend;
    public Material material;

    public static string clickedButtonName = "";
    public string leftClickedButtonName;

    [SerializeField] private Camera mainCamera;
    public GameObject cameraRig;
    Vector3 camerarigpos;
    Quaternion camerarigrotation;
    Vector3 cameraZoom;
    Vector3 camerapos;
    public float movementSpeed;
    public float movementTime;
    public float cameraRotationAmount;
    bool followmouse = true;
    //public Vector3 cameraZoomAmount;

    Vector3 dragStartPosition;
    Vector3 dragCurrentPosition;

    Vector3 rotateStartPosition;
    Vector3 rotateCurrentPosition;






    public float cameraScrollSpeed = 20f;

    public float panBorderThickness = 10f;
    public Vector2 panLimit;
    public float cameraMinY = 1.5f;
    public float cameraMaxY = 30f;
    public static PlaceableObject objectToPlace;




    public GameObject ObjectFollowsMouse;
    public static GameObject buildingSystemObjectFollowMouse;
    public GameObject Selected3DObject;
    public bool isButtonClicked = true;


    // Kitchen
    /*public GameObject CabinetBase1;
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
    public GameObject Stove;
    public static Vector3 StoveSize;

    //Construction
    public GameObject Floor;
    public static Vector3 FloorSize;


    public GameObject Wall;
    public static Vector3 WallSize;
    public GameObject Door1;
    //public static Vector3 Door1Size;
    public GameObject Door2;
    //public static Vector3 Door2Size;
    public GameObject Window;
    public GameObject Frame;

    public GameObject Rail;
    public static Vector3 RailSize;



    // Dynamic Wall Creation
    
    public GameObject wallPrefab;

    //Bathroom
    public GameObject Bathtub;
    public static Vector3 BathtubSize;
    public GameObject Shower;
    public static Vector3 ShowerSize;
    public GameObject Vanity3;
    public static Vector3 Vanity3Size;
    public GameObject Toilet;
    public static Vector3 ToiletSize;
    public GameObject Vanity1;
    public static Vector3 Vanity1Size;*/
    public bool foundcount = false;

    //Living Room
    public GameObject Sofa1;
    public static Vector3 Sofa1Size;












    public GameObject cube;
    public GameObject InteractionCanvas;
    //public int[] itemModelCount = new int[70];
    /* itemModelCount indexes:
     * 0 -> CabinetBase1
     * 1 -> CabinetBase2
     * 2 -> CabinetBaseCorner
     * 3 -> CabinetBaseSink
     * 4 -> CabinetTall
     * 5 -> CabinetWall1
     * 6 -> CabinetWall2
     * 7 -> CabinetBase1
     * 9 -> WallPrefab
     * 
     * 15 -> Stove
     * 20 -> Floor
     * 
     * 
     */
    

    Vector3 mousepos;
    public void Start()
    {
        camerarigpos = cameraRig.transform.position;
        camerarigrotation = cameraRig.transform.rotation;
        cameraZoom = mainCamera.transform.localPosition;
        camerapos = mainCamera.transform.localPosition;


        /*CabinetBase1.transform.localScale = new Vector3(1f, 1f, 1f);
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
        CabinetWall2Size = CabinetWall2.GetComponent<MeshRenderer>().bounds.size;

        Stove.transform.localScale = new Vector3(1f, 1f, 1f);
        StoveSize = Stove.GetComponent<MeshRenderer>().bounds.size;*/


        Sofa1.transform.localScale = new Vector3(1f, 1f, 1f);
        Sofa1Size = Sofa1.GetComponent<MeshRenderer>().bounds.size;

        /*Floor.transform.localScale = new Vector3(0.2f, 0.1f, 0.2f);
        FloorSize = Floor.GetComponent<MeshRenderer>().bounds.size;


        Wall.transform.localScale = new Vector3(1f, 1f, 1f);
        WallSize = Wall.GetComponent<MeshRenderer>().bounds.size;

        Bathtub.transform.localScale = new Vector3(1f, 1f, 1f);
        BathtubSize = Bathtub.GetComponent<MeshRenderer>().bounds.size;
        Shower.transform.localScale = new Vector3(1f, 1f, 1f);
        ShowerSize = Shower.GetComponent<MeshRenderer>().bounds.size;
        Vanity3.transform.localScale = new Vector3(100f, 100f, 100f);
        Vanity3Size = Vanity3.GetComponent<MeshRenderer>().bounds.size;
        Toilet.transform.localScale = new Vector3(1f, 1f, 1f);
        ToiletSize = Toilet.GetComponent<MeshRenderer>().bounds.size;
        Vanity1.transform.localScale = new Vector3(1f, 1f, 1f);
        Vanity1Size = Vanity1.GetComponent<MeshRenderer>().bounds.size;


        Door1.transform.localScale = new Vector3(0.5f, 3f, 0.5f);
        Door2.transform.localScale = new Vector3(0.5f, 3f, 0.5f);
        Window.transform.localScale = new Vector3(0.5f, 3f, 0.5f);
        Frame.transform.localScale = new Vector3(0.5f, 3f, 0.5f);
        Rail.transform.localScale = new Vector3(0.5f, 1f, 0.5f);*/
        //RailSize = Rail.GetComponent<MeshRenderer>().bounds.size;
    }

    //Ana kategoriden Bathroom butonuna týklandýðýnda
    public void BathroomButtonClicked()
    {

        BathroomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(1500f, 127f);
    }

    //Bathroom alt kategoriden Back butonuna týklandýðýnda
    public void BathroomBackButtonClicked()
    {

        BathroomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(1500f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Kitchen butonuna týklandýðýnda
    public void KitchenButtonClicked()
    {

        KitchenMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(3660f, 127f);
    }

    //Kitchen alt kategoriden Back butonuna týklandýðýnda
    public void KitchenBackButtonClicked()
    {

        KitchenMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(3660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Living Room butonuna týklandýðýnda
    public void LivingRoomButtonClicked()
    {

        LivingRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-2820f, 127f);
    }
    //Living Room alt kategoriden Back butonuna týklandýðýnda
    public void LivingRoomBackButtonClicked()
    {

        LivingRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-2820f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Study Room butonuna týklandýðýnda
    public void StudyRoomButtonClicked()
    {

        StudyRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-4980f, 127f);
    }
    //Study Room alt kategoriden Back butonuna týklandýðýnda
    public void StudyRoomBackButtonClicked()
    {

        StudyRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-4980f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Bedroom butonuna týklandýðýnda
    public void BedRoomButtonClicked()
    {

        BedRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-7140f, 127f);
    }
    //Bedroom alt kategoriden Back butonuna týklandýðýnda
    public void BedRoomBackButtonClicked()
    {

        BedRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-7140f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Decoration butonuna týklandýðýnda
    public void DecorationButtonClicked()
    {

        DecorationMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-9300f, 127f);
    }
    //Decoration alt kategoriden Back butonuna týklandýðýnda
    public void DecorationBackButtonClicked()
    {

        DecorationMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-9300f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Lamp butonuna týklandýðýnda
    public void LampButtonClicked()
    {

        LampMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-11460f, 127f);
    }
    //Lamp alt kategoriden Back butonuna týklandýðýnda
    public void LampBackButtonClicked()
    {

        LampMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-11460f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Dining Room butonuna týklandýðýnda
    public void DiningRoomButtonClicked()
    {

        DiningRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-13620f, 127f);
    }
    //Dining Room alt kategoriden Back butonuna týklandýðýnda
    public void DiningRoomBackButtonClicked()
    {

        DiningRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-13620f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }
    public void ItemMenuButtonsLeftClicked()
    {
        leftClickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        /*for (int i = 0; i < itemModelCount.Length; i++)
        {
            itemModelCount[i] = 0;
        }*/
        foundcount = false;

        /*if (leftClickedButtonName == "Cabinet_Base_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            //ObjectFollowsMouse = Instantiate(CabinetBase1, new Vector3(4f, 2f, -18f), Quaternion.Euler( new Vector3(0, 90, 0)));
            ObjectFollowsMouse = Instantiate(CabinetBase1, new Vector3(4f, 2f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();

            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[0]= 1;
            foundcount = true;
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
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();


            //itemModelCount[1] = 1;
            foundcount = true;
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
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[2] = 1;
            foundcount = true;
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
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[3] = 1;
            foundcount = true;
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
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[4] = 1;
            foundcount = true;
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
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[5] = 1;
            foundcount = true;
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
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[6] = 1;
            foundcount = true;
        }
        else if (leftClickedButtonName == "Wall")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(wallPrefab, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[9] = 1;
            foundcount = true;
        }
        else if (leftClickedButtonName == "Stove")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Stove, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[15] = 1;
            foundcount = true;
        }
        else if (leftClickedButtonName == "Floor")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Floor, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[20] = 1;
            foundcount = true;
        }
        else if (leftClickedButtonName == "Bathtub")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Bathtub, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[30] = 1;
            foundcount = true;
        }
        else if (leftClickedButtonName == "Shower")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Shower, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[31] = 1;
            foundcount = true;
        }
        else if (leftClickedButtonName == "Sink")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Vanity3, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[32] = 1;
            foundcount = true;
        }
        else if (leftClickedButtonName == "Toilet")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Toilet, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[33] = 1;
            foundcount = true;
        }
        else if (leftClickedButtonName == "Vanity_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Vanity1, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[34] = 1;
            foundcount = true;
        }
        else if (leftClickedButtonName == "Vanity_3")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Vanity3, new Vector3(4f, 10f, -18f), Quaternion.Euler(new Vector3(-90, 180, 0)));
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[35] = 1;
            foundcount = true;
        }
        else if (leftClickedButtonName == "Door_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Door1, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[36] = 1;
            foundcount = true;
        }
        else if (leftClickedButtonName == "Door_2")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Door2, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[37] = 1;
            foundcount = true;
        }
        else if (leftClickedButtonName == "Window")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Window, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[38] = 1;
            foundcount = true;
        }
        else if (leftClickedButtonName == "Frame")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Frame, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[39] = 1;
            foundcount = true;
        }
        else if (leftClickedButtonName == "Rail")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Rail, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[40] = 1;
            foundcount = true;
        }*/
         if (leftClickedButtonName == "Sofa_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Sofa1, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            //itemModelCount[40] = 1;
            foundcount = true;
        }



        int LayerIgnoreRaycast = LayerMask.NameToLayer("Ignore Raycast");
        ObjectFollowsMouse.layer = LayerIgnoreRaycast;
        if (ObjectFollowsMouse.name == "NewDoor1(Clone)" || ObjectFollowsMouse.name == "NewDoor2(Clone)" || ObjectFollowsMouse.name == "NewWindow2(Clone)" || ObjectFollowsMouse.name == "Frame(Clone)" || ObjectFollowsMouse.name == "Rail(Clone)")
        {
            ObjectFollowsMouse.AddComponent<BoxCollider>();
            ObjectFollowsMouse.GetComponent<BoxCollider>().size = ObjectFollowsMouse.GetComponent<BoxCollider>().size - new Vector3(0.1f, 0.1f, 0.1f);
            for (int i = 0; i < ObjectFollowsMouse.transform.childCount; i++)
            {
                ObjectFollowsMouse.transform.GetChild(i).gameObject.AddComponent<BoxCollider>();
                ObjectFollowsMouse.transform.GetChild(i).gameObject.GetComponent<BoxCollider>().isTrigger = true;
                ObjectFollowsMouse.transform.GetChild(i).gameObject.GetComponent<BoxCollider>().size = ObjectFollowsMouse.transform.GetChild(i).gameObject.GetComponent<BoxCollider>().size - new Vector3(0.1f, 0.1f, 0.1f);

            }

        }
        else
        {
            ObjectFollowsMouse.AddComponent<BoxCollider>();
            ObjectFollowsMouse.GetComponent<BoxCollider>().size = ObjectFollowsMouse.GetComponent<BoxCollider>().size - new Vector3(0.1f, 0.1f, 0.1f);
        }


        ObjectFollowsMouse.GetComponent<BoxCollider>().isTrigger = true;
        buildingSystemObjectFollowMouse = ObjectFollowsMouse;
        Debug.Log(buildingSystemObjectFollowMouse + " BUILDINGSYSTEMOBJECTFOLLOWSMOUSE");



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
    RaycastHit getWorldPoint()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit;
        }
        return hit;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////

    public void Update()
    {
        //Debug.Log(MouseInputUIBlocker.BlockedByUI + " BLOCKEDBYUI");


        /*bool foundcount = false;
        for (int i = 0; i < itemModelCount.Length; i++)
        {
            if (itemModelCount[i] == 1)
            {
                foundcount = true;
            }
        }*/
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
            camerarigpos += (cameraRig.transform.right * -movementSpeed);
        }

        //KAMERA DÖNDÜRMESÝ
        if (Input.GetKey(KeyCode.Q))
        {
            camerarigrotation *= Quaternion.Euler(Vector3.up * -cameraRotationAmount);

        }
        if (Input.GetKey(KeyCode.E))
        {
            camerarigrotation *= Quaternion.Euler(Vector3.up * cameraRotationAmount);

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
                camerarigrotation *= Quaternion.Euler(Vector3.up * (-difference.x / 5f));
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
        camerarigpos.z = Mathf.Clamp(camerarigpos.z, -panLimit.y - 30, panLimit.y - 40);

        //cameraRig.transform.position = Vector3.Lerp(cameraRig.transform.position, camerarigpos, Time.deltaTime * movementTime);
        cameraRig.transform.position = camerarigpos;
        cameraRig.transform.rotation = Quaternion.Lerp(camerarigrotation, cameraRig.transform.rotation, Time.deltaTime * movementTime);


        //SEÇÝLEN OBJE OLUÞUP MOUSEU TAKÝP EDÝYOR
        if (foundcount)
        {
            InteractionCanvas.SetActive(false);



            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                //Debug.Log(raycastHit.point);
                if (ObjectFollowsMouse != null)
                {
                    if (ObjectFollowsMouse.name == "Cabinet_Wall_1(Clone)" || ObjectFollowsMouse.name == "Cabinet_Wall_2(Clone)")
                    {
                        if (followmouse == true)
                        {
                            //ObjectFollowsMouse.transform.position = new Vector3(raycastHit.point.x, raycastHit.point.y + 1.5f, raycastHit.point.z);
                            RaycastHit raycastHitObject = raycastHit;

                            BoxCollider b = ObjectFollowsMouse.GetComponent<BoxCollider>();

                            Vector3 a = BuildingSystem.current.SnapCoordinateToGrid(raycastHitObject);
                            //Debug.Log(a + " aaa");
                            //Debug.Log(b.size.x + " " + b.size.z + " SIZEEEE");
                            Vector3 objectposition = Vector3.zero;
                            float gridposx = 0;
                            float gridposy = 0;
                            float gridposz = 0;
                            if (ObjectFollowsMouse.name == "Cabinet_Wall_1(Clone)")
                            {
                                gridposx = sizeMenu.CabinetWall1x;
                                gridposy = sizeMenu.CabinetWall1y;
                                gridposz = sizeMenu.CabinetWall1z;
                            }
                            else if (ObjectFollowsMouse.name == "Cabinet_Wall_2(Clone)")
                            {
                                gridposx = sizeMenu.CabinetWall2x;
                                gridposy = sizeMenu.CabinetWall2y;
                                gridposz = sizeMenu.CabinetWall2z;
                            }
                            if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 0f)
                            {
                                Debug.Log("1. if");
                                //hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z - 0.25f);
                                objectposition = new Vector3(a.x - 0.25f - 0.25f, a.y + 2.5f - gridposy / 200, a.z + gridposz / 200);
                                //Debug.Log(" abc " + objectposition);
                                //objectposition = new Vector3(a.x - b.size.x, a.y, a.z + b.size.z);
                                //Debug.Log(" abc " + objectposition);
                            }
                            else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 90f)
                            {
                                Debug.Log("2. if");
                                //hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z - 0.25f);
                                objectposition = new Vector3(a.x + gridposz / 200, a.y + 2.5f - gridposy / 200, a.z + 0.25f + 0.25f);
                            }
                            else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 180f)
                            {
                                Debug.Log("3. if");
                                //hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z + 0.25f);
                                objectposition = new Vector3(a.x + 0.25f + 0.25f, a.y + 2.5f - gridposy / 200, a.z - gridposz / 200);
                            }
                            else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 270f)
                            {
                                Debug.Log("4. if");
                                //hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z + 0.25f);
                                objectposition = new Vector3(a.x - gridposz / 200, a.y + 2.5f - gridposy / 200, a.z - 0.25f - 0.25f);
                            }
                            //Vector3 objectposition = new Vector3(a.x + BuildingSystem.posx / 200, a.y + 2f, a.z + BuildingSystem.posz / 200);
                            ObjectFollowsMouse.transform.position = objectposition;
                            if (ObjectFollowsMouse.GetComponent<PlaceableObject>().isColliding == true)
                            {
                                ObjectFollowsMouse.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                                for (int i = 0; i < ObjectFollowsMouse.transform.childCount; i++)
                                {
                                    rend = ObjectFollowsMouse.transform.GetChild(i).GetComponent<MeshRenderer>();
                                    for (int j = 0; j < rend.materials.Length; j++)
                                    {
                                        rend.materials[j].color = Color.red;
                                    }
                                }
                            }
                            else
                            {
                                ObjectFollowsMouse.transform.GetComponent<MeshRenderer>().material.color = Color.white;
                                for (int i = 0; i < ObjectFollowsMouse.transform.childCount; i++)
                                {
                                    rend = ObjectFollowsMouse.transform.GetChild(i).GetComponent<MeshRenderer>();
                                    for (int j = 0; j < rend.materials.Length; j++)
                                    {
                                        rend.materials[j].color = Color.white;
                                    }
                                }
                            }
                        }


                    }
                    /*else if (ObjectFollowsMouse.name == "CubeWall(Clone)" || ObjectFollowsMouse.name == "NewDoor1(Clone)" || ObjectFollowsMouse.name == "NewDoor2(Clone)" || ObjectFollowsMouse.name == "NewWindow2(Clone)" || ObjectFollowsMouse.name == "Floor(Clone)" || ObjectFollowsMouse.name == "Frame(Clone)" || ObjectFollowsMouse.name == "Rail(Clone)")
                    {
                        if (followmouse == true)
                        {
                            //bir önceki buydu
                            //ObjectFollowsMouse.transform.position = new Vector3(raycastHit.point.x, raycastHit.point.y+ wallPrefab.transform.localScale.y /2, raycastHit.point.z);
                            //Vector3 pos = raycastHit.point;
                            RaycastHit raycastHitObject = raycastHit;
                            BoxCollider b = ObjectFollowsMouse.GetComponent<BoxCollider>();

                            Vector3 a = BuildingSystem.current.SnapCoordinateToGrid(raycastHitObject);
                            //Debug.Log(b.size.x + " " + b.size.z + " SIZEEEE");
                            Vector3 objectposition = Vector3.zero;
                            if (ObjectFollowsMouse.name == "CubeWall(Clone)")
                            {

                                objectposition = new Vector3(a.x + 0.25f, a.y + wallPrefab.transform.localScale.y / 2, a.z + 0.25f);
                            }
                            if (ObjectFollowsMouse.name == "NewDoor1(Clone)")
                            {
                                objectposition = new Vector3(a.x + 0.25f, a.y + wallPrefab.transform.localScale.y / 2, a.z + 0.25f);
                            }
                            if (ObjectFollowsMouse.name == "NewDoor2(Clone)")
                            {
                                objectposition = new Vector3(a.x + 0.25f, a.y + wallPrefab.transform.localScale.y / 2, a.z + 0.25f);
                            }
                            if (ObjectFollowsMouse.name == "NewWindow2(Clone)")
                            {
                                objectposition = new Vector3(a.x + 0.25f, a.y + wallPrefab.transform.localScale.y / 2, a.z + 0.25f);
                            }
                            if (ObjectFollowsMouse.name == "Floor(Clone)")
                            {
                                objectposition = new Vector3(a.x + 0.25f, a.y, a.z + 0.25f);
                            }
                            if (ObjectFollowsMouse.name == "Frame(Clone)")
                            {
                                objectposition = new Vector3(a.x + 0.25f, a.y + wallPrefab.transform.localScale.y / 2, a.z + 0.25f);
                            }
                            if (ObjectFollowsMouse.name == "Rail(Clone)")
                            {
                                objectposition = new Vector3(a.x + 0.25f, a.y + 0.5f, a.z + 0.25f);
                            }
                            ObjectFollowsMouse.transform.position = objectposition;



                            //ObjectFollowsMouse.transform.position = new Vector3(raycastHit.point.x, raycastHit.point.y, raycastHit.point.z);
                        }
                    }*/
                    else
                    {
                        if (followmouse == true)
                        {
                            //ObjectFollowsMouse.transform.position = raycastHit.point;
                            RaycastHit raycastHitObject = raycastHit;

                            BoxCollider b = ObjectFollowsMouse.GetComponent<BoxCollider>();

                            Vector3 a = BuildingSystem.current.SnapCoordinateToGrid(raycastHitObject);
                            //Debug.Log(a + " aaa");
                            //Debug.Log(b.size.x + " " + b.size.z + " SIZEEEE");
                            Vector3 objectposition = Vector3.zero;
                            Debug.Log(ObjectFollowsMouse.transform.eulerAngles.y + " obje rotation y");
                            float gridposx = 0;
                            float gridposy = 0;
                            float gridposz = 0;
                            if (ObjectFollowsMouse.name == "Cabinet_Base_1(Clone)")
                            {
                                gridposx = sizeMenu.CabinetBase1x;
                                gridposy = sizeMenu.CabinetBase1y;
                                gridposz = sizeMenu.CabinetBase1z;
                            }
                            else if (ObjectFollowsMouse.name == "Cabinet_Base_2(Clone)")
                            {
                                gridposx = sizeMenu.CabinetBase2x;
                                gridposy = sizeMenu.CabinetBase2y;
                                gridposz = sizeMenu.CabinetBase2z;
                            }
                            else if (ObjectFollowsMouse.name == "Cabinet_Base_Corner(Clone)")
                            {
                                gridposx = sizeMenu.CabinetBaseCornerx;
                                gridposy = sizeMenu.CabinetBaseCornery;
                                gridposz = sizeMenu.CabinetBaseCornerz;
                            }
                            else if (ObjectFollowsMouse.name == "Cabinet_Base_Sink(Clone)")
                            {
                                gridposx = sizeMenu.CabinetBaseSinkx;
                                gridposy = sizeMenu.CabinetBaseSinky;
                                gridposz = sizeMenu.CabinetBaseSinkz;
                            }
                            else if (ObjectFollowsMouse.name == "Cabinet_Tall(Clone)")
                            {
                                gridposx = sizeMenu.CabinetTallx;
                                gridposy = sizeMenu.CabinetTally;
                                gridposz = sizeMenu.CabinetTallz;
                            }
                            else if (ObjectFollowsMouse.name == "Stove(Clone)")
                            {
                                gridposx = sizeMenu.Stovex;
                                gridposy = sizeMenu.Stovey;
                                gridposz = sizeMenu.Stovez;
                            }
                            else if (ObjectFollowsMouse.name == "Bathtub(Clone)")
                            {
                                gridposx = sizeMenu.Bathtubx;
                                gridposy = sizeMenu.Bathtuby;
                                gridposz = sizeMenu.Bathtubz;
                            }
                            else if (ObjectFollowsMouse.name == "Shower(Clone)")
                            {
                                gridposx = sizeMenu.Showerx;
                                gridposy = sizeMenu.Showery;
                                gridposz = sizeMenu.Showerz;
                            }
                            else if (ObjectFollowsMouse.name == "Toilet(Clone)")
                            {
                                gridposx = sizeMenu.Toiletx;
                                gridposy = sizeMenu.Toilety;
                                gridposz = sizeMenu.Toiletz;
                            }
                            else if (ObjectFollowsMouse.name == "Vanity_1(Clone)")
                            {
                                gridposx = sizeMenu.Vanity1x;
                                gridposy = sizeMenu.Vanity1y;
                                gridposz = sizeMenu.Vanity1z;
                            }
                            else if (ObjectFollowsMouse.name == "Vanity_3(Clone)")
                            {
                                gridposx = sizeMenu.Vanity2x;
                                gridposy = sizeMenu.Vanity2z;
                                gridposz = sizeMenu.Vanity2y;
                            }
                            else if (ObjectFollowsMouse.name == "Sofa_1(Clone)")
                            {
                                gridposx = sizeMenu.Sofa1x;
                                gridposy = sizeMenu.Sofa1y;
                                gridposz = sizeMenu.Sofa1z;
                            }
                            if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 0f)
                            {
                                Debug.Log("1. if");
                                //hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z - 0.25f);
                                objectposition = new Vector3(a.x - gridposx / 200, a.y, a.z + gridposz / 200);
                                //Debug.Log(" abc " + objectposition);
                                //objectposition = new Vector3(a.x - b.size.x, a.y, a.z + b.size.z);
                                //Debug.Log(" abc " + objectposition);
                            }
                            else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 90f)
                            {
                                Debug.Log("2. if");
                                //hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z - 0.25f);
                                objectposition = new Vector3(a.x + gridposz / 200, a.y, a.z + gridposx / 200);
                            }
                            else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 180f)
                            {
                                Debug.Log("3. if");
                                //hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z + 0.25f);
                                objectposition = new Vector3(a.x + gridposx / 200, a.y, a.z - gridposz / 200);
                            }
                            else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 270f)
                            {
                                Debug.Log("4. if");
                                //hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z + 0.25f);
                                objectposition = new Vector3(a.x - gridposz / 200, a.y, a.z - gridposx / 200);
                            }


                            /*if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 0f)
                            {
                                Debug.Log("1. if");
                                //hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z - 0.25f);
                                objectposition = new Vector3(a.x - BuildingSystem.posx / 200, a.y, a.z + BuildingSystem.posz / 200);
                                //Debug.Log(" abc " + objectposition);
                                //objectposition = new Vector3(a.x - b.size.x, a.y, a.z + b.size.z);
                                //Debug.Log(" abc " + objectposition);
                            }
                            else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 90f)
                            {
                                Debug.Log("2. if");
                                //hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z - 0.25f);
                                objectposition = new Vector3(a.x + BuildingSystem.posz / 200, a.y, a.z + BuildingSystem.posx / 200);
                            }
                            else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 180f)
                            {
                                Debug.Log("3. if");
                                //hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z + 0.25f);
                                objectposition = new Vector3(a.x + BuildingSystem.posx / 200, a.y, a.z - BuildingSystem.posz / 200);
                            }
                            else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 270f)
                            {
                                Debug.Log("4. if");
                                //hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z + 0.25f);
                                objectposition = new Vector3(a.x - BuildingSystem.posz / 200, a.y, a.z - BuildingSystem.posx / 200);
                            }*/

                            //Vector3 objectposition = new Vector3(a.x + BuildingSystem.posx / 200, a.y, a.z + BuildingSystem.posz / 200);
                            ObjectFollowsMouse.transform.position = objectposition;

                            if (ObjectFollowsMouse.GetComponent<PlaceableObject>().isColliding == true)
                            {
                                ObjectFollowsMouse.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                                for (int i = 0; i < ObjectFollowsMouse.transform.childCount; i++)
                                {
                                    rend = ObjectFollowsMouse.transform.GetChild(i).GetComponent<MeshRenderer>();
                                    for (int j = 0; j < rend.materials.Length; j++)
                                    {
                                        rend.materials[j].color = Color.red;
                                    }
                                }
                            }
                            else
                            {
                                ObjectFollowsMouse.transform.GetComponent<MeshRenderer>().material.color = Color.white;
                                for (int i = 0; i < ObjectFollowsMouse.transform.childCount; i++)
                                {
                                    rend = ObjectFollowsMouse.transform.GetChild(i).GetComponent<MeshRenderer>();
                                    for (int j = 0; j < rend.materials.Length; j++)
                                    {
                                        rend.materials[j].color = Color.white;
                                    }
                                }
                            }
                        }
                    }
                }

            }



            if (MouseInputUIBlocker.BlockedByUI == false)
            {
                //Rotate
                if (Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    if (ObjectFollowsMouse.name == "Vanity_3(Clone)")
                    {
                        ObjectFollowsMouse.transform.Rotate(0, 0, 90f, Space.Self);
                    }
                    else
                    {
                        ObjectFollowsMouse.transform.Rotate(0, 90f, 0, Space.Self);
                    }
                }
                if (Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    if (ObjectFollowsMouse.name == "Vanity_3(Clone)")
                    {
                        ObjectFollowsMouse.transform.Rotate(0, 0, -90f, Space.Self);
                    }
                    else
                    {
                        ObjectFollowsMouse.transform.Rotate(0, -90f, 0, Space.Self);
                    }
                }

                
                if (Input.GetMouseButtonDown(0))
                {
                    if (ObjectFollowsMouse.GetComponent<PlaceableObject>().isColliding == false)
                    {
                        //cabinetbase1count = 0;

                        //ObjectFollowsMouse.AddComponent<BoxCollider>();
                        int LayerDefault = LayerMask.NameToLayer("Default");
                        ObjectFollowsMouse.layer = LayerDefault;
                        Debug.Log(ObjectFollowsMouse.GetComponent<MeshRenderer>().bounds.size);
                        Debug.Log(cube.GetComponent<MeshRenderer>().bounds.size);


                        //Böyle yapýnca NewDoor2 modeli kendi içinde collision veriyor prefabý düzenle
                        /*if (ObjectFollowsMouse.name == "NewDoor1(Clone)" || ObjectFollowsMouse.name == "NewDoor2(Clone)" || ObjectFollowsMouse.name == "NewWindow2(Clone)" || ObjectFollowsMouse.name == "Frame(Clone)" || ObjectFollowsMouse.name == "Rail(Clone)")
                        {
                            ObjectFollowsMouse.AddComponent<Rigidbody>();
                            ObjectFollowsMouse.GetComponent<Rigidbody>().isKinematic = true;
                            for (int i = 0; i < ObjectFollowsMouse.transform.childCount; i++)
                            {
                                ObjectFollowsMouse.transform.GetChild(i).gameObject.AddComponent<Rigidbody>();
                                ObjectFollowsMouse.transform.GetChild(i).gameObject.GetComponent<Rigidbody>().isKinematic = true;                                 

                            }

                        }
                        else
                        {
                            ObjectFollowsMouse.AddComponent<Rigidbody>();
                            ObjectFollowsMouse.GetComponent<Rigidbody>().isKinematic = true;
                        }*/
                        ObjectFollowsMouse.AddComponent<Rigidbody>();
                        ObjectFollowsMouse.GetComponent<Rigidbody>().isKinematic = true;

                        isButtonClicked = false;
                        /*for (int i = 0; i < itemModelCount.Length; i++)
                        {
                            itemModelCount[i] = 0;
                        }*/
                        foundcount = false;
                    }
                    else
                    {
                        Debug.Log("OBJE KOYULAMAZ");
                    }
                }
                


                // Sað týk delete
                if (Input.GetMouseButtonDown(1))
                {
                    //cabinetbase1count = 0;
                    /*for (int i = 0; i < itemModelCount.Length; i++)
                    {
                        itemModelCount[i] = 0;
                    }*/
                    foundcount = false;
                    
                        Destroy(ObjectFollowsMouse);
                   
                }
            }

        }
        else
        {

            // BÜTÜN MODELLERE 3DModel TAG'I EKLE



            if (MouseInputUIBlocker.BlockedByUI == false)
            {
                float camerascroll = Input.GetAxis("Mouse ScrollWheel");
                cameraZoom.y -= camerascroll * cameraScrollSpeed * 100f * Time.deltaTime;
                mainCamera.transform.localPosition = cameraZoom;
            }


            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                //Debug.Log(MouseInputUIBlocker.BlockedByUI + " blockedbyUI");
                //Debug.Log(raycastHit.point);
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log(sizeMenu.transform.position + " sizemenuposition");
                    if (raycastHit.collider.tag == "3DModel" && (sizeMenu.transform.position == new Vector3(3960f, 3540f, 3000f)) && settingsMenu.active == false && IsMouseHoveringOnButton.onButton == false)
                    {
                        Selected3DObject = raycastHit.transform.gameObject;
                        Debug.Log(Selected3DObject + "selected 3d object");
                        InteractionCanvas.SetActive(true);

                        // InteractionCanvas.transform.SetParent(raycastHit.transform);

                        //InteractionCanvas.transform.position = new Vector3(raycastHit.transform.position.x, raycastHit.transform.position.y + raycastHit.transform.gameObject.GetComponent<MeshRenderer>().bounds.size.y + 0.4f, raycastHit.transform.position.z);


                        //InteractionCanvas.transform.position = new Vector3(raycastHit.transform.position.x, raycastHit.transform.position.y + 4f, raycastHit.transform.position.z);  // World spaceteyse buralar açýlacak

                    }

                    else
                    {
                        if (MouseInputUIBlocker.BlockedByUI == false && IsMouseHoveringOnButton.onButton == false)
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
