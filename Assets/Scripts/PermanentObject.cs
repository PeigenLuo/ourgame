using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PermanentObject : MonoBehaviour
{

    int thisSceneIndex;
    //如果切换隐藏
    public bool isHidden = false;

    //可以在面板自定义挂载物体的uniqueID
    public string uniqueID;

    public static Dictionary<string, PermanentObject> PermanentDictionary = new Dictionary<string, PermanentObject>();

    //挂载的GameObject如果有脚本进行单例设置，需要先使用if(instance!=null)进行判断，防止被重写覆盖


    //void Start()
    void Awake()
    {

        thisSceneIndex = SceneManager.GetActiveScene().buildIndex;


        if (uniqueID == "")
        {
            //默认ID等于物体名称
            uniqueID = this.gameObject.name;

            //Debug.Log(uniqueID);

        }


        //如果已经存在该物体
        if (PermanentDictionary.ContainsKey(uniqueID))
        {
            //Debug.Log(uniqueID);

            //切回场景时激活被自动隐藏的最初对应物体
            if (isHidden)
            {
                if (thisSceneIndex == SceneManager.GetActiveScene().buildIndex && PermanentDictionary[uniqueID].gameObject.activeSelf == false)
                {
                    PermanentDictionary[uniqueID].gameObject.SetActive(true);
                }
            }

            //销毁该物体
            //Destroy(gameObject);
            DestroyImmediate(gameObject);

        }
        //如果当前场景没有该物体
        else
        {
            PermanentDictionary.Add(uniqueID, this);

            //DontDestroyOnLoad在Start中加载，该物体可在Awake中判断销毁
            //持久存储挂载物体
            GameObject.DontDestroyOnLoad(gameObject);

        }

    }


    void Update()
    {

        if (isHidden)
        {
            //切换场景时隐藏该物体
            if (thisSceneIndex != SceneManager.GetActiveScene().buildIndex)
            {
                gameObject.SetActive(false);
            }
        }

    }
}
