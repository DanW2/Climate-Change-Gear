using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeMovement : MonoBehaviour
{
    
    private Rigidbody rb;
    private float vInput;
    private float hInput;
    private float frontRotation;
    [SerializeField] float speed;
    [SerializeField] LayerMask ground;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject peddle;
    [SerializeField] GameObject front;
    [SerializeField] GameObject frontWheel;
    [SerializeField] Transform frontWheelGroundCheck;
    [SerializeField] GameObject backWheel;
    [SerializeField] Transform backWheelGroundCheck;
    [SerializeField] float steeringSensitivity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        frontRotation = 0.0f;
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

        if(hInput > 0 && frontRotation < 90.0f){
            frontRotation += (hInput + rotationSpeed) * Time.deltaTime;
        }

        if(hInput< 0 && frontRotation > -90.0f){
            frontRotation -= (hInput + rotationSpeed) * Time.deltaTime;
        }
        //Rotates front axle with turning.
        front.transform.localRotation  = Quaternion.Euler(0, frontRotation, 0);
        
        //Turns bike to face the same direction as the front axle.
        transform.Rotate(0, (frontRotation * vInput) / steeringSensitivity, 0);

        move();
        extrasRotation();
    }

    void move(){
        bool frontGrounded = isGrounded(frontWheelGroundCheck);
        bool backGrounded = isGrounded(backWheelGroundCheck);

        if(frontGrounded && backGrounded){
            // Moves forward in the direction the bike is facing.
                rb.velocity = (transform.forward * vInput) * speed * Time.fixedDeltaTime;
                

        }
    }


    bool isGrounded(Transform checkObject){
       return Physics.CheckSphere(checkObject.position, .1f, ground);
    }


    // Rotates the additional items on the bike like the wheels and peddles.
    void extrasRotation(){
            float partRotation = (vInput * Time.deltaTime) * 300;

            peddle.transform.Rotate(partRotation,0,0);
            frontWheel.transform.Rotate(partRotation,0,0);
            backWheel.transform.Rotate(partRotation,0,0);
        }

}