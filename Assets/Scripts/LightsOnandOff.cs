using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightsOnandOff : MonoBehaviour
{
    public Sprite lightsOn;
    public Sprite lightsOff;
    public int num;
    // Update is called once per frame
    void Update()
    {
        for(int i = 1; i < 9; i++)
        {
            GameObject light = GameObject.Find("light" + i);
            if (BagPanelManage.instance.checkMusicDetail(i))
            {
                light.GetComponent<Image>().sprite = lightsOn;
            }
            else
                light.GetComponent<Image>().sprite = lightsOff;
        }
        
    }

    private void findEvidence()
    {

    }
}
