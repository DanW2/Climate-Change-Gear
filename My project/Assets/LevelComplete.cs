using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public void LoadGameMenu () {
        Time.timeScale = 0f;
        FindObjectOfType<GameManager>().LoadMainMenu();
    }

    public void restartLevel()  {
        FindObjectOfType<GameManager>().RestartLevel();
    }

    public void LoadNextLevel()
    {
        FindObjectOfType<GameManager>().LoadNextLevel();
    }
}
