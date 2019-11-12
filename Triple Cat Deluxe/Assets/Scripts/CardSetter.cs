using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CardSetter : MonoBehaviour
{

    public Animator revealCardAnim;
    public Animator flipCardAnim;
    private Image bg;
    public CardData cardData;
    public CardManager cardManager;

    public Sprite bg1;
    public Sprite bg2;
    public Sprite bg3;
    public Sprite bg4;
    public Sprite bord1;
    public Sprite bord2;
    public Sprite bord3;
    public Sprite bord4;

    public Image cardNameBg;
    public TMP_Text cardName;
    public Image cardImage;
    public TMP_Text cardLore;
    public TMP_Text cardEffect;
    public Image cardBorder;

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
            DrawCard(true);
        }

        // If the card is drawn
        if (cardDrawn)
        {
            // Start a timer
            timerLength -= Time.deltaTime;

            // When the tiemr ends
            if (timerLength <= 0)
            {
                SceneManager.LoadScene("_Game", LoadSceneMode.Single);
            }
        }
    }

    public void DrawCard(bool usingKeyboard)
    {
        // If a card has not already been drawn
        if (cardDrawn == false)
        {
            // Play the animation
            revealCardAnim.Play("Reveal Card");

            if (usingKeyboard)
            {
                flipCardAnim.Play("FlipCard");
            }

            // Choose a random card
            int random = Random.Range(0, cardManager.defaultCards.Count - 1);
            cardData = cardManager.defaultCards[random];
            cardManager.cardData = cardData;

            bg = this.gameObject.GetComponent<Image>();

            // Make it visible
            bg.color = new Color(255, 255, 255, 255);

            // Set the correct background and border
            if (cardData.pointValue == 1)
            {
                bg.sprite = bg1;
                cardBorder.sprite = bord1;
            }
            else if (cardData.pointValue == 2)
            {
                bg.sprite = bg2;
                cardBorder.sprite = bord2;
            }
            else if (cardData.pointValue == 3)
            {
                bg.sprite = bg3;
                cardBorder.sprite = bord3;
            }
            else if (cardData.pointValue == 4)
            {
                bg.sprite = bg4;
                cardBorder.sprite = bord4;
            }

            // Set all the text and images
            // Also set them visible
            cardNameBg.gameObject.SetActive(true);
            cardName.text = cardData.cardName;
            cardName.gameObject.SetActive(true);
            cardImage.sprite = cardData.cardImage;
            cardImage.gameObject.SetActive(true);
            cardLore.text = cardData.cardLore;
            cardLore.gameObject.SetActive(true);
            cardEffect.text = cardData.cardEffect;
            cardEffect.gameObject.SetActive(true);
            cardBorder.gameObject.SetActive(true);

            // Player drew a card, set cardDrawn to true
            cardDrawn = true;
        }
    }

}
