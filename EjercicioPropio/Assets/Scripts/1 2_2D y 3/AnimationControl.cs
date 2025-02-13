using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public CharacterMovement controller;
    public Animator animator;
    public float runSpeed = 40f;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;
    private float previousYPosition;

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        previousYPosition = transform.position.y;
    }

    private void Update()
    {
        // Handle movement input
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // Handle jumping
        if (Input.GetButtonDown("Jump"))
            jump = true;

        if (Input.GetButton("Jump") && !controller.m_Grounded)
            animator.SetBool("Jump", true);

        // Calculate vertical movement for jump animation (allowing negative values)
        float jumpSpeed = transform.position.y - previousYPosition;
        animator.SetFloat("JumpSpeed", jumpSpeed);

        // Handle crouching
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
          //  animator.SetBool("Crouch", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
           // animator.SetBool("Crouch", false);
        }

        // Handle attack
        if (Input.GetButtonDown("Attack"))
            animator.SetTrigger("Attack");

    }
    private void LateUpdate()
    {
        previousYPosition = transform.position.y;
    }

    private void FixedUpdate()
    {
        // Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("Jump", false);
    }

    public void OnCrouch(bool isSliding)
    {
        animator.SetBool("Crouch", isSliding);
    }
}
