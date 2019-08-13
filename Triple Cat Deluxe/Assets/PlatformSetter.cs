using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSetter : MonoBehaviour {

    // This script sets the correct variables based on which platform the player selected

    private SpriteRenderer spriteRenderer;
    public PlatformData platformData;

    private void Start()
    {
        // Get the spriteRenderer
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

        // Set the sprite
        spriteRenderer.sprite = platformData.sprite;

        // Set the scale
        transform.localScale = platformData.size;

        // Add the collider
        // Unity automatically sets the collider to equal the sprite
        this.gameObject.AddComponent<PolygonCollider2D>();
    }
}
