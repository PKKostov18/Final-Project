using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayRiddle : MonoBehaviour
{
    public GameObject appearingCanvas;
    public GameObject disappearingCanvas;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            appearingCanvas.SetActive(true);
            disappearingCanvas.SetActive(false);
        }
    }
}
