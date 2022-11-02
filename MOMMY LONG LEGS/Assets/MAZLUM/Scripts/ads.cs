using UnityEngine;
using System;
using GoogleMobileAds.Api;
using System.Collections;
using UnityEngine.UI;

public enum AdType
{
    INTERSTITIAL,
    REWARDEDLETTER,
    REWARDEDCHANGE,
    REWARDEDCOOL,
    REWARDEDFÝRE,
    REWARDEDHEALTH,
    REWARDEDELECTRO,
    REWARDEDPOISON,
    REWARDEDSHÝELD,
    REWARDED2X,
    REWARDED3X,
    REWARDED5X,
}

public class ads : MonoBehaviour
{
    [HideInInspector]
    public string interstitialId, rewardedAdIdChange, rewardedAdIdLetter;
    [HideInInspector]
    public string rewardedAdIdCool, rewardedAdIdFire, rewardedAdIdHealth, rewardedAdIdElectro, rewardedAdIdPoison, rewardedAdIdShield;
    [HideInInspector]
    public string rewardedAdId2x, rewardedAdId3x, rewardedAdId5x;

    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAdChange;
    private RewardedAd rewardedAdLetter;
    private RewardedAd rewardedAdCool;
    private RewardedAd rewardedAdFire;
    private RewardedAd rewardedAdHealth;
    private RewardedAd rewardedAdElectro;
    private RewardedAd rewardedAdPoison;
    private RewardedAd rewardedAdShield;

    private RewardedAd rewardedAd2x;
    private RewardedAd rewardedAd3x;
    private RewardedAd rewardedAd5x;

    public static ads instance;
    private IAPManager iapManager;

    [SerializeField] private GameObject noAdsButton;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null) instance = this;
        else Destroy(gameObject);

        iapManager = new IAPManager();
        NoAdsButtonAktifligi();
        // ctrl + k + c
        //if (Application.platform == RuntimePlatform.Android)
        //{
        //    interstitialId = "ca-app-pub-1131363594533119/9369877922";

        //    rewardedAdIdChange = "ca-app-pub-1131363594533119/5430632913";

        //    rewardedAdIdLetter = "ca-app-pub-1131363594533119/5430632913";
        //}
        //else
        //{
        //    interstitialId = "ca-app-pub-1131363594533119/3379184647";

        //    rewardedAdIdChange = "ca-app-pub-1131363594533119/2233909348";

        //    rewardedAdIdLetter = "ca-app-pub-1131363594533119/2233909348";
        //}

        #region TestId

        interstitialId = "ca-app-pub-3940256099942544/1033173712";

        rewardedAdIdChange = "ca-app-pub-3940256099942544/5224354917";

        rewardedAdIdLetter = "ca-app-pub-3940256099942544/5224354917";

        rewardedAdIdCool = "ca-app-pub-3940256099942544/5224354917";

        rewardedAdIdFire = "ca-app-pub-3940256099942544/5224354917";

        rewardedAdIdHealth = "ca-app-pub-3940256099942544/5224354917";

        rewardedAdIdPoison = "ca-app-pub-3940256099942544/5224354917";

        rewardedAdIdShield = "ca-app-pub-3940256099942544/5224354917";

        rewardedAdIdElectro = "ca-app-pub-3940256099942544/5224354917";

        rewardedAdId2x = "ca-app-pub-3940256099942544/5224354917";

        rewardedAdId3x = "ca-app-pub-3940256099942544/5224354917";

        rewardedAdId5x = "ca-app-pub-3940256099942544/5224354917";

        

        #endregion
    }

    void Start()
    {
        MobileAds.Initialize(reklamDurumu => { });

        requestAds(AdType.INTERSTITIAL);
        requestAds(AdType.REWARDEDLETTER);
        requestAds(AdType.REWARDEDCHANGE);

        requestAds(AdType.REWARDEDCOOL);
        requestAds(AdType.REWARDEDFÝRE);
        requestAds(AdType.REWARDEDHEALTH);
        requestAds(AdType.REWARDEDELECTRO);
        requestAds(AdType.REWARDEDPOISON);
        requestAds(AdType.REWARDEDSHÝELD);

        requestAds(AdType.REWARDED2X);
        requestAds(AdType.REWARDED3X);
        requestAds(AdType.REWARDED5X);


        this.rewardedAdLetter.OnUserEarnedReward += RewardLetter;
        this.rewardedAdChange.OnUserEarnedReward += RewardChange;

        this.rewardedAdCool.OnUserEarnedReward += RewardCool;
        this.rewardedAdFire.OnUserEarnedReward += RewardFire;
        this.rewardedAdHealth.OnUserEarnedReward += RewardHealth;
        this.rewardedAdPoison.OnUserEarnedReward += RewardPoison;
        this.rewardedAdShield.OnUserEarnedReward += RewardShield;
        this.rewardedAdElectro.OnUserEarnedReward += RewardElectro;
        this.rewardedAd2x.OnUserEarnedReward += Reward2x;
        this.rewardedAd3x.OnUserEarnedReward += Reward3x;
        this.rewardedAd5x.OnUserEarnedReward += Reward5x;

        this.rewardedAdLetter.OnAdClosed += RequestRewardedLetter;
        this.rewardedAdChange.OnAdClosed += RequestRewardedChange;
        this.interstitialAd.OnAdClosed += RequestInterstitial;

        this.rewardedAdCool.OnAdClosed += RequestRewardedCool;
        this.rewardedAdFire.OnAdClosed += RequestRewardedFire;
        this.rewardedAdHealth.OnAdClosed += RequestRewardedHealth;
        this.rewardedAdPoison.OnAdClosed += RequestRewardedPoison;
        this.rewardedAdShield.OnAdClosed += RequestRewardedShield;
        this.rewardedAdElectro.OnAdClosed += RequestRewardedElectro;
        this.rewardedAd2x.OnAdClosed += RequestRewarded2x;
        this.rewardedAd3x.OnAdClosed += RequestRewarded3x;
        this.rewardedAd5x.OnAdClosed += RequestRewarded5x;

    }

    #region CallBacks

    #region Load & Show

    void RewardLetter(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");

        oyunyoneticisi yonetici = FindObjectOfType<oyunyoneticisi>();

       // yonetici.CoolDown();

    }
    void RewardChange(object sender, Reward args)
    {
        Debug.Log("Change Ödülü");

        oyunyoneticisi yonetici = FindObjectOfType<oyunyoneticisi>();

       // yonetici.OyuncuyaOdulVer2();


    }
    void RewardCool(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");

        oyunyoneticisi yonetici = FindObjectOfType<oyunyoneticisi>();

        yonetici.CoolDownReklam();
        //oyunyoneticisi.kontrolCoolReklam = false;
    }
    void RewardFire(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");

        oyunyoneticisi yonetici = FindObjectOfType<oyunyoneticisi>();

        yonetici.FireReklam();
        //oyunyoneticisi.kontrolFireReklam = false;

    }
    void RewardHealth(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");

        oyunyoneticisi yonetici = FindObjectOfType<oyunyoneticisi>();

        yonetici.HealthReklam();
        //oyunyoneticisi.kontrolHealthReklam = false;

    }
    void RewardPoison(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");

        oyunyoneticisi yonetici = FindObjectOfType<oyunyoneticisi>();

        yonetici.PoisonReklam();
        //oyunyoneticisi.kontrolPoisonReklam = false;

    }
    void RewardShield(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");

        oyunyoneticisi yonetici = FindObjectOfType<oyunyoneticisi>();

        yonetici.ShieldReklam();
        //oyunyoneticisi.kontrolShieldReklam = false;

    }
    void RewardElectro(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");

        oyunyoneticisi yonetici = FindObjectOfType<oyunyoneticisi>();

        yonetici.ElectroReklam();
        //oyunyoneticisi.kontrolElectroReklam = false;

    }
    void Reward2x(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");

        moneybar moneyBar = FindObjectOfType<moneybar>();

        moneyBar.IkiX();

    }
    void Reward3x(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");

        moneybar moneyBar = FindObjectOfType<moneybar>();

        moneyBar.UcX();

    }
    void Reward5x(object sender, Reward args)
    {
        Debug.Log("Letter Ödülü");

        moneybar moneyBar = FindObjectOfType<moneybar>();

        moneyBar.BesX();
        

    }
    #endregion

    private void RequestRewardedLetter(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDEDLETTER);
    }
    private void RequestRewardedChange(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDEDCHANGE);
    }
    private void RequestInterstitial(object sender, EventArgs args)
    {
        requestAds(AdType.INTERSTITIAL);
    }

    private void RequestRewardedCool(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDEDCOOL);
    }
    private void RequestRewardedFire(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDEDFÝRE);
    }
    private void RequestRewardedHealth(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDEDHEALTH);
    }
    private void RequestRewardedPoison(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDEDPOISON);
    }
    private void RequestRewardedShield(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDEDSHÝELD);
    }
    private void RequestRewardedElectro(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDEDELECTRO);
    }
    private void RequestRewarded2x(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDED2X);
    }
    private void RequestRewarded3x(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDED3X);
    }
    private void RequestRewarded5x(object sender, EventArgs args)
    {
        requestAds(AdType.REWARDED5X);
    }

    //Show
    public void ShowRewardedLetter()
    {
        //this.rewardedAdLetter.OnUserEarnedReward -= RewardLetter;
        //this.rewardedAdLetter.OnUserEarnedReward += RewardLetter;

        //this.rewardedAdLetter.OnAdClosed -= RequestRewardedLetter;
        //this.rewardedAdLetter.OnAdClosed += RequestRewardedLetter;


        if (rewardedAdLetter.IsLoaded())
            rewardedAdLetter.Show();
    }
    public void ShowRewardedChange()
    {
        //this.rewardedAdChange.OnUserEarnedReward -= RewardChange;
        //this.rewardedAdChange.OnUserEarnedReward += RewardChange;

        //this.rewardedAdChange.OnAdClosed -= RequestRewardedChange;
        //this.rewardedAdChange.OnAdClosed += RequestRewardedChange;

        if (rewardedAdChange.IsLoaded())
            rewardedAdChange.Show();
    }
    public void ShowInter()
    {
        if (iapManager.ReklamEngellendimi()) return; //REKLAM ENGELLENDÝ

        //this.interstitialAd.OnAdClosed -= RequestInterstitial;
        //this.interstitialAd.OnAdClosed += RequestInterstitial;

        if (interstitialAd.IsLoaded())// REKLAM ÇALIÞTI
            interstitialAd.Show();
    }

    public void ShowRewardedCool()
    {
        //this.rewardedAdLetter.OnUserEarnedReward -= RewardLetter;
        //this.rewardedAdLetter.OnUserEarnedReward += RewardLetter;

        //this.rewardedAdLetter.OnAdClosed -= RequestRewardedLetter;
        //this.rewardedAdLetter.OnAdClosed += RequestRewardedLetter;


        if (rewardedAdCool.IsLoaded())
            rewardedAdCool.Show();
    }
    public void ShowRewardedFire()
    {
        //this.rewardedAdChange.OnUserEarnedReward -= RewardChange;
        //this.rewardedAdChange.OnUserEarnedReward += RewardChange;

        //this.rewardedAdChange.OnAdClosed -= RequestRewardedChange;
        //this.rewardedAdChange.OnAdClosed += RequestRewardedChange;

        if (rewardedAdFire.IsLoaded())
            rewardedAdFire.Show();
    }
    public void ShowRewardedHealth()
    {
        //this.rewardedAdLetter.OnUserEarnedReward -= RewardLetter;
        //this.rewardedAdLetter.OnUserEarnedReward += RewardLetter;

        //this.rewardedAdLetter.OnAdClosed -= RequestRewardedLetter;
        //this.rewardedAdLetter.OnAdClosed += RequestRewardedLetter;


        if (rewardedAdHealth.IsLoaded())
            rewardedAdHealth.Show();
    }
    public void ShowRewardedPoison()
    {
        //this.rewardedAdChange.OnUserEarnedReward -= RewardChange;
        //this.rewardedAdChange.OnUserEarnedReward += RewardChange;

        //this.rewardedAdChange.OnAdClosed -= RequestRewardedChange;
        //this.rewardedAdChange.OnAdClosed += RequestRewardedChange;

        if (rewardedAdPoison.IsLoaded())
            rewardedAdPoison.Show();
    }
    public void ShowRewardedShield()
    {
        //this.rewardedAdLetter.OnUserEarnedReward -= RewardLetter;
        //this.rewardedAdLetter.OnUserEarnedReward += RewardLetter;

        //this.rewardedAdLetter.OnAdClosed -= RequestRewardedLetter;
        //this.rewardedAdLetter.OnAdClosed += RequestRewardedLetter;


        if (rewardedAdShield.IsLoaded())
            rewardedAdShield.Show();
    }
    public void ShowRewardedElectro()
    {
        //this.rewardedAdChange.OnUserEarnedReward -= RewardChange;
        //this.rewardedAdChange.OnUserEarnedReward += RewardChange;

        //this.rewardedAdChange.OnAdClosed -= RequestRewardedChange;
        //this.rewardedAdChange.OnAdClosed += RequestRewardedChange;

        if (rewardedAdElectro.IsLoaded())
            rewardedAdElectro.Show();
    }
    public void ShowRewarded2x()
    {
        //this.rewardedAdChange.OnUserEarnedReward -= RewardChange;
        //this.rewardedAdChange.OnUserEarnedReward += RewardChange;

        //this.rewardedAdChange.OnAdClosed -= RequestRewardedChange;
        //this.rewardedAdChange.OnAdClosed += RequestRewardedChange;

        if (rewardedAd2x.IsLoaded())
            rewardedAd2x.Show();
    }
    public void ShowRewarded3x()
    {
        //this.rewardedAdChange.OnUserEarnedReward -= RewardChange;
        //this.rewardedAdChange.OnUserEarnedReward += RewardChange;

        //this.rewardedAdChange.OnAdClosed -= RequestRewardedChange;
        //this.rewardedAdChange.OnAdClosed += RequestRewardedChange;

        if (rewardedAd3x.IsLoaded())
            rewardedAd3x.Show();
    }
    public void ShowRewarded5x()
    {
        //this.rewardedAdChange.OnUserEarnedReward -= RewardChange;
        //this.rewardedAdChange.OnUserEarnedReward += RewardChange;

        //this.rewardedAdChange.OnAdClosed -= RequestRewardedChange;
        //this.rewardedAdChange.OnAdClosed += RequestRewardedChange;

        if (rewardedAd5x.IsLoaded())
            rewardedAd5x.Show();
    }



    #endregion

    #region  Request&Load
    public void requestAds(AdType type)
    {
        switch (type)
        {
            case AdType.INTERSTITIAL:
                {
                    if (interstitialAd != null) interstitialAd.Destroy();
                    interstitialAd = new InterstitialAd(interstitialId);
                    interstitialAd.LoadAd(new AdRequest.Builder().Build());
                    break;

                }

            case AdType.REWARDEDCHANGE:
                {
                    if (rewardedAdChange != null) rewardedAdChange.Destroy();
                    rewardedAdChange = new RewardedAd(rewardedAdIdChange);
                    rewardedAdChange.LoadAd(new AdRequest.Builder().Build());
                    break;
                }
            case AdType.REWARDEDLETTER:
                {
                    if (rewardedAdLetter != null) rewardedAdLetter.Destroy();
                    rewardedAdLetter = new RewardedAd(rewardedAdIdLetter);
                    rewardedAdLetter.LoadAd(new AdRequest.Builder().Build());
                    break;
                }

            case AdType.REWARDEDCOOL:
                {
                    if (rewardedAdCool != null) rewardedAdCool.Destroy();
                    rewardedAdCool = new RewardedAd(rewardedAdIdCool);
                    rewardedAdCool.LoadAd(new AdRequest.Builder().Build());
                    break;
                }
            case AdType.REWARDEDFÝRE:
                {
                    if (rewardedAdFire != null) rewardedAdFire.Destroy();
                    rewardedAdFire = new RewardedAd(rewardedAdIdFire);
                    rewardedAdFire.LoadAd(new AdRequest.Builder().Build());
                    break;
                }
            case AdType.REWARDEDHEALTH:
                {
                    if (rewardedAdHealth != null) rewardedAdHealth.Destroy();
                    rewardedAdHealth = new RewardedAd(rewardedAdIdHealth);
                    rewardedAdHealth.LoadAd(new AdRequest.Builder().Build());
                    break;
                }
            case AdType.REWARDEDPOISON:
                {
                    if (rewardedAdPoison != null) rewardedAdPoison.Destroy();
                    rewardedAdPoison = new RewardedAd(rewardedAdIdPoison);
                    rewardedAdPoison.LoadAd(new AdRequest.Builder().Build());
                    break;
                }
            case AdType.REWARDEDSHÝELD:
                {
                    if (rewardedAdShield != null) rewardedAdShield.Destroy();
                    rewardedAdShield = new RewardedAd(rewardedAdIdShield);
                    rewardedAdShield.LoadAd(new AdRequest.Builder().Build());
                    break;
                }
            case AdType.REWARDEDELECTRO:
                {
                    if (rewardedAdElectro != null) rewardedAdElectro.Destroy();
                    rewardedAdElectro = new RewardedAd(rewardedAdIdElectro);
                    rewardedAdElectro.LoadAd(new AdRequest.Builder().Build());
                    break;
                }
            case AdType.REWARDED2X:
                {
                    if (rewardedAd2x != null) rewardedAd2x.Destroy();
                    rewardedAd2x = new RewardedAd(rewardedAdId2x);
                    rewardedAd2x.LoadAd(new AdRequest.Builder().Build());
                    break;
                }
            case AdType.REWARDED3X:
                {
                    if (rewardedAd3x != null) rewardedAd3x.Destroy();
                    rewardedAd3x = new RewardedAd(rewardedAdId3x);
                    rewardedAd3x.LoadAd(new AdRequest.Builder().Build());
                    break;
                }
            case AdType.REWARDED5X:
                {
                    if (rewardedAd5x != null) rewardedAd5x.Destroy();
                    rewardedAd5x = new RewardedAd(rewardedAdId5x);
                    rewardedAd5x.LoadAd(new AdRequest.Builder().Build());
                    break;
                }


        }
    }
    #endregion
    public void NoAdsButtonAktifligi()
    {
        //SATIN ALMA ÝÞLEMÝ BÝTTÝKTEN SONRA BUTON AKTÝFLÝÐÝ SORGULAMA
        noAdsButton.SetActive(!iapManager.ReklamEngellendimi());
    }
    public void NoAdsButton()
    {
        // REKLAMI ENGELLEMEK ÝÇÝN BUTON ATAMASI
        iapManager.OnPurchaseClicked();
    }
}