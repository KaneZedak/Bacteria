using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RollingText : MonoBehaviour
{
    public TMP_Text tmpText;
    string textMessage;
    int index = 0;
    
    void Start() {
        tmpText = GetComponent<TMP_Text>();
    }

    public void setText(string text) {
        this.textMessage = text;
    }
    public void displayText(float waitTime) {
        StartCoroutine(printText(waitTime));
    }

    private IEnumerator printText(float waitTime) {
        while(index < textMessage.Length) {
            tmpText.text = tmpText.text + textMessage[index++];
            yield return new WaitForSeconds(waitTime);
        }
    }
}
