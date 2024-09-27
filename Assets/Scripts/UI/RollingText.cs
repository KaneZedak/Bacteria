using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RollingText : MonoBehaviour
{
    private TMP_Text tmpText;
    public float waitingTime;
    public MyEvent textFinishDisplaying;
    private IEnumerator coroutine;
    private string textMessage;
    private int index = 0;
    
    void Start() {
        tmpText = GetComponent<TMP_Text>();
        DialogueManager.showText += displayRollingText;
        coroutine = printText(waitingTime);
    }

    public void displayRollingText(string text) {
        StopCoroutine(coroutine);
        coroutine = printText(waitingTime);

        tmpText.text = "";
        setText(text);
        displayText(waitingTime);
    }
    public void setText(string text) {
        this.textMessage = text;
        index = 0;
    }
    public void displayText(float waitTime) {
        StartCoroutine(coroutine);
    }

    private IEnumerator printText(float waitTime) {
        while(index < textMessage.Length) {
            tmpText.text = tmpText.text + textMessage[index++];
            yield return new WaitForSeconds(waitTime);
        }
        textFinishDisplaying.invoke();
    }

    
}
