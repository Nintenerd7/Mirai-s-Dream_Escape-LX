using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 1f;
    public float destroyDelay = 2f;
    public bool respawn = true;
    public float respawnDelay = 5f;


    private Vector3 initialPosition;
    private Rigidbody rb;

    public Animator onPlayerCollision;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player touched platform. Starting fall coroutine.");
            StartCoroutine(Fall());
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    private IEnumerator Fall()
    {
        onPlayerCollision.SetTrigger("PlayerTouch");
        yield return new WaitForSeconds(fallDelay);
        rb.isKinematic = false;
        yield return new WaitForSeconds(destroyDelay);
        onPlayerCollision.gameObject.SetActive(false);
        if (respawn)
        {
            yield return new WaitForSeconds(respawnDelay);
            rb.isKinematic = true;
            onPlayerCollision.gameObject.SetActive(true);
            transform.position = initialPosition;
        }
    }
}
