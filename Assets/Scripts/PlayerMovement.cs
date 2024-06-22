using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Button forwardButton;
    public Button backwardButton;
    public float hopDistance = 5.0f; // Distance to move each hop
    public float giantHopDistance = 10.0f; // Distance to move each giant hop
    public float hopHeight = 1.5f; // Height of the hop
    public float giantHopHeight = 2.0f; // Height of the giant hop
    public float hopDuration = 0.4f; // Time it takes to complete each hop
    public float giantHopDuration = 0.5f; // Time it takes to complete each giant hop
    public float doubleClickTime = 0.7f; // Maximum time between clicks for double click

    private bool isHopping = false; // Flag to check if player is hopping
    private float lastClickTime = 0f; // Time of the last button click

    void Start()
    {
        // Attach button listeners
        forwardButton.onClick.AddListener(() => OnButtonClick(Vector3.forward));
        backwardButton.onClick.AddListener(() => OnButtonClick(Vector3.back));
    }

    void OnButtonClick(Vector3 direction)
    {
        if (!isHopping)
        {
            float currentTime = Time.time;
            if (currentTime - lastClickTime < doubleClickTime)
            {
                // Perform a giant hop
                StartCoroutine(Hop(direction, giantHopDistance, giantHopHeight, giantHopDuration));
            }
            else
            {
                // Perform a regular hop
                StartCoroutine(Hop(direction, hopDistance, hopHeight, hopDuration));
            }
            lastClickTime = currentTime;
        }
    }

    IEnumerator Hop(Vector3 direction, float distance, float height, float duration)
    {
        isHopping = true;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + direction * distance;
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            float currentHeight = Mathf.Sin(Mathf.PI * t) * height;
            transform.position = Vector3.Lerp(startPosition, endPosition, t) + Vector3.up * currentHeight;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;
        isHopping = false;
    }
}