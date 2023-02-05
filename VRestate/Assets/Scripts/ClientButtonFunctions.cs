using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //Ana kategoriden Bathroom butonuna t�kland���nda
    public void BathroomButtonClicked()
    {

        BathroomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(1500f, 127f);
    }

    //Bathroom alt kategoriden Back butonuna t�kland���nda
    public void BathroomBackButtonClicked()
    {

        BathroomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(1500f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Kitchen butonuna t�kland���nda
    public void KitchenButtonClicked()
    {

        KitchenMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(3660f, 127f);
    }

    //Kitchen alt kategoriden Back butonuna t�kland���nda
    public void KitchenBackButtonClicked()
    {

        KitchenMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(3660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Living Room butonuna t�kland���nda
    public void LivingRoomButtonClicked()
    {

        LivingRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-2820f, 127f);
    }
    //Living Room alt kategoriden Back butonuna t�kland���nda
    public void LivingRoomBackButtonClicked()
    {

        LivingRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-2820f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Study Room butonuna t�kland���nda
    public void StudyRoomButtonClicked()
    {

        StudyRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-4980f, 127f);
    }
    //Study Room alt kategoriden Back butonuna t�kland���nda
    public void StudyRoomBackButtonClicked()
    {

        StudyRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-4980f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Bedroom butonuna t�kland���nda
    public void BedRoomButtonClicked()
    {

        BedRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-7140f, 127f);
    }
    //Bedroom alt kategoriden Back butonuna t�kland���nda
    public void BedRoomBackButtonClicked()
    {

        BedRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-7140f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Decoration butonuna t�kland���nda
    public void DecorationButtonClicked()
    {

        DecorationMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-9300f, 127f);
    }
    //Decoration alt kategoriden Back butonuna t�kland���nda
    public void DecorationBackButtonClicked()
    {

        DecorationMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-9300f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Lamp butonuna t�kland���nda
    public void LampButtonClicked()
    {

        LampMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-11460f, 127f);
    }
    //Lamp alt kategoriden Back butonuna t�kland���nda
    public void LampBackButtonClicked()
    {

        LampMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-11460f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Dining Room butonuna t�kland���nda
    public void DiningRoomButtonClicked()
    {

        DiningRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-13620f, 127f);
    }
    //Dining Room alt kategoriden Back butonuna t�kland���nda
    public void DiningRoomBackButtonClicked()
    {

        DiningRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-13620f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }








}
