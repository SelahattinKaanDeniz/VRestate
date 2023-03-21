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
    public GameObject CornerCabinet;
    public static Vector3 CornerCabinetSize;
    public GameObject DishWasher;
    public static Vector3 DishWasherSize;
    public GameObject Fridge1;
    public static Vector3 Fridge1Size;
    public GameObject Fridge2;
    public static Vector3 Fridge2Size;
    public GameObject RangeHood;
    public static Vector3 RangeHoodSize;
    public GameObject Stove;
    public static Vector3 StoveSize;
    public GameObject TV;
    public static Vector3 TVSize;

    //Living Room
    public GameObject Sofa1;
    public static Vector3 Sofa1Size;
    public GameObject Sofa4;
    public static Vector3 Sofa4Size;
    public GameObject Chair2;
    public static Vector3 Chair2Size;
    public GameObject Chair3;
    public static Vector3 Chair3Size;
    public GameObject BarCabinet;
    public static Vector3 BarCabinetSize;
    public GameObject CoffeeTable1;
    public static Vector3 CoffeeTable1Size;
    public GameObject CoffeeTable2;
    public static Vector3 CoffeeTable2Size;
    //public GameObject CornerCabinet;
    //public static Vector3 CornerCabinetSize;
    public GameObject ModularCabinet;
    public static Vector3 ModularCabinetSize;
    public GameObject Shelf1;
    public static Vector3 Shelf1Size;
    //public GameObject TV;
    //public static Vector3 TVSize;
    public GameObject TVStand;
    public static Vector3 TVStandSize;
    public GameObject Table1;
    public static Vector3 Table1Size;
    public GameObject Table2;
    public static Vector3 Table2Size;
    public GameObject Bench;
    public static Vector3 BenchSize;

    //Bathroom
    //public GameObject CornerCabinet;
    //public static Vector3 CornerCabinetSize;
    public GameObject Hamper;
    public static Vector3 HamperSize;
    public GameObject TowelRack2;
    public static Vector3 TowelRack2Size;

    //Study Room
    public GameObject ComputerTable;
    public static Vector3 ComputerTableSize;
    public GameObject Computer;
    public static Vector3 ComputerSize;
    public GameObject ChairStudy;
    public static Vector3 ChairStudySize;
    //public GameObject Shelf1;
    //public static Vector3 Shelf1Size;
    public GameObject Shelf2;
    public static Vector3 Shelf2Size;

    //Bedroom
    public GameObject Bed1;
    public static Vector3 Bed1Size;
    public GameObject Bed2;
    public static Vector3 Bed2Size;
    public GameObject Closet;
    public static Vector3 ClosetSize;
    public GameObject Dresser;
    public static Vector3 DresserSize;
    public GameObject Nightstand1;
    public static Vector3 Nightstand1Size;
    public GameObject Nightstand2;
    public static Vector3 Nightstand2Size;
    public GameObject Nightstand3;
    public static Vector3 Nightstand3Size;

    //Decoration
    public GameObject Carpet;
    public static Vector3 CarpetSize;
    public GameObject Rug;
    public static Vector3 RugSize;
    public GameObject Mirror;
    public static Vector3 MirrorSize;
    public GameObject Painting3;
    public static Vector3 Painting3Size;
    public GameObject Plant;
    public static Vector3 PlantSize;
    public GameObject WineRack;
    public static Vector3 WineRackSize;
    public GameObject WallShelf;
    public static Vector3 WallShelfSize;

    //Lamp
    public GameObject FloorLamp1;
    public static Vector3 FloorLamp1Size;
    public GameObject FloorLamp2;
    public static Vector3 FloorLamp2Size;
    public GameObject TableLamp;
    public static Vector3 TableLampSize;
    public GameObject WallLamp1;
    public static Vector3 WallLamp1Size;
    public GameObject WallLamp2;
    public static Vector3 WallLamp2Size;

    //Dining Room
    public GameObject DTable1;
    public static Vector3 DTable1Size;
    public GameObject DTable2;
    public static Vector3 DTable2Size;
    public GameObject Chair1;
    public static Vector3 Chair1Size;


    public bool foundcount = false;
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

        //kitchen
        CornerCabinet.transform.localScale = new Vector3(1f, 1f, 1f);
        CornerCabinetSize = CornerCabinet.GetComponent<MeshRenderer>().bounds.size;

        DishWasher.transform.localScale = new Vector3(121.6511f, 100f, 100f);
        DishWasherSize = DishWasher.GetComponent<MeshRenderer>().bounds.size;

        Fridge1.transform.localScale = new Vector3(1f, 1f, 1f);
        Fridge1Size = Fridge1.GetComponent<MeshRenderer>().bounds.size;

        Fridge2.transform.localScale = new Vector3(50f, 50f, 50f);
        Fridge2Size = Fridge2.GetComponent<MeshRenderer>().bounds.size;

        RangeHood.transform.localScale = new Vector3(1f, 1f, 1f);
        RangeHoodSize = RangeHood.GetComponent<MeshRenderer>().bounds.size;

        Stove.transform.localScale = new Vector3(1f, 1f, 1f);
        StoveSize = Stove.GetComponent<MeshRenderer>().bounds.size;

        TV.transform.localScale = new Vector3(1f, 1f, 1f);
        TVSize = TV.GetComponent<MeshRenderer>().bounds.size;

        //Living Room
        Sofa1.transform.localScale = new Vector3(1f, 1f, 1f);
        Sofa1Size = Sofa1.GetComponent<MeshRenderer>().bounds.size;

        Sofa4.transform.localScale = new Vector3(127.3344f, 127.3344f, 127.3344f);
        Sofa4Size = Sofa4.GetComponent<MeshRenderer>().bounds.size;

        Chair2.transform.localScale = new Vector3(80f, 76f, 80f);
        Chair2Size = Chair2.GetComponent<MeshRenderer>().bounds.size;

        Chair3.transform.localScale = new Vector3(100f, 100f, 100f);
        Chair3Size = Chair3.GetComponent<MeshRenderer>().bounds.size;

        BarCabinet.transform.localScale = new Vector3(1f, 1f, 1f);
        BarCabinetSize = BarCabinet.GetComponent<MeshRenderer>().bounds.size;

        CoffeeTable1.transform.localScale = new Vector3(1f, 1f, 1f);
        CoffeeTable1Size = CoffeeTable1.GetComponent<MeshRenderer>().bounds.size;

        CoffeeTable2.transform.localScale = new Vector3(100f, 100f, 100f);
        CoffeeTable2Size = CoffeeTable2.GetComponent<MeshRenderer>().bounds.size;

        ModularCabinet.transform.localScale = new Vector3(1f, 1f, 1f);
        ModularCabinetSize = ModularCabinet.GetComponent<MeshRenderer>().bounds.size;

        Shelf1.transform.localScale = new Vector3(1f, 1f, 1f);
        Shelf1Size = Shelf1.GetComponent<MeshRenderer>().bounds.size;

        TVStand.transform.localScale = new Vector3(1f, 1f, 1f);
        TVStandSize = TVStand.GetComponent<MeshRenderer>().bounds.size;

        Table1.transform.localScale = new Vector3(1f, 1f, 1f);
        Table1Size = Table1.GetComponent<MeshRenderer>().bounds.size;

        Table2.transform.localScale = new Vector3(1f, 1f, 1f);
        Table2Size = Table2.GetComponent<MeshRenderer>().bounds.size;

        Bench.transform.localScale = new Vector3(1f, 1f, 1f);
        BenchSize = Bench.GetComponent<MeshRenderer>().bounds.size;

        //Bathroom
        Hamper.transform.localScale = new Vector3(1f, 1f, 1f);
        HamperSize = Hamper.GetComponent<MeshRenderer>().bounds.size;

        TowelRack2.transform.localScale = new Vector3(1f, 1f, 1f);
        TowelRack2Size = TowelRack2.GetComponent<MeshRenderer>().bounds.size;

        //Study Room
        ComputerTable.transform.localScale = new Vector3(1f, 1f, 1f);
        ComputerTableSize = ComputerTable.GetComponent<MeshRenderer>().bounds.size;

        Computer.transform.localScale = new Vector3(1f, 1f, 1f);
        ComputerSize = Computer.GetComponent<MeshRenderer>().bounds.size;

        ChairStudy.transform.localScale = new Vector3(1f, 1f, 1f);
        ChairStudySize = ChairStudy.GetComponent<MeshRenderer>().bounds.size;

        Shelf2.transform.localScale = new Vector3(51.34407f, 63.60788f, 63.60788f);
        Shelf2Size = Shelf2.GetComponent<MeshRenderer>().bounds.size;

        //Bedroom
        Bed1.transform.localScale = new Vector3(1f, 1f, 1f);
        Bed1Size = Bed1.GetComponent<MeshRenderer>().bounds.size;

        Bed2.transform.localScale = new Vector3(1f, 1f, 1f);
        Bed2Size = Bed2.GetComponent<MeshRenderer>().bounds.size;

        Closet.transform.localScale = new Vector3(1f, 1f, 1f);
        ClosetSize = Closet.GetComponent<MeshRenderer>().bounds.size;

        Dresser.transform.localScale = new Vector3(1f, 1f, 1f);
        DresserSize = Dresser.GetComponent<MeshRenderer>().bounds.size;

        Nightstand1.transform.localScale = new Vector3(1f, 1f, 1f);
        Nightstand1Size = Nightstand1.GetComponent<MeshRenderer>().bounds.size;

        Nightstand2.transform.localScale = new Vector3(1f, 1f, 1f);
        Nightstand2Size = Nightstand2.GetComponent<MeshRenderer>().bounds.size;

        Nightstand3.transform.localScale = new Vector3(1f, 1f, 1f);
        Nightstand3Size = Nightstand3.GetComponent<MeshRenderer>().bounds.size;

        //Decoration
        Carpet.transform.localScale = new Vector3(1f, 1f, 1f);
        CarpetSize = Carpet.GetComponent<MeshRenderer>().bounds.size;

        Rug.transform.localScale = new Vector3(1f, 1f, 1f);
        RugSize = Rug.GetComponent<MeshRenderer>().bounds.size;

        Mirror.transform.localScale = new Vector3(1f, 1f, 1f);
        MirrorSize = Mirror.GetComponent<MeshRenderer>().bounds.size;

        Painting3.transform.localScale = new Vector3(1f, 1f, 1f);
        Painting3Size = Painting3.GetComponent<MeshRenderer>().bounds.size;

        Plant.transform.localScale = new Vector3(50f, 50f, 50f);
        PlantSize = Plant.GetComponent<MeshRenderer>().bounds.size;

        WineRack.transform.localScale = new Vector3(1f, 1f, 1f);
        WineRackSize = WineRack.GetComponent<MeshRenderer>().bounds.size;

        WallShelf.transform.localScale = new Vector3(1f, 1f, 1f);
        WallShelfSize = WallShelf.GetComponent<MeshRenderer>().bounds.size;

        //Lamp
        FloorLamp1.transform.localScale = new Vector3(1f, 1f, 1f);
        FloorLamp1Size = FloorLamp1.GetComponent<MeshRenderer>().bounds.size;

        FloorLamp2.transform.localScale = new Vector3(1f, 1f, 1f);
        FloorLamp2Size = FloorLamp2.GetComponent<MeshRenderer>().bounds.size;

        TableLamp.transform.localScale = new Vector3(1f, 1f, 1f);
        TableLampSize = TableLamp.GetComponent<MeshRenderer>().bounds.size;

        WallLamp1.transform.localScale = new Vector3(1f, 1f, 1f);
        WallLamp1Size = WallLamp1.GetComponent<MeshRenderer>().bounds.size;

        WallLamp2.transform.localScale = new Vector3(1f, 1f, 1f);
        WallLamp2Size = WallLamp2.GetComponent<MeshRenderer>().bounds.size;

        //Dining Room
        DTable1.transform.localScale = new Vector3(1f, 1f, 1f);
        DTable1Size = DTable1.GetComponent<MeshRenderer>().bounds.size;

        DTable2.transform.localScale = new Vector3(1f, 1f, 1f);
        DTable2Size = DTable2.GetComponent<MeshRenderer>().bounds.size;

        Chair1.transform.localScale = new Vector3(1f, 1f, 1f);
        Chair1Size = Chair1.GetComponent<MeshRenderer>().bounds.size;
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
        foundcount = false;

        if (leftClickedButtonName == "Corner_Cabinet")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            //ObjectFollowsMouse = Instantiate(CabinetBase1, new Vector3(4f, 2f, -18f), Quaternion.Euler( new Vector3(-90, 0, 0)));
            ObjectFollowsMouse = Instantiate(CornerCabinet, new Vector3(4f, 2f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();

            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Dish_Washer")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(DishWasher, new Vector3(4f, 2f, -18f), Quaternion.Euler(new Vector3(-90, 90, 0)));
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }       
        else if (leftClickedButtonName == "Fridge_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Fridge1, new Vector3(4f, 2f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Fridge_2")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Fridge2, new Vector3(4f, 2f, -18f), Quaternion.Euler(new Vector3(-90, 90, 0)));
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Range_Hood")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(RangeHood, new Vector3(4f, 2f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

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

            foundcount = true;
        }
        else if (leftClickedButtonName == "TV")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(TV, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Sofa_1")
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

            foundcount = true;
        }
        else if (leftClickedButtonName == "Sofa_4")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Sofa4, new Vector3(4f, 10f, -18f), Quaternion.Euler(new Vector3(-90, 90, 0)));
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Chair_2")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Chair2, new Vector3(4f, 10f, -18f), Quaternion.Euler(new Vector3(-90, 90, 0)));
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Chair_3")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Chair3, new Vector3(4f, 10f, -18f), Quaternion.Euler(new Vector3(-90, 90, 0)));
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Bar_Cabinet")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(BarCabinet, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Coffee_Table_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(CoffeeTable1, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Coffee_Table_2")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(CoffeeTable2, new Vector3(4f, 10f, -18f), Quaternion.Euler(new Vector3(-90, 90, 0)));
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Modular_Cabinet")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(ModularCabinet, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Shelf_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Shelf1, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "TV_Stand_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(TVStand, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Table_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Table1, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Table_2")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Table2, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Bench")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Bench, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Hamper")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Hamper, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Towel_Rack_2")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(TowelRack2, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Computer_Table")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(ComputerTable, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Computer")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Computer, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Chair_Study")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(ChairStudy, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Shelf_2")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Shelf2, new Vector3(4f, 10f, -18f), Quaternion.Euler(new Vector3(-90, 90, 0)));
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Bed_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Bed1, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Bed_2")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Bed2, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Closet")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Closet, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Dresser")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Dresser, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Nightstand_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Nightstand1, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Nightstand_2")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Nightstand2, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Nightstand_3")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Nightstand3, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Carpet")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Carpet, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Rug")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Rug, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Wall_Shelf")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(WallShelf, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Mirror")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Mirror, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Painting_3")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Painting3, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Plant")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Plant, new Vector3(4f, 10f, -18f), Quaternion.Euler(new Vector3(-90, 90, 0)));
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Wine_Rack")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(WineRack, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Floor_Lamp_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(FloorLamp1, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Floor_Lamp_2")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(FloorLamp2, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Table_Lamp")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(TableLamp, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Wall_Lamp_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(WallLamp1, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Wall_Lamp_2")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(WallLamp2, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "D_Table_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(DTable1, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "D_Table_2")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(DTable2, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        else if (leftClickedButtonName == "Chair_1")
        {
            if (isButtonClicked == true)
            {
                Destroy(ObjectFollowsMouse);
            }
            if (isButtonClicked == false)
            {
                isButtonClicked = true;
            }

            ObjectFollowsMouse = Instantiate(Chair1, new Vector3(4f, 10f, -18f), Quaternion.identity);
            objectToPlace = ObjectFollowsMouse.GetComponent<PlaceableObject>();
            ObjectFollowsMouse.AddComponent<ObjectDrag>();

            foundcount = true;
        }
        
        //????
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
            /*if(ObjectFollowsMouse.name == "Chair_Study(Clone)")
            {
                ObjectFollowsMouse.GetComponent<BoxCollider>().size = new Vector3(0.8118632f, 1.4f, 0.7751738f);
                ObjectFollowsMouse.GetComponent<BoxCollider>().center = new Vector3(0f, 0.75f, 0.03668194f);

            }*/
            if (ObjectFollowsMouse.name == "Sofa_4(Clone)" || ObjectFollowsMouse.name == "Shelf_2(Clone)" || ObjectFollowsMouse.name == "Chair_2(Clone)" || ObjectFollowsMouse.name == "Chair_3(Clone)" || ObjectFollowsMouse.name == "Fridge_2(Clone)" 
                || ObjectFollowsMouse.name == "Dish_Washer(Clone)" || ObjectFollowsMouse.name == "Coffee_Table_2(Clone)" || ObjectFollowsMouse.name == "Plant(Clone)")
            {
                ObjectFollowsMouse.GetComponent<BoxCollider>().size = ObjectFollowsMouse.GetComponent<BoxCollider>().size - new Vector3(0.001f, 0.001f, 0.001f);
                //ObjectFollowsMouse.GetComponent<BoxCollider>().size = ObjectFollowsMouse.GetComponent<BoxCollider>().size;
            }
            else {
                ObjectFollowsMouse.GetComponent<BoxCollider>().size = ObjectFollowsMouse.GetComponent<BoxCollider>().size - new Vector3(0.1f, 0.1f, 0.1f);
            }
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
                    if (ObjectFollowsMouse.name == "TV(Clone)" || ObjectFollowsMouse.name == "Towel_Rack_2(Clone)" || ObjectFollowsMouse.name == "Painting_3(Clone)" || ObjectFollowsMouse.name == "Mirror(Clone)" || 
                        ObjectFollowsMouse.name == "Wine_Rack(Clone)" || ObjectFollowsMouse.name == "Wall_Shelf(Clone)" || ObjectFollowsMouse.name == "Wall_Lamp_1(Clone)" || ObjectFollowsMouse.name == "Wall_Lamp_2(Clone)")
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
                            if (ObjectFollowsMouse.name == "TV(Clone)")
                            {
                                gridposx = sizeMenu.TVx;
                                gridposy = sizeMenu.TVy;
                                gridposz = sizeMenu.TVz;
                            }
                            else if (ObjectFollowsMouse.name == "Towel_Rack_2(Clone)")
                            {
                                gridposx = sizeMenu.TowelRack2x;
                                gridposy = sizeMenu.TowelRack2y;
                                gridposz = sizeMenu.TowelRack2z;
                            }
                            else if (ObjectFollowsMouse.name == "Wall_Shelf(Clone)")
                            {
                                gridposx = sizeMenu.WallShelfx;
                                gridposy = sizeMenu.WallShelfy;
                                gridposz = sizeMenu.WallShelfz;
                            }
                            else if (ObjectFollowsMouse.name == "Mirror(Clone)")
                            {
                                gridposx = sizeMenu.Mirrorx;
                                gridposy = sizeMenu.Mirrory;
                                gridposz = sizeMenu.Mirrorz;
                            }
                            else if (ObjectFollowsMouse.name == "Painting_3(Clone)")
                            {
                                gridposx = sizeMenu.Painting3x;
                                gridposy = sizeMenu.Painting3y;
                                gridposz = sizeMenu.Painting3z;
                            }
                            else if (ObjectFollowsMouse.name == "Wall_Lamp_1(Clone)")
                            {
                                gridposx = sizeMenu.WallLamp1x;
                                gridposy = sizeMenu.WallLamp1y;
                                gridposz = sizeMenu.WallLamp1z;
                            }
                            else if (ObjectFollowsMouse.name == "Wall_Lamp_2(Clone)")
                            {
                                gridposx = sizeMenu.WallLamp2x;
                                gridposy = sizeMenu.WallLamp2y;
                                gridposz = sizeMenu.WallLamp2z;
                            }
                            else if (ObjectFollowsMouse.name == "Wine_Rack(Clone)")
                            {
                                gridposx = sizeMenu.WineRackx;
                                gridposy = sizeMenu.WineRacky;
                                gridposz = sizeMenu.WineRackz;
                            }

                            if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 0f)
                            {
                                Debug.Log("1. if");
                                //hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z - 0.25f);
                                objectposition = new Vector3(a.x - 0.25f - 0.25f, a.y + 1.75f - gridposy / 200, a.z + gridposz / 200);
                                //Debug.Log(" abc " + objectposition);
                                //objectposition = new Vector3(a.x - b.size.x, a.y, a.z + b.size.z);
                                //Debug.Log(" abc " + objectposition);
                            }
                            else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 90f)
                            {
                                Debug.Log("2. if");
                                //hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z - 0.25f);
                                objectposition = new Vector3(a.x + gridposz / 200, a.y + 1.75f - gridposy / 200, a.z + 0.25f + 0.25f);
                            }
                            else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 180f)
                            {
                                Debug.Log("3. if");
                                //hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z + 0.25f);
                                objectposition = new Vector3(a.x + 0.25f + 0.25f, a.y + 1.75f - gridposy / 200, a.z - gridposz / 200);
                            }
                            else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 270f)
                            {
                                Debug.Log("4. if");
                                //hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z + 0.25f);
                                objectposition = new Vector3(a.x - gridposz / 200, a.y + 1.75f - gridposy / 200, a.z - 0.25f - 0.25f);
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
                                if (ObjectFollowsMouse.name == "TV(Clone)")
                                {
                                    ObjectFollowsMouse.transform.GetComponent<MeshRenderer>().material.color = Color.black;
                                }
                                else
                                {
                                    ObjectFollowsMouse.transform.GetComponent<MeshRenderer>().material.color = Color.white;
                                }
                               
                                for (int i = 0; i < ObjectFollowsMouse.transform.childCount; i++)
                                {
                                    rend = ObjectFollowsMouse.transform.GetChild(i).GetComponent<MeshRenderer>();
                                    for (int j = 0; j < rend.materials.Length; j++)
                                    {
                                        if(ObjectFollowsMouse.name == "TV(Clone)")
                                        {
                                            rend.materials[j].color = Color.black;
                                        }
                                        else
                                        {
                                            rend.materials[j].color = Color.white;
                                        }
                                        
                                    }
                                }
                            }
                        }


                    }
                   
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
                            if (ObjectFollowsMouse.name == "Corner_Cabinet(Clone)")
                            {
                                gridposx = sizeMenu.CornerCabinetx;
                                gridposy = sizeMenu.CornerCabinety;
                                gridposz = sizeMenu.CornerCabinetz;
                            }
                            else if (ObjectFollowsMouse.name == "Dish_Washer(Clone)")
                            {
                                gridposx = sizeMenu.DishWasherx;
                                gridposy = sizeMenu.DishWashery;
                                gridposz = sizeMenu.DishWasherz;
                            }
                            else if (ObjectFollowsMouse.name == "Fridge_1(Clone)")
                            {
                                gridposx = sizeMenu.Fridge1x;
                                gridposy = sizeMenu.Fridge1y;
                                gridposz = sizeMenu.Fridge1z;
                            }
                            else if (ObjectFollowsMouse.name == "Fridge_2(Clone)")
                            {
                                gridposx = sizeMenu.Fridge2x;
                                gridposy = sizeMenu.Fridge2y;
                                gridposz = sizeMenu.Fridge2z;
                            }
                            else if (ObjectFollowsMouse.name == "Range_Hood(Clone)")
                            {
                                gridposx = sizeMenu.RangeHoodx;
                                gridposy = sizeMenu.RangeHoody;
                                gridposz = sizeMenu.RangeHoodz;
                            }
                            else if (ObjectFollowsMouse.name == "Stove(Clone)")
                            {
                                gridposx = sizeMenu.Stovex;
                                gridposy = sizeMenu.Stovey;
                                gridposz = sizeMenu.Stovez;
                            }
                            else if (ObjectFollowsMouse.name == "Sofa_1(Clone)")
                            {
                                gridposx = sizeMenu.Sofa1x;
                                gridposy = sizeMenu.Sofa1y;
                                gridposz = sizeMenu.Sofa1z;
                            }
                            else if (ObjectFollowsMouse.name == "Sofa_4(Clone)")
                            {
                                gridposx = sizeMenu.Sofa4x;
                                gridposy = sizeMenu.Sofa4y;
                                gridposz = sizeMenu.Sofa4z;
                            }
                            else if (ObjectFollowsMouse.name == "Chair_2(Clone)")
                            {
                                gridposx = sizeMenu.Chair2x;
                                gridposy = sizeMenu.Chair2y;
                                gridposz = sizeMenu.Chair2z;
                            }
                            else if (ObjectFollowsMouse.name == "Chair_3(Clone)")
                            {
                                gridposx = sizeMenu.Chair3x;
                                gridposy = sizeMenu.Chair3y;
                                gridposz = sizeMenu.Chair3z;
                            }
                            else if (ObjectFollowsMouse.name == "Bar_Cabinet(Clone)")
                            {
                                gridposx = sizeMenu.BarCabinetx;
                                gridposy = sizeMenu.BarCabinety;
                                gridposz = sizeMenu.BarCabinetz;
                            }
                            else if (ObjectFollowsMouse.name == "Coffee_Table_1(Clone)")
                            {
                                gridposx = sizeMenu.CoffeeTable1x;
                                gridposy = sizeMenu.CoffeeTable1y;
                                gridposz = sizeMenu.CoffeeTable1z;
                            }
                            else if (ObjectFollowsMouse.name == "Coffee_Table_2(Clone)")
                            {
                                gridposx = sizeMenu.CoffeeTable2x;
                                gridposy = sizeMenu.CoffeeTable2y;
                                gridposz = sizeMenu.CoffeeTable2z;
                            }
                            else if (ObjectFollowsMouse.name == "Modular_Cabinet(Clone)")
                            {
                                gridposx = sizeMenu.ModularCabinetx;
                                gridposy = sizeMenu.ModularCabinety;
                                gridposz = sizeMenu.ModularCabinetz;
                            }
                            else if (ObjectFollowsMouse.name == "Shelf_1(Clone)")
                            {
                                gridposx = sizeMenu.Shelf1x;
                                gridposy = sizeMenu.Shelf1y;
                                gridposz = sizeMenu.Shelf1z;
                            }
                            else if (ObjectFollowsMouse.name == "TV_Stand_1(Clone)")
                            {
                                gridposx = sizeMenu.TVStandx;
                                gridposy = sizeMenu.TVStandy;
                                gridposz = sizeMenu.TVStandz;
                            }
                            else if (ObjectFollowsMouse.name == "Table_1(Clone)")
                            {
                                gridposx = sizeMenu.Table1x;
                                gridposy = sizeMenu.Table1y;
                                gridposz = sizeMenu.Table1z;
                            }
                            else if (ObjectFollowsMouse.name == "Table_2(Clone)")
                            {
                                gridposx = sizeMenu.Table2x;
                                gridposy = sizeMenu.Table2y;
                                gridposz = sizeMenu.Table2z;
                            }
                            else if (ObjectFollowsMouse.name == "Bench(Clone)")
                            {
                                gridposx = sizeMenu.Benchx;
                                gridposy = sizeMenu.Benchy;
                                gridposz = sizeMenu.Benchz;
                            }
                            else if (ObjectFollowsMouse.name == "Hamper(Clone)")
                            {
                                gridposx = sizeMenu.Hamperx;
                                gridposy = sizeMenu.Hampery;
                                gridposz = sizeMenu.Hamperz;
                            }
                            else if (ObjectFollowsMouse.name == "Computer_Table(Clone)")
                            {
                                gridposx = sizeMenu.ComputerTablex;
                                gridposy = sizeMenu.ComputerTabley;
                                gridposz = sizeMenu.ComputerTablez;
                            }
                            else if (ObjectFollowsMouse.name == "Computer(Clone)")
                            {
                                gridposx = sizeMenu.Computerx;
                                gridposy = sizeMenu.Computery;
                                gridposz = sizeMenu.Computerz;
                            }
                            else if (ObjectFollowsMouse.name == "Chair_Study(Clone)")
                            {
                                gridposx = sizeMenu.ChairStudyx;
                                gridposy = sizeMenu.ChairStudyy;
                                gridposz = sizeMenu.ChairStudyz;
                            }
                            else if (ObjectFollowsMouse.name == "Shelf_2(Clone)")
                            {
                                gridposx = sizeMenu.Shelf2x;
                                gridposy = sizeMenu.Shelf2y;
                                gridposz = sizeMenu.Shelf2z;
                            }
                            else if (ObjectFollowsMouse.name == "Bed_1(Clone)")
                            {
                                gridposx = sizeMenu.Bed1x;
                                gridposy = sizeMenu.Bed1y;
                                gridposz = sizeMenu.Bed1z;
                            }
                            else if (ObjectFollowsMouse.name == "Bed_2(Clone)")
                            {
                                gridposx = sizeMenu.Bed2x;
                                gridposy = sizeMenu.Bed2y;
                                gridposz = sizeMenu.Bed2z;
                            }
                            else if (ObjectFollowsMouse.name == "Closet(Clone)")
                            {
                                gridposx = sizeMenu.Closetx;
                                gridposy = sizeMenu.Closety;
                                gridposz = sizeMenu.Closetz;
                            }
                            else if (ObjectFollowsMouse.name == "Dresser(Clone)")
                            {
                                gridposx = sizeMenu.Dresserx;
                                gridposy = sizeMenu.Dressery;
                                gridposz = sizeMenu.Dresserz;
                            }
                            else if (ObjectFollowsMouse.name == "Nightstand_1(Clone)")
                            {
                                gridposx = sizeMenu.Nightstand1x;
                                gridposy = sizeMenu.Nightstand1y;
                                gridposz = sizeMenu.Nightstand1z;
                            }
                            else if (ObjectFollowsMouse.name == "Nightstand_2(Clone)")
                            {
                                gridposx = sizeMenu.Nightstand2x;
                                gridposy = sizeMenu.Nightstand2y;
                                gridposz = sizeMenu.Nightstand2z;
                            }
                            else if (ObjectFollowsMouse.name == "Nightstand_3(Clone)")
                            {
                                gridposx = sizeMenu.Nightstand3x;
                                gridposy = sizeMenu.Nightstand3y;
                                gridposz = sizeMenu.Nightstand3z;
                            }
                            else if (ObjectFollowsMouse.name == "Carpet(Clone)")
                            {
                                gridposx = sizeMenu.Carpetx;
                                gridposy = sizeMenu.Carpety;
                                gridposz = sizeMenu.Carpetz;
                            }
                            else if (ObjectFollowsMouse.name == "Rug(Clone)")
                            {
                                gridposx = sizeMenu.Rugx;
                                gridposy = sizeMenu.Rugy;
                                gridposz = sizeMenu.Rugz;
                            }
                            else if (ObjectFollowsMouse.name == "Plant(Clone)")
                            {
                                gridposx = sizeMenu.Plantx;
                                gridposy = sizeMenu.Planty;
                                gridposz = sizeMenu.Plantz;
                            }
                            else if (ObjectFollowsMouse.name == "Floor_Lamp_1(Clone)")
                            {
                                gridposx = sizeMenu.FloorLamp1x;
                                gridposy = sizeMenu.FloorLamp1y;
                                gridposz = sizeMenu.FloorLamp1z;
                            }
                            else if (ObjectFollowsMouse.name == "Floor_Lamp_2(Clone)")
                            {
                                gridposx = sizeMenu.FloorLamp2x;
                                gridposy = sizeMenu.FloorLamp2y;
                                gridposz = sizeMenu.FloorLamp2z;
                            }
                            else if (ObjectFollowsMouse.name == "Table_Lamp(Clone)")
                            {
                                gridposx = sizeMenu.TableLampx;
                                gridposy = sizeMenu.TableLampy;
                                gridposz = sizeMenu.TableLampz;
                            }
                            else if (ObjectFollowsMouse.name == "D_Table_1(Clone)")
                            {
                                gridposx = sizeMenu.DTable1x;
                                gridposy = sizeMenu.DTable1y;
                                gridposz = sizeMenu.DTable1z;
                            }
                            else if (ObjectFollowsMouse.name == "D_Table_2(Clone)")
                            {
                                gridposx = sizeMenu.DTable2x;
                                gridposy = sizeMenu.DTable2y;
                                gridposz = sizeMenu.DTable2z;
                            }
                            else if (ObjectFollowsMouse.name == "Chair_1(Clone)")
                            {
                                gridposx = sizeMenu.Chair1x;
                                gridposy = sizeMenu.Chair1y;
                                gridposz = sizeMenu.Chair1z;
                            }

                            if (ObjectFollowsMouse.name == "Sofa_4(Clone)" || ObjectFollowsMouse.name == "Shelf_2(Clone)" || ObjectFollowsMouse.name == "Chair_2(Clone)" || ObjectFollowsMouse.name == "Chair_3(Clone)" || ObjectFollowsMouse.name == "Fridge_2(Clone)"
                                || ObjectFollowsMouse.name == "Dish_Washer(Clone)" || ObjectFollowsMouse.name == "Coffee_Table_2(Clone)" || ObjectFollowsMouse.name == "Plant(Clone)") {
                                Debug.Log(ObjectFollowsMouse.transform.eulerAngles + " SOFA4 EULERANGLE");
                                if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y== 90f)
                                {
                                    Debug.Log("1. if");
                                    //hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z - 0.25f);
                                    objectposition = new Vector3(a.x - gridposx / 200, a.y + 0.1f, a.z + gridposz / 200);
                                    //Debug.Log(" abc " + objectposition);
                                    //objectposition = new Vector3(a.x - b.size.x, a.y, a.z + b.size.z);
                                    //Debug.Log(" abc " + objectposition);
                                }
                                else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 180f)
                                {
                                    Debug.Log("2. if");
                                    //hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z - 0.25f);
                                    objectposition = new Vector3(a.x + gridposz / 200, a.y + 0.1f, a.z + gridposx / 200);
                                }
                                else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 270f)
                                {
                                    Debug.Log("3. if");
                                    //hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z + 0.25f);
                                    objectposition = new Vector3(a.x + gridposx / 200, a.y + 0.1f, a.z - gridposz / 200);
                                }
                                else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 0f)
                                {
                                    Debug.Log("4. if");
                                    //hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z + 0.25f);
                                    objectposition = new Vector3(a.x - gridposz / 200, a.y + 0.1f, a.z - gridposx / 200);
                                }
                            }
                            else
                            {
                                if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 0f)
                                {
                                    Debug.Log("1. if");
                                    //hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z - 0.25f);
                                    objectposition = new Vector3(a.x - gridposx / 200, a.y + 0.1f, a.z + gridposz / 200);
                                    //Debug.Log(" abc " + objectposition);
                                    //objectposition = new Vector3(a.x - b.size.x, a.y, a.z + b.size.z);
                                    //Debug.Log(" abc " + objectposition);
                                }
                                else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 90f)
                                {
                                    Debug.Log("2. if");
                                    //hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z - 0.25f);
                                    objectposition = new Vector3(a.x + gridposz / 200, a.y + 0.1f, a.z + gridposx / 200);
                                }
                                else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 180f)
                                {
                                    Debug.Log("3. if");
                                    //hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z + 0.25f);
                                    objectposition = new Vector3(a.x + gridposx / 200, a.y + 0.1f, a.z - gridposz / 200);
                                }
                                else if (ObjectFollowsMouse.tag == "3DModel" && ObjectFollowsMouse.transform.eulerAngles.y == 270f)
                                {
                                    Debug.Log("4. if");
                                    //hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z + 0.25f);
                                    objectposition = new Vector3(a.x - gridposz / 200, a.y + 0.1f, a.z - gridposx / 200);
                                }
                            }
                            if(ObjectFollowsMouse.name == "Chair_Study(Clone)")
                            {
                                objectposition = objectposition + new Vector3(0f, gridposy / 100f * 0.33f, 0f);
                               
                            }
                            if (ObjectFollowsMouse.name == "Rug(Clone)" || ObjectFollowsMouse.name == "Carpet(Clone)")
                            {
                                objectposition = objectposition - new Vector3(0f, 0.1f, 0f);

                            }
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
                                if (ObjectFollowsMouse.name == "Computer(Clone)")
                                {
                                    ObjectFollowsMouse.transform.GetComponent<MeshRenderer>().material.color = Color.black;
                                }
                                else
                                {
                                    ObjectFollowsMouse.transform.GetComponent<MeshRenderer>().material.color = Color.white;
                                }

                                for (int i = 0; i < ObjectFollowsMouse.transform.childCount; i++)
                                {
                                    rend = ObjectFollowsMouse.transform.GetChild(i).GetComponent<MeshRenderer>();
                                    for (int j = 0; j < rend.materials.Length; j++)
                                    {
                                        if (ObjectFollowsMouse.name == "Computer(Clone)")
                                        {
                                            rend.materials[j].color = Color.black;
                                        }
                                        else
                                        {
                                            rend.materials[j].color = Color.white;
                                        }

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
                    if (ObjectFollowsMouse.name == "Sofa_4(Clone)" || ObjectFollowsMouse.name == "Shelf_2(Clone)" || ObjectFollowsMouse.name == "Chair_2(Clone)" || ObjectFollowsMouse.name == "Chair_3(Clone)" || ObjectFollowsMouse.name == "Fridge_2(Clone)"
                || ObjectFollowsMouse.name == "Dish_Washer(Clone)" || ObjectFollowsMouse.name == "Coffee_Table_2(Clone)" || ObjectFollowsMouse.name == "Plant(Clone)")
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
                    if (ObjectFollowsMouse.name == "Sofa_4(Clone)" || ObjectFollowsMouse.name == "Shelf_2(Clone)" || ObjectFollowsMouse.name == "Chair_2(Clone)" || ObjectFollowsMouse.name == "Chair_3(Clone)" || ObjectFollowsMouse.name == "Fridge_2(Clone)"
                || ObjectFollowsMouse.name == "Dish_Washer(Clone)" || ObjectFollowsMouse.name == "Coffee_Table_2(Clone)" || ObjectFollowsMouse.name == "Plant(Clone)")
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
                        Debug.Log(ObjectFollowsMouse.GetComponent<BoxCollider>().bounds.size);
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
                        ObjectFollowsMouse = Selected3DObject;
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
