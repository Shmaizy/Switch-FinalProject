using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("player movment")]
    public float Speed;
    public float rotationSpeed;
    public KeyControl script;
    public PlayerHealth playerHealth;
    Rigidbody m_Rigidbody;
    Vector3 movementDirection;

   [Header("Animation properties")]
    [SerializeField] Animator animator;
    public RuntimeAnimatorController odinAnim;
    public RuntimeAnimatorController aresAnim;
    public RuntimeAnimatorController horusAnim;

    public Avatar odinAvatar;
    public Avatar aresAvatar;
    public Avatar horusAvatar;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        playerMovment();
       
    }

    private void FixedUpdate()
    {
        if (playerHealth.isAlive && animator.GetCurrentAnimatorStateInfo(0).IsName("Running"))
        {
            RB();
        }
            
    }

    void playerMovment()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");


        movementDirection = new Vector3(VerticalInput, 0, -horizontalInput);
        movementDirection.Normalize();


        //applies on rotation
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

        //Avatar and animator settings
        switch (script.Chara)
        {
            case 0:
                animator.runtimeAnimatorController = aresAnim;
                animator.avatar = aresAvatar;
                break;

            case 1:
                animator.runtimeAnimatorController = odinAnim;
                animator.avatar = odinAvatar;
                break;

            case 2:
                animator.runtimeAnimatorController = horusAnim;
                animator.avatar = horusAvatar;
                break;
        }


    }

    void RB()
    {
        //applies on RB
         m_Rigidbody.MovePosition(transform.position += movementDirection * Time.deltaTime * Speed);
    }
}


