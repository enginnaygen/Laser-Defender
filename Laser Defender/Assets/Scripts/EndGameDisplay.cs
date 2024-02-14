using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameDisplay : MonoBehaviour
{
    [SerializeField] Text score;
    void Start()
    {
        score.text = FindObjectOfType<ScoreKeeper>().GetCurrentScore().ToString("SCORE\n000000");
    }

   
}
