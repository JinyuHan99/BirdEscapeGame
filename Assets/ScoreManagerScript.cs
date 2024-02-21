using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int currentScore;
    private int bestScore;
    public Text bestScoreText;

    void Start()
    {
        // 加载最高分
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScoreDisplay();
    }


    public void UpdateScore(int newScore)
    {
        currentScore = newScore;

        // 如果当前得分大于最高分，更新最高分
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save(); // 不要忘记保存
            UpdateBestScoreDisplay();
        }
    }

    private void UpdateBestScoreDisplay()
    {
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }
}
