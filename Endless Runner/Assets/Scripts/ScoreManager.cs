using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    // Variables
    public Text scoreText;
    public Text highScoreText;

    public float scoreCount;
    public float highScoreCount;

    public float pointsPerSecond;
    public bool scoreIncreasing;
    public bool pointsDouble;


    private PlayerController thePlayerController;

    void Start()
    {
        highScoreCount = PlayerPrefs.GetInt("HighScore");
        thePlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    void Update()
    {
        if (scoreIncreasing)
        {
            // Add score each second
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        // Update high scores
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;

            // Create playerprefs to store the high score
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        // Increase difficulty over time
        if (scoreCount <= 60)
            {
            thePlayerController.moveSpeed = 15;
            }
        else if ((scoreCount > 60) && (scoreCount <= 120))
        {
            thePlayerController.moveSpeed = 20;
        }
        else if ((scoreCount > 120) && (scoreCount <= 180))
        {
            thePlayerController.moveSpeed = 25;
        }
        else if (scoreCount > 180)
        {
            thePlayerController.moveSpeed = 30;
        }

        // Display scores
        scoreText.text = "Score: " + (int)scoreCount;
        highScoreText.text = "High Score: " + (int)highScoreCount;
    }


    public void AddScore(int scoreToAdd)
    {
        if (pointsDouble)
        {
            scoreToAdd *= 2;
        }
        scoreCount += scoreToAdd;
    }

}
