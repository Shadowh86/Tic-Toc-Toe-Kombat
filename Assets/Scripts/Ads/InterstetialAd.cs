using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class InterstetialAd : MonoBehaviour
{
    [SerializeField]
    string adID;

    //ovaj bool ostavljamo namjerno private i stavljamo ga true dok god testiramo zato što ako je false, a igra nije objavljena dobiti ćemo ban
    bool testMode = true; //true testiramo, false javno

    private void Start()
    {
        //Inicijaliziraj Ad-ove
        Advertisement.Initialize(adID, testMode);
    }

    //Pokaži ad na klik gumba
    public void ShowInterstitialAd()
    {
        //provjeri jel UnityADS spreman za prikazati reklamu
        if (Advertisement.IsReady())
        {
            Debug.Log("Showing comecial: " + Advertisement.isShowing);
            //Spreman je reklama
            Advertisement.Show();

        }
        else
        {
            Debug.Log("Ad cannot be shown right now");
        }
    }
}
