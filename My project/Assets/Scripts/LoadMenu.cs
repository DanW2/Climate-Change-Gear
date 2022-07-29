using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public void LoadGameMenu () {
        FindObjectOfType<GameManager>().LoadMainMenu();
    }
}
