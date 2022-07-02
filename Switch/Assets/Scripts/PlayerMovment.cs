using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("PlayerMovment")]
    public float moveSpeed;

    public float goundDrag;

    [Header("AnimationTransition")]
    private Animator animator;

    [Header(" Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform Oriantation;

    float horizontalInpt;
    float verticalInput;

    float moveDirection;

    public float mouseXAxis;
    public float mouseYAxis;
    public float Horizontal;
    public float Vertical;

    Rigidbody rb;

    private void Start()
    {
        animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        mouseXAxis = Input.GetAxis("Mouse X");
        mouseYAxis = Input.GetAxis("Mouse Y");
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        //Ground Check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();
        //SpeedControl();

        //Handle drag
        if (grounded)
        {
            rb.drag = goundDrag;
        }

        else
        {
            rb.drag = 0;
        }

    }

    private void FixedUpdate()
    {
        MovePlayer(new Vector3(horizontalInpt, 0 , verticalInput).normalized);
    }

    private void MyInput()
    {
        //Input Function
        horizontalInpt = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer(Vector3 direction)
    {
        //Move player function, calculate movment direction
        rb.velocity = direction * moveSpeed;

        //moveDirection = Oriantation.forward * verticalInput + Oriantation.forward * horizontalInpt;
        //rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    //private void SpeedControl()
    //{
    //    Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.y);

    //    //limit velociry if needed, if i go faster than my moveSpeed apply below
    //    if (flatVel.magnitude > moveSpeed)
    //    {
    //        Vector3 limitedVel = flatVel.normalized * moveSpeed;
    //        rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);

    //    }
    //}
}
