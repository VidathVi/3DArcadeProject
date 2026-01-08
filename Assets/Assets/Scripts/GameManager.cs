using TMPro; // for TextMeshPro
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int targetsHit = 0;           // Hit counter
    public int targetGoal = 8;           
    public TextMeshProUGUI counterText;  // Reference to UI Text
    public TextMeshProUGUI resultText; // Reference to "You Won/Lost" text

    [HideInInspector]
    public bool isGameOver = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainHub");
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        UpdateCounterText();
        if (resultText != null) resultText.text = "";
    }

    public void AddHit()
    {
        if (isGameOver) return;

        targetsHit++;
        UpdateCounterText();

        if (targetsHit >= targetGoal)
        {
            WinGame();
        }
    }
    public void CheckLossCondition(int bulletsRemaining)
    {
        // If out of bullets and we haven't reached the target goal
        if (bulletsRemaining <= 0 && targetsHit < targetGoal)
        {
            // We use a slight delay or check to ensure the last bullet didn't hit
            Invoke("LoseGame", 0.5f);
        }
    }

    private void WinGame()
    {
        isGameOver = true;
        resultText.text = "You Won";
        Debug.Log("Game Won!");
    }

    private void LoseGame()
    {
        // Double check we didn't win in the last half-second
        if (targetsHit < targetGoal)
        {
            isGameOver = true;
            resultText.text = "You Lost - Out of Bullets";
            Debug.Log("Game Lost!");
        }
    }

    private void UpdateCounterText()
    {
        if (counterText != null)
            counterText.text = "Targets Hit: " + targetsHit;
    }
}