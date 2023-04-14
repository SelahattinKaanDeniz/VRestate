using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class SaveModeltoVR : MonoBehaviour
{
    public static List<string> item_list;
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
    

    public void writeToJson()
    {
        //StreamWriter writer = new StreamWriter("Assets/Resources/test1.txt", false);
        foreach (GameObject child in scene.GetRootGameObjects())
        {

            Debug.Log(child.name + " --- " + child.tag);

            //if (child.activeInHierarchy && String.(child.tag, "3DModel"))
            if (child.activeInHierarchy && child.name.Contains("(Clone)"))
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
        for(int i = 0;i < item_list.Count; i++)
        {
            //Debug.Log(item_list[i]);
        }
        /*writer.Write("[");

        int count = item_list.Count, i = 0;
        foreach (string s in item_list)
        {
            if (i == count - 1)
            {
                writer.Write(s);
            }
            else
            {
                writer.Write(s + ",");
            }
            i++;
        }

        writer.Write("]");
        writer.Close();*/
        StartCoroutine(DelaySceneLoad());

    }
    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(0.26f);
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene(3);

    }


    

}