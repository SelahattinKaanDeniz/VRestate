using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{


    // Update is called once per frame
    private void Awake()
    {
        GameObject[] effectObj = GameObject.FindGameObjectsWithTag("ButtonClickSound");
        if (effectObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
