using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSetter : MonoBehaviour {

    // This script sets the correct variables based on which platform the player selected

    private SpriteRenderer spriteRenderer;
    public PlatformData platformData;

    public PlatformManager platformManager;

    private void Start()
    {
        // Get the platformManager
        if (GameObject.Find("PlatformManager") != null)
        {
            platformManager = GameObject.Find("PlatformManager").GetComponent<PlatformManager>();

            // Set the correct platform
            platformData = platformManager.platform;
        }

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
