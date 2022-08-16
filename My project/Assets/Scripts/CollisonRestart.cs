
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollisonRestart : MonoBehaviour
{
    [SerializeField] GameObject toolTip;

    void OnTriggerEnter (Collider other){
        if(other.tag == "Player"){
        StartCoroutine("WaitOne");
        }
    }

    // Uses game engine to wait and display message.
    IEnumerator WaitOne(){
        toolTip.SetActive(true);
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);
        Time.timeScale = 1f;
        toolTip.SetActive(false);
        FindObjectOfType<GameManager>().RestartLevel();
    }
}
