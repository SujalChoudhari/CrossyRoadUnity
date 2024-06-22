using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{

    public UnityEvent UnityEvent;

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Death")
        {
            // Game Over
            Debug.Log("Game Over");
            UnityEvent.Invoke();
        }
    }
}
