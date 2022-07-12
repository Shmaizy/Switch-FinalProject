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



    private Animator animator;
    public RuntimeAnimatorController odinAnim;
    public RuntimeAnimatorController aresAnim;
    public RuntimeAnimatorController horusAnim;

    public Avatar odinAvatar;
    public Avatar aresAvatar;
    public Avatar horusAvatar;

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

        if (playerHealth.isAlive)
        {
            transform.Translate(movementDirection * Speed * Time.deltaTime, Space.World);

        }

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

            if (movementDirection != Vector3.zero)
            {
                animator.SetBool("IsMoving", true);
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            if (playerHealth.isAlive)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
                
            }

            else
            {
                animator.SetBool("IsMoving", false);
            }

        }
    }


