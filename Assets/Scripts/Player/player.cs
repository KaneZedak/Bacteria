using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

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

    public string attackKey = "g";
    public string shareKey = "h";
    public float damageForce;
    public float damageFromBot;

    [SerializeField] private bool enemyInRange = false;
    [SerializeField] private GameObject target = null;
    [SerializeField] private bool friendlyInRange = false;
    [SerializeField] private GameObject friendlyTarget = null;
    [SerializeField] private ConditionObject killedNanocell;
    [SerializeField] private ConditionChecker killChecker;

    public UnityEvent OnInteractWithFriendly;
    public UnityEvent OnFirstMove;
    public UnityEvent AfterMetNanocell;
    public UnityEvent AfterKill;

    private bool metNanocell = false;
    private bool moved = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        originalMass = rigidbody.mass;
        killChecker.initialize();
        killChecker.subscribe(AfterKill.Invoke);
    }

    // Update is called once per frame
    void Update()
    {
        playerStatusUpdate();

        if(Input.GetKeyDown(attackKey)) {
            if(enemyInRange && target != null) {
                Destroy(target);
                target = null;
                enemyInRange = false;
                if(killedNanocell) {
                    if(killedNanocell.value != true) killedNanocell.setValue(true);
                }
            }
        }

        if(Input.GetKeyDown(shareKey)) {
            if(friendlyInRange && friendlyTarget != null) {
                friendlyTarget.GetComponent<FriendlyBacteria>().setFollowObject(this.gameObject);
                friendlyTarget = null;
                friendlyInRange = false;
                hydration = hydration / 2;   
            }
        }

        
    }

    void playerStatusUpdate() {
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

        if(!moved && rigidbody.velocity.magnitude > 2) {
            moved = true;
            OnFirstMove.Invoke();
        }
        if(hydration < 0) {
            MyEventSystem.playerDeath();
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D colObj)
    {
        if(colObj.gameObject.tag == "enemy") {
            if(!metNanocell) {
                metNanocell = true;
                AfterMetNanocell.Invoke();
            }
            enemyInRange = true;
            target = colObj.gameObject;
        }

        if(colObj.gameObject.tag == "friendly") {
            friendlyInRange = true;
            friendlyTarget = colObj.gameObject;
        }
    }


    void OnTriggerExit2D(Collider2D colObj)
    {
        if(colObj.gameObject == target) {
            target = null;
            enemyInRange = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "waterdrop") {
            hydration += collision.collider.gameObject.GetComponent<Waterdrop>().replenish_amount;
            if(hydration > maxHydration) hydration = maxHydration;
            Destroy(collision.collider.gameObject.gameObject);
            MyEventSystem.dropletCollected();
        }
        if(collision.collider.gameObject.tag == "enemy") {
            Vector2 targetPos = new Vector2(collision.collider.gameObject.transform.position.x, collision.collider.gameObject.transform.position.y);
            Vector2 selfPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = (selfPos - targetPos).normalized;
            rigidbody.AddForce(damageForce * direction, ForceMode2D.Impulse);
            hydration -= damageFromBot;
        }
        /*
        if(collision.collider.gameObject.tag == "enemy" && collision.collider.gameObject.transform.localScale.x < transform.localScale.x) {
            Destroy(collision.collider.gameObject);
            Experiment.deathCount += 1;
            if(MyEventSystem.OnBacteriaCatch != null) MyEventSystem.OnBacteriaCatch();
        }*/
    }

    
}
