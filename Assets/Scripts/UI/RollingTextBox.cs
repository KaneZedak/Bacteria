using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
public class RollingTextBox : MonoBehaviour
{
    public float typeDisplaySpeed;
    public float textBoxSpacing;
    public TMP_Text sampleText;
    public float textBoxPaddingX;
    public float textBoxPaddingY;
    public float currentPaddingY;
    public ScrollView scrollView;
    private RectTransform rectTrans;
    private Rect rect;
    // Start is called before the first frame update
    private TMP_Text[] textBoxList;
    private int index = 0;
    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        rect = rectTrans.rect;
        currentPaddingY = textBoxPaddingY;
    }

    void displayText(string textMessage) {
        Vector3 textBoxPos = new Vector3(textBoxPaddingX, currentPaddingY, 0);
        TMP_Text newTextBox = Instantiate(sampleText, transform);
        newTextBox.transform.localPosition = textBoxPos;
        textBoxList[index++] = newTextBox;
    }
    // Update is called once per frame
}
