using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] int currentScore;

    private void Awake()
    {
        Singelton();
    }
    void Singelton()
    {
        int instance = FindObjectsOfType(GetType()).Length;

        if (instance > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void IncreaseScore(int value)
    {
        currentScore += value;
    }
    public int GetCurrentScore()
    {
        return currentScore;
    }

    public int ResetScore()
    {
        currentScore = 0;
        return currentScore;

    }
}
