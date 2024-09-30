using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerGameAction", menuName = "ScriptableObjects/GameActions/PlayerGameAction")]
public class PlayerGameAction : ScriptableObject
{
    public GameObject target;
    public List<GameObject> targets;
    public delegate void callback(PlayerGameAction actionA);

    public callback onEnable;
    public callback onDisable;

    public string actionName;
    public string actionBinding;
    private bool isEnabled;
    private bool active;

    public void initialize() {
        isEnabled = false;
        active = true;
        targets = new List<GameObject>();
    }

    public bool getStatus() {
        return isEnabled;
    }

    public void enableAction() {
        isEnabled = true;
        if(onEnable != null) onEnable(this);
    }

    public void disableAction() {
        isEnabled = false;
        if(onDisable != null) onDisable(this);
    }

    public void deactivateAction() {
        active = false;
    }

    public void activateAction() {
        active = true;
    }

    public bool isActive() {
        return active;
    }

    public void addTarget(GameObject tar) {
        enableAction();
        targets.Add(tar);
    }

    public void removeTarget(GameObject tar) {
        targets.Remove(tar);
        if(targets.Count <= 0) {
            disableAction();
        }
    }

    public bool hasTarget(GameObject tar) {
        return targets.Contains(tar);
    }

    public GameObject getTarget() {
        if(targets.Count > 0) return targets[0];
        return null;
    }
}
