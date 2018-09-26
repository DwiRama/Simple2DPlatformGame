using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChestController : MonoBehaviour {
    public Animator animator;
    public UnityEvent onOpenEvent;

    void Awake()
    {
        if (onOpenEvent == null)
            onOpenEvent = new UnityEvent();
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !GameMaster._GM.victory)
        {
            animator.SetBool("Open", true);
            onOpenEvent.Invoke();
        }
    }
}
