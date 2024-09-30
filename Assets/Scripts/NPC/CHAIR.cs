using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHAIR : MonoBehaviour
{
    public GameObject seat;
    private Rigidbody2D rigidbody;
    private bool occupied = false;
    private AudioSource audio;

    void Start() {
        occupied = false;    
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.isKinematic = true;
        audio = GetComponent<AudioSource>();
    }

    public void mountSeat(GameObject target) {
        target.transform.position = seat.transform.position;
        target.transform.rotation = seat.transform.rotation;
        occupied = true;
        if(target.tag == "player") audio.Play();
    }

    public void unmount() {
        occupied = false;
        audio.Pause();
    }

    public bool isVaccant() {
        return !occupied;
    }
    public Vector3 getSeatPosition() {
        return seat.transform.position;
    }
}
