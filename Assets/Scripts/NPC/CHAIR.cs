using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAIR : MonoBehaviour
{
    public GameObject seat;
    private Rigidbody2D rigidbody;
    private bool occupied = false;

    void Start() {
        occupied = false;    
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.isKinematic = true;
    }

    public void mountSeat(GameObject target) {
        target.transform.position = seat.transform.position;
        target.transform.rotation = seat.transform.rotation;
        occupied = true;
    }

    public void unmount() {
        occupied = false;
    }

    public bool isVaccant() {
        return occupied;
    }
    public Vector3 getSeatPosition() {
        return seat.transform.position;
    }
}
