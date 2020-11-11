using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static readonly Dictionary<int, int> _killsByLevel = new Dictionary<int, int>()
    {
        { 1, 16 },
        { 2, 24 }
    };

    private int _numKilled = 0;

    private int _currentBombs = 0;
    public int CurrentBombs { get { return _currentBombs; } }

    private float _currentHealth = 0.0f;
    private float _maxHealth = 100.0f;

    private int _currentScore = 0;
    public int CurrentScore { get { return _currentScore; } }

    private int _currentLevel = 0;
    public int CurrentLevel { get { return _currentLevel; } }

    private UIManager _uiManager = null;

    public GameManager Initialize(int startLevel)
    {
        GameLoader.CallOnComplete(OnGameLoaderComplete);
        SetLevel(startLevel);
        _currentHealth = _maxHealth;
        return this;
    }

    private void OnGameLoaderComplete()
    {
        _uiManager = ServiceLocator.Get<UIManager>();
    }

    private void SetLevel(int level)
    {
        _currentLevel = level;
    }

    private void LoadNextLevel()
    {
        int nextLevel = ++_currentLevel;
        if (nextLevel > _killsByLevel.Count)
        {
            _uiManager.DisplayMessage("YOU WIN!");
        }

        SceneManager.LoadScene(nextLevel);
        SetLevel(nextLevel);
        _numKilled = 0;
        _uiManager.DisplayMessage("");
    }

    public void UpdateScore(int score)
    {
        _currentScore += score;
        _uiManager.UpdateScoreDisplay(_currentScore);
        CheckWinCondition();
    }

    public void UpdateKills()
    {
        ++_numKilled;
        CheckWinCondition();
    }

    public void UpdateHealth(float health)
    {
        _currentHealth += health;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
        _uiManager.UpdateHealthDisplay(_currentHealth);

        CheckLoseCondition();
    }

    public void UpdateBombs(int bombs)
    {
        _currentBombs += bombs;
        _uiManager.UpdateBombsDisplay(_currentBombs);
    }

    private void CheckWinCondition()
    {
        int numToWin = _killsByLevel[_currentLevel];
        if (_numKilled >= numToWin)
        {
            _uiManager.DisplayMessage("Level Completed");
            Time.timeScale = 0;
            //LoadNextLevel();
        }
    }

    private void CheckLoseCondition()
    {
        if (_currentHealth <= 0)
        {
            _uiManager.DisplayMessage("GAME OVER");
            Time.timeScale = 0;
        }
    }
}
