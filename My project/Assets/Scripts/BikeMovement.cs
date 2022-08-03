using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeMovement : MonoBehaviour
{
    
    private Rigidbody rb;
    private float vInput;
    private float hInput;
    private float frontRotation;
    private float momentum;
    public float rotationSpeed;
    public float bikeAcceleration;
    public GameObject peddle;
    public GameObject front;
    public GameObject frontWheel;
    public GameObject backWheel;
    public float steeringSensitivity;
    public float addGravity;               // The game already has gravity. This just increases it on the bike alone.

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        frontRotation = 0.0f;
        momentum = 0.0f;
    }

    void Update(){
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.F)){
            FindObjectOfType<GameManager>().RestartLevel();
        }
    }

    void FixedUpdate()
    {
        //bool frontGrounded = isGrounded(frontWheel);
        //Debug.Log(frontGrounded);
        if(momentum < 20 && vInput > 0){
        momentum += vInput * bikeAcceleration;
        }

        if(vInput == 0){
            if(momentum > 0){
                 momentum -= 1.0f;
            }
           if(momentum < 0){
                momentum = 0;
            }
        }

        if(hInput > 0 && frontRotation < 90.0f){
            frontRotation += (hInput + rotationSpeed) * Time.deltaTime;
        }

        if(hInput< 0 && frontRotation > -90.0f){
            frontRotation -= (hInput + rotationSpeed) * Time.deltaTime;
        }
        //Rotates front axel with turning.
        front.transform.localRotation  = Quaternion.Euler(0, frontRotation, 0);
        
        // Corrects the z rotation and turns wheel.
        transform.Rotate(0, (frontRotation * vInput) / steeringSensitivity, -transform.rotation.eulerAngles.z);


        transform.Translate((Vector3.forward * Time.deltaTime * momentum));


        if(vInput > 0){
            float partRotation = (vInput * Time.deltaTime) * 300;

            peddle.transform.Rotate(partRotation,0,0);
            frontWheel.transform.Rotate(partRotation,0,0);
            backWheel.transform.Rotate(partRotation,0,0);
        }
    }



   bool isGrounded(GameObject wheel){
        Collider wheelCollider = wheel.GetComponent<Collider>();
        float distanceToGround = wheelCollider.bounds.extents.y;
        return Physics.Raycast(wheelCollider.transform.position, new Vector3(0,-1,0), distanceToGround - 0.1f);
    }

}