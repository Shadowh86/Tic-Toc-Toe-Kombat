using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RemovePlayerPrefs : MonoBehaviour
{

    GameManager gm;


    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }
    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        gm.ResetGame();
    }
}
