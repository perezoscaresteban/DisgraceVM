using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private float speed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float groundDrag;

    [Header("Jumping")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float airMultiplier;
    private bool readyToJump = true;

    [Header("Crouching")]
    [SerializeField] private float crouchSpeed;
    [SerializeField] private float crouchYScale;
    private float startYScale;

    [Header("KeyBinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftControl;
    public KeyCode crouchKey = KeyCode.LeftShift;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Slope Handling")]
    [SerializeField] private float maxSlopeangle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    public MovementState movementState;

    public enum MovementState
    {
        walking,
        sprinting,
        crouching,
        air
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation= true;

        startYScale = transform.localScale.y;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyImputs();
        speedControl();
        StateHandler();

        // on slope
        if (OnSlope() && !exitingSlope)
        {
            rb.AddForce(GetSlopeMoveDirection() * speed * 20f, ForceMode.Force);

            if (rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * 80f, ForceMode.Force);
            }
        }

        // turn gravity of on slope
        rb.useGravity = !OnSlope();


        // in air
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void MyImputs()
    { 
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if (Input.GetKey(jumpKey) && readyToJump && grounded) 
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump),jumpCooldown);
        }

        // start crouch
        if (Input.GetKeyDown(crouchKey)) 
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        // stop crouch
        if (Input.GetKeyUp(crouchKey)) 
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }

    private void MovePlayer() 
    { 
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
            rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * speed * 10f * airMultiplier, ForceMode.Force);
    }


    private void Move(Vector3 moveDir)
    {
        transform.position += (moveDir.x * transform.right + moveDir.z * transform.forward) * (speed * Time.deltaTime);
    }

    private void speedControl() 
    {
        // limit speed on slope
        if (OnSlope() && !exitingSlope)
        {
            if (rb.velocity.magnitude > speed)
            {
                rb.velocity = rb.velocity.normalized * speed;
            }
        }
        else
        {
            // limit speed on ground in air
            Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            // limit velocity if need
            if (flatVel.magnitude > speed)
            {
                Vector3 limitedVel = flatVel.normalized * speed;
                rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
            }
        }

    }

    private void Jump()
    {
        exitingSlope = true;

        // reset velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump() 
    {
        readyToJump = true;
        exitingSlope = false;
    }



    private void StateHandler()
    {
        // mode crouching
        if (Input.GetKey(crouchKey)) 
        {
            movementState = MovementState.crouching;
            speed = crouchSpeed;
        }
        // mode sprinting
        else if (grounded && Input.GetKey(sprintKey))
        {
            movementState = MovementState.sprinting;
            speed = sprintSpeed;
        }

        // mode grounded
        else if (grounded)
        {
            movementState = MovementState.walking;
            speed = walkSpeed;
        }
        else
        {
            movementState = MovementState.air;
        }
    }

    private bool OnSlope() 
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeangle && angle != 0; 
        }
        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }
}