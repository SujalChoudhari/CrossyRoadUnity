using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{

    public UnityEvent gameOverCallback;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Death")
        {
            // Game Over
            Debug.Log("Game Over");
            gameOverCallback.Invoke();
        }
    }
}
