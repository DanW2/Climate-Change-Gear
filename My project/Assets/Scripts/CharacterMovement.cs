using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float speed;
    public float jumpSpeed;
    public float rotationSpeed;
    private float horizontalInput;
    private float forwardInput;
    private bool restartPressed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        restartPressed = Input.GetKeyDown("f");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, (horizontalInput* rotationSpeed) * Time.deltaTime, 0);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }

        if (rb.position.y < -5f){
            FindObjectOfType<GameManager>().RestartLevel();
        }

        if (restartPressed){
                    FindObjectOfType<GameManager>().RestartLevel();
        }
    }
}
