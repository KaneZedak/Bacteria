using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgm;

    void Start() {
        player.playerMounted += onPlayerMounted;
        player.playerDismounted += OnPlayerDismounted;
    }

    void onPlayerMounted() {
        bgm.volume = 0.2f;
    }

    void OnPlayerDismounted() {
        bgm.volume = 0.7f;
    }
}
