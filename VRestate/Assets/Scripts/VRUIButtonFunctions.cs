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

    public TMP_Text NameText;
    public TMP_Text MailText;
    public TMP_Text IBANText;
    public TMP_Text TelefonText;
    public TMP_Text LocationText;
   
    string[] tokens;

    public RawImage Map;

    public RawImage EstatePhoto;
   
    void Start()
    {
        
        StartCoroutine(readFromJson_Coroutine());
       
        //StartCoroutine(DownloadImageEstatePhoto());
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
        string postID = MainMenu.modelId;
        Debug.Log("postid " + postID);

        string url = "http://vrestate.tech:5002/unity/estateDetails?modelId=" + postID;
        //string url = "http://vrestate.tech:5002/unity/estateDetails?modelId=893263"; 
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
        int titleIndex = json.IndexOf("\"title\":\"") + 9;
        int nextQuote = json.Substring(titleIndex).IndexOf("\"");
        Debug.Log(json.Substring(titleIndex, nextQuote) + " titlewithspace");
        string titlewithspace = json.Substring(titleIndex, nextQuote);
        if(titlewithspace.Length > 82)
        {
            titlewithspace = titlewithspace.Substring(0, 79);
            titlewithspace +=  "...";
        }


        json = Regex.Replace(json, @"\s+", String.Empty);
        //json = json.Substring(json.IndexOf("["));
        //json = json.Substring(0,json.Length - 1);
        json = json
            .TrimEnd(new Char[] { '}' })
            .TrimStart(new Char[] { '{'});

        tokens = json.Split("},{");

        AdData ad;
        foreach (string token in tokens)
        {
            if (!String.Equals(token, ""))
            {
                Debug.Log(token + " token");

                //
                
                //

                ad = JsonUtility.FromJson<AdData>("{" + token + "}");
                //ret.Add(item);
                //Debug.Log(ad.id);
                //Debug.Log(ad.title);
                //Debug.Log(ad.estate_type);


                if(ad.type == "HepsiEmlak")
                {
                    EstateTypeText.text = "Ýlan Tipi: " + ad.estate_type;
                    CategoryText.text = "Konut Þekli: " + ad.category;
                    PriceText.text = "Fiyat: " + ad.price + " TL";
                    //CreateDateText.text = "Oluþturma Tarihi: " + ad.create_date;
                    //LastUpdateText.text = "Güncelleme Tarihi: " + ad.last_update;
                    TitleText.text = titlewithspace;
                    LocationIlceText.text = "Ýlçe: " + ad.location_ilce;
                    LocationIlText.text = "Ýl: " + ad.location_il;
                    RoomTypeText.text = "Oda Sayýsý: " + ad.room_type;
                    M2Text.text = "Net m2: " + ad.m2;
                    StartCoroutine(DownloadImageEstatePhotoHepsiEmlak(ad.head_photo_url));
                }
                else if (ad.type == "VRestate")
                {
                    EstateTypeText.text = "Ýlan Tipi: " + ad.estate_type;
                    CategoryText.text = "Konut Þekli: " + ad.category;
                    PriceText.text = "Fiyat: " + ad.price + " TL";
                    //CreateDateText.text = "Oluþturma Tarihi: " + ad.create_date;
                    //LastUpdateText.text = "Güncelleme Tarihi: " + ad.last_update;
                    TitleText.text = titlewithspace;
                    LocationIlceText.text = "Ýlçe: " + ad.location_ilce;
                    LocationIlText.text = "Ýl: " + ad.location_il;
                    RoomTypeText.text = "Oda Sayýsý: " + ad.room_type;
                    M2Text.text = "Net m2: " + ad.m2;
                    StartCoroutine(DownloadImageEstatePhoto(ad.head_photo_id));
                    StartCoroutine(getUserDetails_Coroutine(ad.owner_id));
                }

                




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
       

        StartCoroutine(DownloadImageMap());
        //reader.Close();
    }

    public IEnumerator getUserDetails_Coroutine(string owner_id)
    {
        string json = "";
      
        //string url = "http://vrestate.tech:5002/unity/userDetails?ownerId=116244235846840353991";
        string url = "http://vrestate.tech:5002/unity/userDetails?ownerId=" + owner_id;

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
        //json = json.Substring(json.IndexOf("["));
        //json = json.Substring(0,json.Length - 1);
        json = json
            .TrimEnd(new Char[] { '}' })
            .TrimStart(new Char[] { '{' });

        tokens = json.Split("},{");

        AdData ad;
        foreach (string token in tokens)
        {
            if (!String.Equals(token, ""))
            {
                Debug.Log(token + " token");
                ad = JsonUtility.FromJson<AdData>("{" + token + "}");
                Debug.Log(ad.name  + " ad");
                //ret.Add(item);
                //Debug.Log(ad.id);
                //Debug.Log(ad.title);
                //Debug.Log(ad.estate_type);



                    NameText.text = "Ad Soyad: " + ad.name + " "+ ad.surname;
                    MailText.text = "Mail: " + ad.mail;
                    IBANText.text = "IBAN: " + ad.paymentInfo;                   
                    TelefonText.text ="Cep Telefonu: " + ad.phone;
                    LocationText.text = "Konum: " + ad.currentLocation;
           



            }
        }


        
        //reader.Close();
    }

    IEnumerator DownloadImageMap()
    {
        AdData ad  = JsonUtility.FromJson<AdData>("{" + tokens[0] + "}");
        string MediaUrl = null;
        Debug.Log(ad.coordX + " COORDX");
        if (ad.coordX != "" && ad.coordY != "")
        {
            Debug.Log("coord var");
            MediaUrl = "https://maps.googleapis.com/maps/api/staticmap?center="+ad.coordX+","+ ad.coordY+ "&zoom=15&size=800x450&key=AIzaSyDqLkJ5k5jCTiyg85lrGEs9vo0FMgJlKik";
        }
        else if(ad.location_ilce != "")
        {
            Debug.Log("coord yok");
            MediaUrl = "https://maps.googleapis.com/maps/api/staticmap?center=" + ad.location_ilce+ "&zoom=15&size=800x450&key=AIzaSyDqLkJ5k5jCTiyg85lrGEs9vo0FMgJlKik";
        }
         //MediaUrl = "https://maps.googleapis.com/maps/api/staticmap?center=golbasi&zoom=15&size=800x450&key=AIzaSyDqLkJ5k5jCTiyg85lrGEs9vo0FMgJlKik";

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            Map.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }

    IEnumerator DownloadImageEstatePhoto(string parameter)
    {
        string MediaUrl = "http://vrestate.tech:5002/getImage?id="+ parameter;
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            EstatePhoto.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }

    IEnumerator DownloadImageEstatePhotoHepsiEmlak(string url)
    {
        
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
            EstatePhoto.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}
