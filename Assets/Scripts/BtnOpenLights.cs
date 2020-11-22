using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnOpenLights : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(doOpenLights);
    }
    private void doOpenLights()
    {
        UILights.inst.doShowPanel();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
