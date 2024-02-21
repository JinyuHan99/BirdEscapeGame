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
        // ������߷�
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateBestScoreDisplay();
    }


    public void UpdateScore(int newScore)
    {
        currentScore = newScore;

        // �����ǰ�÷ִ�����߷֣�������߷�
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save(); // ��Ҫ���Ǳ���
            UpdateBestScoreDisplay();
        }
    }

    private void UpdateBestScoreDisplay()
    {
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }
}
