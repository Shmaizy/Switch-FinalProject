using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public Transform target;

    public void Attack()
    {
        
        //detects enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers); //creates a circle that will be the range of our attack

        //damage them
        foreach (Collider enemy in hitEnemies)
        {
           
            enemy.GetComponent<EnemyAI>().TakeDamage(50);
        }  

    }

    private void OnDrawGizmosSelected() //draw gizmos that are also pickable and always drawn. This allows  to quickly pick important objects in your Scene
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
