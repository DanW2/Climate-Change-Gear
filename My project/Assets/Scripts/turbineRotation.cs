using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turbineRotation : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject toolTip;

    void FixedUpdate(){
        transform.Rotate(new Vector3 (0, 0, speed) * Time.deltaTime);
    }

}
