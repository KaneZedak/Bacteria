using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class ExitGame : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    private TMP_Text tmp_text;
    // Start is called before the first frame update
    void Start()
    {
        tmp_text = GetComponent<TMP_Text>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventD) {
        tmp_text.text = "Alright, that’s it for today. Could you clean the plate now?";
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventD) {
        tmp_text.color = new Color(1.0f, 0.5f, 0.5f, 1.0f);
    }

    public void OnPointerExit(PointerEventData eventD) {
        tmp_text.color = new Color(1f, 1f, 1.0f, 1.0f);
    }
}
