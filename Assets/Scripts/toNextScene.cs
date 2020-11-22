using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toNextScene : MonoBehaviour
{
    private int nextleveltoload;
    
    private void Start()
    {
        nextleveltoload = SceneManager.GetActiveScene().buildIndex + 1;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(nextleveltoload);
        Debug.Log(nextleveltoload);
    }
}

