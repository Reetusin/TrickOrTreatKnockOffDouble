using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Score : MonoBehaviour
{
    public GameObject scoreBoard;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI highScoreText;

    public Sprite[] medals;

    public void ShowScoreBoard(int score)
    {
        scoreBoard.SetActive(true);
        scoreText.text = score.ToString("D4");

        var hightScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > hightScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
            highScoreText.text = score.ToString("D4");
           
        }
        else
        {
            highScoreText.text = hightScore.ToString("D4");
            
        }
    }
}
