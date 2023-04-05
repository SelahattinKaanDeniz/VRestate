using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  
using System.IO;
using System;
using UnityEngine.Networking;

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
        StreamWriter writer = new StreamWriter("Assets/Resources/test.txt", false);
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


        ////////////////// HTTP REQUESTLÝ SAVE
        
        //StartCoroutine(writeToJson_Coroutine());

    }

    public IEnumerator writeToJson_Coroutine()
    {
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
        string json = "[";
        //writer.Write("[");

        int count = item_list.Count, i = 0;
        foreach (string s in item_list)
        {
            if (i == count - 1)
            {
                //writer.Write(s);
                json += s;

            }
            else
            {
                //writer.Write(s + ",");
                json += s + ",";

            }
            i++;
        }

        //writer.Write("]");
        json += "]";
        //writer.Close();
        string postID = MainMenu.modelId;
        //var req = new UnityWebRequest($"http://localhost:5002/unity/save?id={postID}", "POST");
        var req = new UnityWebRequest("http://10.3.192.113:5000/data", "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        req.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        req.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        req.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return req.SendWebRequest();

        if (req.isNetworkError)
        {
            Debug.Log("Error While Sending: " + req.error);
        }
        else
        {
            Debug.Log("Received: " + req.downloadHandler.text);
        }
    }
           
}
