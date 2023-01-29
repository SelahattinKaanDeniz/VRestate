using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenuButtonFunctions : MonoBehaviour
{
    public GameObject BathroomMenuPanel;
    public GameObject KitchenMenuPanel;
    public GameObject ConstructionMenuPanel;
    public GameObject ItemMenuPanel;

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
}
