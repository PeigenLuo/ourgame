using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILights : MonoBehaviour
{
    public static UILights inst = null;
    private void Awake()
    {
        inst = this;
        DontDestroyOnLoad(inst);
    }
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("close").GetComponent<Button>().onClick.AddListener(doClickClose);
        doShowOrHidePanel(false);
    }

    public void doShowPanel()
    {
        doShowOrHidePanel(true);
    }

    private void doClickClose()
    {
        doShowOrHidePanel(false);
    }

    public void doShowOrHidePanel(bool ck)
    {
        gameObject.SetActive(ck);
    }
}
