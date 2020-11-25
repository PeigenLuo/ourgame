using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnOpenBag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(doOpenPackage);
    }
    private void doOpenPackage()
    {
        BagPanelManage.instance.doShowPanel1();
        BagPanelManage.instance.doShowPanel2();
        BagPanelManage.instance.doShowPanel3();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
