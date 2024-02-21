using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public bool gameStarted = false;
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverSceen;
    public GameObject gameStartScreen;
    public bool isIntro = true;
    public GameObject initialPipe;
    public Rigidbody2D myRigidbody;
    public float flapStrength = 12.09f;
    public ScoreManagerScript scoreManager;
    //public MusicManagerScript musicManager;

    public void addScore(int scoreToAdd)
    {
    playerScore += scoreToAdd;
    scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameStarted = false;
        isIntro = true;
        //Debug.Log(gameStarted);
        //Debug.Log(isIntro);
    }
    public void gameOver()
    {
        OpenGameOverScreen();
        scoreManager.UpdateScore(playerScore);
    }
    public void gameStart()
    {
        gameStarted = true;
        CloseGameStartScreen();
        isIntro = false;
        Jump();
        Destroy(initialPipe);
        //musicManager.PlayIntroMusic();
    }
    public void gameExit()
    {
    #if UNITY_EDITOR
        // ����Unity�༭��ֹͣ����ģʽ
        UnityEditor.EditorApplication.isPlaying = false;
    #else
            // ������Ǳ༭��ģʽ���˳���ϷӦ�ó���
            Application.Quit();
    #endif
    }
    public void gamePause()
    {
        OpenGameStartScreen();
    }

    public void Jump()
    {
        myRigidbody.velocity = Vector2.up * flapStrength;
    }

    public void CloseGameStartScreen()
    {
        gameStartScreen.SetActive(false);
    }
    public void OpenGameStartScreen()
    {
        gameStartScreen.SetActive(true);
    }

    public void OpenGameOverScreen()
    {
        gameOverSceen.SetActive(true);
    }

    public void CloseGameOverScreen()
    {
        gameOverSceen.SetActive(false);
    }
}
