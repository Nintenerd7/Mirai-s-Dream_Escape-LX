using System.Collections;
using UnityEngine;

public class GrenadeSpawner : MonoBehaviour
{
    public GameObject GrenadePrefab;
    public float MaxLaunchStrength = 50;
    public float MinLaunchStrength = 5;
    public float GrenadeReloadTime = 1; 
    public GameObject GrenadeInHand;
    private bool _IsGrenadeReady = true;
    private Animator _Animator;

    private void Awake() {
        _Animator = GetComponent<Animator>();
        _Animator.SetFloat("ChargeSpeed", 1 / MaxChargeTime);
    }

    public void LaunchGrenade() {
        _IsGrenadeReady = false;
        float LaunchStrength = Mathf.Lerp(MinLaunchStrength, MaxLaunchStrength, _ChargeTime / MaxChargeTime);
        GrenadeInHand.transform.parent = null;
        GrenadeInHand.GetComponent<Collider>().enabled = true;
        GrenadeInHand.GetComponent<Rigidbody>().isKinematic = false;
        GrenadeInHand.GetComponent<Rigidbody>().AddForce(transform.forward * LaunchStrength, ForceMode.Impulse);
        GrenadeInHand.GetComponent<Grenade>().LaunchGrenade();//edited due to both launch grenade voids were named after eachother.
        GrenadeInHand = null;
        StartCoroutine(ReloadGrenade());
    }

    private IEnumerator ReloadGrenade() {
        yield return new WaitForSeconds(GrenadeReloadTime);
        CreateNewGrenade();
    }

    private bool _IsChargingThrow = false;
    private float _ChargeTime = 0;
    public float MaxChargeTime = 3;

    void CreateNewGrenade() {
        if (GrenadeInHand != null) {
            Destroy(GrenadeInHand);
        }

        GrenadeInHand = Instantiate(GrenadePrefab, transform.position, transform.rotation);
        GrenadeInHand.transform.parent = transform;
        GrenadeInHand.GetComponent<Rigidbody>().isKinematic = true;
        GrenadeInHand.GetComponent<Collider>().enabled = false;
        _IsGrenadeReady = true;
    }

    void Update() {
        if (_IsGrenadeReady) {
            if (Input.GetMouseButton(0))
            {
                if (_IsChargingThrow == false) _ChargeTime = 0;
                _IsChargingThrow = true;
                _Animator.SetBool("IsCharging", true);
            }
            if (Input.GetMouseButtonUp(0))
            {
                _IsChargingThrow = false;
                _Animator.SetBool("IsCharging", false);
                LaunchGrenade();
            }
            if (_IsChargingThrow)
            {
                _ChargeTime += Time.deltaTime;
                if (_ChargeTime > MaxChargeTime)
                {
                    _ChargeTime = MaxChargeTime;
                }
            }
        }
    }
}
