using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    // Declare variables.
    public float speed = 5f;
    private float leftScreenEdge;

    // Set the left screen position for event trigger.
    private void Start()
    {
        leftScreenEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        // Move pipes to the left.
        transform.position += Vector3.left * speed * Time.deltaTime;

        // Once pipes are not visible on lefthand side of screen, remove pipe object instance.
        if(transform.position.x < leftScreenEdge)
        {
            Destroy(gameObject);
        }
    }


}
