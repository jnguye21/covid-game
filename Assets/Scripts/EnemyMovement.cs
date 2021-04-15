using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float followSpeed = 4f;
    [SerializeField] private int enemyDamage = 1;
    [SerializeField] private float enemyAttackDelay = 1.2f;
    [SerializeField] private float enemyAttackTimer = 1.2f;

    bool attackReady = true;
    Transform target;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else
        {
            return;
        }
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, followSpeed * Time.deltaTime);
        }
        else{ return; }

        if (!attackReady)
        {
            enemyAttackTimer -= Time.deltaTime;
            if(enemyAttackTimer <= 0) { attackReady = true; }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && attackReady)
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
            attackReady = false; //Wait a certain amount of time before able to deal damage again
            enemyAttackTimer = enemyAttackDelay;
        }
    }
}
