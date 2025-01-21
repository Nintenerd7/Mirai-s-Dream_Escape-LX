using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon_Switcher : MonoBehaviour
{
  //bullet index
  public static Weapon_Switcher Instance;
  public GameObject Weapon;
  public Weapon_Index[] WEAPONS;
  public bool isShooting;
      private void Awake()
    {
        if (Instance == null)//if there is no instance in the audio source
        {
            Instance = this;//set instance to the index of the sound name.
            //DontDestroyOnLoad(gameObject);//do not destroy
        }
    }
      private void Start()
    {
        SwitchWeapon("Gun");
    }
    public void SwitchWeapon(string Name)
    {
        Weapon_Index s = Array.Find(WEAPONS, X => X.WeaponName == Name);

        if (s == null)
        {
          isShooting = false;
            Debug.Log("Error");
        }
        else
        {
          isShooting = true;
          Weapon = s.WeaponType;
        }
    }
}
