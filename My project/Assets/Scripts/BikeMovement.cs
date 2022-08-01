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
        transform.Rotate(0, hInput * rotationSpeed * Time.deltaTime, 0);
        transform.Translate(Vector3.forward * vInput * Time.deltaTime * bikeSpeed);

        //Controls movement of parts of the bike while moving.
        //float frontRotation = transform.localRotation.eulerAngles.x;
       // float chasisRotation = transform.localRotation.eulerAngles.x;
       // Debug.Log(chasisRotation);

        //front.transform.Rotation(0, ((hInput * Time.deltaTime) * (rotationSpeed * 3)) * 2 , 0);
        if(hInput>0 && frontRotation < 90.0f){
            frontRotation += (hInput + rotationSpeed)*Time.deltaTime;
        }

        if(hInput<0 && frontRotation > -90.0f){
            frontRotation -= (hInput + rotationSpeed)*Time.deltaTime;
        }

        front.transform.localRotation  = Quaternion.Euler(0, frontRotation, 0);

        float partRotation = (vInput * Time.deltaTime) * 300;

        peddle.transform.Rotate(partRotation,0,0);
        frontWheel.transform.Rotate(partRotation,0,0);
        backWheel.transform.Rotate(partRotation,0,0);
    }

}