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

        //applies on transform
        if (playerHealth.isAlive &!Input.GetKey(KeyCode.Space))
        {
            transform.Translate(movementDirection * Speed * Time.deltaTime, Space.World); 
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

            //applies on rotation
            if (movementDirection != Vector3.zero) 
            {
                animator.SetBool("IsMoving", true);
                Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            //don't move when special abillity is on
              if (playerHealth.isAlive &!Input.GetKeyDown(KeyCode.Space))
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


