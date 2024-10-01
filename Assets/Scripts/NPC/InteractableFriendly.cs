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
    private PlayerGameAction sitAction;

    void Start() {
        base.Start();

        targetChair = null;
        player.playerMounted += onPlayerMounted;
        player.playerDismounted += OnPlayerDismounted;
        sitAction = ScriptableObject.CreateInstance<PlayerGameAction>();
        sitAction.initialize();
    }

    public void Update() {
        if(targetChair != null && sitAction.hasTarget(targetChair)) {
            mountChair(targetChair);
        }
        if(seated) return;
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
        if(collider.gameObject.tag == "chair") {
            sitAction.addTarget(collider.gameObject);
            if(targetChair == collider.gameObject) mountChair(targetChair);
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.tag == "chair") {
            sitAction.removeTarget(collider.gameObject);
        }
    }

    void mountChair(GameObject chairToMount) {
        rigidbody.velocity = new Vector2(0, 0);
        rigidbody.angularVelocity = 0;
        chairToMount.GetComponent<CHAIR>().mountSeat(this.gameObject);
        seated = true;
    }
    void onPlayerMounted() {
        GameObject[] chairs;
        chairs = GameObject.FindGameObjectsWithTag("chair");
        foreach(GameObject chair in chairs) {
            if(chair.GetComponent<CHAIR>().isVaccant()) {
                targetChair = chair;
                break;
            }
        }
    }

    void OnPlayerDismounted() {
        if(seated) {
            seated = false;
            
        }
        if(targetChair != null) targetChair.GetComponent<CHAIR>().unmount();
        targetChair = null;
    }

}
