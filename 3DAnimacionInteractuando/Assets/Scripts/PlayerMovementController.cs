using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementController : MonoBehaviour
{
    // Movement Variables
    [Header("Movement Settings")]
    [Tooltip("The movement speed of the player.")]
    [Space(15), Range(0, 10)] public float speed = 5.0f; // Player movement speed
    [Tooltip("Speed reduction when pushing objects.")]
    [Space(15), Range(0, 100)] public int pushSpeedDecrease; // Speed reduction when pushing objects
    [Tooltip("Speed reduction when crouching.")]
    [Range(0, 100)] public int crouchSpeedDecrease; // Speed reduction when pushing objects
    [Tooltip("Speed at which the player rotates.")]
    [Space(15), Range(0, 200)] public float rotationSpeed = 100.0f; // Rotation speed
    [Tooltip("The transform of the camera used for aiming.")]
    public Transform cameraAim;
    [Tooltip("The force applied to the player's jump.")]
    [Space(15),Range(0, 10)] public float jumpForce = 40; // Jump force

    // Interaction Variables
    [Header("World Interaction Settings")]
    [Tooltip("Position used to check if there are objects in front of the player.")]
    [Space(15)] public Transform pushCheck; // Position for checking interactable objects
    [Tooltip("Radius for object interaction.")]
    [Range(0, 1)] public float pushRadius; // Interaction radius for objects
    [Tooltip("Position to check if the player is grounded.")]
    [Space(15)] public Transform groundCheck;
    [Tooltip("Radius for checking if the player is grounded.")]
    [Range(0, 1)] public float groundRadius; // Ground check radius
    [Tooltip("Position to check if the player under a low ceiling.")]
    [Space(15)] public Transform ceilingCheck;
    [Tooltip("Radius for checking if player has to crouch.")]
    [Range(0, 1)] public float ceilingRadius; // Ground check radius

    // Player State and Physics
    [HideInInspector] public bool isPushing; // Flag indicating if the player is pushing an object
    [HideInInspector] public bool isGrounded, shouldJump; // Flag indicating if the player is on the ground
    [HideInInspector] public bool isCrouching, crouchInput; // Flag indicating if the player is on the ground
    private Animator animator; // Animator for animations
    private Rigidbody rb; // Rigidbody for physics interactions

    // Private Movement Variables
    private float spinY, spinX, x, z; // Variables for controlling rotation and movement
    // Initialization Method
    private void Start()
    {
        UnityEngine.Cursor.visible = false;
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update Method
    void Update()
    {
        Walking(); // Controls the movement of the player
        Crouching();
        Spinning(); // Controls the player's rotation
        Jumping(); // Controls the player's jump
        Pushing(); // Handles object pushing action
        Attack();
    }

    private void FixedUpdate()
    {
        if (shouldJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * (jumpForce * 2), ForceMode.Impulse);
            isGrounded = false;
            shouldJump = false;
        }
    }

    // Method to control walking (movement)
    public void Walking()
    {
        x = Input.GetAxis("Horizontal"); // Movement along the X axis
        z = Input.GetAxis("Vertical"); // Movement along the Z axis

        // Set animator values for walking
        animator.SetFloat("SpeedX", !isPushing ? x : 0); // Do not move in X if pushing
        animator.SetFloat("SpeedZ", z); // Z axis movement

        // Move the player
        transform.Translate( (!isPushing && !isCrouching ? x : 0) * Time.deltaTime * speed,0, z * Time.deltaTime * (isPushing ? speed * (1 - pushSpeedDecrease / 100.0f): isCrouching? speed * (1 - crouchSpeedDecrease / 100.0f): speed ));
    }

    // Method to handle rotation (spinning)
    public void Spinning()
    {
        
        spinY = Input.GetAxis("Mouse X"); // Y-axis rotation
        spinX = Input.GetAxis("Mouse Y"); // X-axis rotation

        // Rotate the player (do not rotate if pushing)
        transform.Rotate(0, isPushing ? 0 : (spinY * Time.deltaTime * (rotationSpeed * 5)), 0);

        // Handle camera rotation in Y when pushing
        if (isPushing)
        {
            cameraAim.transform.Rotate(0, spinY * Time.deltaTime * rotationSpeed * 5, 0, Space.Self);
        }
        else if (cameraAim.transform.localEulerAngles.y != 0)
        {
            float newYAngle = Mathf.MoveTowardsAngle(cameraAim.transform.localEulerAngles.y, 0, (rotationSpeed * 5) * Time.deltaTime);
            cameraAim.transform.localEulerAngles = new Vector3(cameraAim.transform.localEulerAngles.x, newYAngle, 0);
        }

        // Control camera's X-axis rotation
        cameraAim.transform.Rotate(
            cameraAim.transform.eulerAngles.x > 180 && cameraAim.transform.eulerAngles.x <= 350 ? 0.1f :
            cameraAim.transform.eulerAngles.x < 180 && cameraAim.transform.eulerAngles.x >= 75 ? -0.1f :
            -(spinX * Time.deltaTime * rotationSpeed), 0, 0);
    }

    // Gizmo Drawing for interaction radius
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pushCheck.position, pushRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        Gizmos.DrawWireSphere(ceilingCheck.position, ceilingRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(cameraAim.position, cameraAim.transform.localScale.x);
    }

    // Jumping method
    public void Jumping()
    {
        Collider[] hitColliders = Physics.OverlapSphere(groundCheck.position, groundRadius);
        bool foundGround = false;

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.transform.gameObject != this.gameObject && !hitCollider.isTrigger)
            {
                foundGround = true;
                break;
            }
        }

        // Use Raycast as a backup check
        if (!foundGround)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, groundRadius + 0.1f))
            {
                if (hit.collider.gameObject != this.gameObject && !hit.collider.isTrigger)
                {
                    foundGround = true;
                }
            }
        }

        isGrounded = foundGround;

        // Jumping Logic
        if (Input.GetButton("Jump") && isGrounded && !isCrouching)
        {
            shouldJump = true;
        }

        animator.SetBool("Jumping", !isGrounded);
    }


    public void Crouching()
    {
        if (Input.GetButton("Crouch") && isGrounded)
        {
            crouchInput = true;
        }
        if (Input.GetButtonUp("Crouch"))
        {
            crouchInput = false;
        }

        if (!crouchInput) 
        {
            bool foundCollider = false;
            Collider[] colliders = Physics.OverlapSphere(ceilingCheck.position, ceilingRadius);
            // If the character has a ceiling preventing them from standing up, keep them crouching
            for(int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != this.gameObject && !colliders[i].isTrigger)
                {
                    foundCollider = true;
                }
            }
            isCrouching = foundCollider;
        }
        else
        {
            isCrouching = true;
        }
        Debug.Log(isCrouching);
        animator.SetBool("Crouching", isCrouching);
    }

    // Pushing method for interacting with objects
    public void Pushing()
    {
        DetectInteractionFormFront(); // Check for objects in front of the player

        if (Input.GetButtonUp("Push"))
        {
            animator.SetBool("Pushing", false); // Deactivate pushing animation
            isPushing = false; // Stop pushing
        }
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Attack") && !isPushing && !isCrouching && isGrounded)
        {
            animator.SetTrigger("Attack"); // Deactivate pushing animation
        }
    }

    // Method to detect objects in front of the player for interaction
    public void DetectInteractionFormFront()
    {
        Collider[] hitColliders = Physics.OverlapSphere(pushCheck.position, pushRadius);

        if (hitColliders.Length > 0)
        {
            foreach (Collider hitCollider in hitColliders)
            {
                PushingObject pushingObject = hitCollider.transform.GetComponent<PushingObject>();
                PushingParent pushingParent = hitCollider.transform.GetComponent<PushingParent>();

                if (pushingParent != null)
                {
                    pushingParent.PushObject(this, pushCheck);
                }

                if (pushingObject != null || pushingParent != null)
                {
                    if (Input.GetButtonDown("Push"))
                    {
                        animator.SetBool("Pushing", true);
                        isPushing = true;
                    }
                }
            }
        }
    }
}
