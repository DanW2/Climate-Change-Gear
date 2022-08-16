using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollLog : MonoBehaviour{
    [SerializeField] float speed;
    private float startX;
    // Use this for initialization
    void Start(){
        startX = transform.position.x;
    }
    // Update is called once per frame
    void Update () {
       transform.position = new Vector3(startX + Mathf.PingPong(Time.time * speed, 14) , transform.position.y , transform.position.z);
    }
}