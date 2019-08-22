using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cat", menuName = "Cat", order = 51)]
public class CatData : ScriptableObject {

    public string catName;
    public bool facingRight;
    public Vector3 size = new Vector3(1, 1, 1);
    public Sprite sprite;
    public Sprite winSprite;

}
