using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    [SerializeField] Slider healthSlider;
    [SerializeField] Text scoreText;
    ScoreKeeper _scoreKeeper;


    private void Awake()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start() //buranýn olmasinin sebebi her sahne yeniden yuklendiginde burasýnýn da tekrardan artmasý
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    private void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = _scoreKeeper.GetCurrentScore().ToString("000000"); //bu sayede 000050 seklinde artacak


      
        //scoreEndText.text = _scoreKeeper.GetCurrentScore().ToString("SCORE\n000000"); //bu sayede 000050 seklinde artacak
    }


}
