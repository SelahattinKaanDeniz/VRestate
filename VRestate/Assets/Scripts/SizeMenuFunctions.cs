using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SizeMenuFunctions : MonoBehaviour
{
    
    private ItemMenuButtonFunctions itemMenuFunctions;
    private ClientButtonFunctions clientMenuFunctions;
    public GameObject sizeMenuPopUp;
    private string whichButtonClicked;
    private string whichButtonClickedClient;
    public TMP_InputField lengthInputField;
    public TMP_InputField widthInputField;
    public TMP_InputField heightInputField;

    public  float CabinetBase1x;
    public  float CabinetBase1y;
    public  float CabinetBase1z;

    public  float CabinetBase2x;
    public  float CabinetBase2y;
    public  float CabinetBase2z;

    public  float CabinetBaseCornerx;
    public  float CabinetBaseCornery;
    public  float CabinetBaseCornerz;

    public  float CabinetBaseSinkx;
    public  float CabinetBaseSinky;
    public  float CabinetBaseSinkz;

    public  float CabinetTallx;
    public  float CabinetTally;
    public  float CabinetTallz;

    public float CabinetWall1x;
    public float CabinetWall1y;
    public float CabinetWall1z;

    public float CabinetWall2x;
    public float CabinetWall2y;
    public float CabinetWall2z;

    public  float Stovex;
    public  float Stovey;
    public  float Stovez;

    public  float Bathtubx;
    public  float Bathtuby;
    public  float Bathtubz;

    public  float Showerx;
    public  float Showery;
    public  float Showerz;

    public  float Toiletx;
    public  float Toilety;
    public  float Toiletz;

    public  float Vanity1x;
    public  float Vanity1y;
    public  float Vanity1z;

    public  float Vanity2x;
    public  float Vanity2y;
    public  float Vanity2z;

    public  float Vanity3x;
    public  float Vanity3y;
    public  float Vanity3z;

    public float CornerCabinetx;
    public float CornerCabinety;
    public float CornerCabinetz;

    public float DishWasherx;
    public float DishWashery;
    public float DishWasherz;
    
    public float Fridge1x;
    public float Fridge1y;
    public float Fridge1z;

    public float Fridge2x;
    public float Fridge2y;
    public float Fridge2z;

    public float RangeHoodx;
    public float RangeHoody;
    public float RangeHoodz;

    //public float Stovex;
    //public float Stovey;
    //public float Stovez;

    public float TVx;
    public float TVy;
    public float TVz;

    public float Sofa1x;
    public float Sofa1y;
    public float Sofa1z;

    public float Sofa4x;
    public float Sofa4y;
    public float Sofa4z;

    public float Chair2x;
    public float Chair2y;
    public float Chair2z;

    public float Chair3x;
    public float Chair3y;
    public float Chair3z;

    public float BarCabinetx;
    public float BarCabinety;
    public float BarCabinetz;

    public float CoffeeTable1x;
    public float CoffeeTable1y;
    public float CoffeeTable1z;

    public float CoffeeTable2x;
    public float CoffeeTable2y;
    public float CoffeeTable2z;

    public float ModularCabinetx;
    public float ModularCabinety;
    public float ModularCabinetz;

    public float Shelf1x;
    public float Shelf1y;
    public float Shelf1z;

    public float TVStandx;
    public float TVStandy;
    public float TVStandz;

    public float Table1x;
    public float Table1y;
    public float Table1z;

    public float Table2x;
    public float Table2y;
    public float Table2z;

    public float Benchx;
    public float Benchy;
    public float Benchz;

    public float Hamperx;
    public float Hampery;
    public float Hamperz;

    public float TowelRack2x;
    public float TowelRack2y;
    public float TowelRack2z;

    public float ComputerTablex;
    public float ComputerTabley;
    public float ComputerTablez;

    public float Computerx;
    public float Computery;
    public float Computerz;

    public float ChairStudyx;
    public float ChairStudyy;
    public float ChairStudyz;

    public float Shelf2x;
    public float Shelf2y;
    public float Shelf2z;

    public float Bed1x;
    public float Bed1y;
    public float Bed1z;

    public float Bed2x;
    public float Bed2y;
    public float Bed2z;

    public float Closetx;
    public float Closety;
    public float Closetz;

    public float Dresserx;
    public float Dressery;
    public float Dresserz;
    
    public float Nightstand1x;
    public float Nightstand1y;
    public float Nightstand1z;

    public float Nightstand2x;
    public float Nightstand2y;
    public float Nightstand2z;

    public float Nightstand3x;
    public float Nightstand3y;
    public float Nightstand3z;

    public float Carpetx;
    public float Carpety;
    public float Carpetz;

    public float Rugx;
    public float Rugy;
    public float Rugz;

    public float WallShelfx;
    public float WallShelfy;
    public float WallShelfz;

    public float Mirrorx;
    public float Mirrory;
    public float Mirrorz;

    public float Painting3x;
    public float Painting3y;
    public float Painting3z;

    public float Plantx;
    public float Planty;
    public float Plantz;

    public float WineRackx;
    public float WineRacky;
    public float WineRackz;

    public float FloorLamp1x;
    public float FloorLamp1y;
    public float FloorLamp1z;

    public float FloorLamp2x;
    public float FloorLamp2y;
    public float FloorLamp2z;

    public float TableLampx;
    public float TableLampy;
    public float TableLampz;

    public float WallLamp1x;
    public float WallLamp1y;
    public float WallLamp1z;

    public float WallLamp2x;
    public float WallLamp2y;
    public float WallLamp2z;

    public float DTable1x;
    public float DTable1y;
    public float DTable1z;

    public float DTable2x;
    public float DTable2y;
    public float DTable2z;

    public float Chair1x;
    public float Chair1y;
    public float Chair1z;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        itemMenuFunctions = canvas.GetComponent<ItemMenuButtonFunctions>();
        clientMenuFunctions = canvas.GetComponent<ClientButtonFunctions>();
        Debug.Log(itemMenuFunctions + " itemmenufunctions");
        Debug.Log(clientMenuFunctions + " clientmenufunctions");


    }
    public void lengthValueChanged(string txt)
    {
        if (txt.Length > 0 && txt[0] == '-') lengthInputField.text = txt.Remove(0, 1);
    }
    public void widthValueChanged(string txt)
    {
        if (txt.Length > 0 && txt[0] == '-') widthInputField.text = txt.Remove(0, 1);
    }
    public void heightValueChanged(string txt)
    {
        if (txt.Length > 0 && txt[0] == '-') heightInputField.text = txt.Remove(0, 1);
    }

    // OYUNDAN ÇIKIÞ YAPINCA BÜTÜN PREFABLERÝN BOYUTLARINI ESKÝ HALÝNE GETÝR
    public void SaveButtonClicked() { 
        float length; // Z
        float.TryParse(lengthInputField.text, out float lengthresult);
        length = lengthresult;

        float width; // X
        float.TryParse(widthInputField.text, out float widthresult);
        width = widthresult;

        float height; // Y
        float.TryParse(heightInputField.text, out float heightresult);
        height = heightresult;

        //HER BÝR MODEL ÝÇÝN BAÞLANGIÇTA bounds size'ýný(e.g. CabinetBase1Size) alýp küpe göre orantýsýný alýp(e.g. CabinetBase1Size.x) scalelarýný ayarla 
        // UYGULAMA KAPANDIÐINDA BÜTÜN PREFABLERÝN BOYUTLARINI EN BAÞTAKÝ BOYUTLARINA DÖNDÜR
        // BÜTÜN BETONARMELER 50 CM KALINLIÐINDA
        if (length > 0 && width >0 && height > 0)
        { 
            if(whichButtonClicked == "Cabinet_Base_1")
            {
                Debug.Log(CabinetBase1x + " " + CabinetBase1y + CabinetBase1z + "size if içi öncesi cabinetbase1");
                CabinetBase1x = width;
                CabinetBase1y = height;
                CabinetBase1z = length;
                Debug.Log(CabinetBase1x + " " + CabinetBase1y + CabinetBase1z + "size if içi cabinetbase1");
                //itemMenuFunctions.CabinetBase1.transform.localScale = new Vector3(length / 100, height / 100, width / 100);
                itemMenuFunctions.CabinetBase1.transform.localScale = new Vector3((width/100)*(1f/ ItemMenuButtonFunctions.CabinetBase1Size.x), (height/100) * (1f / ItemMenuButtonFunctions.CabinetBase1Size.y), ( length/100) * (1f / ItemMenuButtonFunctions.CabinetBase1Size.z));
            }
            else if (whichButtonClicked == "Cabinet_Base_2")
            {
                CabinetBase2x = width;
                CabinetBase2y = height;
                CabinetBase2z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.CabinetBase2Size.x), (height / 100) * (1f / ItemMenuButtonFunctions.CabinetBase2Size.y), (length / 100) * (1f / ItemMenuButtonFunctions.CabinetBase2Size.z));
            }
            else if (whichButtonClicked == "Cabinet_Base_Corner")
            {
                CabinetBaseCornerx = width;
                CabinetBaseCornery = height;
                CabinetBaseCornerz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.CabinetBaseCorner.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.CabinetBaseCornerSize.x), (height / 100) * (1f / ItemMenuButtonFunctions.CabinetBaseCornerSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.CabinetBaseCornerSize.z));
            }
            else if (whichButtonClicked == "Cabinet_Base_Sink")
            {
                CabinetBaseSinkx = width;
                CabinetBaseSinky = height;
                CabinetBaseSinkz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.CabinetBaseSink.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.CabinetBaseSinkSize.x), (height / 100) * (1f / ItemMenuButtonFunctions.CabinetBaseSinkSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.CabinetBaseSinkSize.z));
            }
            else if (whichButtonClicked == "Cabinet_Tall")
            {
                CabinetTallx = width;
                CabinetTally = height;
                CabinetTallz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.CabinetTall.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.CabinetTallSize.x), (height / 100) * (1f / ItemMenuButtonFunctions.CabinetTallSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.CabinetTallSize.z));
            }
            else if (whichButtonClicked == "Cabinet_Wall_1")
            {
                CabinetWall1x = width;
                CabinetWall1y = height;
                CabinetWall1z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.CabinetWall1.transform.localScale = new Vector3((50f / 100f) * (1f / ItemMenuButtonFunctions.CabinetWall1Size.x), (height / 100) * (1f / ItemMenuButtonFunctions.CabinetWall1Size.y), (length / 100) * (1f / ItemMenuButtonFunctions.CabinetWall1Size.z));
            }
            else if (whichButtonClicked == "Cabinet_Wall_2")
            {
                CabinetWall2x = width;
                CabinetWall2y = height;
                CabinetWall2z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.CabinetWall2.transform.localScale = new Vector3((50f / 100f) * (1f / ItemMenuButtonFunctions.CabinetWall2Size.x), (height / 100) * (1f / ItemMenuButtonFunctions.CabinetWall2Size.y), (length / 100) * (1f / ItemMenuButtonFunctions.CabinetWall2Size.z));
            }
            else if (whichButtonClicked == "Wall")
            {
               
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                //itemMenuFunctions.Wall.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.WallSize.x), (height / 100) * (1f / ItemMenuButtonFunctions.WallSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.WallSize.z));
                //itemMenuFunctions.Wall.transform.localScale = new Vector3(0.5f, (height / 100) * (1f / ItemMenuButtonFunctions.WallSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.WallSize.z));
                //itemMenuFunctions.Wall.transform.localScale = new Vector3(1f, (height / 100) * (1f / ItemMenuButtonFunctions.WallSize.y), 0.2f);

                itemMenuFunctions.wallPrefab.transform.localScale = new Vector3(0.5f, 3f, 0.5f);

            }
            else if (whichButtonClicked == "Stove")
            {
                Stovex = width;
                Stovey = height;
                Stovez = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.Stove.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.StoveSize.x), (height / 100) * (1f / ItemMenuButtonFunctions.StoveSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.StoveSize.z));
            }
            else if (whichButtonClicked == "Bathtub")
            {
                Bathtubx = width;
                Bathtuby = height;
                Bathtubz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.Bathtub.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.BathtubSize.x), (height / 100) * (1f / ItemMenuButtonFunctions.BathtubSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.BathtubSize.z));
            }
            else if (whichButtonClicked == "Shower")
            {
                Showerx = width;
                Showery = height;
                Showerz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.Shower.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.ShowerSize.x), (height / 100) * (1f / ItemMenuButtonFunctions.ShowerSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.ShowerSize.z));
            }
            
            else if (whichButtonClicked == "Toilet")
            {
                Toiletx = width;
                Toilety = height;
                Toiletz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.Toilet.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.ToiletSize.x), (height / 100) * (1f / ItemMenuButtonFunctions.ToiletSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.ToiletSize.z));
            }
            else if (whichButtonClicked == "Vanity_1")
            {
                Vanity1x = width;
                Vanity1y = height;
                Vanity1z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.Vanity1.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.Vanity1Size.x), (height / 100) * (1f / ItemMenuButtonFunctions.Vanity1Size.y), (length / 100) * (1f / ItemMenuButtonFunctions.Vanity1Size.z));
            }
            else if (whichButtonClicked == "Vanity_3")
            {
                Vanity3x = width;
                Vanity3z = height;
                Vanity3y = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.Vanity3.transform.localScale = new Vector3((width / 100) * (100f / ItemMenuButtonFunctions.Vanity3Size.x), (height / 100) * (100f / ItemMenuButtonFunctions.Vanity3Size.z), (length / 100) * (100f / ItemMenuButtonFunctions.Vanity3Size.y));
            }
            else if (whichButtonClicked == "Floor")
            {
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                //itemMenuFunctions.Floor.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.FloorSize.x), 1f, (length / 100) * (1f / ItemMenuButtonFunctions.FloorSize.z));
                itemMenuFunctions.Floor.transform.localScale = new Vector3(0.2f, 0.1f, 0.2f);
            }
            else if (whichButtonClicked == "Frame")
            {
                
                itemMenuFunctions.Frame.transform.localScale = new Vector3(0.5f, 3f, 0.5f);
            }
            else if (whichButtonClicked == "Rail")
            {
                itemMenuFunctions.Frame.transform.localScale = new Vector3(0.5f, 1f, 0.5f);
            }
            //CLIENT MODELLERÝ ÝÇÝN
            else if (whichButtonClickedClient == "Corner_Cabinet")
            {
                CornerCabinetx = width;
                CornerCabinety = height;
                CornerCabinetz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.CornerCabinet.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.CornerCabinetSize.x), (height / 100) * (1f / ClientButtonFunctions.CornerCabinetSize.y), (length / 100) * (1f / ClientButtonFunctions.CornerCabinetSize.z));
            }
            else if (whichButtonClickedClient == "Dish_Washer")
            {
                DishWasherx = width;
                DishWashery = height;
                DishWasherz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.DishWasher.transform.localScale = new Vector3((length / 100) * (121.6511f / ClientButtonFunctions.DishWasherSize.x), (width / 100) * (100f / ClientButtonFunctions.DishWasherSize.z), (height / 100) * (100f / ClientButtonFunctions.DishWasherSize.y));
            }
            else if (whichButtonClickedClient == "Fridge_1")
            {
                Fridge1x = width;
                Fridge1y = height;
                Fridge1z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Fridge1.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.Fridge1Size.x), (height / 100) * (1f / ClientButtonFunctions.Fridge1Size.y), (length / 100) * (1f / ClientButtonFunctions.Fridge1Size.z));
            }
            else if (whichButtonClickedClient == "Fridge_2")
            {
                Fridge2x = width;
                Fridge2y = height;
                Fridge2z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Fridge2.transform.localScale = new Vector3((length / 100) * (50f / ClientButtonFunctions.Fridge2Size.x), (width / 100) * (50f / ClientButtonFunctions.Fridge2Size.z), (height / 100) * (50f / ClientButtonFunctions.Fridge2Size.y));
            }
            else if (whichButtonClickedClient == "Range_Hood")
            {
                RangeHoodx = width;
                RangeHoody = height;
                RangeHoodz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.RangeHood.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.RangeHoodSize.x), (height / 100) * (1f / ClientButtonFunctions.RangeHoodSize.y), (length / 100) * (1f / ClientButtonFunctions.RangeHoodSize.z));
            }
            else if (whichButtonClickedClient == "Stove")
            {
                Stovex = width;
                Stovey = height;
                Stovez = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Stove.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.StoveSize.x), (height / 100) * (1f / ClientButtonFunctions.StoveSize.y), (length / 100) * (1f / ClientButtonFunctions.StoveSize.z));
            }
            else if (whichButtonClickedClient == "TV")
            {
                TVx = width;
                TVy = height;
                TVz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.TV.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.TVSize.x), (height / 100) * (1f / ClientButtonFunctions.TVSize.y), (length / 100) * (1f / ClientButtonFunctions.TVSize.z));
            }
            else if (whichButtonClickedClient == "Sofa_1")
            {
                Debug.Log("sofa1 button clicked");
                Sofa1x = width;
                Sofa1y = height;
                Sofa1z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Sofa1.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.Sofa1Size.x), (height / 100) * (1f / ClientButtonFunctions.Sofa1Size.y), (length / 100) * (1f / ClientButtonFunctions.Sofa1Size.z));
            }
            else if (whichButtonClickedClient == "Sofa_4")
            {
                Sofa4x = width;
                Sofa4y = height;
                Sofa4z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Sofa4.transform.localScale = new Vector3((length / 100) * (127.3344f / ClientButtonFunctions.Sofa4Size.x), (width / 100) * (127.3344f / ClientButtonFunctions.Sofa4Size.z), (height / 100) * (127.3344f / ClientButtonFunctions.Sofa4Size.y));
            }
            else if (whichButtonClickedClient == "Chair_2")
            {
                Chair2x = width;
                Chair2y = height;
                Chair2z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Chair2.transform.localScale = new Vector3((length / 100) * (80f / ClientButtonFunctions.Chair2Size.x), (width / 100) * (76f / ClientButtonFunctions.Chair2Size.z), (height / 100) * (80f / ClientButtonFunctions.Chair2Size.y));
            }
            else if (whichButtonClickedClient == "Chair_3")
            {
                Chair3x = width;
                Chair3y = height;
                Chair3z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Chair3.transform.localScale = new Vector3((length / 100) * (100f / ClientButtonFunctions.Chair3Size.x), (width / 100) * (100f / ClientButtonFunctions.Chair3Size.z), (height / 100) * (100f / ClientButtonFunctions.Chair3Size.y));
            }
            else if (whichButtonClickedClient == "Bar_Cabinet")
            {
                BarCabinetx = width;
                BarCabinety = height;
                BarCabinetz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.BarCabinet.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.BarCabinetSize.x), (height / 100) * (1f / ClientButtonFunctions.BarCabinetSize.y), (length / 100) * (1f / ClientButtonFunctions.BarCabinetSize.z));
            }
            else if (whichButtonClickedClient == "Coffee_Table_1")
            {
                CoffeeTable1x = width;
                CoffeeTable1y = height;
                CoffeeTable1z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.CoffeeTable1.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.CoffeeTable1Size.x), (height / 100) * (1f / ClientButtonFunctions.CoffeeTable1Size.y), (length / 100) * (1f / ClientButtonFunctions.CoffeeTable1Size.z));
            }
            else if (whichButtonClickedClient == "Coffee_Table_2")
            {
                CoffeeTable2x = width;
                CoffeeTable2y = height;
                CoffeeTable2z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.CoffeeTable2.transform.localScale = new Vector3((length / 100) * (100f / ClientButtonFunctions.CoffeeTable2Size.x), (width / 100) * (100f / ClientButtonFunctions.CoffeeTable2Size.z), (height / 100) * (100f / ClientButtonFunctions.CoffeeTable2Size.y));
            }
            else if (whichButtonClickedClient == "Modular_Cabinet")
            {
                ModularCabinetx = width;
                ModularCabinety = height;
                ModularCabinetz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.ModularCabinet.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.ModularCabinetSize.x), (height / 100) * (1f / ClientButtonFunctions.ModularCabinetSize.y), (length / 100) * (1f / ClientButtonFunctions.ModularCabinetSize.z));
            }
            else if (whichButtonClickedClient == "Shelf_1")
            {
                Shelf1x = width;
                Shelf1y = height;
                Shelf1z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Shelf1.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.Shelf1Size.x), (height / 100) * (1f / ClientButtonFunctions.Shelf1Size.y), (length / 100) * (1f / ClientButtonFunctions.Shelf1Size.z));
            }
            else if (whichButtonClickedClient == "TV_Stand_1")
            {
                TVStandx = width;
                TVStandy = height;
                TVStandz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.TVStand.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.TVStandSize.x), (height / 100) * (1f / ClientButtonFunctions.TVStandSize.y), (length / 100) * (1f / ClientButtonFunctions.TVStandSize.z));
            }
            else if (whichButtonClickedClient == "Table_1")
            {
                Table1x = width;
                Table1y = height;
                Table1z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Table1.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.Table1Size.x), (height / 100) * (1f / ClientButtonFunctions.Table1Size.y), (length / 100) * (1f / ClientButtonFunctions.Table1Size.z));
            }
            else if (whichButtonClickedClient == "Table_2")
            {
                Table2x = width;
                Table2y = height;
                Table2z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Table2.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.Table2Size.x), (height / 100) * (1f / ClientButtonFunctions.Table2Size.y), (length / 100) * (1f / ClientButtonFunctions.Table2Size.z));
            }
            else if (whichButtonClickedClient == "Bench")
            {
                Benchx = width;
                Benchy = height;
                Benchz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Bench.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.BenchSize.x), (height / 100) * (1f / ClientButtonFunctions.BenchSize.y), (length / 100) * (1f / ClientButtonFunctions.BenchSize.z));
            }
            else if (whichButtonClickedClient == "Hamper")
            {
                Hamperx = width;
                Hampery = height;
                Hamperz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Hamper.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.HamperSize.x), (height / 100) * (1f / ClientButtonFunctions.HamperSize.y), (length / 100) * (1f / ClientButtonFunctions.HamperSize.z));
            }
            else if (whichButtonClickedClient == "Towel_Rack_2")
            {
                TowelRack2x = width;
                TowelRack2y = height;
                TowelRack2z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.TowelRack2.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.TowelRack2Size.x), (height / 100) * (1f / ClientButtonFunctions.TowelRack2Size.y), (length / 100) * (1f / ClientButtonFunctions.TowelRack2Size.z));
            }
            else if (whichButtonClickedClient == "Computer_Table")
            {
                ComputerTablex = width;
                ComputerTabley = height;
                ComputerTablez = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.ComputerTable.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.ComputerTableSize.x), (height / 100) * (1f / ClientButtonFunctions.ComputerTableSize.y)/1.5f, (length / 100) * (1f / ClientButtonFunctions.ComputerTableSize.z));
            }
            else if (whichButtonClickedClient == "Computer")
            {
                Computerx = width;
                Computery = height;
                Computerz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Computer.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.ComputerSize.x), (height / 100) * (1f / ClientButtonFunctions.ComputerSize.y), (length / 100) * (1f / ClientButtonFunctions.ComputerSize.z));
            }
            else if (whichButtonClickedClient == "Chair_Study")
            {
                ChairStudyx = width;
                ChairStudyy = height;
                ChairStudyz = length;
             
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.ChairStudy.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.ChairStudySize.x)/1.25f, (height / 100) * (1f / ClientButtonFunctions.ChairStudySize.y) / 1.25f, (length / 100) * (1f / ClientButtonFunctions.ChairStudySize.z) / 1.25f);
                
            }
            else if (whichButtonClickedClient == "Shelf_2")
            {
                Shelf2x = width;
                Shelf2y = height;
                Shelf2z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Shelf2.transform.localScale = new Vector3((length / 100) * (51.34407f / ClientButtonFunctions.Shelf2Size.x), (width / 100) * (63.60788f / ClientButtonFunctions.Shelf2Size.z), (height / 100) * (63.60788f / ClientButtonFunctions.Shelf2Size.y));
            }
            else if (whichButtonClickedClient == "Bed_1")
            {
                Bed1x = width;
                Bed1y = height;
                Bed1z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Bed1.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.Bed1Size.x), (height / 100) * (1f / ClientButtonFunctions.Bed1Size.y), (length / 100) * (1f / ClientButtonFunctions.Bed1Size.z));
            }
            else if (whichButtonClickedClient == "Bed_2")
            {
                Bed2x = width;
                Bed2y = height;
                Bed2z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Bed2.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.Bed2Size.x), (height / 100) * (1f / ClientButtonFunctions.Bed2Size.y), (length / 100) * (1f / ClientButtonFunctions.Bed2Size.z));
            }
            else if (whichButtonClickedClient == "Closet")
            {
                Closetx = width;
                Closety = height;
                Closetz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Closet.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.ClosetSize.x), (height / 100) * (1f / ClientButtonFunctions.ClosetSize.y), (length / 100) * (1f / ClientButtonFunctions.ClosetSize.z));
            }
            else if (whichButtonClickedClient == "Dresser")
            {
                Dresserx = width;
                Dressery = height;
                Dresserz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Dresser.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.DresserSize.x), (height / 100) * (1f / ClientButtonFunctions.DresserSize.y), (length / 100) * (1f / ClientButtonFunctions.DresserSize.z));
            }
            else if (whichButtonClickedClient == "Nightstand_1")
            {
                Nightstand1x = width;
                Nightstand1y = height;
                Nightstand1z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Nightstand1.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.Nightstand1Size.x), (height / 100) * (1f / ClientButtonFunctions.Nightstand1Size.y), (length / 100) * (1f / ClientButtonFunctions.Nightstand1Size.z));
            }
            else if (whichButtonClickedClient == "Nightstand_2")
            {
                Nightstand2x = width;
                Nightstand2y = height;
                Nightstand2z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Nightstand2.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.Nightstand2Size.x), (height / 100) * (1f / ClientButtonFunctions.Nightstand2Size.y), (length / 100) * (1f / ClientButtonFunctions.Nightstand2Size.z));
            }
            else if (whichButtonClickedClient == "Nightstand_3")
            {
                Nightstand3x = width;
                Nightstand3y = height;
                Nightstand3z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Nightstand3.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.Nightstand3Size.x), (height / 100) * (1f / ClientButtonFunctions.Nightstand3Size.y), (length / 100) * (1f / ClientButtonFunctions.Nightstand3Size.z));
            }
            else if (whichButtonClickedClient == "Carpet")
            {
                Carpetx = width;
                Carpety = height;
                Carpetz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Carpet.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.CarpetSize.x), (height / 100) * (1f / ClientButtonFunctions.CarpetSize.y), (length / 100) * (1f / ClientButtonFunctions.CarpetSize.z));
            }
            else if (whichButtonClickedClient == "Rug")
            {
                Rugx = width;
                Rugy = height;
                Rugz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Rug.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.RugSize.x), (height / 100) * (1f / ClientButtonFunctions.RugSize.y), (length / 100) * (1f / ClientButtonFunctions.RugSize.z));
            }
            else if (whichButtonClickedClient == "Wall_Shelf")
            {
                WallShelfx = width;
                WallShelfy = height;
                WallShelfz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.WallShelf.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.WallShelfSize.x), (height / 100) * (1f / ClientButtonFunctions.WallShelfSize.y), (length / 100) * (1f / ClientButtonFunctions.WallShelfSize.z));
            }
            else if (whichButtonClickedClient == "Mirror")
            {
                Mirrorx = width;
                Mirrory = height;
                Mirrorz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Mirror.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.MirrorSize.x), (height / 100) * (1f / ClientButtonFunctions.MirrorSize.y), (length / 100) * (1f / ClientButtonFunctions.MirrorSize.z));
            }
            else if (whichButtonClickedClient == "Painting_3")
            {
                Painting3x = width;
                Painting3y = height;
                Painting3z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Painting3.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.Painting3Size.x), (height / 100) * (1f / ClientButtonFunctions.Painting3Size.y), (length / 100) * (1f / ClientButtonFunctions.Painting3Size.z));
            }
            else if (whichButtonClickedClient == "Plant")
            {
                Plantx = width;
                Planty = height;
                Plantz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Plant.transform.localScale = new Vector3((length / 100) * (50f / ClientButtonFunctions.PlantSize.x), (width / 100) * (50f / ClientButtonFunctions.PlantSize.z), (height / 100) * (50f / ClientButtonFunctions.PlantSize.y));
            }
            else if (whichButtonClickedClient == "Wine_Rack")
            {
                WineRackx = width;
                WineRacky = height;
                WineRackz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.WineRack.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.WineRackSize.x), (height / 100) * (1f / ClientButtonFunctions.WineRackSize.y), (length / 100) * (1f / ClientButtonFunctions.WineRackSize.z));
            }
            else if (whichButtonClickedClient == "Floor_Lamp_1")
            {
                FloorLamp1x = width;
                FloorLamp1y = height;
                FloorLamp1z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.FloorLamp1.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.FloorLamp1Size.x), (height / 100) * (1f / ClientButtonFunctions.FloorLamp1Size.y), (length / 100) * (1f / ClientButtonFunctions.FloorLamp1Size.z));
            }
            else if (whichButtonClickedClient == "Floor_Lamp_2")
            {
                FloorLamp2x = width;
                FloorLamp2y = height;
                FloorLamp2z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.FloorLamp2.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.FloorLamp2Size.x), (height / 100) * (1f / ClientButtonFunctions.FloorLamp2Size.y), (length / 100) * (1f / ClientButtonFunctions.FloorLamp2Size.z));
            }
            else if (whichButtonClickedClient == "Table_Lamp")
            {
                TableLampx = width;
                TableLampy = height;
                TableLampz = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.TableLamp.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.TableLampSize.x), (height / 100) * (1f / ClientButtonFunctions.TableLampSize.y), (length / 100) * (1f / ClientButtonFunctions.TableLampSize.z));
            }
            else if (whichButtonClickedClient == "Wall_Lamp_1")
            {
                WallLamp1x = width;
                WallLamp1y = height;
                WallLamp1z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.WallLamp1.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.WallLamp1Size.x), (height / 100) * (1f / ClientButtonFunctions.WallLamp1Size.y), (length / 100) * (1f / ClientButtonFunctions.WallLamp1Size.z));
            }
            else if (whichButtonClickedClient == "Wall_Lamp_2")
            {
                WallLamp2x = width;
                WallLamp2y = height;
                WallLamp2z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.WallLamp2.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.WallLamp2Size.x), (height / 100) * (1f / ClientButtonFunctions.WallLamp2Size.y), (length / 100) * (1f / ClientButtonFunctions.WallLamp2Size.z));
            }
            else if (whichButtonClickedClient == "D_Table_1")
            {
                DTable1x = width;
                DTable1y = height;
                DTable1z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.DTable1.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.DTable1Size.x), (height / 100) * (1f / ClientButtonFunctions.DTable1Size.y), (length / 100) * (1f / ClientButtonFunctions.DTable1Size.z));
            }
            else if (whichButtonClickedClient == "D_Table_2")
            {
                DTable2x = width;
                DTable2y = height;
                DTable2z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.DTable2.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.DTable2Size.x), (height / 100) * (1f / ClientButtonFunctions.DTable2Size.y), (length / 100) * (1f / ClientButtonFunctions.DTable2Size.z));
            }
            else if (whichButtonClickedClient == "Chair_1")
            {
                Chair1x = width;
                Chair1y = height;
                Chair1z = length;
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                clientMenuFunctions.Chair1.transform.localScale = new Vector3((width / 100) * (1f / ClientButtonFunctions.Chair1Size.x), (height / 100) * (1f / ClientButtonFunctions.Chair1Size.y), (length / 100) * (1f / ClientButtonFunctions.Chair1Size.z));
            }

            GameObject sizeMenu = GameObject.Find("SizeMenu");
            //sizeMenu.SetActive(false);
            //sizeMenu.transform.position = new Vector3(0f, 50f, -2.6759e-05f);
            this.transform.position = new Vector3(3960f, 3540f, 3000f);
            cleanInputField();
        }
        else
        {
            sizeMenuPopUp.SetActive(true);
        }
        cleanInputField();
    }
    public void cleanInputField()
    {
        lengthInputField.text = "";
        widthInputField.text = "";
        heightInputField.text = "";
    }
    public void cancelOrExitButtonClicked()
    {
        GameObject sizeMenu = GameObject.Find("SizeMenu");
        this.transform.position = new Vector3(3960f, 3540f, 3000f);
        cleanInputField();
    }

    public void sizeMenuOpenFunction()
    {
        GameObject sizeMenu = GameObject.Find("SizeMenu");
        this.transform.position = new Vector3(960f, 590f, -2.6759e-05f);
    }

    // Update is called once per frame
    void Update()
    {
        whichButtonClicked = ItemMenuButtonFunctions.clickedButtonName;
        whichButtonClickedClient = ClientButtonFunctions.clickedButtonName;
        Debug.Log(CabinetBase1x + " " + CabinetBase1y + CabinetBase1z + "size cabinetbase1");
        

    }
}
