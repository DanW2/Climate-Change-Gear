using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    void OnCollisionEnter (Collision collisionInfo){
        if(collisionInfo.collider.tag == "Obstacle"){
        }
    }
}
