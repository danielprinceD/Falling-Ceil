using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject secondsSurvived;
    public GameObject GameOverDisplay;
    bool isGameOver = false;

    void Start()
    {
        GameOverDisplay.SetActive(false);
        FindFirstObjectByType<PlayerController>().OnTriggerGameOver += OnGameOver;
    }

    void Update()
    {
        if ( isGameOver && Input.GetKeyUp(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void OnGameOver()
    {
        isGameOver = true;        
        GameOverDisplay.SetActive(true);
        TextMeshProUGUI textMeshProUGUI = secondsSurvived.GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.SetText(Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString());

    }

}
