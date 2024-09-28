using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDTipText : MonoBehaviour
{
    private TMP_Text tmp_text;
    
    void Start() {
        tmp_text = GetComponent<TMP_Text>();
        tmp_text.text = "";
        GameActionSystem.showText += displayText;
        GameActionSystem.hideText += hideText;
    }
    public void displayText(string text) {
        tmp_text.text = text;
    }

    public void hideText() {
        tmp_text.text = "";
    }
}
