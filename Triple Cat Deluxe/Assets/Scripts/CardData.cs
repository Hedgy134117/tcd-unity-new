using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card", order = 53)]
public class CardData : ScriptableObject {

    public string cardName;
    public Sprite cardImage;
    public string cardLore;
    public string cardEffect;

    public int pointValue;

}