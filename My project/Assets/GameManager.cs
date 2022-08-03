
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteUI;
    [SerializeField] GameObject timeUI;
    private bool gameEnded = false;
    private float time;
    
    void start(){
        time = 0f;
    }

    public void LoadEndMenu()
    {
        Time.timeScale = 0f;
        //timeUi.SetActive(false);
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

    public string getScore(){
        time += Time.deltaTime;
        string score = time.ToString("0.00");
        return  score;
    }
}
