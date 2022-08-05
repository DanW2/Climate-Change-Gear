
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteUI;
    private bool gameEnded = false;
    
    void start(){
    }

    public void LoadEndMenu()
    {
        Time.timeScale = 0f;
        levelCompleteUI.SetActive(true);
    }

    public void RestartLevel ()
    {
        if(!gameEnded){
            gameEnded = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    public void LoadMainMenu ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadNextLevel ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
