using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
 
    //[SerializeField] private float attackDamage = 1f;
    //[SerializeField] private float attackSpeed = 1f;
    private float canAttack;
     
    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {

            Debug.Log("die");
        }
    }
}