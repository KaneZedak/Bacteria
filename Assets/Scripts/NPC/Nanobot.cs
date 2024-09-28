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
    public bool enableReplication = false;
    // Start is called before the first frame update
    void Start()
    {
        defaultLayer = this.gameObject.layer;
        rigidbody = GetComponent<Rigidbody2D>();
        splittingLayer = LayerMask.NameToLayer("SplittingBot");
        //this.gameObject.layer = splittingLayer;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Experiment.nanoReplication) return;
        countTimer += Time.deltaTime;
        if(countTimer > replicationTime) {
            countTimer -= replicationTime;
            replicate();
        }
    }

    private void replicate() {
        
        GameObject newNanobot = Instantiate(this.gameObject);
        gameObject.layer = splittingLayer;
        newNanobot.layer = splittingLayer;

        Vector2 direction = new Vector2(Random.Range(-10,10), Random.Range(-10, 10));
        direction = direction.normalized;
        rigidbody.AddForce(splitForce * direction, ForceMode2D.Impulse);
        newNanobot.GetComponent<Rigidbody2D>().AddForce(splitForce * -direction, ForceMode2D.Impulse);

        gameObject.layer = defaultLayer;
        newNanobot.layer = defaultLayer;
    }


}
