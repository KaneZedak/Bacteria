using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBacteria : MonoBehaviour
{
    public GameObject followingObject;
    public Rigidbody2D rigidbody;
    public float followRange;
    public float maxRange;
    public float stretchForce;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(followingObject != null)  {
            Vector2 targetPos = new Vector2(followingObject.transform.position.x, followingObject.transform.position.y);
            Vector2 selfPos = new Vector2(transform.position.x, transform.position.y);
            float distance = (targetPos - selfPos).magnitude;
            Vector2 direction = (targetPos - selfPos).normalized;
            if(distance > followRange) {
                rigidbody.AddForce(direction * Mathf.Lerp(0, stretchForce, (distance - followRange) / maxRange));
            }
        }
    }

    public void setFollowObject(GameObject gameObj) {
        followingObject = gameObj;
    }
}
