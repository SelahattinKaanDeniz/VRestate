using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SizeMenuFunctions : MonoBehaviour
{
    
    private ItemMenuButtonFunctions itemMenuFunctions;

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
        float length; // X
        float.TryParse(lengthInputField.text, out float lengthresult);
        length = lengthresult;

        float width; // Z
        float.TryParse(widthInputField.text, out float widthresult);
        width = widthresult;

        float height; // Y
        float.TryParse(heightInputField.text, out float heightresult);
        height = heightresult;


        if (length > 0 && width >0 && height > 0)
        {
            if(whichButtonClicked == "Cabinet_Base_1")
            {
                itemMenuFunctions.CabinetBase1.transform.localScale = new Vector3(length/100,height/100, width/100);
            }
            else if (whichButtonClicked == "Cabinet_Base_2")
            {
                itemMenuFunctions.CabinetBase2.transform.localScale = new Vector3(length / 100, height / 100, width / 100);
            }
        }
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
