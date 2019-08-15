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

        if (effectApplied == false)
        {
            // If the card spawns an object
            if (cardData.spawnsObject)
            {
                // Spawn the object x amount of times 
                for (int i = 0; i < cardData.amountToSpawn; i++)
                {
                    if (cardData.randomSpawn)
                    {
                        Instantiate(cardData.obj, new Vector3(Random.Range(-5f, 5f), Random.Range(1.5f, 4.5f), 0), new Quaternion(0, 0, 0, 0));
                    }
                    else
                    {
                        Instantiate(cardData.obj, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
                    }
                }
            }
            // If the card impacts stats
            if (cardData.impactsStats)
            {
                // Impact each stat
                playerOne.GetComponent<CatMovement>().moveForce *= cardData.speedMultiplier;
                playerOne.GetComponent<CatMovement>().jumpForce *= cardData.jumpMultiplier;
                playerOne.transform.localScale *= cardData.sizeMultiplier;
                playerTwo.GetComponent<CatMovement>().moveForce *= cardData.speedMultiplier;
                playerTwo.GetComponent<CatMovement>().jumpForce *= cardData.jumpMultiplier;
                playerTwo.transform.localScale *= cardData.sizeMultiplier;
            }
            // If the card has it's own special thing
            if (cardData.specialEffect)
            {
                switch (cardData.cardName)
                {
                    case "Sickly Mickly":
                        playerOne.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                        playerTwo.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                        break;
                }
            }

            effectApplied = true;
        }
        
    }
}
