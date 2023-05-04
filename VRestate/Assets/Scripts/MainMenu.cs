using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Web;


public class MainMenu : MonoBehaviour
{
    public static string userId;
    public static string type;
    public static string modelId;







    public void StartGame()
    {
        //Debug.Log(Application.absoluteURL);
        //string q = "http://127.0.0.1:5500/?modelId=1&userId=123891284912&type=client";
         
        /////
        
        string q = Application.absoluteURL;
        q = q.Substring(q.IndexOf("?"));
        Debug.Log(q);
        
        //////
        

        //string q = "?modelId=1&userId=123891284912&type=client";
        //string q = "?modelId=893263&userId=123891284912&type=client";

        var query = HttpUtility.ParseQueryString(q);

        //var query = HttpUtility.ParseQueryString(Application.absoluteURL);       
        userId = query["userId"];
        type = query["type"];
        modelId = query["modelId"];
        Debug.Log("modelId " + modelId);
        Debug.Log("userId " + userId);
        Debug.Log("type " + type);
        if(type== "client")
        {
            StartCoroutine(DelaySceneLoadClient());
        }
        else if (type == "seller")
        {
            StartCoroutine(DelaySceneLoadSeller());
        }

        // SceneManager.LoadScene(1);

        //StartCoroutine(DelaySceneLoadSeller());
        //StartCoroutine(DelaySceneLoadClient());
        
    }
    IEnumerator DelaySceneLoadSeller()
    {
        yield return new WaitForSeconds(0.01f);
        SceneManager.LoadScene(1);

    }

    IEnumerator DelaySceneLoadClient()
    {
        yield return new WaitForSeconds(0.01f);
        SceneManager.LoadScene(2);

    }

    IEnumerator DelaySceneQuit()
    {
        yield return new WaitForSeconds(0.01f);
        Application.Quit();
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        //Application.Quit();
        StartCoroutine(DelaySceneQuit());
    }


}
