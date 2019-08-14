using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CardSetter : MonoBehaviour
{

    private Image bg;
    public CardData cardData;
    public CardManager cardManager;

    public Sprite bg1;
    public Sprite bg2;
    public Sprite bg3;
    public Sprite bg4;

    public TMP_Text cardName;
    public Image cardImage;
    public TMP_Text cardLore;
    public TMP_Text cardEffect;

    [HideInInspector]
    public bool cardDrawn = false;

    public float timerLength;

    private void Start()
    {
        cardManager = GameObject.Find("CardManager").GetComponent<CardManager>();
    }

    private void LateUpdate()
    {
        // If the player presses the space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Draw a card
            DrawCard();
        }

        // If the card is drawn
        if (cardDrawn)
        {
            // Start a timer
            timerLength -= Time.deltaTime;

            // When the tiemr ends
            if (timerLength <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void DrawCard()
    {
        // If a card has not already been drawn
        if (cardDrawn == false)
        {
            // Choose a random card
            int random = Random.Range(0, cardManager.defaultCards.Count - 1);
            cardData = cardManager.defaultCards[random];
            cardManager.cardData = cardData;

            bg = this.gameObject.GetComponent<Image>();

            // Make it visible
            bg.color = new Color(255, 255, 255, 255);

            // Set the correct background
            if (cardData.pointValue == 1)
            {
                bg.sprite = bg1;
            }
            else if (cardData.pointValue == 2)
            {
                bg.sprite = bg2;
            }
            else if (cardData.pointValue == 3)
            {
                bg.sprite = bg3;
            }
            else if (cardData.pointValue == 4)
            {
                bg.sprite = bg4;
            }

            // Set all the text and images
            // Also set them visible
            cardName.text = cardData.cardName;
            cardName.gameObject.SetActive(true);
            cardImage.sprite = cardData.cardImage;
            cardImage.gameObject.SetActive(true);
            cardLore.text = cardData.cardLore;
            cardLore.gameObject.SetActive(true);
            cardEffect.text = cardData.cardEffect;
            cardEffect.gameObject.SetActive(true);

            // Player drew a card, set cardDrawn to true
            cardDrawn = true;
        }
    }

}
