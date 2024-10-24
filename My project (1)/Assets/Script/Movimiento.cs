using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");

        Vector3 move = new Vector3(moveX, jump, moveZ) * speed *
        Time.deltaTime;
        rb.MovePosition(rb.position + move);
    }
}
