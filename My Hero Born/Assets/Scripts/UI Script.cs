using UnityEngine;
using UnityEngine.UI;  // For UI elements

public class UIManager : MonoBehaviour
{
    // Reference to the UI elements in the scene
    public Text playerHealthText;
    public Text itemsCollectedText;
    public Button winButton;
    public Button loseButton;

    private bool showWinScreen = false;
    private bool showLossScreen = false;

    private int _playerHP = 100;  // Example player health
    private int _itemsCollected = 5;  // Example items collected

    void Start()
    {
        // Ensure buttons are hidden at the start
        winButton.gameObject.SetActive(false);
        loseButton.gameObject.SetActive(false);
    }

    void Update()
    {
        // Update UI text based on current player stats
        playerHealthText.text = "Player Health: " + _playerHP;
        itemsCollectedText.text = "Items Collected: " + _itemsCollected;

        // Check if win or loss screens should be shown
        if (showWinScreen)
        {
            winButton.gameObject.SetActive(true);
            winButton.onClick.AddListener(RestartLevel);  // Add listener for button click
        }
        else
        {
            winButton.gameObject.SetActive(false);
        }

        if (showLossScreen)
        {
            loseButton.gameObject.SetActive(true);
            loseButton.onClick.AddListener(RestartLevel);  // Add listener for button click
        }
        else
        {
            loseButton.gameObject.SetActive(false);
        }
    }

    public void ShowWinScreen()
    {
        showWinScreen = true;
        showLossScreen = false;  // Hide loss screen if showing win screen
    }

    public void ShowLossScreen()
    {
        showLossScreen = true;
        showWinScreen = false;  // Hide win screen if showing loss screen
    }

    // Method to restart the level
    private void RestartLevel()
    {
        // Your level restart logic, e.g., reload the scene
        Debug.Log("Level Restarted");
        // Utilities.RestartLevel(0);  // Uncomment if you have this utility
    }
}
