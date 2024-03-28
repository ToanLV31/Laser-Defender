using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class UIControler : MonoBehaviour
{
    [Header("health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [Header("soccer")]
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;

    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        SetScoreText();
        SetSliderValue();
    }

    void SetScoreText()
    {
        scoreText.text = scoreKeeper.GetCurrentScore().ToString();
    }

    void SetSliderValue()
    {
        healthSlider.value = playerHealth.GetHealth();
    }





}
