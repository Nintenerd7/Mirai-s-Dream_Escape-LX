using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeSpawner : MonoBehaviour
{
    public GameObject GrenadePrefab;
    public int LaunchStrength = 10;
    public GameObject LaunchGrenade() {
        GameObject grenade = Instantiate(GrenadePrefab, transform.position, transform.rotation);
        grenade.GetComponent<Rigidbody>().AddForce(transform.forward * LaunchStrength, ForceMode.Impulse);
        return grenade;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            LaunchGrenade();
        }
    }
}
