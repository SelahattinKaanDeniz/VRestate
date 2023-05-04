using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using UnityEngine.Networking;
using System.Text.RegularExpressions;

public class LoadModel : MonoBehaviour
{
    List<GameObject> item_list;
    public GameObject CabinetBase1;

    public GameObject CabinetBase2;

    public GameObject CabinetBaseCorner;

    public GameObject CabinetBaseSink;

    public GameObject CabinetTall;

    public GameObject CabinetWall1;

    public GameObject CabinetWall2;

    public GameObject Stove;


    //Construction
    public GameObject Floor;



    public GameObject Wall;

    public GameObject Door1;
    //public static Vector3 Door1Size;
    public GameObject Door2;
    //public static Vector3 Door2Size;
    public GameObject Window;
    public GameObject Frame;

    public GameObject Rail;

    // Dynamic Wall Creation

    public GameObject CubeWall;

    //Bathroom
    public GameObject Bathtub;

    public GameObject Shower;


    public GameObject Toilet;

    public GameObject Vanity1;


    public GameObject Cube;
    public GameObject Capsule;

    // Start is called before the first frame update
    void Start()
    {
         item_list = new List<GameObject>();
        
        item_list.Add(CubeWall);
        item_list.Add(Floor);
        item_list.Add(CabinetBase1);
        item_list.Add(CabinetBase2);
        item_list.Add(CabinetBaseCorner);
        item_list.Add(CabinetBaseSink);
        item_list.Add(CabinetTall);
        item_list.Add(CabinetWall1);
        item_list.Add(CabinetWall2);
        item_list.Add(Stove);
        item_list.Add(Wall);
        item_list.Add(Door1);
        item_list.Add(Door2);
        item_list.Add(Window);
        item_list.Add(Frame);
        item_list.Add(Rail);
        item_list.Add(Bathtub);
        item_list.Add(Shower);
        item_list.Add(Toilet);
        item_list.Add(Vanity1);

       

      
        readFromJson("Assets/Resources/test.txt");
          

      
        
        //item_list.Add(Cube);
        //item_list.Add(Capsule);

    }

    public void readFromJson(string path)
    {
        /*StreamReader reader = new StreamReader(path);

        // List<ItemData> ret = new List<ItemData>();

        string json = reader.ReadToEnd();
        json = json
            .TrimEnd(new Char[] { '}', ']' })
            .TrimStart(new Char[] { '{', '[' });

        string[] tokens = json.Split("},{");

        ItemData item;
        foreach (string token in tokens)
        {
            if (!String.Equals(token, ""))
            {
                Debug.Log(token + " token");
                item = JsonUtility.FromJson<ItemData>("{" + token + "}");
                //ret.Add(item);
                foreach (GameObject s in item_list)
                {
                    if(s.name+"(Clone)" == item.id)
                    {
                        GameObject obj;
                        obj =Instantiate(s, new Vector3(float.Parse(item.pos_x), float.Parse(item.pos_y), float.Parse(item.pos_z)), new Quaternion(float.Parse(item.rotation_x), float.Parse(item.rotation_y), float.Parse(item.rotation_z), float.Parse(item.rotation_w)));
                        obj.transform.localScale = new Vector3(float.Parse(item.scale_x), float.Parse(item.scale_y), float.Parse(item.scale_z));
                        obj.AddComponent<BoxCollider>();
                        obj.GetComponent<BoxCollider>().size = obj.GetComponent<BoxCollider>().size - new Vector3(0.1f, 0.1f, 0.1f);
                        obj.GetComponent<BoxCollider>().isTrigger = true;
                        obj.AddComponent<Rigidbody>();
                        obj.GetComponent<Rigidbody>().isKinematic = true;
                        obj.tag = "Untagged";
                    }
                }
                //Instantiate(DishWasher, new Vector3(4f, 2f, -18f), Quaternion.Euler(new Vector3(-90, 90, 0)));
            }
        }

        reader.Close();*/

        //////////////////////////  HTTP REQUESTLÝ LOAD
        
        StartCoroutine(readFromJson_Coroutine());


    }
  
    public IEnumerator readFromJson_Coroutine()
    {
        string json = "";

        // string url = "http://10.3.192.113:5000/data";
        string postID = MainMenu.modelId;
        Debug.Log("postid " + postID);
        string url = "http://vrestate.tech:5002/unity/load?id=" + postID;
        Debug.Log(url);
        using (UnityWebRequest request = UnityWebRequest.Get(url)){
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
        json = json
            .TrimEnd(new Char[] { '}', ']' })
            .TrimStart(new Char[] { '{', '[' });

        string[] tokens = json.Split("},{");

        ItemData item;
        foreach (string token in tokens)
        {
            if (!String.Equals(token, "") && !String.Equals(token, "null"))
            {
                Debug.Log(token + " token");
                item = JsonUtility.FromJson<ItemData>("{" + token + "}");
                //ret.Add(item);
                foreach (GameObject s in item_list)
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
                        Scene m_Scene = SceneManager.GetActiveScene();
                        Debug.Log(m_Scene.name);
                        if(m_Scene.name == "MainScene")
                        {
                            obj.tag = "3DModel";
                        }
                        else
                        {
                            obj.tag = "Untagged";
                        }
                        
                    }
                }
                //Instantiate(DishWasher, new Vector3(4f, 2f, -18f), Quaternion.Euler(new Vector3(-90, 90, 0)));
            }
        }

        //reader.Close();
    }
}
