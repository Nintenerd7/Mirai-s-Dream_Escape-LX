using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Logic : MonoBehaviour
{
    //Weapon Variables
    public GameObject Sword;
    public bool Attack = true;
    public float CoolDown = 1.0f;
    public bool DoingDamage = false;
    //

    // Update is called once per frame
    void Update()
    {
        //left click input 
        if (Input.GetMouseButtonDown(0))
        {
            if (Attack)
            {
                SwordAttack();
            }
        }
        //end if 
    }

    //Activate Sword
    public void SwordAttack()
    {
        DoingDamage = true;
        Attack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        //AudioSourceController.Instance.PlaySFX("Sword_Slash");
        //animation trigger goes here
        StartCoroutine(CoolDownReset());//activates cooldown before attacking again
    }

    IEnumerator CoolDownReset()
    {
        StartCoroutine(resetAttack());
        yield return new WaitForSeconds(CoolDown);
        Attack = true;
    }
    //
    //reset attack
    IEnumerator resetAttack()
    {
        yield return new WaitForSeconds(1.0f);
        DoingDamage = false;
    }
}
