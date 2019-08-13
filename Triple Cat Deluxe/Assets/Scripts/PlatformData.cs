using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Platform", menuName = "Platform", order = 52)]
public class PlatformData : ScriptableObject {

    public string platformName;
    public Sprite sprite;
    public Vector3 size = new Vector3(1, 1, 1);

    [Header("Behaviours")]
    public bool shrinksOverTime;
    public float shrinkSpeed = 0.002f;
    public bool rotatesAfterShrunk;
    public bool rotatesConstantly;
    public float rotateSpeed = 0.5f;

}
