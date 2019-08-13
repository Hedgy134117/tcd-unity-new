using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardSetter : MonoBehaviour
{

    private Image bg;
    public CardData cardData;

    public List<Sprite> cardBackgrounds;

    public TMP_Text cardName;
    public Image cardImage;
    public TMP_Text cardLore;
    public TMP_Text cardEffect;

    public void DrawCard()
    {
        bg = this.gameObject.GetComponent<Image>();

        // Make it visible
        bg.color = new Color(255, 255, 255, 255);

        // Set the correct background
        bg.sprite = cardBackgrounds[cardData.pointValue - 1];

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
    }

}
