using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    public string person;
    public string place;
    public string detail; //是否是线索
    public string type; // 三种类型之一
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(gameObject.name);
        BagPanelManage.instance.doAddMusic(gameObject.name, type);
        if (detail != null)
        {
            BagPanelManage.instance.addMusicDetail(detail);
        }
        //Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
