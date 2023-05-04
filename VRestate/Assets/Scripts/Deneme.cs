using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject camera;

   public void debug()
    {
        Debug.Log(camera.transform.position + " webxr camera pos");
    }
}
