using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        // SceneManager.LoadScene(1);
        StartCoroutine(DelaySceneLoad());
    }
    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(0.26f);
        SceneManager.LoadScene(1);
    }

    IEnumerator DelaySceneQuit()
    {
        yield return new WaitForSeconds(0.26f);
        Application.Quit();
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        //Application.Quit();
        StartCoroutine(DelaySceneQuit());
    }


}
