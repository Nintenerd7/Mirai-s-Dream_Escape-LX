using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //Target Script: For the enemy taking damage from the players weapons
    public float health = 50f;// max health number

//Damage Enemy Method Holds logic for when the enemy is hit by the weapons 
public void TakeDamage (float amount)//Parameter for how much damage each weapon does to the enemy
{
    health -= amount;//max health decreases from damage taken if enemy is attacked
    if(health <= 0) Die();//if health is less or equal to 0 the enemy will die
}

public void Die()//after health decreases to 0
{
  Destroy(gameObject);//destroys itself
}
}
