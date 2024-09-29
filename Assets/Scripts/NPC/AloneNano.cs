using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AloneNano : Nanobot
{
    public UnityEvent afterSparing;
    public ConditionObject sparedNanocell;
    public ConditionObject killedNanocell;

    public void Update() {
    }
    void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.tag == "player") {
            if(killedNanocell.value == false && sparedNanocell.value == false) {
                sparedNanocell.setValue(true);
                afterSparing.Invoke();
            }
        }
    }

    protected void replicate () {
        return;
    }
}
