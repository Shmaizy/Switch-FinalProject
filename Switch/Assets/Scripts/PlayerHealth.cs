using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("PlayerHealth")]

    public int maxHealth;
    public int currentHealth;
    public int damage;

    public HealthController healthbar;
    
    void Awake ()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        
    }

    void Update()
    {
        void OnCollisionEnter(Collision col)
         {
            if (col.gameObject.CompareTag("Enemy") && CompareTag("Odin, Horus"))
            {
                TakeDamage();
                Death();
            }
        }

        void TakeDamage()
        {
            currentHealth = currentHealth - damage;
            healthbar.SetHealth(currentHealth);
        }

        void Death()
        {
            if (currentHealth == 0)
            {
                Debug.Log("You Died");
            }

            else
            {
                Debug.Log("Carry on");
            }
        }
    }
   
}

