using UnityEngine;
using TMPro; // Required for TextMeshPro
using UnityEngine.SceneManagement; // Required to restart the scene

public class GameManagerHockey : MonoBehaviour
{
    // Singleton instance so goals can find the manager easily
    public static GameManagerHockey instance;

    [Header("Score Settings")]
    public int playerScore = 0;
    public int opponentScore = 0;
    public int scoreToWin = 12;

    [Header("UI References")]
    public TextMeshProUGUI playerText;    // Drag Player Score Text here
    public TextMeshProUGUI computerText;  // Drag Computer Score Text here
    public GameObject endScreenPanel;     // Drag your Win/Loss Panel here
    public TextMeshProUGUI endScreenText; // Drag the text inside that panel here

    void Awake()
    {
       //Singleton setup
       if (instance == null)
       {
           instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainHub");
        }
    }

    void Start()
    {
        // Reset game state
        Time.timeScale = 1; 
        endScreenPanel.SetActive(false);
        UpdateUI();
    }

    // Called when puck enters the Opponent's Goal
    public void PlayerScored()
    {
        playerScore++;
        UpdateUI();
        CheckWinCondition();
    }

    // Called when puck enters the Player's Goal
    public void OpponentScored()
    {
        opponentScore++;
        UpdateUI();
        CheckWinCondition();
    }

    void UpdateUI()
    {
        playerText.text = $"PLAYER: {playerScore}";
        computerText.text = $"COMPUTER: {opponentScore}";
    }

    void CheckWinCondition()
    {
        if (playerScore >= scoreToWin)
        {
            ShowEndScreen("YOU WIN!", Color.green);
        }
        else if (opponentScore >= scoreToWin)
        {
            ShowEndScreen("YOU LOST!", Color.red);
        }
    }

    void ShowEndScreen(string message, Color messageColor)
    {
        endScreenPanel.SetActive(true);
        endScreenText.text = message;
        endScreenText.color = messageColor;
        
        // Stop the game
        Time.timeScale = 0; 
        
        // Unlock mouse cursor for the restart button
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Link this to a UI Button's OnClick event
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}