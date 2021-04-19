using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUp : MonoBehaviour
{
    public GameObject popUp;
    public bool open = false;

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
        if (Input.GetKeyDown(KeyCode.T) && !open)
        {
            popUpBox();
            open = true;
        }
        else if(Input.GetKeyDown(KeyCode.T) && open)
        {
            popUp.SetActive(false);
            open = false;
        }
    }
}
