using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTime = 10f;

    Slider slider;
    LevelController levelController;
    bool timerExpired = false;

    private void Start()
    {
        slider = GetComponent<Slider>();
        levelController = FindObjectOfType<LevelController>();
    }

    void Update()
    {

        if (!timerExpired)
        {
            SetSliderValue();
            timerExpired = (Time.timeSinceLevelLoad >= levelTime);
        }
        else
        {
            levelController.LevelTimerFinished();
        }

    }

    private void SetSliderValue()
    {
        slider.value = Time.timeSinceLevelLoad / levelTime;
    }

    public bool IsTimerExpired()
    {
        return timerExpired;
    }
}
