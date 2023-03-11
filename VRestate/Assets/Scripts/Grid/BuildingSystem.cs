using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem current;

    public GridLayout gridLayout;
    private Grid grid;
    [SerializeField] private Tilemap MainTilemap;
    [SerializeField] private TileBase whiteTile;

    public GameObject prefab1;
    public GameObject prefab2;

    public static float posx;
    public static float posy;
    public static float posz;
    //private PlaceableObject objectToPlace;

    public GameObject SizeMenu;
    private SizeMenuFunctions sizeMenuFunctions;

    #region Unity methods

    private void Awake()
    {
        current = this;
        grid = gridLayout.gameObject.GetComponent<Grid>();
        sizeMenuFunctions = SizeMenu.GetComponent<SizeMenuFunctions>();
    }

    private void Update()
    {
        //Debug.Log(BuildingSystem.GetMouseWorldPosition() + " MOUSE POZÝSYONU");
             

        /*if (Input.GetKeyDown(KeyCode.A))
        {
            InitializeWithObject(prefab1);
        }else if (Input.GetKeyDown(KeyCode.B))
        {
            InitializeWithObject(prefab2);
        }
        if (!objectToPlace)
        {
            return;
        }*/

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ItemMenuButtonFunctions.objectToPlace.Rotate();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
           
            if (CanBePlaced(ItemMenuButtonFunctions.objectToPlace))
            {
                Debug.Log("BOYANDI");
                ItemMenuButtonFunctions.objectToPlace.Place();
                Vector3Int start = gridLayout.WorldToCell(ItemMenuButtonFunctions.objectToPlace.GetStartPosition());
                TakeArea(start, ItemMenuButtonFunctions.objectToPlace.Size);
            }
            else
            {
                Destroy(ItemMenuButtonFunctions.objectToPlace.gameObject);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(ItemMenuButtonFunctions.objectToPlace.gameObject);
        }
    }

    #endregion

    #region Utils

    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            return raycastHit.point;
        }
        else
        {
            return Vector3.zero;
        }
    }
    

    public Vector3 SnapCoordinateToGrid(RaycastHit hit)
    {
        //Debug.Log(hit + " position");
        RaycastHit originalHit = hit;
        Vector3Int cellPos = gridLayout.WorldToCell(hit.point);
        //Debug.Log(cellPos + " cellpos");
        hit.point = grid.GetCellCenterWorld(cellPos);
        //Debug.Log(hit.point + " newposition");
        //Debug.Log(originalHit.collider.gameObject.name);
        /* if(originalHit.collider.tag == "3DModel")
         {
             hit.point = new Vector3(hit.point.x - 0.25f,   hit.point.y + originalHit.collider.gameObject.GetComponent<BoxCollider>().size.y, hit.point.z - 0.25f);
         }*/
        //else
        //{
        if (ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.name == "CubeWall(Clone)" || ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.name == "NewDoor1(Clone)" || ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.name == "NewDoor2(Clone)" || ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.name == "NewWindow2(Clone)" 
            || ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.name == "Floor(Clone)" || ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.name == "Frame(Clone)" || ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.name == "Rail(Clone)")
        {
            if (ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.tag == "3DModel" && ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.transform.eulerAngles.y == 0f)
            {

                hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z - 0.25f);
                //Debug.Log("snapcoordinate 1.if" + hit.point);
            }
            else if (ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.tag == "3DModel" && ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.transform.eulerAngles.y == 90f)
            {

                hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z -0.25f);
                //Debug.Log("snapcoordinate 2.if" + hit.point);
            }
            else if (ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.tag == "3DModel" && ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.transform.eulerAngles.y == 180f)
            {

                hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z - 0.25f);
                //Debug.Log("snapcoordinate 3.if" + hit.point);
            }
            else if (ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.tag == "3DModel" && ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.transform.eulerAngles.y == 270f)
            {

                hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z - 0.25f);
                //Debug.Log("snapcoordinate 4.if" + hit.point);
            }
        }
        /*else if (ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.name == "Cabinet_Wall_1(Clone)" || ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.name == "Cabinet_Wall_2(Clone)")
        {
            if (ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.tag == "3DModel" && ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.transform.eulerAngles.y == 0f)
            {

                hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z - 0.25f);
                Debug.Log("snapcoordinate 1.if" + hit.point);
            }
            else if (ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.tag == "3DModel" && ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.transform.eulerAngles.y == 90f)
            {

                hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z - 0.25f);
                Debug.Log("snapcoordinate 2.if" + hit.point);
            }
            else if (ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.tag == "3DModel" && ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.transform.eulerAngles.y == 180f)
            {

                hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z + 0.25f);
                Debug.Log("snapcoordinate 3.if" + hit.point);
            }
            else if (ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.tag == "3DModel" && ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.transform.eulerAngles.y == 270f)
            {

                hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z + 0.25f);
                Debug.Log("snapcoordinate 4.if" + hit.point);
            }
        }*/
        else
        {
            if (ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.tag == "3DModel" && ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.transform.eulerAngles.y == 0f)
            {

                hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z - 0.25f);
                //Debug.Log("snapcoordinate 1.if" + hit.point);
            }
            else if (ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.tag == "3DModel" && ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.transform.eulerAngles.y == 90f)
            {

                hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z - 0.25f);
                //Debug.Log("snapcoordinate 2.if" + hit.point);
            }
            else if (ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.tag == "3DModel" && ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.transform.eulerAngles.y == 180f)
            {

                hit.point = new Vector3(hit.point.x - 0.25f, hit.point.y, hit.point.z + 0.25f);
                //Debug.Log("snapcoordinate 3.if" + hit.point);
            }
            else if (ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.tag == "3DModel" && ItemMenuButtonFunctions.buildingSystemObjectFollowMouse.transform.eulerAngles.y == 270f)
            {

                hit.point = new Vector3(hit.point.x + 0.25f, hit.point.y, hit.point.z + 0.25f);
                //Debug.Log("snapcoordinate 4.if" + hit.point);
            }
        }

        //}


        return hit.point;
    }

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var v in area.allPositionsWithin)
        {
            Vector3Int pos = new Vector3Int(v.x, v.y, 0);
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }
        return array;
    }

    #endregion

    #region Building Placement
    
    /*public void InitializeWithObject(GameObject prefab)
    {
        Vector3 position = SnapCoordinateToGrid(Vector3.zero);

        GameObject obj = Instantiate(prefab, position, Quaternion.identity);
        objectToPlace = obj.GetComponent<PlaceableObject>();
        obj.AddComponent<ObjectDrag>();
    }*/

    private bool CanBePlaced(PlaceableObject placeableObject)
    {
        BoundsInt area = new BoundsInt();
        area.position = gridLayout.WorldToCell(ItemMenuButtonFunctions.objectToPlace.GetStartPosition());
        area.size = placeableObject.Size;

        TileBase[] baseArray = GetTilesBlock(area, MainTilemap);
        
        foreach (var b in baseArray)
        {
            if (b == whiteTile)
            {
                return false;
            }
        }
        return true;
    }
    public void TakeArea(Vector3Int start, Vector3Int size)

    {
        /*Debug.Log("TAKEAREA GÝRDÝ");
        Debug.Log(start + " start"); 
        Debug.Log(size.x + " takearea x");
        Debug.Log(size.y + " takearea y");*/
        MainTilemap.BoxFill(start, whiteTile, start.x, start.y,
                            start.x + size.x -1, start.y + size.y -1);

    }
    #endregion

}