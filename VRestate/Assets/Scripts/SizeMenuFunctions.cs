using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SizeMenuFunctions : MonoBehaviour
{
    
    private ItemMenuButtonFunctions itemMenuFunctions;
    public GameObject sizeMenuPopUp;
    private string whichButtonClicked;
    public TMP_InputField lengthInputField;
    public TMP_InputField widthInputField;
    public TMP_InputField heightInputField;
    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("Canvas");
        itemMenuFunctions = canvas.GetComponent<ItemMenuButtonFunctions>();
        

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
                //itemMenuFunctions.CabinetBase1.transform.localScale = new Vector3(length / 100, height / 100, width / 100);
                itemMenuFunctions.CabinetBase1.transform.localScale = new Vector3((width/100)*(1f/ ItemMenuButtonFunctions.CabinetBase1Size.x), (height/100) * (1f / ItemMenuButtonFunctions.CabinetBase1Size.y), ( length/100) * (1f / ItemMenuButtonFunctions.CabinetBase1Size.z));
            }
            else if (whichButtonClicked == "Cabinet_Base_2")
            {
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.CabinetBase2Size.x), (height / 100) * (1f / ItemMenuButtonFunctions.CabinetBase2Size.y), (length / 100) * (1f / ItemMenuButtonFunctions.CabinetBase2Size.z));
            }
            else if (whichButtonClicked == "Cabinet_Base_Corner")
            {
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.CabinetBaseCorner.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.CabinetBaseCornerSize.x), (height / 100) * (1f / ItemMenuButtonFunctions.CabinetBaseCornerSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.CabinetBaseCornerSize.z));
            }
            else if (whichButtonClicked == "Cabinet_Base_Sink")
            {
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.CabinetBaseSink.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.CabinetBaseSinkSize.x), (height / 100) * (1f / ItemMenuButtonFunctions.CabinetBaseSinkSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.CabinetBaseSinkSize.z));
            }
            else if (whichButtonClicked == "Cabinet_Tall")
            {
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.CabinetTall.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.CabinetTallSize.x), (height / 100) * (1f / ItemMenuButtonFunctions.CabinetTallSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.CabinetTallSize.z));
            }
            else if (whichButtonClicked == "Cabinet_Wall_1")
            {
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.CabinetWall1.transform.localScale = new Vector3((50f / 100f) * (1f / ItemMenuButtonFunctions.CabinetWall1Size.x), (height / 100) * (1f / ItemMenuButtonFunctions.CabinetWall1Size.y), (length / 100) * (1f / ItemMenuButtonFunctions.CabinetWall1Size.z));
            }
            else if (whichButtonClicked == "Cabinet_Wall_2")
            {
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
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.Stove.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.StoveSize.x), (height / 100) * (1f / ItemMenuButtonFunctions.StoveSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.StoveSize.z));
            }
            else if (whichButtonClicked == "Bathtub")
            {
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.Bathtub.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.BathtubSize.x), (height / 100) * (1f / ItemMenuButtonFunctions.BathtubSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.BathtubSize.z));
            }
            else if (whichButtonClicked == "Shower")
            {
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.Shower.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.ShowerSize.x), (height / 100) * (1f / ItemMenuButtonFunctions.ShowerSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.ShowerSize.z));
            }
            
            else if (whichButtonClicked == "Toilet")
            {
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.Toilet.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.ToiletSize.x), (height / 100) * (1f / ItemMenuButtonFunctions.ToiletSize.y), (length / 100) * (1f / ItemMenuButtonFunctions.ToiletSize.z));
            }
            else if (whichButtonClicked == "Vanity_1")
            {
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.Vanity1.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.Vanity1Size.x), (height / 100) * (1f / ItemMenuButtonFunctions.Vanity1Size.y), (length / 100) * (1f / ItemMenuButtonFunctions.Vanity1Size.z));
            }
            else if (whichButtonClicked == "Vanity_3")
            {
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                itemMenuFunctions.Vanity3.transform.localScale = new Vector3((width / 100) * (100f / ItemMenuButtonFunctions.Vanity3Size.x), (height / 100) * (100f / ItemMenuButtonFunctions.Vanity3Size.z), (length / 100) * (100f / ItemMenuButtonFunctions.Vanity3Size.y));
            }
            else if (whichButtonClicked == "Floor")
            {
                //itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);  //1.315
                //itemMenuFunctions.Floor.transform.localScale = new Vector3((width / 100) * (1f / ItemMenuButtonFunctions.FloorSize.x), 1f, (length / 100) * (1f / ItemMenuButtonFunctions.FloorSize.z));
                itemMenuFunctions.Floor.transform.localScale = new Vector3(0.2f, 0.1f, 0.2f);
            }
            GameObject sizeMenu = GameObject.Find("SizeMenu");
            sizeMenu.SetActive(false);
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
    // Update is called once per frame
    void Update()
    {
        whichButtonClicked = ItemMenuButtonFunctions.clickedButtonName;
        

    }
}
