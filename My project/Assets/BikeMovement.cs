using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeMovement : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;

    private CharacterController cController; // Unity implemented class to deal with movement.
    private float ySpeed;
    // Start is called before the first frame update
    void Start()
    {
        cController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Unity logic to record input as -1 0 or 1 for horizontal movement.
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize(); 

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if(cController.isGrounded){

           // ySpeed = -0.5f;

            if(Input.GetButtonDown("Jump")){
                ySpeed = jumpSpeed;
            }
        }

        Vector3 velo = movementDirection*speed;
        velo.y = ySpeed;

        cController.Move(velo * Time.deltaTime);




        //if(movementDirection != Vector3.zero){    //Check if moving
        //    Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        //}
        //This is to rotate to direction moving

    }

}
