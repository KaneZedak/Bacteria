using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaSpawner : MonoBehaviour
{
    public static GameObject bacteriaPrefab;
    public GameObject bacPrefab;
    void Awake() {
        bacteriaPrefab = bacPrefab;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void mergeBacteria(GameObject bacteriaA, GameObject bacteriaB, Vector3 newBacteriaPos) {
        if(bacteriaA) Destroy(bacteriaA);
        else return;
        if(bacteriaB) Destroy(bacteriaB);
        else return;
        Instantiate(bacteriaPrefab, newBacteriaPos, Quaternion.identity);
    }

}
