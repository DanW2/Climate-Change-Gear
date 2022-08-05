
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gm;

    void OnTriggerEnter (Collider other){
            if(other.tag == "Player"){
                gm.LoadEndMenu();
            }

        }



}
