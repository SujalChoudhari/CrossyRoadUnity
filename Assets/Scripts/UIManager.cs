using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject levelSelectionPanel;
    public GameObject termsAndConditionsPanel;

    [Header("Level Selection")]
    public GameObject gridPanel;
    public GameObject levelButtonPrefab;

    public int totalLevels = 5;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainPanel();
        OrganizeGrid();
    }

    public void ShowMainPanel()
    {
        mainPanel.SetActive(true);
        levelSelectionPanel.SetActive(false);
        termsAndConditionsPanel.SetActive(false);
    }

    public void ShowLevelSelectionPanel()
    {
        mainPanel.SetActive(false);
        levelSelectionPanel.SetActive(true);
        termsAndConditionsPanel.SetActive(false);
    }

    public void ShowTermsAndConditionsPanel()
    {
        mainPanel.SetActive(false);
        levelSelectionPanel.SetActive(false);
        termsAndConditionsPanel.SetActive(true);
    }

    public void OnPlayButtonPressed()
    {
        ShowLevelSelectionPanel();
    }

    public void OnTermsAndConditionsButtonPressed()
    {
        ShowTermsAndConditionsPanel();
    }

    public void OnBackButtonPressed()
    {
        ShowMainPanel();
    }

    public void OnLevelButtonPressed(int levelIndex)
    {
        // Assuming level scenes are named as "Level1", "Level2", etc.
        string levelName = "Level" + levelIndex;
        SceneManager.LoadScene(levelName);
    }

    public void OrganizeGrid()
    {
        // Clear all existing children
        foreach (Transform child in gridPanel.transform)
        {
            Destroy(child.gameObject);
        }

        gridPanel.GetComponent<GridLayoutGroup>().constraintCount = totalLevels;

        for (int i = 0; i < totalLevels; i++)
        {
            GameObject levelButton = Instantiate(levelButtonPrefab, gridPanel.transform);

            // Ensure to capture the current value of i
            int levelIndex = i + 1;

            TextMeshProUGUI textMeshPro = levelButton.GetComponentInChildren<TextMeshProUGUI>();
            if (textMeshPro != null)
            {
                textMeshPro.text = "" + levelIndex;
            }

            levelButton.GetComponent<Button>().onClick.AddListener(() => OnLevelButtonPressed(levelIndex));
        }
    }

    public void OnQuitButtonPressed()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
