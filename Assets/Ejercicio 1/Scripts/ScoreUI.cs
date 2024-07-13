using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameManager gameManager;

    private void OnEnable()
    {
        gameManager.OnVictory += UpdateUI;
    }

    private void OnDisable()
    {
        gameManager.OnVictory -= UpdateUI;
    }
    private void UpdateUI(bool isPlayerVictory)
    {
        scoreText.text = isPlayerVictory ? "Player wins!" : "Enemy wins!";
    }
}
