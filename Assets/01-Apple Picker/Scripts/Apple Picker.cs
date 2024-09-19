using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePicker : MonoBehaviour {
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    // List to keep track of the baskets
    private List<GameObject> basketList;

    void Start() {
        // Initialize the basket list
        basketList = new List<GameObject>();

        // Loop to create and position baskets
        for (int i = 0; i < numBaskets; i++) {
            GameObject tBasketGO = Instantiate(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (i * basketSpacingY);
            tBasketGO.transform.position = pos;

            // Add the created basket to the list
            basketList.Add(tBasketGO);
        }

        // Log initial baskets
        Debug.Log("Baskets created: " + basketList.Count);
    }

    public void AppleDestroyed() {
        // Find all GameObjects tagged as "Apple"
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");

        // Loop through each apple and destroy it
        foreach (GameObject tGO in tAppleArray) {
            Destroy(tGO);
        }
    }

    public void DestroyLastBasket() {
        // Check if there are any baskets to destroy
        if (basketList.Count > 0) {
            // Get the index of the last basket in the list
            int basketIndex = basketList.Count - 1;

            // Get a reference to that basket GameObject
            GameObject tBasketGO = basketList[basketIndex];

            // Log the basket being destroyed
            Debug.Log("Destroying basket: " + tBasketGO.name);

            // Remove the basket from the list and destroy it
            basketList.RemoveAt(basketIndex);
            Destroy(tBasketGO);
        } else {
            Debug.LogWarning("No baskets to destroy.");
        }
    }
}
