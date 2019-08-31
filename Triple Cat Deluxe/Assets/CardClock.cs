using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardClock : MonoBehaviour {

    private CardSetter cardSetter;
    private float timer;

    private void Start()
    {
        cardSetter = GameObject.Find("Card").GetComponent<CardSetter>();
    }

    private void Update()
    {
        timer = cardSetter.timerLength;
        this.GetComponent<Slider>().value = timer;
    }
}
