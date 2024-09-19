using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour {
    [Header("Set in Inspector")]
    // Prefab for instantiating apples
    public GameObject applePrefab;  // This should appear in the Inspector now

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change direction
    public float chanceToChangeDirection = 0.02f;

    // Rate at which apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    void Start() {
        // Dropping apples every second
        Invoke("DropApple", 2f); // Drop first apple after 2 seconds
    }
public class Apple : MonoBehaviour {
    public static float bottomY = -20f; // Static variable to set the threshold

    void Update() {
        // Check if the apple's y position is below the threshold
        if (transform.position.y < bottomY) {
            Destroy(gameObject); // Destroy the apple GameObject
        }
    }
}
    void DropApple() {
        // Instantiate an apple
        GameObject apple = Instantiate(applePrefab) as GameObject;

        // Set the apple's position to be the same as the AppleTree's position
        apple.transform.position = transform.position;

        // Invoke the DropApple method again after a delay to continuously drop apples
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    void Update() {
    // Basic movement
    Vector3 pos = transform.position;
    pos.x += speed * Time.deltaTime;
    transform.position = pos;

    // Changing direction based on edges
    if (pos.x < -leftAndRightEdge) {
        speed = Mathf.Abs(speed); // Move right
    } else if (pos.x > leftAndRightEdge) {
        speed = -Mathf.Abs(speed); // Move left
    }
}

    void FixedUpdate() {
        // Randomly change direction based on chance
        if (Random.value < chanceToChangeDirection) {
            speed *= -1; // Change direction
        }
    }
}


