using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class player : MonoBehaviour
{
    public delegate void Handler();
    public static Handler playerMounted;
    public static Handler playerDismounted;

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

    public float attackCD;
    public float attackCountTimer;

    float proportion;
    private float originalMass;
    Rigidbody2D rigidbody;
    Animator animator;
    private Vector2 currentDirection = new Vector2();
    private Vector3 pos = new Vector3();

    public float damageForce;
    public float damageFromBot;

    [SerializeField] private bool enemyInRange = false;
    [SerializeField] private GameObject target = null;
    [SerializeField] private bool friendlyInRange = false;
    [SerializeField] private GameObject friendlyTarget = null;
    [SerializeField] private ConditionObject killedNanocell;
    [SerializeField] private ConditionChecker killChecker;
    [SerializeField] private PlayerGameAction attackAction;
    [SerializeField] private PlayerGameAction shareAction;
    [SerializeField] private PlayerGameAction sitAction;


    public UnityEvent OnFirstMove;
    public UnityEvent AfterMetNanocell;
    public UnityEvent AfterKill;
    public MyUnityEvent afterGroupUp;
    public MyUnityEvent afterKilledByNano;
    public MyUnityEvent afterSeat;

    private bool metNanocell = false;
    private bool moved = false;
    private bool isMounted = false;
    private int botProximityCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        originalMass = rigidbody.mass;
        killChecker.initialize();
        killChecker.subscribe(AfterKill.Invoke);

        attackAction.initialize();
        shareAction.initialize();
        sitAction.initialize();
    
        UserInputManager.playerInputs.Bacteria.sit.performed += sitActionFun;
        UserInputManager.playerInputs.Bacteria.attack.performed += attackActionFun;
        UserInputManager.playerInputs.Bacteria.share.performed += shareActionFun;

        attackCountTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(hydration <= 0) return;
        if(Experiment.gamePaused) return;
        if(!isMounted) playerStatusUpdate();
        
        if(attackCountTimer <= 0) {
            attackAction.activateAction();
            attackCountTimer = 0;
        } else {
            attackCountTimer -= Time.deltaTime;
        }

        //if(!Experiment.gamePaused) hydration -= botProximityCount * Time.deltaTime * 1;
    }

    void attackActionFun(InputAction.CallbackContext context) {
        if(attackAction.isActive() && attackAction.getStatus() && attackAction.target != null) {
            killedNanocell.setValue(true);
            Destroy(attackAction.target);
            attackAction.disableAction();
            attackAction.target = null;
            attackCountTimer = attackCD;
            attackAction.deactivateAction();
        }
    }

    void shareActionFun(InputAction.CallbackContext context) {
        if(shareAction.getStatus() && shareAction.target != null) {
            shareAction.target.GetComponent<InteractableFriendly>().setFollowObject(this.gameObject);
            shareAction.target.tag = "followingBacteria";
            shareAction.disableAction();
            shareAction.target = null;
            hydration = hydration / 2;   
            afterGroupUp.Invoke();
        }
    }

    void sitActionFun(InputAction.CallbackContext context) {
        if(!isMounted && sitAction.target && sitAction.getStatus()) {
            isMounted = true;
            rigidbody.isKinematic = true;
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.angularVelocity = 0;
            sitAction.target.GetComponent<CHAIR>().mountSeat(this.gameObject);
            if(playerMounted != null) playerMounted();
            afterSeat.Invoke();
        } else if(isMounted) {
            isMounted = false;
            rigidbody.isKinematic = false;
            sitAction.target.GetComponent<CHAIR>().unmount();
            if(playerDismounted != null) playerDismounted();
        }
    }
    void playerStatusUpdate() {
        Vector2 direction = UserInputManager.playerInputs.Bacteria.move.ReadValue<Vector2>();
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
            hydration = 0;
            MyEventSystem.playerDeath();
            UserInputManager.playerInputs.Disable();
            afterKilledByNano.Invoke();
            animator.SetBool("Death", true);
        }
    }
    void OnTriggerEnter2D(Collider2D colObj)
    {
        if(colObj.gameObject.tag == "enemy") {
            if(!metNanocell) {
                metNanocell = true;
                AfterMetNanocell.Invoke();
            }
            
            botProximityCount++;
            attackAction.enableAction();
            attackAction.target = colObj.gameObject;
        }

        if(colObj.gameObject.tag == "friendly") {
            shareAction.enableAction();
            shareAction.target = colObj.gameObject;
        }

        if(colObj.gameObject.tag == "chair") {
            sitAction.enableAction();
            sitAction.target = colObj.gameObject;
        }
    }


    void OnTriggerExit2D(Collider2D colObj)
    {
        if(colObj.gameObject.tag == "enemy") {
            botProximityCount--;
        }
        if(colObj.gameObject == attackAction.target) {
            attackAction.target = null;
            attackAction.disableAction();
        }
        if(colObj.gameObject == shareAction.target) {
            shareAction.target = null;
            shareAction.disableAction();
        }
        if(colObj.gameObject.tag == "chair") {
            sitAction.disableAction();
            sitAction.target = null;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "waterdrop") {
            /*
            hydration += collision.collider.gameObject.GetComponent<Waterdrop>().replenish_amount;
            if(hydration > maxHydration) hydration = maxHydration;*/
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
