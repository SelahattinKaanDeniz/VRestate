using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VRUIButtonFunctions : MonoBehaviour
{
    //public GameObject InfoPanel;
    //public GameObject ImagePanel;
    //public GameObject MapPanel;

    public TMP_Text EstateTypeText;
    public TMP_Text CategoryText;
    public TMP_Text PriceText;
    public TMP_Text CreateDateText;
    public TMP_Text LastUpdateText;
    public TMP_Text TitleText;
    public TMP_Text LocationIlceText;
    public TMP_Text LocationIlText;
    public TMP_Text RoomTypeText;
    public TMP_Text M2Text;

    public RawImage Map;

    public RawImage EstatePhoto;
    void Start()
    {
        StartCoroutine(readFromJson_Coroutine());
        StartCoroutine(DownloadImageMap());
        StartCoroutine(DownloadImageEstatePhoto());
    }

    /*public void InfoNextButtonClicked()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        InfoPanel.SetActive(false);
        ImagePanel.SetActive(true);
    }

    public void ImageBackButtonClicked()
    {
        ImagePanel.SetActive(false);
        InfoPanel.SetActive(true);
    }
    public void ImageNextButtonClicked()
    {
        ImagePanel.SetActive(false);
        MapPanel.SetActive(true);
    }

    public void MapBackButtonClicked()
    {
        MapPanel.SetActive(false);
        ImagePanel.SetActive(true);
    }*/


    public IEnumerator readFromJson_Coroutine()
    {
        string json = "";
        string url = "http://vrestate.tech:5002/estate/getEstates?detail=true";
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
                json = request.downloadHandler.text;
            }
        }

        // List<ItemData> ret = new List<ItemData>();
        //json = json.Replace(" ", "");
        
        json = Regex.Replace(json, @"\s+", String.Empty);
        json = json.Substring(json.IndexOf("["));
        json = json.Substring(0,json.Length - 1);
        json = json
            .TrimEnd(new Char[] { '}', ']' })
            .TrimStart(new Char[] { '{', '[' });

        string[] tokens = json.Split("},{");

        AdData ad;
        foreach (string token in tokens)
        {
            if (!String.Equals(token, ""))
            {
                Debug.Log(token + " token");
                ad = JsonUtility.FromJson<AdData>("{" + token + "}");
                //ret.Add(item);
                Debug.Log(ad.id);
                Debug.Log(ad.title);
                Debug.Log(ad.estate_type);

                EstateTypeText.text = "Ýlan Durumu: " + ad.estate_type;
                CategoryText.text = "Konut Þekli: " + ad.category;
                PriceText.text = "Fiyat: " + ad.price;
                //CreateDateText.text = "Oluþturma Tarihi: " + ad.create_date;
                //LastUpdateText.text = "Güncelleme Tarihi: " + ad.last_update;
                TitleText.text = ad.title;
                LocationIlceText.text = "Ýlçe: " + ad.location_ilce;
                LocationIlText.text = "Ýl: " + ad.location_il;
                RoomTypeText.text = "Oda Sayýsý: " + ad.room_type;
                M2Text.text = "Net M2: " + ad.m2;




                /*foreach (GameObject s in item_list)
                {
                    if (s.name + "(Clone)" == item.id)
                    {
                        GameObject obj;
                        obj = Instantiate(s, new Vector3(float.Parse(item.pos_x), float.Parse(item.pos_y), float.Parse(item.pos_z)), new Quaternion(float.Parse(item.rotation_x), float.Parse(item.rotation_y), float.Parse(item.rotation_z), float.Parse(item.rotation_w)));
                        obj.transform.localScale = new Vector3(float.Parse(item.scale_x), float.Parse(item.scale_y), float.Parse(item.scale_z));
                        obj.AddComponent<BoxCollider>();
                        obj.GetComponent<BoxCollider>().size = obj.GetComponent<BoxCollider>().size - new Vector3(0.1f, 0.1f, 0.1f);
                        obj.GetComponent<BoxCollider>().isTrigger = true;
                        obj.AddComponent<Rigidbody>();
                        obj.GetComponent<Rigidbody>().isKinematic = true;
                        obj.tag = "Untagged";
                    }
                }*/
                //Instantiate(DishWasher, new Vector3(4f, 2f, -18f), Quaternion.Euler(new Vector3(-90, 90, 0)));
            }
        }



        //reader.Close();
    }

    IEnumerator DownloadImageMap()
    {
        string MediaUrl = "https://maps.googleapis.com/maps/api/staticmap?center=golbasi&zoom=15&size=800x450&key=AIzaSyDqLkJ5k5jCTiyg85lrGEs9vo0FMgJlKik";
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            Map.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }

    IEnumerator DownloadImageEstatePhoto()
    {
        string MediaUrl = "http://vrestate.tech:5002/getImage?id=19";
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            EstatePhoto.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}
