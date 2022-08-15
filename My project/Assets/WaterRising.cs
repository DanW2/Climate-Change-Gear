using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRising : MonoBehaviour
{
    [SerializeField] float speed;
    private float yPosition;
    void Start()
    {
        yPosition = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x , yPosition += speed, transform.position.z);
    }
}
