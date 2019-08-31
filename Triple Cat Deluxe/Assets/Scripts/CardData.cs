using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Card", menuName = "Card", order = 53)]
public class CardData : ScriptableObject {

    public string cardName;
    public Sprite cardImage;
    public string cardLore;
    public string cardEffect;

    public int pointValue;

    [Header("Effects")]
    public bool spawnsObject;
    public GameObject obj;
    public int amountToSpawn = 1;
    public bool randomSpawn;
    [Space(10)]
    public bool impactsStats;
    public float speedMultiplier = 1;
    public float jumpMultiplier = 1;
    public float sizeMultiplierX = 1;
    public float sizeMultiplierY = 1;
    [Space(10)]
    public bool specialEffect;
    public PhysicsMaterial2D specialMaterial;
    public List<GameObject> specialObjects;

}