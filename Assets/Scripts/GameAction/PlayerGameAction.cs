using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "PlayerGameAction", menuName = "ScriptableObjects/GameActions/PlayerGameAction")]
public class PlayerGameAction : ScriptableObject
{
    public GameObject target;
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
    }

    public bool getStatus() {
        return isEnabled;
    }

    public void enableAction() {
        isEnabled = true;
        onEnable(this);
    }

    public void disableAction() {
        isEnabled = false;
        onDisable(this);
    }

    public void deactivateAction() {
        active = false;
    }

    public bool isActive() {
        return active;
    }
}
