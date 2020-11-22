using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[System.Serializable]
public class BagPanelManage : MonoBehaviour
{
    public static BagPanelManage inst = null;
    
    public List<AudioClip> iAudioList = new List<AudioClip>();
    public AudioSource iAudioSource;
    private Transform iCopyItem1;
    private Transform iCopyItem2;
    private Transform iCopyItem3;
    private List<string> iMusicList1 = new List<string>();
    private List<string> iMusicList2 = new List<string>();
    private List<string> iMusicList3 = new List<string>();
    public List<int> typeofMusic = new List<int>(); //range from 1 to 8, if any number exists, lighton

    private void Awake()
    {
        inst = this;
        DontDestroyOnLoad(transform.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        iCopyItem1 = transform.Find("Scroll View1/Viewport/item");
        iCopyItem2 = transform.Find("Scroll View2/Viewport/item");
        iCopyItem3 = transform.Find("Scroll View3/Viewport/item");
        transform.Find("close").GetComponent<Button>().onClick.AddListener(doClickClose);
        doShowOrHidePanel(false);
        
    }
    public void doAddMusic(string musicname, string type)
    {
        if(type == "媚")
        {
            if (iMusicList1.Contains(musicname))
                return;
            iMusicList1.Add(musicname);
        }

        if (type == "威")
        {
            if (iMusicList2.Contains(musicname))
                return;
            iMusicList2.Add(musicname);
        }

        if (type == "欺")
        {
            if (iMusicList3.Contains(musicname))
                return;
            iMusicList3.Add(musicname);
        }

    }

    //mei-1, wei-2, qi-3, 三种
    public void doShowPanel1()
    {
        Transform content = transform.Find("Scroll View1/Viewport/Content");
        for (int i= content.childCount-1; i>=0; i--)
        {
            Destroy(content.GetChild(i).gameObject);
        }
        for(int i = 0; i < iMusicList1.Count; i++)
        {
            Transform item = Instantiate(iCopyItem1);
            item.gameObject.name = iMusicList1[i];
            item.SetParent(content);
            item.localScale = Vector3.one;
            item.localPosition = Vector3.zero;
            item.Find("Text").GetComponent<Text>().text = iMusicList1[i];
            item.GetComponent<Button>().onClick.AddListener(()=>{
                doPlayMusic(item.gameObject.name);
            });
        }
        doShowOrHidePanel(true);
    }
    public void doShowPanel2()
    {
        Transform content = transform.Find("Scroll View2/Viewport/Content");
        for (int i = content.childCount - 1; i >= 0; i--)
        {
            Destroy(content.GetChild(i).gameObject);
        }
        for (int i = 0; i < iMusicList2.Count; i++)
        {
            Transform item = Instantiate(iCopyItem2);
            item.gameObject.name = iMusicList2[i];
            item.SetParent(content);
            item.localScale = Vector3.one;
            item.localPosition = Vector3.zero;
            item.Find("Text").GetComponent<Text>().text = iMusicList2[i];
            item.GetComponent<Button>().onClick.AddListener(() => {
                doPlayMusic(item.gameObject.name);
            });
        }
        doShowOrHidePanel(true);
    }
    public void doShowPanel3()
    {
        Transform content = transform.Find("Scroll View3/Viewport/Content");
        for (int i = content.childCount - 1; i >= 0; i--)
        {
            Destroy(content.GetChild(i).gameObject);
        }
        for (int i = 0; i < iMusicList3.Count; i++)
        {
            Transform item = Instantiate(iCopyItem3);
            item.gameObject.name = iMusicList3[i];
            item.SetParent(content);
            item.localScale = Vector3.one;
            item.localPosition = Vector3.zero;
            item.Find("Text").GetComponent<Text>().text = iMusicList3[i];
            item.GetComponent<Button>().onClick.AddListener(() => {
                doPlayMusic(item.gameObject.name);
            });
        }
        doShowOrHidePanel(true);
    }
    private void doPlayMusic(string musicname)
    {
        Debug.Log("musicname = " + musicname);
        string[] audio = musicname.Split('-');
        int index = (int.Parse(audio[0])-1) * 3 + int.Parse(audio[1]) - 1;
        iAudioSource.Stop();
        iAudioSource.clip = iAudioList[index];
        iAudioSource.Play();
    }
    private void doClickClose()
    {
        doShowOrHidePanel(false);
        iAudioSource.Stop();
    }
    public void doShowOrHidePanel(bool ck)
    {
        gameObject.SetActive(ck);
    }


    public void addMusicDetail(string str)
    {
        string c = str.Substring(str.Length - 1);
        int x = Convert.ToInt32(c);
        //Debug.Log("evidence: "+ x);
        if (!typeofMusic.Contains(x))
        {
            typeofMusic.Add(x);
        }
    }

    public bool checkMusicDetail(int x)
    {
        if (typeofMusic.Contains(x))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

 
}
