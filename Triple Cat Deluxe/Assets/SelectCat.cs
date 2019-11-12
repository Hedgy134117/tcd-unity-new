using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCat : MonoBehaviour
{
    public UICatSelect catManager;
    public CatData cat;

    // Start is called before the first frame update
    void Start()
    {
        catManager = GameObject.Find("CatManager").GetComponent<UICatSelect>();
        catManager.playerSelecting = 1;
    }

    public void catSelect()
    {
        catManager.selectCat(cat);
    }

    public void randomCatSelect()
    {
        catManager.randomSelectCat();
    }
}
