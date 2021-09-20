using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public SpriteRenderer ballImage;
    public Rigidbody2D ballRb;
    public BoxCollider2D racketColliderPlayer;
    public BoxCollider2D racketColliderEnemy;
    public Image ballUIImage;
    public Text scoreText;
    //public GameObject ballGO;
    public Transform ballTr;
    private bool gameStarted = false;
    public BallControls ballControls;
    public PhysicsMaterial2D racketPhysMat_bouncy;
    public PhysicsMaterial2D racketPhysMat_soft;
    public GameObject pauseButton;
    public GameObject winScreen;
    public GameObject looseScreen;


    void Start()
    {
        if (!PlayerPrefs.HasKey("initialized"))
        {
            PlayerPrefs.SetInt("initialized", 1);
            PlayerPrefs.SetInt("red", 255);
            PlayerPrefs.SetInt("green", 0);
            PlayerPrefs.SetInt("blue", 0);

            PlayerPrefs.SetInt("wins", 0);
            PlayerPrefs.SetInt("loose", 0);
        }

        ballImage.color = new Color(PlayerPrefs.GetInt("red"), PlayerPrefs.GetInt("green"), PlayerPrefs.GetInt("blue"));
        ballUIImage.color = ballImage.color;

        scoreText.text = "Wins " + PlayerPrefs.GetInt("wins") + " : Loose " + PlayerPrefs.GetInt("loose");
    }


    void FixedUpdate()
    {
        if(ballRb.velocity.magnitude > 6.0f)
        {
            racketColliderPlayer.sharedMaterial = racketPhysMat_soft;
            racketColliderEnemy.sharedMaterial = racketPhysMat_soft;
            //racketPhysMat.bounciness = 0.1f;
        }
        else
        {
            racketColliderPlayer.sharedMaterial = racketPhysMat_bouncy;
            racketColliderEnemy.sharedMaterial = racketPhysMat_bouncy;
            //racketPhysMat.bounciness = 1.1f;
        }
    }
    public void PlayerLoose()
    {
        pauseButton.SetActive(false);
        looseScreen.SetActive(true);
        PlayerPrefs.SetInt("loose", PlayerPrefs.GetInt("loose") + 1);
        scoreText.text = "Wins " + PlayerPrefs.GetInt("wins") + " : Loose " + PlayerPrefs.GetInt("loose");
        Time.timeScale = 0.0f;
        //Debug.Log("Player loose");
    }
    public void PlayerWins()
    {
        pauseButton.SetActive(false);
        winScreen.SetActive(true);
        PlayerPrefs.SetInt("wins", PlayerPrefs.GetInt("wins") + 1);
        scoreText.text = "Wins " + PlayerPrefs.GetInt("wins") + " : Loose " + PlayerPrefs.GetInt("loose");
        Time.timeScale = 0.0f;
        //Debug.Log("Player wins");
    }
    public void RestartGame()
    {
        ballTr.position = Vector3.zero;
        Time.timeScale = 1.0f;
        ballControls.StartGame();
    }
    public void StartGame()
    {
        if (!gameStarted)
        {
            ballControls.StartGame();
            gameStarted = true;
        }
        Time.timeScale = 1.0f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }

    public void SetBallColor(int newColor)
    {
        Color color = new Color(0, 0, 0);
        switch (newColor)
        {
            case 0://red
                PlayerPrefs.SetInt("red", 255);
                PlayerPrefs.SetInt("green", 0);
                PlayerPrefs.SetInt("blue", 0);
                color = new Color(255, 0, 0);
                break;
            case 1://green
                PlayerPrefs.SetInt("red", 0);
                PlayerPrefs.SetInt("green", 255);
                PlayerPrefs.SetInt("blue", 0);
                color = new Color(0, 255, 0);
                break;
            case 2://blue
                PlayerPrefs.SetInt("red", 0);
                PlayerPrefs.SetInt("green", 0);
                PlayerPrefs.SetInt("blue", 255);
                color = new Color(0, 0, 255);
                break;
            case 3://yellow
                PlayerPrefs.SetInt("red", 255);
                PlayerPrefs.SetInt("green", 255);
                PlayerPrefs.SetInt("blue", 0);
                color = new Color(255, 255, 0);
                break;
            default:
                Debug.LogWarning("Ball Color doesn't set");
                break;

        }

        ballImage.color = color;
        ballUIImage.color = color;
    }

}
