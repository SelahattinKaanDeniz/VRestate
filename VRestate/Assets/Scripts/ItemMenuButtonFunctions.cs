using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenuButtonFunctions : MonoBehaviour
{
    public GameObject BathroomMenuPanel;
    public GameObject ItemMenuPanel;
    public void BathroomButtonClicked()
    {
        
        BathroomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
        
        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(1500f, 127f);
    }

    public void BathroomBackButtonClicked()
    {
       
        BathroomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(1500f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }
}
