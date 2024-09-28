using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AloneNano : Nanobot
{
    public UnityEvent afterSparing;
    private bool spared = false;
    public ConditionObject killedNanocell;

    public void Update() {
    }
    void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.tag == "player") {
            if(killedNanocell.value == false && spared == false) {
                spared = true;
                afterSparing.Invoke();
            }
        }
    }

    protected void replicate () {
        return;
    }
}
