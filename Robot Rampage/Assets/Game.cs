using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private static Game singleton;
    [SerializeField]
    RobotSpawn[] spawns;
    public int enemiesLeft;
    public GameObject gameOverPanel;
    public GameUI gameUI;
    public GameObject player;
    public int score;
    public int waveCountdown;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
        StartCoroutine("IncreaseScoreEachSecond");
        isGameOver = false;
        Time.timeScale = 1;
        waveCountdown = 30;
        enemiesLeft = 0;
        StartCoroutine("UpdateWaveTimer");
        SpawnRobots();
    }

    private void SpawnRobots()
    {
        foreach (RobotSpawn spawn in spawns)
        {
            spawn.SpawnRobot();
            enemiesLeft++;
        }
        gameUI.SetEnemyText(enemiesLeft);
    }

    private IEnumerator UpdateWaveTimer()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1f);
            waveCountdown--;
            gameUI.SetWaveText(waveCountdown);

            if (waveCountdown == 0) { SpawnRobots(); waveCountdown = 30; gameUI.ShowNewWaveText(); }
        }
    }

    IEnumerator IncreaseScoreEachSecond()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1);
            score++;
            gameUI.SetScoreText(score);
        }
    }

    public static void RemoveEnemy()
    {
        singleton.enemiesLeft--;
        singleton.gameUI.SetEnemyText(singleton.enemiesLeft);
        singleton.score += 10;
        singleton.gameUI.SetScoreText(singleton.score);

        if(singleton.enemiesLeft == 0)
        {
            singleton.score += 50;
            singleton.gameUI.ShowWaveClearBonus();
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        player.GetComponent<FirstPersonController>().enabled = true;
        player.GetComponent<CharacterController>().enabled = false;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(Constants.SceneBattle);
        gameOverPanel.SetActive(true );
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Constants.SceneMenu);
    }

    
}
