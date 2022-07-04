using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("player movment")]
    public float Speed;
    public float rotationSpeed;
    [SerializeField] List<GameObject> charecters;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, VerticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * Speed * Time.deltaTime, Space.World);

        //foreach (GameObject player in charecters)
        //{

            if (movementDirection != Vector3.zero)
            {
                animator.SetBool("IsMoving", true);
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }

            else
            {
                animator.SetBool("IsMoving", false);
            }
       // }

         
              
    }
}
