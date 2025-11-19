using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score: MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;

    int score = 0;
    int hiScore = 0;

    //Allows access of functions from another script

    public static Score instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //There are currently bugs with PlayerPrefs
        //Will sort this out in CW2
        //hiScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = " ";
        hiScoreText.text = " ";
        //hiScoreText.text = "HiScore: " + hiScore.ToString();
    }

    public void AddPoint()
    {
        score++;
        scoreText.text = score.ToString() + " GET !";
        if (hiScore < score)
        {
            //PlayerPrefs.SetInt("highscore", score);
        }
    }
}
