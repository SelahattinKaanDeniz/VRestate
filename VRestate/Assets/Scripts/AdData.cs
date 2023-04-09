using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdData
{
    [SerializeField] public string id;
    [SerializeField] public string title;
    [SerializeField] public string head_photo_id;
    [SerializeField] public string estate_type;
    [SerializeField] public string category;
    [SerializeField] public string price;
    [SerializeField] public string create_date;
    [SerializeField] public string last_update;
    [SerializeField] public string location_ilce;
    [SerializeField] public string location_il;
    [SerializeField] public string coordX;
    [SerializeField] public string coordY;
    [SerializeField] public string room_type;
    [SerializeField] public string m2;
    [SerializeField] public string vr_id;
    [SerializeField] public string owner_id;

    public AdData(
       string id,
       string title,
       string head_photo_id,
       string estate_type,
       string category,
       string price,
       string create_date,
       string last_update,
       string location_ilce,
       string location_il,
       string coordX,
       string coordY,
       string room_type,
       string m2,
       string vr_id,
       string owner_id

    )
    {
        this.id = id;
        this.title = title;
        this.head_photo_id = head_photo_id;
        this.estate_type = estate_type;
        this.category = category;
        this.price = price;
        this.create_date = create_date;
        this.last_update = last_update;
        this.location_ilce = location_ilce;
        this.location_il = location_il;
        this.coordX = coordX;
        this.coordY = coordY;
        this.room_type = room_type;
        this.m2 = m2;
        this.vr_id = vr_id;
        this.owner_id = owner_id;
    }
}

