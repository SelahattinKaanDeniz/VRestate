using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
public class LoadModelforVR : MonoBehaviour
{

    public GameObject VRCamera;
    List<GameObject> item_list;
    public static Vector3 VRCameraSpawnPoint;
    public GameObject NewDoor2WithAnim;

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
    
    public GameObject Door2;
   
    public GameObject Window;
    public GameObject Frame;

    public GameObject Rail;

    public GameObject CornerCabinet;
    
    public GameObject DishWasher;
    
    public GameObject Fridge1;
    
    public GameObject Fridge2;
    
    public GameObject RangeHood;
   
    
    public GameObject TV;
    

    //Living Room
    public GameObject Sofa1;
    
    public GameObject Sofa4;
   
    public GameObject Chair2;
    
    public GameObject Chair3;
    
    public GameObject BarCabinet;
    
    public GameObject CoffeeTable1;
    
    public GameObject CoffeeTable2;
    
    //public GameObject CornerCabinet;
    //public static Vector3 CornerCabinetSize;
    public GameObject ModularCabinet;
   
    public GameObject Shelf1;
    
    //public GameObject TV;
    //public static Vector3 TVSize;
    public GameObject TVStand;
    
    public GameObject Table1;
    
    public GameObject Table2;
    
    public GameObject Bench;
    

    //Bathroom
    //public GameObject CornerCabinet;
    //public static Vector3 CornerCabinetSize;
    public GameObject Hamper;
   
    public GameObject TowelRack2;
    

    //Study Room
    public GameObject ComputerTable;
    
    public GameObject Computer;
   
    public GameObject ChairStudy;
    
    //public GameObject Shelf1;
    //public static Vector3 Shelf1Size;
    public GameObject Shelf2;
    

    //Bedroom
    public GameObject Bed1;
    
    public GameObject Bed2;
    
    public GameObject Closet;
    
    public GameObject Dresser;
    
    public GameObject Nightstand1;
   
    public GameObject Nightstand2;
    
    public GameObject Nightstand3;
    

    //Decoration
    public GameObject Carpet;
    
    public GameObject Rug;
    
    public GameObject Mirror;
    
    public GameObject Painting3;
   
    public GameObject Plant;
   
    public GameObject WineRack;
    
    public GameObject WallShelf;
    

    //Lamp
    public GameObject FloorLamp1;
    
    public GameObject FloorLamp2;
   
    public GameObject TableLamp;
    
    public GameObject WallLamp1;
   
    public GameObject WallLamp2;
    

    //Dining Room
    public GameObject DTable1;
    
    public GameObject DTable2;
    
    public GameObject Chair1;
    




    // Dynamic Wall Creation

    public GameObject CubeWall;

    //Bathroom
    public GameObject Bathtub;

    public GameObject Shower;


    public GameObject Toilet;

    public GameObject Vanity1;
    public GameObject Cube;
    public GameObject Capsule;

    GameObject exteriordoor;
    float exteriordoorRotationy = 10f;

    Vector3 firstcamerapos = new Vector3(0.00f, 0.20f, 0.00f);

    // Start is called before the first frame update
    void Start()
    {
        item_list = new List<GameObject>();
        item_list.Add(CubeWall);
        item_list.Add(Floor);
        item_list.Add(CabinetBase1);
        item_list.Add(CabinetBase2);
        item_list.Add(CabinetBaseCorner);
        item_list.Add(CabinetBaseSink);
        item_list.Add(CabinetTall);
        item_list.Add(CabinetWall1);
        item_list.Add(CabinetWall2);
        item_list.Add(Stove);
        item_list.Add(Wall);
        item_list.Add(Door1);
        item_list.Add(Door2);
        item_list.Add(Window);
        item_list.Add(Frame);
        item_list.Add(Rail);
        item_list.Add(Bathtub);
        item_list.Add(Shower);
        item_list.Add(Toilet);
        item_list.Add(Vanity1);

        item_list.Add(CornerCabinet);
        item_list.Add(DishWasher);
        item_list.Add(Fridge1);
        item_list.Add(Fridge2);
        item_list.Add(RangeHood);
        item_list.Add(TV);
        item_list.Add(Sofa1);
        item_list.Add(Sofa4);
        item_list.Add(Chair2);
        item_list.Add(Chair3);
        item_list.Add(BarCabinet);
        item_list.Add(CoffeeTable1);
        item_list.Add(CoffeeTable2);
        item_list.Add(ModularCabinet);
        item_list.Add(Shelf1);
        item_list.Add(TVStand);
        item_list.Add(Table1);
        item_list.Add(Table2);
        item_list.Add(Bench);
        item_list.Add(Hamper);
        item_list.Add(TowelRack2);
        item_list.Add(ComputerTable);
        item_list.Add(Computer);
        item_list.Add(ChairStudy);
        item_list.Add(Shelf2);
        item_list.Add(Bed1);
        item_list.Add(Bed2);
        item_list.Add(Closet);
        item_list.Add(Dresser);
        item_list.Add(Nightstand1);
        item_list.Add(Nightstand2);
        item_list.Add(Nightstand3);
        item_list.Add(Carpet);
        item_list.Add(Rug);
        item_list.Add(Mirror);
        item_list.Add(Painting3);
        item_list.Add(Plant);
        item_list.Add(WineRack);
        item_list.Add(WallShelf);
        item_list.Add(FloorLamp1);
        item_list.Add(FloorLamp2);
        item_list.Add(TableLamp);
        item_list.Add(WallLamp1);
        item_list.Add(WallLamp2);
        item_list.Add(DTable1);
        item_list.Add(DTable2);
        item_list.Add(Chair1);

        //readFromJson("Assets/Resources/test1.txt");

        readFromArrayList();

        

        //item_list.Add(Cube);
        //item_list.Add(Capsule);

    }

    private void Update()
    {
        //Debug.Log("Kamera pozisyonu: " + VRCamera.transform.position);

        if(VRCamera.transform.position == firstcamerapos)
        {
            VRCamera.transform.position = VRCameraSpawnPoint;
        }
    }
    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(new Vector3(17.25f - 0.5f, 0.05f, -14.25f - 1f), 0.2f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(17.25f + 0.5f, 0.05f, -14.25f - 1f), 0.2f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(17.25f + 1f, 0.05f, -14.25f + 0.5f), 0.2f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(17.25f + 1f, 0.05f, -14.25f - 0.5f), 0.2f);
        
    }*/

    public void readFromArrayList()
    {
        ItemData item;
        foreach (string token in SaveModeltoVR.item_list)
        {
            if (!String.Equals(token, ""))
            {
                //Debug.Log(token + " token");
                item = JsonUtility.FromJson<ItemData>(token);
                //ret.Add(item);
                foreach (GameObject s in item_list)
                {
                    if (s.name + "(Clone)" == item.id)
                    {
                        
                        GameObject obj = null;
                        if (item.id != "NewDoor2(Clone)")
                        {
                            obj = Instantiate(s, new Vector3(float.Parse(item.pos_x), float.Parse(item.pos_y), float.Parse(item.pos_z)), new Quaternion(float.Parse(item.rotation_x), float.Parse(item.rotation_y), float.Parse(item.rotation_z), float.Parse(item.rotation_w)));
                            Destroy(obj.GetComponent<PlaceableObject>());
                            obj.transform.localScale = new Vector3(float.Parse(item.scale_x), float.Parse(item.scale_y), float.Parse(item.scale_z));
                            obj.AddComponent<BoxCollider>();
                            obj.GetComponent<BoxCollider>().size = obj.GetComponent<BoxCollider>().size - new Vector3(0.1f, 0.1f, 0.1f);
                            obj.GetComponent<BoxCollider>().isTrigger = true;
                            obj.AddComponent<Rigidbody>();
                            obj.GetComponent<Rigidbody>().isKinematic = true;
                            obj.tag = "Untagged";
                        }
                        if (item.id == "NewDoor1(Clone)")
                        {
                            exteriordoor = obj;
                            exteriordoorRotationy = obj.transform.localRotation.eulerAngles.y;
                        }
                        if (item.id == "NewDoor2(Clone)")
                        {
                            
                            obj = Instantiate(NewDoor2WithAnim, new Vector3(float.Parse(item.pos_x), float.Parse(item.pos_y), float.Parse(item.pos_z)), new Quaternion(float.Parse(item.rotation_x), float.Parse(item.rotation_y), float.Parse(item.rotation_z), float.Parse(item.rotation_w)));
                            obj.transform.localScale = new Vector3(float.Parse(item.scale_x), float.Parse(item.scale_y), float.Parse(item.scale_z));                           
                            obj.tag = "Untagged";
                        }
                        // Çatý için
                        if (item.id == "Floor(Clone)")
                        {
                            obj = Instantiate(s, new Vector3(float.Parse(item.pos_x), 2.99f, float.Parse(item.pos_z)), new Quaternion(float.Parse(item.rotation_x), float.Parse(item.rotation_y), float.Parse(item.rotation_z), float.Parse(item.rotation_w)));
                            Destroy(obj.GetComponent<PlaceableObject>());
                            obj.transform.localScale = new Vector3(float.Parse(item.scale_x) +0.1f, float.Parse(item.scale_y), float.Parse(item.scale_z)+0.1f);
                            obj.AddComponent<BoxCollider>();
                            obj.GetComponent<BoxCollider>().size = obj.GetComponent<BoxCollider>().size - new Vector3(0.1f, 0.1f, 0.1f);
                            obj.GetComponent<BoxCollider>().isTrigger = true;
                            obj.AddComponent<Rigidbody>();
                            obj.GetComponent<Rigidbody>().isKinematic = true;
                            obj.tag = "Untagged";
                        }
                        
                    }
                }
                //Instantiate(DishWasher, new Vector3(4f, 2f, -18f), Quaternion.Euler(new Vector3(-90, 90, 0)));
            }
            //GameObject exteriordoor = GameObject.Find("NewDoor1(Clone)");
            Debug.Log(exteriordoorRotationy);
            //float exteriordoorRotationy = exteriordoor.transform.rotation.y;


            Debug.Log(exteriordoor + " EXTERIORDOOR");

            if (exteriordoor != null)
            {
                bool isfound = false;
                if (exteriordoorRotationy == 90f)
                {

                    Collider[] intersectingleftup = Physics.OverlapSphere(new Vector3(exteriordoor.transform.position.x - 0.5f, 0.05f, exteriordoor.transform.position.z - 1f), 0.2f);
                    //OnDrawGizmos();
                    if (intersectingleftup.Length != 0 && isfound == false)
                    {
                        for (int i = 0; i < intersectingleftup.Length; i++)
                        {
                            Debug.Log(intersectingleftup[i].gameObject.name + " left");
                            if (intersectingleftup[i].gameObject.name == "Floor(Clone)")
                            {
                                Debug.Log(exteriordoor + " SOLUNDA FLOOR BULDU");
                                VRCamera.transform.position = new Vector3(exteriordoor.transform.position.x - 0.5f , 0.2f, exteriordoor.transform.position.z - 1f);
                                VRCamera.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                                isfound = true;
                                break;
                            }
                        }
                    }


                    Collider[] intersectingright = Physics.OverlapSphere(new Vector3(exteriordoor.transform.position.x + 0.5f, 0.05f, exteriordoor.transform.position.z - 1f), 0.2f);
                    //OnDrawGizmos();
                    if (intersectingright.Length != 0 && isfound == false)
                    {
                        for (int i = 0; i < intersectingright.Length; i++)
                        {
                            Debug.Log(intersectingright[i].gameObject.name + " right");
                            if (intersectingright[i].gameObject.name == "Floor(Clone)")
                            {
                                Debug.Log(exteriordoor + " SAÐINDA FLOOR BULDU");
                                VRCamera.transform.position = new Vector3(exteriordoor.transform.position.x + 0.5f, 0.2f, exteriordoor.transform.position.z - 1f);
                                VRCamera.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                                isfound = true;
                                break;
                            }
                        }
                    }
                }
                else if (exteriordoorRotationy == 270f)
                {

                    Collider[] intersectingleftup = Physics.OverlapSphere(new Vector3(exteriordoor.transform.position.x - 0.5f, 0.05f, exteriordoor.transform.position.z + 1f), 0.2f);
                    //OnDrawGizmos();
                    if (intersectingleftup.Length != 0 && isfound == false)
                    {
                        for (int i = 0; i < intersectingleftup.Length; i++)
                        {
                            Debug.Log(intersectingleftup[i].gameObject.name + " left");
                            if (intersectingleftup[i].gameObject.name == "Floor(Clone)")
                            {
                                Debug.Log(exteriordoor + " SOLUNDA FLOOR BULDU");
                                VRCamera.transform.position = new Vector3(exteriordoor.transform.position.x - 0.5f, 0.2f, exteriordoor.transform.position.z + 1f);
                                VRCamera.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
                                isfound = true;
                                break;
                            }
                        }
                    }


                    Collider[] intersectingright = Physics.OverlapSphere(new Vector3(exteriordoor.transform.position.x + 0.5f, 0.05f, exteriordoor.transform.position.z + 1f), 0.2f);
                    //OnDrawGizmos();
                    if (intersectingright.Length != 0 && isfound == false)
                    {
                        for (int i = 0; i < intersectingright.Length; i++)
                        {
                            Debug.Log(intersectingright[i].gameObject.name + " right");
                            if (intersectingright[i].gameObject.name == "Floor(Clone)")
                            {
                                Debug.Log(exteriordoor + " SAÐINDA FLOOR BULDU");
                                VRCamera.transform.position = new Vector3(exteriordoor.transform.position.x + 0.5f , 0.2f, exteriordoor.transform.position.z + 1f);
                                VRCamera.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
                                isfound = true;
                                break;
                            }
                        }

                    }
                }
                else if (exteriordoorRotationy == 180f)
                {
                    Collider[] intersectingforward = Physics.OverlapSphere(new Vector3(exteriordoor.transform.position.x - 1f, 0.05f, exteriordoor.transform.position.z + 0.5f), 0.2f);
                    //OnDrawGizmos();
                    if (intersectingforward.Length != 0 && isfound == false)
                    {
                        for (int i = 0; i < intersectingforward.Length; i++)
                        {
                            Debug.Log(intersectingforward[i].gameObject.name + " forward");
                            if (intersectingforward[i].gameObject.name == "Floor(Clone)")
                            {
                                Debug.Log(exteriordoor + " ÝLERÝSÝNDE FLOOR BULDU");
                                VRCamera.transform.position = new Vector3(exteriordoor.transform.position.x - 1f, 0.2f, exteriordoor.transform.position.z + 0.5f );
                                VRCamera.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                isfound = true;
                                break;
                            }
                        }
                    }
                    Collider[] intersectingback = Physics.OverlapSphere(new Vector3(exteriordoor.transform.position.x - 1f, 0.05f, exteriordoor.transform.position.z - 0.5f), 0.2f);
                    //OnDrawGizmos();
                    if (intersectingback.Length != 0 && isfound == false)
                    {
                        for (int i = 0; i < intersectingback.Length; i++)
                        {
                            Debug.Log(intersectingback[i].gameObject.name + " back");
                            if (intersectingback[i].gameObject.name == "Floor(Clone)")
                            {
                                Debug.Log(exteriordoor + " ARKASINDA FLOOR BULDU");
                                VRCamera.transform.position = new Vector3(exteriordoor.transform.position.x - 1f, 0.2f, exteriordoor.transform.position.z - 0.5f );
                                VRCamera.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                                isfound = true;
                                break;
                            }
                        }
                    }
                }
                else if (exteriordoorRotationy == 0f)
                {
                    Collider[] intersectingforward = Physics.OverlapSphere(new Vector3(exteriordoor.transform.position.x + 1f, 0.05f, exteriordoor.transform.position.z + 0.5f), 0.2f);
                    //OnDrawGizmos();
                    if (intersectingforward.Length != 0 && isfound == false)
                    {
                        for (int i = 0; i < intersectingforward.Length; i++)
                        {
                            Debug.Log(intersectingforward[i].gameObject.name + " forward");
                            if (intersectingforward[i].gameObject.name == "Floor(Clone)")
                            {
                                Debug.Log(exteriordoor + " ÝLERÝSÝNDE FLOOR BULDU");
                                VRCamera.transform.position = new Vector3(exteriordoor.transform.position.x + 1f, 0.2f, exteriordoor.transform.position.z + 0.5f );
                                VRCamera.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                                isfound = true;
                                break;
                            }
                        }
                    }
                    Collider[] intersectingback = Physics.OverlapSphere(new Vector3(exteriordoor.transform.position.x + 1f, 0.05f, exteriordoor.transform.position.z - 0.5f), 0.2f);
                    //OnDrawGizmos();
                    if (intersectingback.Length != 0 && isfound == false)
                    {
                        for (int i = 0; i < intersectingback.Length; i++)
                        {
                            Debug.Log(intersectingback[i].gameObject.name + " back");
                            if (intersectingback[i].gameObject.name == "Floor(Clone)")
                            {
                                Debug.Log(exteriordoor + " ARKASINDA FLOOR BULDU");
                                VRCamera.transform.position = new Vector3(exteriordoor.transform.position.x + 1f, 0.2f, exteriordoor.transform.position.z - 0.5f -2f);
                                VRCamera.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                                isfound = true;
                                break;
                            }
                        }
                    }
                }
            }
        }
        Debug.Log(VRCamera.transform.position + "KAMERANIN SON POZÝSYONU");
        VRCameraSpawnPoint = VRCamera.transform.position;
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
                    if (s.name + "(Clone)" == item.id)
                    {
                        GameObject obj;
                        obj = Instantiate(s, new Vector3(float.Parse(item.pos_x), float.Parse(item.pos_y), float.Parse(item.pos_z)), new Quaternion(float.Parse(item.rotation_x), float.Parse(item.rotation_y), float.Parse(item.rotation_z), float.Parse(item.rotation_w)));
                        Destroy(obj.GetComponent<PlaceableObject>());
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
