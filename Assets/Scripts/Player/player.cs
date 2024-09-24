using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public Camera mainCamera;
    public float dragForce;
    public float stoppingSpeed;
    public float maxSpeed;
    public float hydration;
    public float stillDrainRate;
    public float movingDrainRate;
    public float maxHydration;
    public float minScale;
    public float maxScale;
    
    float proportion;
    private float originalMass;
    Rigidbody2D rigidbody;
    private Vector2 currentDirection = new Vector2();
    private Vector3 pos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        originalMass = rigidbody.mass;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 scenePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos =  new Vector2(scenePos.x, scenePos.y);
        
        
        if(this.gameObject.GetComponent<Collider2D>().OverlapPoint(scenePos)) {
            rigidbody.drag = 8;
            hydration -= (stillDrainRate * Time.deltaTime);
        } else {
            rigidbody.drag = 1;
            Vector2 movingDirection = mousePos - new Vector2(this.transform.position.x, this.transform.position.y);
            movingDirection = movingDirection.normalized;
            rigidbody.AddForce(movingDirection * dragForce);
            hydration -= (movingDrainRate * Time.deltaTime);
        }*/
        Vector2 direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        direction = direction.normalized;
        rigidbody.AddForce(direction * dragForce);
        hydration -= Mathf.Lerp(stillDrainRate, movingDrainRate, rigidbody.velocity.magnitude / maxSpeed) * Time.deltaTime;
        proportion = hydration / maxHydration * (maxScale - minScale) + minScale;

        this.transform.localScale = new Vector3(proportion, proportion, 1);
        rigidbody.mass = originalMass * proportion;

        if(rigidbody.velocity.magnitude > maxSpeed) {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }

        if(hydration < 0) {
            MyEventSystem.playerDeath();
            Destroy(this.gameObject);
        }
    }
    /*
    public void OnMove(InputValue value) 
    {
        Vector2 direction = value.Get<Vector2>();
        currentDirection = direction;
        
    }*/
    void OnTriggerEnter2D(Collider2D colObj)
    {
        if(colObj.gameObject.tag == "waterdrop") {
            hydration += colObj.gameObject.GetComponent<Waterdrop>().replenish_amount;
            if(hydration > maxHydration) hydration = maxHydration;
            Destroy(colObj.gameObject);
            MyEventSystem.dropletCollected();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "enemy" && collision.collider.gameObject.transform.localScale.x < transform.localScale.x) {
            Destroy(collision.collider.gameObject);
            Experiment.deathCount += 1;
            if(MyEventSystem.OnBacteriaCatch != null) MyEventSystem.OnBacteriaCatch();
        }
    }
}
