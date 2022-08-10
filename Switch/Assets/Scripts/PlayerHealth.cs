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

    [SerializeField] Animator animator;

    public HealthController healthbar;
    public PlayerMana PlayerMana;

    void Awake()
    {
        
        PlayerMana = GetComponent<PlayerMana>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy")) //Player takes damage on collision
        {
            

            switch (script.Chara)
            {
                case 0:
                    
                    TakeDamage();
                    Invulnerability();
                    break;

                case 1: 
                    if (!Input.GetKey(KeyCode.Space))
                    {
                        
                        TakeDamage();
                        Invulnerability();
                    }
                    break;

                case 2:
                    TakeDamage();
                    Invulnerability();
                    break;
            }
        }

    }
    void TakeDamage()
    {
        if(currentHealth > 0)
        {
            animator.SetBool("IsHit", true);
            FindObjectOfType<AudioManager>().Play("Player damage");
            currentHealth = currentHealth - damage;
            healthbar.SetHealth(currentHealth);
            StartCoroutine(AnimationEvents.instance.AnimationEndPoint("IsHit", false, "Hit"));
            Death();
        }
    }

    IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);

        yield return new WaitForSeconds(1);

        Physics2D.IgnoreLayerCollision(6, 7, false);
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

