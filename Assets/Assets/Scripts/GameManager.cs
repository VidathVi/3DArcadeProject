using UnityEngine;
using TMPro; // for TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int targetsHit = 0;           // Hit counter
    public TextMeshProUGUI counterText;  // Reference to UI Text

    private void Awake()
    {
        // Simple singleton pattern
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        // Initialize counter display
        UpdateCounterText();
    }

    public void AddHit()
    {
        targetsHit++;
        Debug.Log("Targets hit: " + targetsHit);
        UpdateCounterText();
    }

    private void UpdateCounterText()
    {
        if (counterText != null)
            counterText.text = "Targets Hit: " + targetsHit;
    }
}