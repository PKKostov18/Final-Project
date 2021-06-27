using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class outroexit : MonoBehaviour
{
    public string levelToLoad;
    private float timer = 24f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            Application.LoadLevel (levelToLoad);
        }    
    }
}
