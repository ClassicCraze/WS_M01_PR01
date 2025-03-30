using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    private string _state;

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    public bool showWinScreen = false;
    public bool showLossScreen = false;
    public string labelText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    private int _itemsCollected = 0;
    private int _playerHP = 3;

    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI itemsCollectedText;
 
    public GameObject winPanel;
    public GameObject lossPanel;

    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;

            if (_itemsCollected >= maxItems)
            {
                labelText = "You've found all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);

            if (_playerHP <= 0)
            {
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                labelText = "Ouch... that's gotta hurt.";
            }
        }
    }

    void Start()
    {
        Initialize();
        winPanel.SetActive(false);  
        lossPanel.SetActive(false);  
    }

    public void Initialize()
    {
        _state = "Manager initialized..";
        Debug.Log(_state);
    }

    void Update()
    {
        playerHealthText.text = "Player Health: " + _playerHP;
        itemsCollectedText.text = "Items Collected: " + _itemsCollected;

        if (showWinScreen)
        {
            winPanel.SetActive(true);
            lossPanel.SetActive(false);
        }
        else if (showLossScreen)
        {
            winPanel.SetActive(false);
            lossPanel.SetActive(true);
        }
        else
        {
            winPanel.SetActive(false);
            lossPanel.SetActive(false);
        }
    }

    public void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        showWinScreen = false;
        showLossScreen = false;
    }
}
