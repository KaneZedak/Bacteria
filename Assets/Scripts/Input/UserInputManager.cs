using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class UserInputManager : MonoBehaviour
{
    public static PlayerAction playerInputs;
    public PlayerAction playerInputsActions;

    void Awake() {
        playerInputsActions = new PlayerAction();
        playerInputs = playerInputsActions;
        playerInputs.Bacteria.Enable();
    }
}
