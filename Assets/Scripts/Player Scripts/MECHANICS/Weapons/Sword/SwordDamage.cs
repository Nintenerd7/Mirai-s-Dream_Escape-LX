using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
  
    public Weapon_Logic Hitbox;

    public float damage = 10f;
    //

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy"&& Hitbox.DoingDamage)
        {
        Target target = other.GetComponent<Target>();//gets target object reference from target script without being public
        
        if(target != null) target.TakeDamage(damage);// if target is not empty then the enemy will be damaged using the damage number above to pass the parameter
        Debug.Log("you hit a foe");
        }
       
    }

}
