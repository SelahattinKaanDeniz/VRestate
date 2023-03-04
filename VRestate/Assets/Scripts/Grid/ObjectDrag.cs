using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDrag : MonoBehaviour
{
    private Vector3 offset;
    private Vector3[] Vertices;
 
    /*private void OnMouseDown()
    {
        offset = transform.position - BuildingSystem.GetMouseWorldPosition();

    }*/

    /*private void OnMouseDrag()
    {
        //Vector3 pos = BuildingSystem.GetMouseWorldPosition() - offset - new Vector3(0.25f,0f,0.25f);
        
        


        Vector3 pos = BuildingSystem.GetMouseWorldPosition() - offset;
        
        BoxCollider b = gameObject.GetComponent<BoxCollider>();
       
        Vector3 a = BuildingSystem.current.SnapCoordinateToGrid(pos);
        Debug.Log(b.size.x + " " + b.size.z + " SIZEEEE");
        Vector3 objectposition = new Vector3(a.x + BuildingSystem.posx / 200, a.y, a.z + BuildingSystem.posz / 200);
        transform.position =objectposition;
    }*/
}
