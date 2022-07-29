using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    public void LoadNext ()
    {
        FindObjectOfType<GameManager>().LoadNextLevel();
    }
}
