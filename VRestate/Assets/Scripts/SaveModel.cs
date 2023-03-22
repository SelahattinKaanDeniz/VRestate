using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
using System.IO;
using System;

public class SaveModel : MonoBehaviour
{
    List<string> item_list;
    ItemData single_item;
    Scene scene;
    // Start is called before the first frame update
    public void Start()
    {
       scene = SceneManager.GetActiveScene();
        
       

         item_list = new List<string>();

        
        
        //writeToJson(item_list, "Assets/Resources/test.txt");
        //List<ItemData> items = readFromJson("Assets/Resources/test.txt");
    
        /*foreach (ItemData d in items) {
            // instantiate here
            Debug.Log(">>" + d.id + " " + d.pos_x + "<<");
        }*/
    }

    public void writeToJson() {
        StreamWriter writer = new StreamWriter("Assets/Resources/test.txt", true);
        foreach (GameObject child in scene.GetRootGameObjects())
        {

            Debug.Log(child.name + " --- " + child.tag);

            if (child.activeInHierarchy && String.Equals(child.tag, "3DModel"))
            {
                single_item = new ItemData(
                    child.name,
                    string.Format("{0:N5}", child.transform.position.x),
                    string.Format("{0:N5}", child.transform.position.y),
                    string.Format("{0:N5}", child.transform.position.z),
                    string.Format("{0:N5}", child.transform.rotation.w),
                    string.Format("{0:N5}", child.transform.rotation.x),
                    string.Format("{0:N5}", child.transform.rotation.y),
                    string.Format("{0:N5}", child.transform.rotation.z),
                    string.Format("{0:N5}", child.transform.localScale.x),
                    string.Format("{0:N5}", child.transform.localScale.y),
                    string.Format("{0:N5}", child.transform.localScale.z)
                );

                item_list.Add(JsonUtility.ToJson(single_item, false));
            }

        }
        writer.Write("[");

        int count = item_list.Count, i = 0;
        foreach (string s in item_list) {
            if (i == count - 1) {
                writer.Write(s);
            } else {
                writer.Write(s + ",");
            }
            i++;
        }

        writer.Write("]");
        writer.Close();
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
                item = JsonUtility.FromJson<ItemData>("{" + token + "}");
                //ret.Add(item);
                //Instantiate(DishWasher, new Vector3(4f, 2f, -18f), Quaternion.Euler(new Vector3(-90, 90, 0)));
            }
        }

        reader.Close();

    }
    
}
