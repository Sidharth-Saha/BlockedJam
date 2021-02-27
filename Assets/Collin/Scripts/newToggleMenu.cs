using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newToggleMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas mainMenu;
    [SerializeField] Canvas controlMenu;
    [SerializeField] FirstPersonLook playScript;
    int inMenu;
    void Start()
    {
        inMenu = 0;
        UpdateMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inMenu = (inMenu == 0) ? 1 : 0;
            UpdateMenu();
            playScript.ToggleMouse();
        }
    }

    void UpdateMenu()
    {
        Time.timeScale = (inMenu == 0) ? 1 : 0;
        mainMenu.enabled = (inMenu == 1) ? true : false;
        controlMenu.enabled = (inMenu == 2) ? true : false;
    }

    public void Resume()
    {
        inMenu = 0;
        playScript.ToggleMouse();
        UpdateMenu();
    }
}
