using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NanoSpawn : MonoBehaviour
{
    public UnityEvent afterEnter;

    private bool playerEntered = false;
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "player" && !playerEntered) {
            playerEntered = true;
            afterEnter.Invoke();
        }
    }
}
