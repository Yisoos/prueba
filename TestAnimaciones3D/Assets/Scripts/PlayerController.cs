using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0,10)]public float speed = 5.0f;
    [Range(0, 200)] public float rotationSpeed = 100.0F;
    [Range(0, 100)] public float jumpForce = 40;

    private Animator animator;
    Vector2 previousmMovement;

    private float x, z;

    private Rigidbody rb;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        animator.SetFloat("SpeedX", x);
        animator.SetFloat("SpeedZ", z);
        if (new Vector2(x,z) != previousmMovement)
        {
            animator.SetTrigger("InteruptEmote");
        }

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, z * Time.deltaTime * speed);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(0, (jumpForce * 10), 0);
            animator.SetBool("Jump", true);
            animator.SetTrigger("InteruptEmote");
        }
        if (Input.GetButtonDown("Aim"))
        {
            animator.SetBool("Aim", true);
            animator.SetTrigger("InteruptEmote");
        }
        if (Input.GetButtonUp("Aim"))
        {
            animator.SetBool("Aim", false);
        }
        previousmMovement =new Vector2(x,z);
    }

    private void FixedUpdate()
    {
        animator.SetBool("Jump", false);
    }
}