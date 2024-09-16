using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveForward : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;  // Kecepatan gerakan
    float vel;
    float horInput, verInput;

    Vector3 moveDirector;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void SetInput()
    {
        horInput = Input.GetAxisRaw("Horizontal");
        verInput = Input.GetAxisRaw("Vertical");
    }

    void Update()
    {
        SetInput();
    }

    void PlayerMove()
    {
        moveDirector = Camera.main.transform.forward * verInput + Camera.main.transform.right * horInput;
        rb.AddForce(moveDirector.normalized * moveSpeed, ForceMode.Force);
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    void FixedUpdate()
    {
        PlayerMove();
    }
}