using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public bool Placed { get; private set; }
    public Vector3Int Size { get; private set; }
    private Vector3[] Vertices;
    public bool isColliding = false;
    private List<GameObject> CollidingObjects = new List<GameObject>();

    private void GetColliderVertexPositionsLocal()
    {
        BoxCollider b = gameObject.GetComponent<BoxCollider>();
        Vertices = new Vector3[4];
       
        Vertices[0] = b.center + new Vector3(-b.size.x, -b.size.y, -b.size.z) * 0.5f;
        Vertices[1] = b.center + new Vector3(b.size.x, -b.size.y, -b.size.z) * 0.5f;
        Vertices[2] = b.center + new Vector3(b.size.x, -b.size.y, b.size.z) * 0.5f;
        Vertices[3] = b.center + new Vector3(-b.size.x, -b.size.y, b.size.z) * 0.5f;
        
    }

    private void Update()
    {
        //Debug.Log(transform.TransformPoint(Vertices[0]) + " Vertices[0]");
    }
    private void CalculateSizeInCells()
    {
        Vector3Int[] vertices = new Vector3Int[Vertices.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 worldPos = transform.TransformPoint(Vertices[i]);
            //Debug.Log(worldPos + " worldpos");
            vertices[i] = BuildingSystem.current.gridLayout.WorldToCell(worldPos);
            //Debug.Log(vertices[i] + " vertices " + i);
            BoxCollider b = gameObject.GetComponent<BoxCollider>();
            //Debug.Log(b.center + " b.center");

        }
        //Debug.Log(Math.Abs((vertices[0] - vertices[1]).x) + " SIZE X");
        //Debug.Log(Math.Abs((vertices[0] - vertices[3]).y) + " SIZE Y");
        Size = new Vector3Int(Math.Abs((vertices[0] - vertices[1]).x),
                              Math.Abs((vertices[0] - vertices[3]).y), 
                              1);
    }
    public Vector3 GetStartPosition()
    {
        return transform.TransformPoint(Vertices[0]);
    }

    private void Start()
    {
        GetColliderVertexPositionsLocal();
        CalculateSizeInCells();
    }
    public void Rotate()
    {
        transform.Rotate(new Vector3(0, 90, 0));
        Size = new Vector3Int(Size.y, Size.x, 1);

        Vector3[] vertices = new Vector3[Vertices.Length];
        for (int i=0; i < vertices.Length; i++)
        {
            vertices[i] = Vertices[(i + 1) % Vertices.Length];
        }
        Vertices = vertices;
    }
    public virtual void Place()
    {
        ObjectDrag drag = gameObject.GetComponent<ObjectDrag>();
        Destroy(drag);

        Placed = true;

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!CollidingObjects.Contains(other.gameObject))
        {
            CollidingObjects.Add(other.gameObject);
        }
        
        Debug.Log(this.gameObject.name + " ontrigger this");
        Debug.Log(other.gameObject.name + " ontrigger other");
        isColliding = true;
    }
    void OnTriggerExit(Collider other)
    {
        
        CollidingObjects.Remove(other.gameObject);
        if(CollidingObjects.Count == 0)
        {
            isColliding = false;
        }
        

    }

    

    
}

