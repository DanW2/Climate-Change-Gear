using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //public void LoadLevelSelect();

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("test"); // Exits ( doesn't work in editor.)
    }
}

