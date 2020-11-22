using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toPrevScene : MonoBehaviour
{
    private int prevleveltoload;
    
    private void Start()
    {
        prevleveltoload = SceneManager.GetActiveScene().buildIndex - 1;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(prevleveltoload);
    }
}

