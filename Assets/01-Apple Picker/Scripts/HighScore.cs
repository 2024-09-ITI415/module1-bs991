using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Remember, we need this for UI elements

public class HighScore : MonoBehaviour {
    static public int score = 1000; // Initial high score

    void Awake() {
        // If the PlayerPrefs HighScore already exists, load it
        if (PlayerPrefs.HasKey("HighScore")) {
            score = PlayerPrefs.GetInt("HighScore");
        }
        
        // Assign the high score to HighScore
        PlayerPrefs.SetInt("HighScore", score);
    }

    void Update() {
        // Get the Text component of this GameObject
        Text gt = this.GetComponent<Text>();

        // Update the UI text with the high score
        gt.text = "High Score: " + score;

        // Update the PlayerPrefs HighScore if the current score is higher
        if (score > PlayerPrefs.GetInt("HighScore")) {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
