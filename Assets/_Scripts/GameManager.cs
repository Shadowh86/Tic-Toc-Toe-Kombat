using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Array")] public Text[] fieldList; //text polja koji je sakriven
    public Image[] fieldImageList;
    [Header("Panels")] public GameObject gameOverPanel;
    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    [Header("Active Game Panel")] public Text playerOneName; //ime playera jedan na Game panelu
    public Text playerTwoName; //ime playera dva na Game panelu
    public InputField playerOneNameInput; //Unos imena playera jedan na Main Panelu
    public InputField playerTwoNameInput; //Unos imena playera dva na Main Panelu
    public Text scorePlOne; //iznos bodova playera jedan na game panelu
    public Text scorePlTwo; //iznos bodova playera dva na game panelu
    public Text movesText; //Broj poteza
    [SerializeField] private Button startButton;
    [Header("Other / X & O")] public string side; // Može imati vrijednost X ili O
    public int moves = 1; //Koliko smo napravili poteza

    [Header("Audio")] public AudioSource hitSound;
    public Slider musicSlider; // slider za muziku
    public AudioSource musicSource;


    [Header("Sprites")] [SerializeField] Sprite[] sprites;
    [SerializeField] Image image;

    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        hitSound = GetComponent<AudioSource>();

        gameOverPanel.SetActive(false);

        side = "X";
        spriteRenderer.sprite = sprites[1];
        moves = 1;

        CheckGamePanel();


        for (int i = 0; i < fieldList.Length; i++)
        {
            fieldList[i].text = "";
            fieldList[i].GetComponentInParent<Button>().interactable = true;
        }

        for (int i = 0; i < fieldImageList.Length; i++)
        {
            fieldImageList[i].sprite = null;
            fieldImageList[i].GetComponentInParent<Button>().interactable = true;
        }

        scorePlOne.text = PlayerPrefs.GetInt("ScoreOne").ToString();
        scorePlTwo.text = PlayerPrefs.GetInt("ScoreTwo").ToString();

        playerOneName.text = PlayerPrefs.GetString("PlayerOne");
        playerTwoName.text = PlayerPrefs.GetString("PlayerTwo");

        movesText.text = "Move " + moves + ".";
    }

    void CheckGamePanel()
    {
        if (mainMenuPanel.activeSelf == true && gameOverPanel.activeSelf == false)
        {
            gamePanel.SetActive(false);
        }

        else if (mainMenuPanel.activeSelf == false && gameOverPanel.activeSelf == false)
        {
            gamePanel.SetActive(true);
        }
    }

    private void Update()
    {
        playerOneNameInput.onValueChanged.AddListener(arg0 =>
        {
            if (playerOneNameInput.text.Length > 2)
            {
                if (playerTwoNameInput.text.Length > 2)
                {
                    startButton.interactable = true;
                }
            }
        });


        CheckGamePanel();
        musicSource.volume = musicSlider.value;
        if (gameOverPanel.activeSelf == true)
        {
            musicSlider.gameObject.SetActive(false);
        }
        else
        {
            musicSlider.gameObject.SetActive(true);
        }
    }


    //Metoda koja mjenja tko je na potezu
    public void ChageSide()
    {
        if (side == "X")
        {
            side = "O";
        }
        else
        {
            side = "X";
        }

        if (spriteRenderer.sprite == sprites[0])
        {
            spriteRenderer.sprite = sprites[1];
        }
        else
        {
            spriteRenderer.sprite = sprites[0];
        }

        //Prikazi da je novi potez
        movesText.text = "Move " + moves + ".";
    }

    //Metoda sa kojom provjeravmo imamo li Pobjednika
    public void EndGame()
    {
        if (fieldList[0].text == side && fieldList[1].text == side && fieldList[2].text == side)
        {
            CheckWin();
        }
        else if (fieldList[3].text == side && fieldList[4].text == side && fieldList[5].text == side)
        {
            CheckWin();
        }
        else if (fieldList[6].text == side && fieldList[7].text == side && fieldList[8].text == side)
        {
            CheckWin();
        }
        else if (fieldList[0].text == side && fieldList[3].text == side && fieldList[6].text == side)
        {
            CheckWin();
        }
        else if (fieldList[1].text == side && fieldList[4].text == side && fieldList[7].text == side)
        {
            CheckWin();
        }
        else if (fieldList[2].text == side && fieldList[5].text == side && fieldList[8].text == side)
        {
            CheckWin();
        }
        else if (fieldList[0].text == side && fieldList[4].text == side && fieldList[8].text == side)
        {
            CheckWin();
        }
        else if (fieldList[2].text == side && fieldList[4].text == side && fieldList[6].text == side)
        {
            CheckWin();
        }
        else if (moves > 9)
        {
            CheckWin();
        }

        ChageSide();
    }

    public void ResetGame()
    {
        Start();
    }

    //Nakon što smo ili postavili 3 u nizu ista znaka ili je nerješeno pali game over panel i prikazuje rezultat
    void CheckWin()
    {
        gameOverPanel.SetActive(true); //Upali game over panel
        gamePanel.SetActive(false);
        //Ako je 10 "potez" koji je nemogući, dakle nerješeno je
        if (moves > 9)
        {
            //Uzimamo od childa jer game over panel ima child koji je text
            gameOverPanel.GetComponentInChildren<Text>().text = "TIE!";
        }
        //X pobjedio - Prvi Player
        else if (moves % 2 == 0)
        {
            gameOverPanel.GetComponentInChildren<Text>().text = playerOneName.text + " WINS!";

            PlayerPrefs.SetInt("ScoreOne", PlayerPrefs.GetInt("ScoreOne") + 1);
        }
        //O pobjedio - Drugi Player
        else
        {
            gameOverPanel.GetComponentInChildren<Text>().text = playerTwoName.text + " WINS!";
            PlayerPrefs.SetInt("ScoreTwo", PlayerPrefs.GetInt("ScoreTwo") + 1);
        }

        hitSound.Play();
    }

    //Poziva se na play gumb kada se unesu imena
    public void SetUpName()
    {
        //Promjeni vrijednost imena isključivo ako su unjeta imena
        if (playerOneNameInput.text != "" && playerTwoNameInput.text != "")
        {
            playerOneName.text = playerOneNameInput.text;
            playerTwoName.text = playerTwoNameInput.text;
            PlayerPrefs.SetString("PlayerOne", playerOneName.text);
            PlayerPrefs.SetString("PlayerTwo", playerTwoName.text);
        }
    }
}