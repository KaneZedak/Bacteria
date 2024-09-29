using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nanobot : MonoBehaviour
{
    public static float damage;
    public float replicationTime;
    private Rigidbody2D rigidbody;
    private float countTimer = 0;
    [SerializeField] private float splitForce = 10;
    private int splittingLayer;
    private int defaultLayer;
    public float botDamage;
    public float moveMinCd;
    public float moveMaxCd;
    public float moveForce;
    private float moveTimer;
    private float moveTime;
    public bool enableReplication = false;
    public GameObject NanoTemplate;
    private Vector2 spreadDirection;
    private int proxmityNanoCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        defaultLayer = this.gameObject.layer;
        rigidbody = GetComponent<Rigidbody2D>();
        splittingLayer = LayerMask.NameToLayer("SplittingBot");
        moveTimer = 0;
        countTimer = 0;
        moveTime = Random.Range(moveMinCd, moveMaxCd);
        spreadDirection = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2)).normalized;
        //this.gameObject.layer = splittingLayer;
    }

    // Update is called once per frame
    protected void Update()
    {
        if(Experiment.nanoReplication && enableReplication) {
            countTimer += Time.deltaTime;
            if(countTimer > replicationTime) {
                countTimer -= replicationTime;
                replicate();
            }
        }
        
        moveTimer += Time.deltaTime;
        if(moveTimer > moveMaxCd) {
            moveTime = Random.Range(moveMinCd, moveMaxCd);
            moveTimer = 0;
            Vector2 direction = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));
            direction += spreadDirection;
            direction = direction.normalized;
            rigidbody.AddForce(direction * moveForce, ForceMode2D.Impulse);
        }
        
    }

    protected void replicate() {
        
        GameObject newNanobot = Instantiate(NanoTemplate, this.gameObject.transform.parent);
        gameObject.layer = splittingLayer;
        newNanobot.layer = splittingLayer;

        Vector2 direction;
        direction = spreadDirection.normalized;
        rigidbody.AddForce(splitForce * direction, ForceMode2D.Impulse);
        newNanobot.GetComponent<Rigidbody2D>().AddForce(splitForce * -direction, ForceMode2D.Impulse);

        gameObject.layer = defaultLayer;
        newNanobot.layer = defaultLayer;
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "enemy") {
            GameObject otherNano = collider.gameObject;
            Vector2 nanoPos = new Vector2(otherNano.transform.position.x, otherNano.transform.position.y);
            Vector2 selfPos = new Vector2(transform.position.x, transform.position.y);

            if(collider.gameObject.GetComponent<Nanobot>().enabled == false) {
                spreadDirection += 10 * (selfPos - nanoPos).normalized;
            } else {
                spreadDirection += (selfPos - nanoPos).normalized * 2;
            }
            proxmityNanoCount++;
            if(proxmityNanoCount > 7) GetComponent<Nanobot>().enabled = false;
        }
    }

    public void OnTriggerExit2D(Collider2D collider) {
        if(collider.tag == "enemy") {
            proxmityNanoCount--;
        }
    }

}
