using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeSpawner : MonoBehaviour
{
    public GameObject GrenadePrefab;
    public float MaxLaunchStrength = 50;
    public float MinLaunchStrength = 5;
    public GameObject LaunchGrenade() {
        float LaunchStrength = Mathf.Lerp(MinLaunchStrength, MaxLaunchStrength, _ChargeTime / _MaxChargeTime);
        GameObject grenade = Instantiate(GrenadePrefab, transform.position, transform.rotation);
        grenade.GetComponent<Rigidbody>().AddForce(transform.forward * LaunchStrength, ForceMode.Impulse);
        return grenade;
    }

    private bool _IsChargingThrow = false;
    private float _ChargeTime = 0;
    private float _MaxChargeTime = 3;

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            _IsChargingThrow = true;
        }
        if (Input.GetMouseButtonUp(0)) {
            _IsChargingThrow = false;
            LaunchGrenade();
            _ChargeTime = 0;
        }
        if (_IsChargingThrow) {
            _ChargeTime += Time.deltaTime;
            if (_ChargeTime > _MaxChargeTime) {
                _ChargeTime = _MaxChargeTime;
            }
        }
    }
}
