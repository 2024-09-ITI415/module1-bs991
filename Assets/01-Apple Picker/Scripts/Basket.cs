using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For UI Text component

public class Basket : MonoBehaviour {
    [Header("Set Dynamically")]
    public Text scoreGT; // Reference to the UI Text for the score

    void Start() {
        // Find a reference to the ScoreCounter GameObject in the scene
        GameObject scoreGO = GameObject.Find("ScoreCounter");

        // Check if the GameObject was found
        if (scoreGO != null) {
            Debug.Log("Found ScoreCounter GameObject.");
            // Get the Text component from the ScoreCounter GameObject
            scoreGT = scoreGO.GetComponent<Text>();

            // Check if the Text component was found
            if (scoreGT != null) {
                // Set the starting number of points to 0
                scoreGT.text = "0";
                Debug.Log("scoreGT assigned and initialized.");
            } else {
                Debug.LogError("ScoreCounter GameObject does not have a Text component.");
            }
        } else {
            Debug.LogError("ScoreCounter GameObject not found.");
        }
    }

    void Update() {
        // Get the current screen position of the mouse
        Vector3 mousePos2D = Input.mousePosition;

        // Set the z coordinate of mousePos2D to the negative of the Main Camera's Z position
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space to 3D world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of this Basket to match the mouse's x position
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll) {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;

        // Check if the collided object has the "Apple" tag
        if (collidedWith.CompareTag("Apple")) {
            // Destroy the apple GameObject
            Destroy(collidedWith);

            // Ensure scoreGT is assigned
            if (scoreGT != null) {
                int score;
                if (int.TryParse(scoreGT.text, out score)) {
                    // Add points for catching the apple
                    score += 100;

                    // Convert the score back to a string and update the scoreGT text
                    scoreGT.text = score.ToString();
                    Debug.Log("Score updated to: " + score);
                } else {
                    Debug.LogError("Score text could not be parsed to an integer.");
                }
            } else {
                Debug.LogError("scoreGT is not assigned.");
            }
        }
    }
}
