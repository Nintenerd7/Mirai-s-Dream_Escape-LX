using System.Collections;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject grenadeObject;
    public ParticleSystem[] particles;
    public float FuseTime = 3;
    public float ExplosionRadius = 5;
    public float ExplosionForce = 700;
    public AnimationCurve ForcePerDistance;

    void Start()
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(FuseTime);
        grenadeObject.SetActive(false);
        foreach (ParticleSystem particle in particles)
        {
            particle.Play();
        }
        ApplyExplosionForce();
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void ApplyExplosionForce()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
        foreach (Collider hit in colliders)
        {
            if (hit.TryGetComponent<Rigidbody>(out var rb))
            {
                if (rb != GetComponent<Rigidbody>()) {
                    float distance = Vector3.Distance(transform.position, rb.position);
                    float force = ForcePerDistance.Evaluate(distance / ExplosionRadius) * ExplosionForce;
                    Debug.Log("Applying force: " + force + " to " + rb.name);
                    rb.AddExplosionForce(force, transform.position, ExplosionRadius);
                }
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}
