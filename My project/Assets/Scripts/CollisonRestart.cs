
using UnityEngine;
using System.Collections;

public class CollisonRestart : MonoBehaviour
{
    [SerializeField] GameObject toolTip;

    void OnTriggerEnter (){
        FindObjectOfType<GameManager>().RestartLevel();
        StartCoroutine("WaitTwo");
    }

    // Uses game engine to wait and display message.
    IEnumerator WaitTwo(){
        toolTip.SetActive(true);
        yield return new WaitForSeconds(1f);
        toolTip.SetActive(false);
    }
}
