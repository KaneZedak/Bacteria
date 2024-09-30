using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGame : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler,  IPointerExitHandler
{
    private TMP_Text tmp_text;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        tmp_text = GetComponent<TMP_Text>();  
        audio = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventD) {
        SceneManager.LoadScene("Lab");
    }

    public void OnPointerEnter(PointerEventData eventD) {
        tmp_text.color = new Color(0.5f, 0.5f, 1.0f, 1.0f);
        audio.Play();
    }

    public void OnPointerExit(PointerEventData eventD) {
        tmp_text.color = new Color(1f, 1f, 1.0f, 1.0f);
        audio.Stop();
    }
}
