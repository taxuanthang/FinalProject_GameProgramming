using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Vector3 targetPosition; // The target position to move to
    public float duration = 2f;      // Duration of the movement in seconds

    private Rigidbody2D rb;
    private Collider2D c2D;

    private bool isMoving = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void MoveDoorTrigger() 
    {
        isMoving = false;
    }

    void Update()
    {
        // Example trigger: Start moving the object when spacebar is pressed
        if (!isMoving)
        {
        StartCoroutine(MoveToPosition(transform, targetPosition, duration));
        }
    }

    private IEnumerator MoveToPosition(Transform objectToMove, Vector3 target, float time)
    {
        isMoving = true;
        Vector3 startPosition = objectToMove.position;
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            objectToMove.position = Vector3.LerpUnclamped(startPosition, target, elapsedTime / time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        objectToMove.position = target; // Ensure it reaches the exact target
        isMoving = false;
    }
}
