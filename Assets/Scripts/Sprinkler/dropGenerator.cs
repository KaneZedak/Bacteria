using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropGenerator : MonoBehaviour
{
    public int minDrop;
    public int maxDrop;
    public int maxDropSpawn;
    public int totalDropSpawned;
    public GameObject droplet;
    public float minTimeInterval;
    public float maxTimeInterval;
    private float timePassed;
    private RectTransform rectTransform;
    private Rect rect;
    private float timeInterval;

    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0;
        totalDropSpawned = 0;
        rectTransform = GetComponent<RectTransform>();
        rect = rectTransform.rect;
        timeInterval = Random.Range(minTimeInterval, maxTimeInterval);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed >= timeInterval && totalDropSpawned < maxDropSpawn) {
            timePassed -= timeInterval;
            timeInterval = Random.Range(minTimeInterval, maxTimeInterval);
            spawnDroplets();
        }
    }

    private void spawnDroplets() {
        float dropPosX;
        float dropPosY;

        int numDrops = (int)Random.Range(minDrop, maxDrop);
        numDrops = Mathf.Min(maxDropSpawn - totalDropSpawned, numDrops);
        for(int i = 0; i < numDrops; i++) {
            dropPosX = Random.Range(rect.x, rect.x + rect.width);
            dropPosY = Random.Range(rect.y, rect.y + rect.height);

            Vector3 dropPos = new Vector3(dropPosX, dropPosY, 0);
            Instantiate(droplet, dropPos,  Quaternion.identity);
        }
        totalDropSpawned += numDrops;
    }
}