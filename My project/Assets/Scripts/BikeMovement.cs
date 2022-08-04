using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeMovement : MonoBehaviour
{
    
    private Rigidbody rb;
    [SerializeField] Transform backWheelGroundCheck;
    [SerializeField] Transform frontWheelGroundCheck;
    [SerializeField] LayerMask ground;
    private float vInput;
    private float hInput;
    private float frontRotation;
    [SerializeField] float rotationSpeed;
    [SerializeField] float bikeAcceleration;
    [SerializeField] GameObject peddle;
    [SerializeField] GameObject front;
    [SerializeField] GameObject frontWheel;
    [SerializeField] GameObject backWheel;
    [SerializeField] float steeringSensitivity;
    private RaycastHit slopeHit;

    
    bool onSlope(){
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, 3.0f)){
            if(slopeHit.normal != Vector3.up){
                return true;
            }
            else{
                return false;
            }
        }
        return false;
    }


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
        move();

        if(hInput > 0 && frontRotation < 90.0f){
            frontRotation += (hInput + rotationSpeed) * Time.deltaTime;
        }

        if(hInput< 0 && frontRotation > -90.0f){
            frontRotation -= (hInput + rotationSpeed) * Time.deltaTime;
        }
        //Rotates front axel with turning.
        front.transform.localRotation  = Quaternion.Euler(0, frontRotation, 0);
        
        // Corrects the z rotation and turns wheel.
        transform.Rotate(0, (frontRotation * vInput) / steeringSensitivity, 0);

        extrasRotation();
    }

    void move(){
        bool frontGrounded = isGrounded(frontWheelGroundCheck);
        bool backGrounded = isGrounded(backWheelGroundCheck);

        if(frontGrounded && backGrounded){
            rb.AddForce(transform.forward * 100f * vInput);
        }
    }


   bool isGrounded(Transform checkObject){
       return Physics.CheckSphere(checkObject.position, .1f, ground);
    }


    // Rotates the additional items on the bike like the wheel and peddle.
    void extrasRotation(){
                if(vInput > 0){
            float partRotation = (vInput * Time.deltaTime) * 300;

            peddle.transform.Rotate(partRotation,0,0);
            frontWheel.transform.Rotate(partRotation,0,0);
            backWheel.transform.Rotate(partRotation,0,0);
        }
    }

}