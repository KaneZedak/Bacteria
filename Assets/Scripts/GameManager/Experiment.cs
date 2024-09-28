using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Experiment : MonoBehaviour
{
    public static int deathCount;
    public static float bestSurvivalTime;
    public static GameObject currentBacteria;
    public static float surviveTime;
    public static int totalDropCollected;
    public static int dropCollected;
    public static bool nanoReplication;

    public GameObject player;
    public GameObject playerPrefab;
    public GameObject mainCamera;
    public ConditionList conditionList;    
    public ConditionObject gameStart;

    public NarrativeStateMachine storyStateMachine;
    public GameActionSystem gameActionSystem;

    public void killPlayer() {
        currentBacteria.GetComponent<player>().stillDrainRate = 120;
        //MyEventSystem.playerDeath();
    }
    // Start is called before the first frame update
    void Awake() {
        deathCount = 0;
        bestSurvivalTime = 0;
        surviveTime = 0;
        currentBacteria = player;
        totalDropCollected = 0;
        dropCollected = 0;
        nanoReplication = false;

        MyEventSystem.playerDeath += onPlayerDeath;
        MyEventSystem.dropletCollected += onDropCollect;
        initializeConditions();
        storyStateMachine.initialize();
        gameActionSystem.initialize();
    }
    void Start()
    {
        gameStart.setValue(true);
        storyStateMachine.startNarrative();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentBacteria != null) {
            surviveTime += Time.deltaTime;
            bestSurvivalTime = Mathf.Max(surviveTime, bestSurvivalTime);
        }
    }

    void onPlayerDeath() {
        dropCollected = 0;
        //respawnPlayer();
    }

    void respawnPlayer() {
        surviveTime = 0;
        currentBacteria = Instantiate(playerPrefab, this.transform.position, Quaternion.identity);
        mainCamera.GetComponent<PlayerCamera>().followPlayer(currentBacteria);
        mainCamera.GetComponent<PlayerCamera>().trackToPlayer();
    }

    void onDropCollect() {
        totalDropCollected += 1;
        dropCollected += 1;
    }

    public void enableReplication() {
        nanoReplication = true;
    }
    public static void updateCondition(ConditionObject condition, bool value) {
        condition.setValue(value);
    }

    public void initializeConditions() {
        conditionList.initializeConditions();
    }

    public void setState(NarrativeState newState) {
        storyStateMachine.transitionToState(newState);
    }
}
