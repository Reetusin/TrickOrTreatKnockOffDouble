using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public End end;                        // Reference to the End script to handle game over
    public static Score instance;           // Singleton instance
    public TextMeshProUGUI text;            // UI text for displaying the score

    private int points = 0;                 // Internal points field

    public int Points
    {
        get { return points; }
        set
        {
            points = value;
            text.text = points.ToString("D4");

            // Increase gravity every 50 points
            if (points > 0 && points % 50 == 0)
                Physics2D.gravity *= 1.1f;

            // End game if points go below 0
            if (points < 0)
                end.EndScene();
        }
    }

    private void Awake()
    {
        // Singleton setup to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional if you want the score to persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy any duplicate Score instances
        }
    }
}