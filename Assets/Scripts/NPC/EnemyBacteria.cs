using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBacteria : MonoBehaviour
{
    public float movingForce;
    public GameObject target;
    public float scale = 1;
    public float mergeIncrease = 0.15f;
    public bool attack;
    private Rigidbody2D rigidbody;
    private Vector2 selfPos;
    // Start is called before the first frame update
    void Start()
    {
        attack = false;
        target = null;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        selfPos = new Vector2(this.transform.position.x, this.transform.position.y);
        if(target) {
            if(target.gameObject.transform.localScale.x < this.transform.localScale.x) attack = true;
            else attack = false;
            Vector2 targetPos = new Vector2(target.transform.position.x, target.transform.position.y);
            Vector2 direction = (attack?(targetPos - selfPos):(selfPos - targetPos)).normalized;
            Vector2 appliedForce =  direction * movingForce;
            rigidbody.AddForce(appliedForce);
        }
    }

    public void setScale(float newScale) {
        this.scale = newScale;
        this.transform.localScale = new Vector3(newScale, newScale, newScale);
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "player" && target == null) {
            target = collider.gameObject;
        }

        /*
        if(collider.gameObject.tag == "enemy") {
            target = collider.gameObject;
            attack = true;
        }*/
    }
    
    void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject == target) {
            target = null;
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.collider.gameObject.tag == "player" && attack) {
            Destroy(collision.collider.gameObject);
            MyEventSystem.playerDeath();
            if(MyEventSystem.BeingEaten != null) MyEventSystem.BeingEaten();
        }
        /*
        if(collision.collider.gameObject.tag == "enemy") {
            GameObject anotherEnemy = collision.collider.gameObject;
            Vector2 enemyPos = new Vector2(anotherEnemy.transform.position.x, anotherEnemy.transform.position.y);

            Vector3 newEnemyPos = new Vector3((enemyPos.x + selfPos.x) / 2, (enemyPos.y + selfPos.y) / 2, this.transform.position.z);
            BacteriaSpawner.mergeBacteria(this.gameObject, anotherEnemy, newEnemyPos);
        }*/
    }


}
