using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderMenuAnimation : MonoBehaviour
{
    public GameObject PanelMenu;
    public GameObject SliderImage;

    public void ShowHideMenu()
    {
        if(PanelMenu!= null)
        {
            Animator animator = PanelMenu.GetComponent<Animator>();
            if(animator!= null)
            {
                bool isOpen = animator.GetBool("notShow");
                animator.SetBool("notShow", !isOpen);
                RectTransform sliderImageRectTransform = SliderImage.GetComponent<RectTransform>();
                sliderImageRectTransform.Rotate(new Vector3(0, 0, 180));


            }
        }
    }
}
