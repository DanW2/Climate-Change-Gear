using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 500f;
    public float sideForce = 500f;
    public float upForce = 1f;
    public bool grounded = true;

    // Update is called once per frame
    void FixedUpdate()  // Use fixed update for physics.
    {
        if(Input.GetKey("d")){
            rb.AddForce(sideForce * Time.deltaTime, 0, 0);

        }

        if(Input.GetKey("a")){
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0);

        }

        if(Input.GetKey("w")){
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

        if(Input.GetKey("s")){
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
        }

        if(Input.GetKeyDown("space") && grounded){
        Vector3 jump = new Vector3(0.0f, 1.0f, 0.0f);
        rb.AddForce(jump*upForce, ForceMode.Impulse);
        grounded = false;
        }
    }
}
