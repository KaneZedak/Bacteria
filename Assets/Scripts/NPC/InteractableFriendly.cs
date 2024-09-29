using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableFriendly : FriendlyBacteria
{

    public UnityEvent afterEnter;

    private bool playerEntered = false;
    private GameObject targetChair;
    private bool seated = false;

    void Start() {
        base.Start();
        targetChair = null;
        player.playerMounted += onPlayerMounted;
        player.playerDismounted += OnPlayerDismounted;
    }
    public void Update() {
        if(targetChair) {
            targetPos = targetChair.transform.position;
            moveTowardTargetPos();
        } else if(followingObject != null)  {
            targetPos = new Vector2(followingObject.transform.position.x, followingObject.transform.position.y);
            moveTowardTargetPos();
        }
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "player" && !playerEntered) {
            playerEntered = true;
            afterEnter.Invoke();
        }
        if(collider.gameObject.tag == "chair" && collider.gameObject == targetChair) {
            collider.gameObject.GetComponent<CHAIR>().mountSeat(this.gameObject);
            seated = true;
        }
    }

    void onPlayerMounted() {
        GameObject[] chairs;
        chairs = GameObject.FindGameObjectsWithTag("chair");
        foreach(GameObject chair in chairs) {
            if(!chair.GetComponent<CHAIR>().isVaccant()) {
                targetChair = chair;
                break;
            }
        }
    }

    void OnPlayerDismounted() {
        if(seated) {
            seated = false;
        }
        targetChair = null;
    }

}
