using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour {

    // This script manages movement for each player

    [System.NonSerialized]
    public bool canJump = false;

    public float moveForce;
    public float jumpForce;

    // Fixed Update over Update because dealing with physics
    private void Update()
    {
        // If the player is playerOne
        if (this.gameObject.tag == "playerOne")
        {
            // W -> Jump
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Check if the player can jump (on the ground)
                if (canJump == true)
                {
                    // Apply force to make the player jump
                    this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    // The player can't jump again because they're no longer on the floor
                    canJump = false;
                }
            }
            // A -> Left
            if (Input.GetKeyDown(KeyCode.A))
            {
                // Apply force to make the player go to the left
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-moveForce, 0), ForceMode2D.Impulse);
            }
            // S -> Down
            if (Input.GetKeyDown(KeyCode.S))
            {
                // Apply force to make the player go down
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -jumpForce), ForceMode2D.Impulse);
            }
            // D -> Right
            if (Input.GetKeyDown(KeyCode.D))
            {
                // Apply force to make the player go right
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(moveForce, 0), ForceMode2D.Impulse);
            }
        }

        // If the player is playerTwo
        if (this.gameObject.tag == "playerTwo")
        {
            // Up -> Jump
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Check if the player can jump (on the ground)
                if (canJump == true)
                {
                    // Apply force to make the player jump
                    this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    // The player can't jump again because they're no longer on the floor
                    canJump = false;
                }
            }
            // Left -> Left
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // Apply force to make the player go to the left
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-moveForce, 0), ForceMode2D.Impulse);
            }
            // Down -> Down
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Apply force to make the player go down
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -jumpForce), ForceMode2D.Impulse);
            }
            // Right -> Right
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Apply force to make the player go right
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(moveForce, 0), ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player is on the ground
        if (collision.gameObject.tag == "platform")
        {
            // The player can jump
            canJump = true;
        }
    }
}
