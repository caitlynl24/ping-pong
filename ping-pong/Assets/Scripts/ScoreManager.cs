using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int leftPlayerScore = 0;
    public int rightPlayerScore = 0;

    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;

    //Assign this in the Inspector
    public TextMeshProUGUI gameOverText;

    //Reference to the ball script
    public ball ballScript;

    public int winningScore = 5;

    private bool gameEnded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreUI();
        gameOverText.gameObject.SetActive(false);
    }

    public void LeftPlayerScores()
    {
        if(gameEnded) return;

        leftPlayerScore++;
        UpdateScoreUI();

        if(leftPlayerScore >= winningScore)
        {
            EndGame("Left Player Wins!");
        }
        else
        {
            //Send ball to the right
            ResetBall(-1);
        }
    }

    public void RightPlayerScores()
    {
        if(gameEnded) return;

        rightPlayerScore++;
        UpdateScoreUI();

        if(rightPlayerScore >= winningScore)
        {
            EndGame("Right Player Wins!");
        }
        else
        {
            //Send ball to the left
            ResetBall(1);
        }
    }

    // Update is called once per frame
    void UpdateScoreUI()
    {
        leftScoreText.text = leftPlayerScore.ToString();
        rightScoreText.text = rightPlayerScore.ToString();
    }

    void ResetBall(int direction)
    {
        ballScript.ResetBall(direction);
    }

    void EndGame(string message)
    {
        //Show game over message
        gameOverText.text = message;
        gameOverText.gameObject.SetActive(true);
    }
}