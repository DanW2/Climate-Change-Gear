using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcebergFloat : MonoBehaviour{
    [SerializeField] float speed;
    private float startY;
    // Use this for initialization
    void Start(){
        startY = transform.position.y;
    }
    // Update is called once per frame
    void Update () {
       transform.position = new Vector3( transform.position.x , startY - Mathf.PingPong(Time.time * speed, 4) , transform.position.z);
    }
}