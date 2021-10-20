using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldScript : MonoBehaviour
{
    //OBAVEZNO STAVITI NA SVAKI BUTTON
    public Text btnText;
    Button btn;
    public Image btnImage;
    
    GameManager gm;

    private void Start()
    {
        btn = GetComponent<Button>();
        gm = FindObjectOfType<GameManager>();
        btnText = GetComponentInChildren<Text>();
        btnImage = GetComponentInChildren<Image>();

    }

    public void SetSymbol()
    {
        btnText.text = gm.side;
        btnImage.sprite = gm.spriteRenderer.sprite;
        btn.interactable = false;
        gm.moves++;
        gm.EndGame();

        gm.hitSound.Play();
    }
}
