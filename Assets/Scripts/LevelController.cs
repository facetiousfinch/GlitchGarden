using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [Header("Win Config")]
    [SerializeField] GameObject winLabel;
    [SerializeField] float winDelay = 4f;

    [Header("Lose Config")]
    [SerializeField] GameObject loseLabel;

    bool levelWon = false;
    bool levelLost = false;

    //references
    SceneLoader sceneLoader;
    GameTimer gameTimer;
    AttackerSpawner[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
        sceneLoader = FindObjectOfType<SceneLoader>();
        spawners = FindObjectsOfType<AttackerSpawner>();
        gameTimer = FindObjectOfType<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelWon)
        {
            int attackerCount = GetAttackerCount();
            bool isTimerExpired = gameTimer.IsTimerExpired();

            if (isTimerExpired && attackerCount == 0)
            {
                levelWon = true;
                StartCoroutine(HandleWinCondition());
            }
        }

    }

    public void LevelTimerFinished()
    {
        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }

    private int GetAttackerCount()
    {
        int attackerCount = 0;

        foreach (AttackerSpawner spawner in spawners)
        {
            attackerCount += spawner.transform.childCount;
        }

        return attackerCount;
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(winDelay);
        sceneLoader.LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        //slow time to zero
        Time.timeScale = 0;
    }
}
