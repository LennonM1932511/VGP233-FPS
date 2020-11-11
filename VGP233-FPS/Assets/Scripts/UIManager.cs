using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject hudPrefab = null;
    private GameplayHUD _hud = null;

    private void Awake()
    {
        if (hudPrefab == null)
        {
            Debug.Log("UIManager has no HUD prefab assigned");
            return;
        }

        GameLoader.CallOnComplete(Initialize);
    }

    public void Initialize()
    {
        var hudObject = Instantiate(hudPrefab);
        hudObject.transform.SetParent(transform);
        _hud = hudObject.GetComponent<GameplayHUD>();
        if (_hud == null)
        {
            Debug.Log("GameplayHUD is null");
            return;
        }

        _hud.Initialize();
    }

    public void UpdateScoreDisplay(int currentScore)
    {
        _hud.UpdateScore(currentScore);
    }

    public void UpdateHealthDisplay(float health)
    {
        _hud.UpdateHealth(health);
    }

    public void UpdateBombsDisplay(int bombs)
    {
        _hud.UpdateBombs(bombs);
    }

    public void DisplayMessage(string message)
    {
        _hud.UpdateMessageText(message);
    }
}
