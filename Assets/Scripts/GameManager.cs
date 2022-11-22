using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Declare variables.
    public Player player;
    public Text scoreText;
    public Text highScoreText;
    public Text jumpText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject keyboardImg;
    public GameObject mouseImg;

    private int score;
    private int highScore;

    // Pause game upon starting.
    private void Awake()
    {
        Application.targetFrameRate = 60;
        gameOver.SetActive(false);
        Pause();
    }

    // Stop game and disable player controls when game starts/ends.
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    // Start game when play button is clicked.
    public void Play()
    {
        // Reset score and score text.
        score = 0;
        scoreText.text = score.ToString();

        // Hide components.
        playButton.SetActive(false);
        gameOver.SetActive(false);
        jumpText.gameObject.SetActive(false);
        keyboardImg.SetActive(false);
        mouseImg.SetActive(false);
        
        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        // Clear any existing pipes when game starts.
        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    // Show game over text and prompt player to play again.
    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        jumpText.gameObject.SetActive(true);
        keyboardImg.SetActive(true);
        mouseImg.SetActive(true);

        setHighScore();
        Pause();
    }

    // Increase score by one when player successfully passes a pipe.
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void setHighScore()
    {
        if(score > highScore)
        {
            highScore = score;
            highScoreText.text = highScore.ToString();
        }
    }
}
