using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UISettingsLabel : MonoBehaviour {

    public bool isMultiplier;

    private void LateUpdate()
    {
        this.GetComponent<TMP_Text>().text = this.gameObject.GetComponentInParent<Slider>().value.ToString();

        if (isMultiplier)
        {
            this.GetComponent<TMP_Text>().text += "x";
        }
    }

}
