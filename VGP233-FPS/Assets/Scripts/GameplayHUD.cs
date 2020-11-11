using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayHUD : MonoBehaviour
{
    [SerializeField] private Text MessageText = null;
    [SerializeField] private Text ScoreText = null;
    [SerializeField] private Text HealthText = null;
    [SerializeField] private Text BombText = null;

    public void Initialize()
    {
        MessageText.text = string.Empty;
        ScoreText.text = "0";
    }

    public void SetGameplayHUDActive(bool shouldBeActive)
    {
        gameObject.SetActive(shouldBeActive);
    }

    public void UpdateScore(int currentScore)
    {
        ScoreText.text = currentScore.ToString();
    }

    public void UpdateHealth(float health)
    {
        //HealthText.text = health.ToString() + "%";
        int roundHealth = Mathf.RoundToInt(health);
        HealthText.text = roundHealth.ToString();
    }

    public void UpdateBombs(int bombs)
    {
        BombText.text = bombs.ToString();
    }

    public void UpdateMessageText(string message)
    {
        MessageText.text = message;
    }
}
