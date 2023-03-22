using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData
{

    [SerializeField] public string id;
    
    [SerializeField] public string pos_x;
    [SerializeField] public string pos_y;
    [SerializeField] public string pos_z;

    [SerializeField] public string rotation_w;
    [SerializeField] public string rotation_x;
    [SerializeField] public string rotation_y;
    [SerializeField] public string rotation_z;

    [SerializeField] public string scale_x;
    [SerializeField] public string scale_y;
    [SerializeField] public string scale_z;

    public ItemData(
        string id,
        string pos_x,
        string pos_y,
        string pos_z,
        string rotation_w,
        string rotation_x,
        string rotation_y,
        string rotation_z,
        string scale_x,
        string scale_y,
        string scale_z
    ) {
        this.id = id;
        this.pos_x = pos_x;
        this.pos_y = pos_y;
        this.pos_z = pos_z;
        this.rotation_w = rotation_w;
        this.rotation_x = rotation_x;
        this.rotation_y = rotation_y;
        this.rotation_z = rotation_z;
        this.scale_x = scale_x;
        this.scale_y = scale_y;
        this.scale_z = scale_z;
    }

}
