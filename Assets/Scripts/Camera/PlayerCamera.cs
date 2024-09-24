using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject followingPlayer;
    public GameObject boundingBox;
    public float minFollowingVelocity;
    public float followSpeed;
    public Vector2 playerVelocity;
    public float trackingRange;
    private Rigidbody2D playerRigidBody;
    private Rect boundingRect;
    private bool isTracking = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = followingPlayer.GetComponent<Rigidbody2D>();
        isTracking = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate() {
        
        if(followingPlayer) {
            Vector2 playerPos = new Vector2(followingPlayer.transform.position.x, followingPlayer.transform.position.y);
            Vector2 cameraPos = new Vector2(this.transform.position.x, this.transform.position.y);
            
            Vector2 cameraVelocity;
            
            float rangeToPlayer = ((cameraPos - playerPos).magnitude);
            /*
            if(rangeToPlayer > trackingRange) {
                isTracking = true;
            }

            if(isTracking) {
                if(rangeToPlayer < followSpeed * Time.deltaTime) {
                    transform.Translate(playerPos - cameraPos);
                    isTracking = false;
                } else {                
                    cameraVelocity = (playerPos - cameraPos).normalized * 5f;
                    transform.Translate(cameraVelocity * Time.deltaTime);
                }
            }*/

            cameraVelocity = (playerPos - cameraPos).normalized * Mathf.Lerp(0, Mathf.Max(playerRigidBody.velocity.magnitude, followSpeed), rangeToPlayer / trackingRange);
            transform.Translate(cameraVelocity * Time.deltaTime);
            /*
            if(boundingRect.Contains(playerPos)) {
                cameraVelocity = (playerPos - cameraPos) * followingVelocity;
            }*/
            /*
            Vector2 panningVelocity = playerRigidBody.velocity1;
            Vector2 trackingVelocity = (playerPos - cameraPos).normalized * minFollowingVelocity;*/
            /*
            if(boundingRect.Contains(playerPos)) {
                cameraVelocity = panningVelocity * trackingVelocity;
                
            } else {
                cameraVelocity = panningVelocity;
            }*/
            /*
            if(!boundingRect.Contains(playerPos)) {
                cameraVelocity = panningVelocity;
                transform.Translate(cameraVelocity * Time.deltaTime);
            }*/

            
            /*
            {
                cameraVelocity = followingPlayer.GetComponent<Rigidbody2D>().velocity;
            }*/
            
            
        }
    }

    public void followPlayer(GameObject bacteria) {
        followingPlayer = bacteria;
        playerRigidBody = followingPlayer.GetComponent<Rigidbody2D>();
    }
    public void trackToPlayer() {
        isTracking = true;
    }
}
