using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    void Start() {
        // Initialize the basket list
        basketList = new List<GameObject>();

        // Loop to create and position baskets
        for (int i = 0; i < numBaskets; i++) {
            GameObject tBasketGO = Instantiate(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (i * basketSpacingY);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed() {
        // Find all GameObjects tagged as "Apple"
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        // Loop through each apple and destroy it
        foreach (GameObject tempGO in appleArray) {
            Destroy(tempGO);
        }
            int basketIndex = basketList.Count - 1;
            // Get a reference to that basket GameObject
            GameObject basketGO = basketList[basketIndex];
            basketList.RemoveAt(basketIndex);
            Destroy(basketGO);
            if (basketList.Count == 0) {
                SceneManager.LoadScene("Main-ApplePicker");
        } 
    }
}

