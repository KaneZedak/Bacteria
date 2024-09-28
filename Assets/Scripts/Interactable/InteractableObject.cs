using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public delegate void Handler(InteractableObject source);
    public Handler OnInteract;
}
