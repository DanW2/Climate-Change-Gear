using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    public void Restart ()
    {
        FindObjectOfType<GameManager>().RestartLevel();
    }
}
