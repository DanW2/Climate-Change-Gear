using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeMovement : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float groundedFixForce = -0.7f;          // Needed to fix a Unity error where it needs enough force with the floor to detect grounded.
    private float playerSpeed = 0.02f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = groundedFixForce;
        }

        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
       // controller.Move(move * Time.deltaTime * playerSpeed);

        //if (move != Vector3.zero)
       // {
        //    gameObject.transform.forward = move;
        //}

        transform.Rotate(0, Input.GetAxis("Horizontal")  * .2f, 0);
        var forward = transform.TransformDirection((Vector3.forward)*Input.GetAxis("Vertical")*playerSpeed);
        controller.Move(forward);
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue - groundedFixForce);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

}
