using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("PlayerHealth")]

    public int maxHealth;
    public int currentHealth;

    public int damage;
    public int heal;

    public KeyControl script;
    public bool isAlive => currentHealth > 0; //lamda expresion

    [SerializeField] private Animator animator;

    public HealthController healthbar;
    public PlayerMana PlayerMana;

    void Awake()
    {
        animator = GetComponent<Animator>();
        PlayerMana = GetComponent<PlayerMana>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy")) //Player takes damage on collision
        {
            switch(script.Chara)
            {
                case 0:
                    TakeDamage();
                    break;

                case 1: 
                    if (!Input.GetKey(KeyCode.Space))
                    {
                        TakeDamage();
                    }
                    break;

                case 2:
                    TakeDamage();
                    break;
            }
        }
    }
    void TakeDamage()
    {
        if(currentHealth > 0)
        {
            currentHealth = currentHealth - damage;
            healthbar.SetHealth(currentHealth);
            Death();
        }

    }

    void Death()
    {
        if (currentHealth == 0 && animator.GetBool ("IsDead")== false)
        {
            animator.SetBool("IsDead", true);
            FindObjectOfType<GameManager>().EndGame();
        }

        else
        {
            animator.SetBool("IsDead", false);
            Debug.Log(currentHealth);

        }
    }

    public void Healing()
    {
        if(PlayerMana.currentMana > 0)
        {
            Debug.Log("Extra Health");
            currentHealth = currentHealth + heal;
            healthbar.SetHealth(currentHealth);
        }

    }

}

