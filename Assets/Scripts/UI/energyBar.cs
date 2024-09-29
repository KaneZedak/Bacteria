using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class energyBar : MonoBehaviour
{
    public GameObject energyIndicator;
    private player playerScript;
    private RectTransform rectTransform;
    private Rect rect;
    Vector3 originalScale;

    // Start is called before the first frame update
    void Start()
    {
        
        rectTransform = GetComponent<RectTransform>();
        rect = rectTransform.rect;
        originalScale = rectTransform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
       if(Experiment.currentBacteria != null) {
            playerScript = Experiment.currentBacteria.GetComponent<player>();
            rectTransform.localScale = new Vector3((playerScript.attackCD - playerScript.attackCountTimer) / playerScript.attackCD * originalScale.x, originalScale.y, originalScale.z);
       }
    }
}
