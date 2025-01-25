using UnityEngine;

public class WeaponManager : MonoBehaviour
{
  public GameObject[] Weapon;
  public int CurrentWeapon = 0;

  // TODO: Weapon switching animations
  public void Awake() {
    foreach (GameObject weapon in Weapon) {
      weapon.SetActive(false);
    }
    Weapon[CurrentWeapon].SetActive(true);
  }

  public void Update() {
    if (Input.GetKeyDown(KeyCode.Alpha1)) {
      SwitchWeapon(0);
    }
    if (Input.GetKeyDown(KeyCode.Alpha2)) {
      SwitchWeapon(1);
    }
    if (Input.GetKeyDown(KeyCode.Alpha3)) {
      SwitchWeapon(2);
    }
  }

  public void SwitchWeapon(int weaponIndex) {
    if (weaponIndex < 0 || weaponIndex >= Weapon.Length) {
      Debug.LogError("Invalid weapon index: " + weaponIndex);
      return;
    }
    Weapon[CurrentWeapon].SetActive(false);
    CurrentWeapon = weaponIndex;
    Weapon[CurrentWeapon].SetActive(true);
  }
}
