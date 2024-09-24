using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class playerProgress : MonoBehaviour
{
    public TMP_Text text_survival;
    public TMP_Text text_max_survival;
    public TMP_Text text_death_count;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateText();
    }

    void updateText() {
        text_max_survival.text = Math.Round(Experiment.bestSurvivalTime, 2).ToString();
        text_survival.text = Math.Round(Experiment.surviveTime, 2).ToString();
        text_death_count.text = Experiment.deathCount.ToString();
    }
}
