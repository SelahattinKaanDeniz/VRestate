using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemMenuButtonFunctions : MonoBehaviour
{
    public GameObject BathroomMenuPanel;
    public GameObject KitchenMenuPanel;
    public GameObject ConstructionMenuPanel;
    public GameObject ItemMenuPanel;

    public  static string clickedButtonName = "";
    private string leftClickedButtonName;
    [SerializeField] private Camera mainCamera;

    private GameObject ObjectFollowsMouse;

    public GameObject CabinetBase1;
    private int cabinetbase1count = 0;
    Vector3 mousepos;

    //Ana kategoriden Bathroom butonuna týklandýðýnda
    public void BathroomButtonClicked()
    {
        
        BathroomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
        
        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(1500f, 127f);
    }

    //Ana kategoriden Kitchen butonuna týklandýðýnda
    public void KitchenButtonClicked()
    {

        KitchenMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(3660f, 127f);
    }

    //Ana kategoriden Construction butonuna týklandýðýnda
    public void ConstructionButtonClicked()
    {

        ConstructionMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-2820f, 127f);
    }

    //Bathroom alt kategoriden Back butonuna týklandýðýnda
    public void BathroomBackButtonClicked()
    {
       
        BathroomMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(1500f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Kitchen alt kategoriden Back butonuna týklandýðýnda
    public void KitchenBackButtonClicked()
    {

        KitchenMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(3660f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }

    //Construction alt kategoriden Back butonuna týklandýðýnda
    public void ConstructionBackButtonClicked()
    {

        ConstructionMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-2820f, 127f);

        ItemMenuPanel.GetComponent<RectTransform>().localPosition = new Vector3(-660f, 127f);
    }


    //buton ismine göre bu metottan prefab oluþtur
    public void CabinetBase1ButtonClicked() 
    {
        //leftClickedButtonName = EventSystem.current.currentSelectedGameObject.name;

        ObjectFollowsMouse = Instantiate(CabinetBase1, new Vector3(4f, 2f, -18f), Quaternion.identity);
        cabinetbase1count = 1;
        
    }
    public void CabinetBase1ButtonRightClicked()
    {
        //CabinetBase1.transform.localScale = new Vector3(5f, 5f, 5f);
        //CabinetBase1.transform.localScale = new Vector3(1f, 1f, 1f);
        clickedButtonName = "Cabinet_Base_1";
        Debug.Log(clickedButtonName);

    }
    public void ItemMenuButtonsRightClicked()
    {
        //CabinetBase1.transform.localScale = new Vector3(5f, 5f, 5f);
        //CabinetBase1.transform.localScale = new Vector3(1f, 1f, 1f);
        //clickedButtonName = EventSystem.current.currentSelectedGameObject.name;

        PointerEventData pointer = new PointerEventData(EventSystem.current);
        pointer.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);

        if (raycastResults.Count > 0)
        {
            int indexofbutton = 0;
            foreach (var go in raycastResults)
            {
                if (indexofbutton == 1)
                {
                     clickedButtonName = go.gameObject.name;
                }
                //Debug.Log(go.gameObject.name, go.gameObject);
                indexofbutton++;
            }
        }
        //clickedButtonName = "Cabinet_Base_2";
        Debug.Log(clickedButtonName);



    }
    public void Update()
    {
        //SEÇÝLEN OBJE OLUÞUP MOUSEU TAKÝP EDÝYOR
        if (cabinetbase1count == 1)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                ObjectFollowsMouse.transform.position = raycastHit.point;
            }

            //mousepos.z = ObjectFollowsMouse.transform.position.z;
            //ObjectFollowsMouse.transform.position = Camera.main.ScreenToWorldPoint(mousepos); 

            //Rotate
            if (MouseInputUIBlocker.BlockedByUI == false)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0)
                {
                    ObjectFollowsMouse.transform.Rotate(0, 90f, 0, Space.Self);
                }
                if (Input.GetAxis("Mouse ScrollWheel") < 0)
                {
                    ObjectFollowsMouse.transform.Rotate(0, -90f, 0, Space.Self);
                }
                // Sol týk koyma
                if (Input.GetMouseButtonDown(0))
                {
                    cabinetbase1count = 0;
                }
                // Sað týk delete
                if (Input.GetMouseButtonDown(1))
                {
                    cabinetbase1count = 0;
                    Destroy(ObjectFollowsMouse);
                }
            }
        }
    }
}
