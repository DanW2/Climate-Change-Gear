
using UnityEngine;
using System.Collections;

public class CollisonRestart : MonoBehaviour
{
    [SerializeField] GameObject toolTip;

    void OnTriggerEnter (Collider other){
        if(other.tag == "Player"){
        FindObjectOfType<GameManager>().RestartLevel();
        StartCoroutine("WaitTwo");
        }
    }

    // Uses game engine to wait and display message.
    IEnumerator WaitTwo(){
        toolTip.SetActive(true);
        yield return new WaitForSeconds(1200f);
        toolTip.SetActive(false);
    }
}
