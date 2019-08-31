using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObjectGrow : MonoBehaviour {

    public float growthSpeed;

	// Update is called once per frame
	void Update () {
        transform.localScale += new Vector3(growthSpeed, growthSpeed);	
	}
}
