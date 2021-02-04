using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    [SerializeField] float baseLives = 3;
    [SerializeField] int damage = 1;
    
    float lives;

    Text livesText;
    LevelController levelController;

    void Start()
    {
        lives = baseLives - PlayerPreferences.GetDifficulty();
        livesText = GetComponent<Text>();
        UpdateDisplay();
        levelController = FindObjectOfType<LevelController>();
    }

    private void UpdateDisplay()
    {
        livesText.text = lives.ToString();
    }

    public void AddLives(int lives)
    {
        this.lives += lives;
        UpdateDisplay();
    }

    public void TakeLife()
    {
        //don't want the lives to display as negative ever
        if (lives > 0)
        {
            this.lives -= damage;
            UpdateDisplay();
        }

        if (this.lives <= 0)
        {
            Lose();
        }
    }

    private void Lose()
    {
        levelController.HandleLoseCondition();
    }
}
