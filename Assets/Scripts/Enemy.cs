using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Player player;
    public float attackDistance;
    public int damage;
    public int health;

    private bool isAttacking;
    private bool isDead;

    public NavMeshAgent agent;

    private void Update()
    {
        if(isDead)
            return;

        if(Vector3.Distance(transform.position,player.transform.position) <= attackDistance)
        {
            agent.isStopped = true;
            
            if(!isAttacking)
                Attack();
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }

    }

    void Attack()
    {
        isAttacking = true;

        Invoke("TryDamage", 1.3f);
        Invoke("DisableIsAttacking", 2.66f);

    }
    void TryDamage()
    {
        if(Vector3.Distance(transform.position,player.transform.position)<= attackDistance)
        {
            player.TakeDamage(damage);
        }
    }
    void DisableIsAttacking()
    {
        isAttacking = false;
    }
    public void TakeDamage(int damageToTake)
    {
        health -= damageToTake;

        if(health <= 0)
        {
            isDead = true;
            agent.isStopped = true;
            //disable anim
        }
    }
}
