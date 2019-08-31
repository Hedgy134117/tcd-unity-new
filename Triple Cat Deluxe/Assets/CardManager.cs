using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour {

    public List<CardData> defaultCards;

    public CardData cardData;

    bool effectApplied = false;

    

    // Put object in dont destroy on load
    private static CardManager cardManagerInstance;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (cardManagerInstance == null)
        {
            cardManagerInstance = this;
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "_Game" && !effectApplied)
        {
            CardEffect();
        }
        if (SceneManager.GetActiveScene().name != "_Game" && effectApplied)
        {
            effectApplied = false;
        }
    }

    

    void CardEffect()
    {
        GameObject playerOne = GameObject.FindGameObjectWithTag("playerOne");
        GameObject playerTwo = GameObject.FindGameObjectWithTag("playerTwo");
        GameObject platform = GameObject.FindGameObjectWithTag("platform");

        if (effectApplied == false)
        {
            // If the card spawns an object and the object hasn't spawned yet
            if (cardData.spawnsObject)
            {
                // Spawn the object x amount of times 
                for (int i = 0; i < cardData.amountToSpawn; i++)
                {
                    // If the card spawns the objects at random positions
                    if (cardData.randomSpawn)
                    {
                        Instantiate(cardData.obj, new Vector3(Random.Range(-5f, 5f), Random.Range(1.5f, 4.5f), 0), new Quaternion(0, 0, 0, 0));
                    }
                    else
                    {
                        Instantiate(cardData.obj, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
                    }
                }

                effectApplied = true;
            }
            // If the card impacts stats
            if (cardData.impactsStats)
            {
                // Impact each stat
                playerOne.GetComponent<CatMovement>().moveForce *= cardData.speedMultiplier;
                playerOne.GetComponent<CatMovement>().jumpForce *= cardData.jumpMultiplier;
                playerOne.transform.localScale = new Vector3(playerOne.transform.localScale.x * cardData.sizeMultiplierX, playerOne.transform.localScale.y * cardData.sizeMultiplierY, playerOne.transform.localScale.z);
                playerTwo.GetComponent<CatMovement>().moveForce *= cardData.speedMultiplier;
                playerTwo.GetComponent<CatMovement>().jumpForce *= cardData.jumpMultiplier;
                playerTwo.transform.localScale = new Vector3(playerTwo.transform.localScale.x * cardData.sizeMultiplierX, playerTwo.transform.localScale.y * cardData.sizeMultiplierY, playerTwo.transform.localScale.z); ;
                effectApplied = true;
            }
            // If the card has it's own special thing
            if (cardData.specialEffect)
            {
                switch (cardData.cardName)
                {
                    // Sick Cats
                    // Each cat has a green tint
                    case "Sickly Mickly":
                        playerOne.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                        playerTwo.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                        effectApplied = true;
                        break;

                    // Ground Shakes
                    case "meOW":
                        platform.transform.localPosition += new Vector3(Random.Range(-0.5f, 0.5f), 0f, 0f);
                        break;

                    // Flying Cats
                    case "Rocky":
                        playerOne.GetComponent<CatMovement>().canFly = true;
                        playerTwo.GetComponent<CatMovement>().canFly = true;
                        effectApplied = true;
                        break;

                    // Rising Platform
                    case "Fwuffy Jr.":
                        platform.transform.localPosition += new Vector3(0f, 0.01f);
                        break;

                    // Slippery Floor
                    case "Scrub a Dub Tub":
                        platform.GetComponent<Rigidbody2D>().sharedMaterial = cardData.specialMaterial;
                        effectApplied = true;
                        break;

                    // Walls
                    case "Kitty Korner":
                        Instantiate(cardData.specialObjects[0], new Vector3(-11f, 4f, 1f), Quaternion.identity);
                        Instantiate(cardData.specialObjects[1], new Vector3(11f, 4f, 1f), Quaternion.identity);
                        effectApplied = true;
                        break;

                    // Cats are attracted to eachother
                    case "Nice Kitty":
                        playerOne.transform.localPosition = Vector3.MoveTowards(playerOne.transform.localPosition, playerTwo.transform.localPosition, 1f);
                        playerTwo.transform.localPosition = Vector3.MoveTowards(playerTwo.transform.localPosition, playerOne.transform.localPosition, 1f);
                        break;
                }
            }
        }
        
    }
}
