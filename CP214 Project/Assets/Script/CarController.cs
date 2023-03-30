using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{


    private float moveInput;
    private float turnInput;

    public float fwdSpeed;
    public float revSpeed;
    public float turnSpeed;

    public Rigidbody sphereRB;

    void Start()
    {
        sphereRB.transform.parent = null;
    }


    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");


        moveInput *= moveInput > 0 ? fwdSpeed : revSpeed;

        if(moveInput > 0)
        {
            moveInput *= fwdSpeed;
        }
        else
        {
            moveInput *= revSpeed;
        }
        

        transform.position = sphereRB.transform.position;

        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(0, newRotation, 0, Space.World);
        
    }

    private void FixedUpdate()
    {
        sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
    }
}
