using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatSetter : MonoBehaviour {
    
    // This script sets the correct variables based on which cat the player selected

    private SpriteRenderer spriteRenderer;
    public CatData catData;

    private void Start()
    {
        // Get the sprite renderer
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        // Set the sprite
        spriteRenderer.sprite = catData.sprite;

        // Set the scale
        transform.localScale = catData.size;

        // Add the collider
        // Unity automatically sets the collider to equal the sprite
        this.gameObject.AddComponent<PolygonCollider2D>();
    }

}
