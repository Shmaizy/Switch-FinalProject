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
        if (Input.GetKeyDown(KeyCode.Space)) //Will be changed with onCollision when enemies will be in place
        {
            TakeDamage();
            Death();
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
