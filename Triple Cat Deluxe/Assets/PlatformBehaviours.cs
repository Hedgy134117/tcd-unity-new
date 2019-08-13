using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviours : MonoBehaviour
{

    private PlatformData platformData;

    private void Start()
    {
        platformData = this.gameObject.GetComponent<PlatformSetter>().platformData;
    }

    // Update is called once per frame
    void Update()
    {
        if (platformData.shrinksOverTime)
        {
            if (transform.localScale.x >= 0)
            {
                transform.localScale -= new Vector3(platformData.shrinkSpeed, 0, 0);
            }
        }
        
        if (platformData.rotatesAfterShrunk)
        {
            if (transform.localScale.x <= 0)
            {
                transform.Rotate(Vector3.one);
            }
        }

        if (platformData.rotatesConstantly)
        {
            transform.Rotate(new Vector3(0, 0, platformData.rotateSpeed));
        }
    }
}
