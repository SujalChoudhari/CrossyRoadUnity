using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int coinsCollected = 0;
    private int deathCount = 0;
    private string currentLevel;

    private LevelUIManager levelUIManager;

    private void Start()
    {
        currentLevel = SceneManager.GetActiveScene().name;
        levelUIManager = GameObject.Find("LevelUIManager").GetComponent<LevelUIManager>();
        deathCount = PlayerPrefs.GetInt("DeathCount" + currentLevel, 0);
        coinsCollected = PlayerPrefs.GetInt("Coins", 0);
        levelUIManager.coinsText.text = coinsCollected.ToString();
        levelUIManager.levelDeathCountText.text = deathCount.ToString();
    }

    public void CollectCoin()
    {
        coinsCollected++;
        PlayerPrefs.SetInt("Coins", coinsCollected);
        Debug.Log("Coin collected: " + coinsCollected);
        levelUIManager.coinsText.text = coinsCollected.ToString();
    }

    public void UpdateDeathCountForCurrentLevel()
    {
        deathCount++;
        PlayerPrefs.SetInt("DeathCount" + currentLevel, deathCount);
        levelUIManager.levelDeathCountText.text = deathCount.ToString();
    }
}
