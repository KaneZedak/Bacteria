using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{
    public GameObject OuterSpace;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(target) {
        }
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "player") {
            target = collider.gameObject;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.gameObject.tag == "player") {
            collision.collider.gameObject.transform.position = OuterSpace.transform.position;
        }
    }
    
}
