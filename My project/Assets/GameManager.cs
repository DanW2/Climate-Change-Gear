
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public GameObject levelCompleteUI;
    public GameObject player;
    

    public void NextLevel()
    {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
