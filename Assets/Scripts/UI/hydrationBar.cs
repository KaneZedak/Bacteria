using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hydrationBar : MonoBehaviour
{
    public GameObject hydrationIndicator;
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
            rectTransform.localScale = new Vector3(playerScript.hydration / playerScript.maxHydration * originalScale.x, originalScale.y, originalScale.z);
       }
    }
}
