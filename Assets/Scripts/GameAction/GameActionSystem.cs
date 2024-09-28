using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerGameActionSystem", menuName = "ScriptableObjects/GameActions/PlayerGameActionSystem")]
public class GameActionSystem : ScriptableObject
{
    public PlayerGameAction[] actionList;
    public bool suppressTip = false;

    public void initialize() {
        foreach(PlayerGameAction gameAction in actionList) {
            gameAction.initialize();
            gameAction.onEnable += showTip;
            gameAction.onDisable += hideTip;
        }
        suppressTip = false;
    }

    void showTip(PlayerGameAction enabledAction) {
        if(!suppressTip) {
            Debug.Log("Press " + enabledAction.actionBinding + " to " + enabledAction.actionName);
        }
    }

    void hideTip(PlayerGameAction disabledAction) {
    }

    
}
