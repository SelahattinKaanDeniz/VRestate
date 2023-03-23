using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

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

    public GameObject Vanity3;

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
        readFromJson("Assets/Resources/test.txt");
        //item_list.Add(Cube);
        //item_list.Add(Capsule);

    }

    public void readFromJson(string path)
    {
        StreamReader reader = new StreamReader(path);

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

        reader.Close();


    }
}