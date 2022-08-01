using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    private float forwardInput;

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
    }

        void FixedUpdate()
    {
        transform.Rotate((forwardInput* 100) * Time.deltaTime, 0, 0);
    }
}
