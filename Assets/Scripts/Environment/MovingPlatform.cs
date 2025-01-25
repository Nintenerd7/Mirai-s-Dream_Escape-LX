using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    public float speed;
    private int currentPoint;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, points[currentPoint].position) > 0.1f)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, points[currentPoint].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            currentPoint = (currentPoint + 1) % points.Length;
        }
    }
}
