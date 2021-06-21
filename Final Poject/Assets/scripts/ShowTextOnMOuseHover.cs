using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTextOnMOuseHover : MonoBehaviour
{
    public GameObject logoText;

    public void Start()
    {
        logoText.SetActive(false);
    }

    public void OnPointerEnter()
    {
        logoText.SetActive(true);
    }

    public void OnPointerExit()
    {
        logoText.SetActive(false);
    }
}
