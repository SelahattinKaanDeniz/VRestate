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

    public GameObject ItemMenuPanel;

    //Ana kategoriden Bathroom butonuna tıklandığında
    public void BathroomButtonClicked()
    {

        BathroomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(1500f, 127f);
    }

    //Bathroom alt kategoriden Back butonuna tıklandığında
    public void BathroomBackButtonClicked()
    {

        BathroomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(1500f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Kitchen butonuna tıklandığında
    public void KitchenButtonClicked()
    {

        KitchenMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(3660f, 127f);
    }

    //Kitchen alt kategoriden Back butonuna tıklandığında
    public void KitchenBackButtonClicked()
    {

        KitchenMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(3660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Living Room butonuna tıklandığında
    public void LivingRoomButtonClicked()
    {

        LivingRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-2820f, 127f);
    }
    //Living Room alt kategoriden Back butonuna tıklandığında
    public void LivingRoomBackButtonClicked()
    {

        LivingRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-2820f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Study Room butonuna tıklandığında
    public void StudyRoomButtonClicked()
    {

        StudyRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-4980f, 127f);
    }
    //Study Room alt kategoriden Back butonuna tıklandığında
    public void StudyRoomBackButtonClicked()
    {

        StudyRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-4980f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Bedroom butonuna tıklandığında
    public void BedRoomButtonClicked()
    {

        BedRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-7140f, 127f);
    }
    //Bedroom alt kategoriden Back butonuna tıklandığında
    public void BedRoomBackButtonClicked()
    {

        BedRoomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-7140f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Decoration butonuna tıklandığında
    public void DecorationButtonClicked()
    {

        DecorationMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-9300f, 127f);
    }
    //Decoration alt kategoriden Back butonuna tıklandığında
    public void DecorationBackButtonClicked()
    {

        DecorationMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-9300f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Ana kategoriden Lamp butonuna tıklandığında
    public void LampButtonClicked()
    {

        LampMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-11460f, 127f);
    }
    //Lamp alt kategoriden Back butonuna tıklandığında
    public void LampBackButtonClicked()
    {

        LampMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-11460f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }








}
