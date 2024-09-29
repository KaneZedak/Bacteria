using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerGameActionSystem", menuName = "ScriptableObjects/GameActions/PlayerGameActionSystem")]
public class GameActionSystem : ScriptableObject
{
    public delegate void Handler(string text);
    public delegate void DisableHandler();
    public static Handler showText;
    public static DisableHandler hideText;

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
            if(showText != null) showText("Press " + enabledAction.actionBinding + " to " + enabledAction.actionName);
        }
    }

    void hideTip(PlayerGameAction disabledAction) {
        if(hideText != null) hideText();
    }

    
}
