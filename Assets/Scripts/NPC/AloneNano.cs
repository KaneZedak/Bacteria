using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AloneNano : Nanobot
{
    public UnityEvent afterSparing;
    public ConditionObject killedNanocell;

    void OnTriggerExit2D(Collider2D collider) {
        if(collider.gameObject.tag == "player") {
            if(killedNanocell.value == false) {
                afterSparing.Invoke();
            }
        }
    }
}
