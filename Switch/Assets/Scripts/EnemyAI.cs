using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [Header("EnemyAI")]
    public GameObject Player;
    public float Distance;

    public bool isAngered;

    public NavMeshAgent _agent;
    private Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        NavemashConfig();
    }

    void NavemashConfig()
    {
        Distance = Vector3.Distance(Player.transform.position, this.transform.position); //Navemash distans and angered setting

        if (Distance <= 6)
        {
            isAngered = true;
        }

        if (Distance > 6)
        {
            isAngered = false;
        }

        if (isAngered)
        {
            animator.SetBool("IsMoving", true);
            _agent.isStopped = false;
            _agent.SetDestination(Player.transform.position);
        }

        if (!isAngered)
        {
            animator.SetBool("IsMoving", false);
            _agent.isStopped = true;
        }
    }

    public void TakeDamage(int Damage)
    {
        currentHealth -= Damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");

        animator.SetBool("IsDead", true);

        GetComponent<Collider>().enabled = false;
        this.enabled = false;
    }


    void OnTriggerEnter(Collider col) //zombie attack machenics
    {
        if (col.gameObject.CompareTag("Player") && Distance < 1)
        {
            animator.SetTrigger("Attecking");
        }

    }

}
