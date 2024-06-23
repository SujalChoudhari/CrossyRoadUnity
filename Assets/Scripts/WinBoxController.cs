using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinBoxController : MonoBehaviour
{
    public UnityEvent OnWinCallback;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Win");
            OnWinCallback?.Invoke();
        }
    }
}
