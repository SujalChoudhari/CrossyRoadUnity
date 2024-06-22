using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 30.0f; // Speed at which the car moves
    public float lifetime = 10.0f; // Time after which the car will be destroyed
    public float acceleration = 50.0f; // Acceleration of the car

    void Start()
    {
        // Schedule the car for destruction after 'lifetime' seconds
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the car forward at the specified speed
        speed += acceleration * Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
