using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool pickedUp;

    [HideInInspector]
    public bool equipped;
    public bool playersObject;

    public void Update() {
        if(equipped){
            // play it.
        }
    }

    public void ItemUsage(){
        //audio
        if(type == "Audio" && description == "#1"){
            equipped = true;
            //specific content 
        }
    }

}
