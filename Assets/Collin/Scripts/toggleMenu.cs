using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleMenu : MonoBehaviour
{
    [SerializeField] bool main_menu;
    Canvas menu;
    Boolean inMenu;
    // Start is called before the first frame update
    void Start()
    {
        menu = GetComponent<Canvas>();
        inMenu = false;
        menu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            togMen();
        }
            
    }

    public void togMen()
    {
        if (main_menu)
        {
            inMenu = !inMenu;
            Time.timeScale = (inMenu) ? 0 : 1;
            menu.enabled = inMenu;
        }
        else
        {
            menu.enabled = false;
        }
    }
}
