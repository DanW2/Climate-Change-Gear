using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameMenu : MonoBehaviour
{
    private static bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }else{
                PauseGame();
            }
        }
    }

    void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void LoadGameMenu () {
        Time.timeScale = 1f;
        FindObjectOfType<GameManager>().LoadMainMenu();
    }

    public void QuitGame(){
        Application.Quit();
    }
}
