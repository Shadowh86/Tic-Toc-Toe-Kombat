using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressedButton : MonoBehaviour
{
    Image sides;
    [SerializeField]
    Sprite[] sprites;

    int arraySprite;

    private void Start()
    {
        arraySprite = 0;
    }

    public void ChangeSides()
    {
        if (arraySprite == 0)
        {
            arraySprite = 1;
            sides.gameObject.SetActive(true);
        }
        else
        {
            arraySprite = 0;
        }
    }
}
