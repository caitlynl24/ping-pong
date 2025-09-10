using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int leftPlayerScore = 0;
    public int rightPlayerScore = 0;

    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;

    //Reference to the ball script
    public ball ballScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreUI();
    }

    public void LeftPlayerScores()
    {
        leftPlayerScore++;
        UpdateScoreUI();
        //Send ball to the right
        ResetBall(-1);
    }

    public void RightPlayerScores()
    {
        rightPlayerScore++;
        UpdateScoreUI();
        //Send ball to the left
        ResetBall(1);
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
}