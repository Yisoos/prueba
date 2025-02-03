using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [Range(0, 10)] public float speed = 5.0f;
    [Range(0, 200)] public float rotationSpeed = 100.0F;
    [Range(0, 100)] public float jumpForce = 40;

    private Animator animator;
    Vector2 previousmMovement;

    private float spin, x, z;
    [HideInInspector] public bool isPushing;

    private Rigidbody rb;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        spin = Input.GetAxis("Spin");
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        animator.SetFloat("SpeedX", !isPushing ? x : 0);
        animator.SetFloat("SpeedZ", z);
        if (new Vector2(spin, z) != previousmMovement)
        {
           // animator.SetTrigger("InteruptEmote");
        }

        transform.Rotate(0, (!isPushing ? spin : 0) * Time.deltaTime * rotationSpeed, 0);
        transform.Translate((!isPushing ? x : 0)* Time.deltaTime * speed, 0, (!isPushing ? z : z >= 0 ? z/1.5f: 0) * Time.deltaTime * speed);

        if (Input.GetButtonDown("Jump")&& !isPushing)
        {
            rb.AddForce(0, (jumpForce * 10), 0);
            animator.SetBool("Jumping", true);
            //animator.SetTrigger("InteruptEmote");
        }
        if (Input.GetButtonDown("Push"))
        {
            animator.SetBool("Pushing", true);
            isPushing = true;
            //animator.SetTrigger("InteruptEmote");
        }
        if (Input.GetButtonUp("Push"))
        {
            animator.SetBool("Pushing", false);
            isPushing = false;
        }
        previousmMovement = new Vector2(spin, z);
    }

    private void FixedUpdate()
    {
        animator.SetBool("Jumping", false);
    }

    
}

