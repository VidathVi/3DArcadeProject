using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score: MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;

    int score = 0;

    //Allows access of functions from another script

    public static Score instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = " ";
    }

    public void AddPoint()
    {
        score++;
        scoreText.text = score.ToString() + " GET !";
        if (score == 8)
        {
            scoreText.text = "ALL GET !!!";
        }
    }
}
