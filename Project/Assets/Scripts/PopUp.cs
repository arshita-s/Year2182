using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUp : MonoBehaviour
{
    public GameObject popUp;

    public void popUpBox()
    {
        popUp.SetActive(true);
    }

    private void Start()
    {
        popUp.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            popUpBox();
        }
    }
    public void closeIt()
    {
        popUp.SetActive(false);
    }
}
