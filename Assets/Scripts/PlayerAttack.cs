using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask enemyDef;
    /* following two Animators should be used for attack animations
    public Animator camAnim;
    public Animator playerAnim;
    */
    public float attackRange;
    public int damage;

    void Update(){

        if(timeBtwAttack <= 0){
            // attack ready
            if(Input.GetKey(KeyCode.Space)){
                //camAnim.SetTrigger("shake");
                //playerAnim.SetTrigger("attack");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyDef);
                for (int i = 0; i < enemiesToDamage.Length; i++) {
                    enemiesToDamage[i].GetComponent<EnemyMovement>().TakeDamage(damage);
                }
                timeBtwAttack = startTimeBtwAttack;
            }

            
        } else {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected(){

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
