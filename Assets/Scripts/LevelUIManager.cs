using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject winMenu;
    public GameObject gameOverMenu;

    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI levelDeathCountText;

    private void Start()
    {
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void OnPauseButtonPressed()
    {
        PauseGame();
    }

    public void OnResumeButtonPressed()
    {
        ResumeGame();
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }
    public void OnRestartPressed()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnHomePressed()
    {
        SceneManager.LoadScene(0);
    }

    public void OnWin()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnGameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnNextLevelPressed()
    {
        LoadNextLevel();
    }

    private void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private void LoadNextLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;
        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(nextLevelIndex);
            Time.timeScale = 1f;
            //SceneManager.LoadScene(currentLevelIndex);
        }
        else
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }



    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }



}
