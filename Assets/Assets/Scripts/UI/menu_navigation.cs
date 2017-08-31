using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_navigation : MonoBehaviour {

    private bool isInMenu = false;

    private Canvas mainMenu;
    private Canvas settingsMenu;


    private void Start()
    {
        mainMenu = GameObject.FindGameObjectWithTag("main_menu").GetComponent<Canvas>();
        mainMenu.enabled = false;
    }

    void Update () {
        if (Input.GetKeyDown("escape"))
        {
            MenuSwitching();
        }
	}

    public void MenuSwitching()
    {
        if (isInMenu)
        {
            GameManager.PauseGame();
            mainMenu.enabled = true;
            isInMenu = !isInMenu;
        }
        else
        {
            GameManager.ContinueGame();
            mainMenu.enabled = false;
            isInMenu = !isInMenu;
        }
    }
}
