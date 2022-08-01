using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeMovement : MonoBehaviour
{
    private float vInput;
    private float hInput;
    private float frontRotation;
    public float rotationSpeed;
    public float bikeSpeed;
    public GameObject peddle;
    public GameObject front;
    public GameObject frontWheel;
    public GameObject backWheel;

    private void Start()
    {
        frontRotation = 0.0f;
    }

    void Update(){
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        if(hInput>0 && frontRotation < 90.0f){
            frontRotation += (hInput + rotationSpeed)*Time.deltaTime;
        }

        if(hInput<0 && frontRotation > -90.0f){
            frontRotation -= (hInput + rotationSpeed)*Time.deltaTime;
        }

        front.transform.localRotation  = Quaternion.Euler(0, frontRotation, 0);
        //transform.localRotation = Quaternion.Euler(0, 0, (-frontRotation/5));
        
        transform.Rotate(0, (frontRotation * vInput)/90, 0);
        transform.Translate(Vector3.forward * vInput * Time.deltaTime * bikeSpeed);

        float partRotation = (vInput * Time.deltaTime) * 300;

        peddle.transform.Rotate(partRotation,0,0);
        frontWheel.transform.Rotate(partRotation,0,0);
        backWheel.transform.Rotate(partRotation,0,0);
    }

}