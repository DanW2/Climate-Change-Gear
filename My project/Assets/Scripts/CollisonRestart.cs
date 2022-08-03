
using UnityEngine;

public class CollisonRestart : MonoBehaviour
{
    void OnTriggerEnter (){
        FindObjectOfType<GameManager>().RestartLevel();
    }
}
