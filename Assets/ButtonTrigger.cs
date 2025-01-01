using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField] private bool triggerOnce;
    [SerializeField] private UnityEvent myEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggerOnce)
        {
            if (collision.CompareTag("Sheep"))
            {
                myEvent.Invoke();
            }
        }
    }
}
