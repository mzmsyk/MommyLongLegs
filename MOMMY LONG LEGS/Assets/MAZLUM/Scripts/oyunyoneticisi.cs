using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class oyunyoneticisi : MonoBehaviour
{
    public TextMeshProUGUI altinText;
    public static int altin = 200;
    GameObject Dusman;
    bool kntrl = true;
    public GameObject[] olusacakObjeler;
    public GameObject[] olusacakAlanlar;
    public int[] dalgadakiObjeSayisi;
    GameObject Spawnlama;
    GameObject OkHareketi;
    public Vector3 okunUzamaMiktari;
    public GameObject yetenekBar;
    public float yetenekBarSayac;
    public static bool kontrolElUzama = false;
    public static bool kontrolShild = false;
    public static bool kontrolCoolDown = false;
    public static bool kontrolFire = false;
    public static bool kontrolElectro = false;
    public static bool kontrolPoison = false;
    public GameObject transparantImage;
    public float sure;
    public float zaman;
    public GameObject effect;
    public GameObject kartPanel;
    public GameObject ilkAcilisSkillBar;
    public GameObject ilkAcilisSkillBar2;
    [Header("SKÝLLS")]
    public GameObject skillerCool;
    public GameObject skillerFire;
    public GameObject skillerHealth;
    public GameObject skillerElectro;
    public GameObject skillerPoison;
    public GameObject skillerShield;
    public GameObject skillerKlonCool;
    public GameObject skillerKlonFire;
    public GameObject skillerKlonHealth;
    public GameObject skillerKlonElectro;
    public GameObject skillerKlonPoison;
    public GameObject skillerKlonShield;
    public GameObject zamanlayiciCool;
    public GameObject zamanlayiciFire;
    public GameObject zamanlayiciHealth;
    public GameObject zamanlayiciElectro;
    public GameObject zamanlayiciPoison;
    public GameObject zamanlayiciShield;
    public GameObject ikinciEl;
    public GameObject effectHealth;
    [Header("REKLAM KISMI COOL")]    
    public int yetenekLevelCool=0;
    public int altinCool;
    public TextMeshProUGUI yetenekLevelCoolText;
    public TextMeshProUGUI yetenekAltinCoolText;
    public GameObject coolReklam;
    public static bool kontrolCoolReklam = false;

    [Header("REKLAM KISMI FIRE")]
    public int yetenekLevelFire=0;
    public int altinFire;
    public TextMeshProUGUI yetenekLevelFireText;
    public TextMeshProUGUI yetenekAltinFireText;
    public GameObject fireReklam;
    public static bool kontrolFireReklam = false;
    [Header("REKLAM KISMI HEALTH")]
    public int yetenekLevelHealth = 0;
    public int altinHealth;
    public TextMeshProUGUI yetenekLevelHealthText;
    public TextMeshProUGUI yetenekAltinHealthText;
    public GameObject healthReklam;
    public static bool kontrolHealthReklam = false;
    [Header("REKLAM KISMI SHIELD")]
    public int yetenekLevelShield = 0;
    public int altinShield;
    public TextMeshProUGUI yetenekLevelShieldText;
    public TextMeshProUGUI yetenekAltinShieldText;
    public GameObject shieldReklam;
    public static bool kontrolShieldReklam = false;
    [Header("REKLAM KISMI POISON")]
    public int yetenekLevelPoison = 0;
    public int altinPoison;
    public TextMeshProUGUI yetenekLevelPoisonText;
    public TextMeshProUGUI yetenekAltinPoisonText;
    public GameObject poisonReklam;
    public static bool kontrolPoisonReklam = false;
    [Header("REKLAM KISMI ELECTRO")]
    public int yetenekLevelElectro = 0;
    public int altinElectro;
    public TextMeshProUGUI yetenekLevelElectroText;
    public TextMeshProUGUI yetenekAltinElectroText;
    public GameObject electroReklam;
    public static bool kontrolElectroReklam = false;
    [Header("KAYBETME PANELÝ")]
    public GameObject kaybetmePanel;
    public TextMeshProUGUI dolarKaybetmeText;
    public TextMeshProUGUI canavarOldurmeKaybetmeText;
    [Header("KAZANMA PANELÝ")]
    public GameObject kazanmaPanel;
    public TextMeshProUGUI dolarKazanmaText;
    public TextMeshProUGUI canavarOldurmeKazanmaText;
    [Header("DALGALAR")]
    public GameObject[] dalgalarIsim;
    public int dalgalarIsimSayac=0;
    [Header("OYUNA BAÞLA")]
    public GameObject oyunaBaslaButton;
    public static int dolarKayit;
    public int sayacDalga;
    bool kontrolGecisReklam=true;
    public static bool kontrolreklam = false;

    public TextMeshProUGUI levelBarText;
    public TextMeshProUGUI dalgaKacText;
    public TextMeshProUGUI levelText;

    public GameObject[] yetenekBarArti;
    public static int yetenekBarArtiSayac;
   


    public static bool kontrolHealthYavas = false;
    public TextMeshProUGUI coolTextFull;
    public TextMeshProUGUI shieldTextFull;
    public TextMeshProUGUI poisonTextFull;
    public TextMeshProUGUI healthTextFull;
    public TextMeshProUGUI fireTextFull;
    public TextMeshProUGUI electroTextFull;
    public GameObject coolFull;
    public GameObject fireFull;
    public GameObject helathFull;
    public GameObject poisonFull;
    public GameObject shieldFull;
    public GameObject electroFull;

    public static bool kntrldigerLevel=true;
    public int dalgaSayisi;
    //public static oyunyoneticisi instance;
    void Start()
    {
        PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name));
        
        dolarKayit += altin;    //PlayerPrefs.GetInt("dolarKayit")+dolarKayit;
        altinCool = 200;
        altinFire = 200;
        altinHealth = 200;
        altinShield = 200;
        altinPoison = 200;
        altinElectro = 200;
        Dusman = GameObject.FindGameObjectWithTag("dusman");
        Spawnlama = GameObject.FindGameObjectWithTag("Respawn");
        OkHareketi = GameObject.FindGameObjectWithTag("Player");
        altin = 100;
        altinText.text = (dolarKayit).ToString();
        zaman = sure;
        //ilkAcilisSkillBar.SetActive(true);
        kartPanel.SetActive(true);
        OkHareketi.GetComponent<okhareketi>().kontrolMouse = false;
        yetenekAltinCoolText.text = altinCool.ToString();
        yetenekAltinFireText.text = altinFire.ToString();
        yetenekAltinHealthText.text = altinHealth.ToString();
        yetenekAltinShieldText.text = altinShield.ToString();
        yetenekAltinPoisonText.text = altinPoison.ToString();
        yetenekAltinElectroText.text = altinElectro.ToString();
        levelBarText.text = "LVL "+int.Parse(SceneManager.GetActiveScene().name).ToString();
        dalgaKacText.text = (sayacDalga+1).ToString() + "-" + dalgadakiObjeSayisi.Length.ToString();
        levelText.text = "CHAPTER " + SceneManager.GetActiveScene().name;
        Time.timeScale = 0;
        dalgalarIsim[dalgalarIsimSayac].SetActive(false);
        
        Invoke("d", 0.3f);
        
        Invoke("DIK", 1.5f);
        //StartCoroutine(SkillsTimer());
    }

    // Update is called once per frame
    void Update()
    {
        // PlayerPrefs.SetInt("dolarKayit", altin);
        //StartCoroutine(SkillsTimer());
        
        yetenekLevelCoolText.text = yetenekLevelCool.ToString();
        yetenekLevelFireText.text = yetenekLevelFire.ToString();
        yetenekLevelHealthText.text = yetenekLevelHealth.ToString();
        yetenekLevelShieldText.text = yetenekLevelShield.ToString();
        yetenekLevelPoisonText.text = yetenekLevelPoison.ToString();
        yetenekLevelElectroText.text = yetenekLevelElectro.ToString();
        //dolarKayit = PlayerPrefs.GetInt("dolarKayit");
        if (kontrolreklam)
        {
            dolarKayit += altin;
            altin = 0;
            kontrolreklam = false;
        }
        altinText.text = (dolarKayit+altin).ToString();
        StartCoroutine(Dalgalar());
        dolarKaybetmeText.text = (dolarKayit + altin).ToString();
        canavarOldurmeKaybetmeText.text = okhareketi.canavarOldurme.ToString();
        dolarKazanmaText.text = (dolarKayit + altin).ToString();
        canavarOldurmeKazanmaText.text = okhareketi.canavarOldurme.ToString();
        dalgaKacText.text =(sayacDalga+1).ToString()+ "-"+dalgadakiObjeSayisi.Length.ToString();
        if (OkHareketi.GetComponent<okhareketi>().can==0&&kontrolGecisReklam)
        {
            kaybetmePanel.SetActive(true);
            for (int j = 0; j < dalgalarIsim.Length; j++)
            {
                dalgalarIsim[j].SetActive(false);
            }
            okhareketi.sonObjeSayac = 0;
            rota.sonObjeSayac = 0;
            kontrolGecisReklam = false;
            ads.instance.ShowInter();
            Time.timeScale = 0;

        }
        PlayerPrefs.SetInt("dolarKayit", dolarKayit);
        if (!kontrolGecisReklam)
        {
            Time.timeScale = 0;
        }
        //if (dalgalarIsimSayac<=0&&dalgalarIsimSayac<3)
        //{
        //    ilkAcilisSkillBar.SetActive(true);
        //    ilkAcilisSkillBar2.SetActive(false);
        //}
        //if (dalgalarIsimSayac>=3&&dalgalarIsimSayac<5)
        //{
        //    ilkAcilisSkillBar.SetActive(false);
        //    ilkAcilisSkillBar2.SetActive(true);
        //}
        if (kontrolShild)
        {
            // rota.hasar /= 4;
            Invoke("h", 2f);
        }
        if (kontrolCoolDown)
        {
            Invoke("c", 3f);
        }
        if (kontrolElUzama)
        {
            Invoke("e",1);
        }
        if (kontrolHealthYavas)
        {
            OkHareketi.GetComponent<okhareketi>().can += 1;
            effectHealth.SetActive(true);
        }
        if(OkHareketi.GetComponent<okhareketi>().can >= 1000)
        {
            kontrolHealthYavas = false;
            effectHealth.SetActive(false);
        }
        
        if (!kontrolCoolReklam)
        {
            // yetenekAltinCoolText.enabled = true;
            skillerCool.SetActive(true);
            coolReklam.SetActive(false);
           
        }
        if(kontrolCoolReklam)
        {
            // yetenekAltinCoolText.enabled = false;
            skillerCool.SetActive(false);
            coolReklam.SetActive(true);
            
        }
        if (!kontrolFireReklam)
        {
            // yetenekAltinCoolText.enabled = true;
            skillerFire.SetActive(true);
            fireReklam.SetActive(false);

        }
        if (kontrolFireReklam)
        {
            // yetenekAltinCoolText.enabled = false;
            skillerFire.SetActive(false);
            fireReklam.SetActive(true);

        }
        if (!kontrolHealthReklam)
        {
            // yetenekAltinCoolText.enabled = true;
            skillerHealth.SetActive(true);
            healthReklam.SetActive(false);

        }
        if (kontrolHealthReklam)
        {
            // yetenekAltinCoolText.enabled = false;
            skillerHealth.SetActive(false);
            healthReklam.SetActive(true);

        }
        if (!kontrolShieldReklam)
        {
            // yetenekAltinCoolText.enabled = true;
            skillerShield.SetActive(true);
            shieldReklam.SetActive(false);

        }
        if (kontrolShieldReklam)
        {
            // yetenekAltinCoolText.enabled = false;
            skillerShield.SetActive(false);
            shieldReklam.SetActive(true);

        }
        if (!kontrolPoisonReklam)
        {
            // yetenekAltinCoolText.enabled = true;
            skillerPoison.SetActive(true);
            poisonReklam.SetActive(false);

        }
        if (kontrolPoisonReklam)
        {
            // yetenekAltinCoolText.enabled = false;
            skillerPoison.SetActive(false);
            poisonReklam.SetActive(true);

        }
        if (!kontrolElectroReklam)
        {
            // yetenekAltinCoolText.enabled = true;
            skillerElectro.SetActive(true);
            electroReklam.SetActive(false);

        }
        if (kontrolElectroReklam)
        {
            // yetenekAltinCoolText.enabled = false;
            skillerElectro.SetActive(false);
            electroReklam.SetActive(true);

        }
        if (yetenekLevelCool==5)
        {
            coolFull.SetActive(false);
            coolTextFull.gameObject.SetActive(true);
            coolTextFull.text = "FULL";
            
        }
        if (yetenekLevelFire == 5)
        {
            fireFull.SetActive(false);
            fireTextFull.gameObject.SetActive(true);
            fireTextFull.text = "FULL";
            
        }
        if (yetenekLevelHealth == 5)
        {
            helathFull.SetActive(false);
            healthTextFull.gameObject.SetActive(true);
            healthTextFull.text = "FULL";
            
        }
        if (yetenekLevelPoison == 5)
        {
            poisonFull.SetActive(false);
            poisonTextFull.gameObject.SetActive(true);
            poisonTextFull.text = "FULL";
            
        }
        if (yetenekLevelShield == 5)
        {
            shieldFull.SetActive(false);
            shieldTextFull.gameObject.SetActive(true);
            shieldTextFull.text = "FULL";
            
        }
        if (yetenekLevelElectro == 5)
        {
            electroFull.SetActive(false);
            electroTextFull.gameObject.SetActive(true);
            electroTextFull.text = "FULL";
            
        }
    }
   public IEnumerator Dalgalar()
    {
        for (int i = 0; i < olusacakObjeler.Length; i++)
        {
            if (dalgadakiObjeSayisi[i] == spawnlama.dalgaObjeSayisi&&(okhareketi.sonObjeSayac+rota.sonObjeSayac)==dalgadakiObjeSayisi[i]&&kntrldigerLevel)
            {
                kntrl = true;
                yield return new WaitForSeconds(1.1f);
                if (kntrl)
                {
                    altin += 50;
                    kontrolreklam = true;
                    sayacDalga++;
                    dalgalarIsim[dalgalarIsimSayac].SetActive(true);
                    dalgalarIsimSayac++;
                    Invoke("DIK", 1.5f);
                    kntrl = false;
                }
                
                effectHealth.SetActive(false);
                
                
                
                okhareketi.sonObjeSayac = 0;
                rota.sonObjeSayac = 0;
                if (sayacDalga==dalgadakiObjeSayisi.Length&&kontrolGecisReklam)
                {
                    for (int j = 0; j < dalgalarIsim.Length; j++)
                    {
                        dalgalarIsim[j].SetActive(false);
                    }
                    kntrldigerLevel = false;
                    kazanmaPanel.SetActive(true);
                    dalgalarIsimSayac = dalgadakiObjeSayisi.Length;
                    //okhareketi.sonObjeSayac = 0;
                    //rota.sonObjeSayac = 0;
                    kontrolGecisReklam = false;
                    ads.instance.ShowInter();
                    Time.timeScale = 0;
                }
                if (i != dalgaSayisi)
                {

                    olusacakObjeler[i].SetActive(false);
                    olusacakAlanlar[i].SetActive(false);
                    olusacakObjeler[i + 1].SetActive(true);
                    olusacakAlanlar[i + 1].SetActive(true);
                    //dalgalarIsimSayac++;
                    //sayacDalga++;

                }
                else
                {

                    olusacakObjeler[i].SetActive(true);
                    olusacakAlanlar[i].SetActive(true);
                    kazanmaPanel.SetActive(true);
                    kntrldigerLevel = false;
                }
            }
        }
        
    }
    public IEnumerator SkillsTimer()
    {
        while (zaman>=0)
        {
            transparantImage.GetComponent<Image>().fillAmount = Mathf.InverseLerp(1, sure, zaman);
            //kontrolCoolDown = false;
            effect.SetActive(false);
            yield return new WaitForSeconds(1f);
            zaman--;
            if (zaman == 0)
            {
                OkHareketi.GetComponent<okhareketi>().can = 1000;
                Effect();
                //kontrolCoolDown = true;
                zaman = sure;
            }
        }
    }
    public void OyunaBasla()
    {
        Time.timeScale = 1;
        kartPanel.SetActive(false);
        oyunaBaslaButton.SetActive(false);
        Invoke("m", 0.1f);

    }
    public void ElUzama()
    {
        //OkHareketi.GetComponent<okhareketi>().kontrolMouse = true;
        OkHareketi.GetComponent<okhareketi>().okunGidecegiMesafe = okunUzamaMiktari;
        kontrolElUzama = false;
        kartPanel.SetActive(false);
        oyunaBaslaButton.SetActive(false);
        Time.timeScale = 1;
        Invoke("m", 1);
    }
    public void ElGuc()
    {
        OkHareketi.GetComponent<okhareketi>().hiz=100;
        Time.timeScale = 1;
    }
    public void IkinciEl()
    {
        ikinciEl.SetActive(true);
        kartPanel.SetActive(false);
        oyunaBaslaButton.SetActive(false);
        Time.timeScale = 1;
        Invoke("m", 0.1f);

    }
    public void YetenekBarDolumu()
    {
        yetenekBarSayac += 5;
        yetenekBar.transform.localScale = new Vector3(yetenekBarSayac / 100, 1, 1);
        if (yetenekBarSayac==50)
        {
            OkHareketi.GetComponent<okhareketi>().kontrolMouse = false;

            //ilkAcilisSkillBar.SetActive(true);
            //ilkAcilisSkillBar2.SetActive(true);
            if (dalgalarIsimSayac >= 0 && dalgalarIsimSayac < 4)
            {
                ilkAcilisSkillBar.SetActive(true);
                ilkAcilisSkillBar2.SetActive(false);
            }
            if (dalgalarIsimSayac >= 4 && dalgalarIsimSayac < 6)
            {
                ilkAcilisSkillBar.SetActive(false);
                ilkAcilisSkillBar2.SetActive(true);
            }
            //yetenekLevelCoolText.text = yetenekLevelCool.ToString();
            //yetenekAltinCoolText.text = altinCool.ToString();
            Time.timeScale = 0;

            
            
            
            //Invoke("ilk", 1f);
            
        }
        if (yetenekBarSayac>=100)
        {
            OkHareketi.GetComponent<okhareketi>().kontrolMouse = false;

            //ilkAcilisSkillBar.SetActive(true);
            //ilkAcilisSkillBar2.SetActive(true);
            if (dalgalarIsimSayac >= 0 && dalgalarIsimSayac < 4)
            {
                ilkAcilisSkillBar.SetActive(true);
                ilkAcilisSkillBar2.SetActive(false);
            }
            if (dalgalarIsimSayac >= 4 && dalgalarIsimSayac < 5)
            {
                ilkAcilisSkillBar.SetActive(false);
                ilkAcilisSkillBar2.SetActive(true);
            }
            //yetenekLevelCoolText.text = yetenekLevelCool.ToString();
            //yetenekAltinCoolText.text = altinCool.ToString();

            Time.timeScale = 0;
            
            //Invoke("ilk", 1f);
            yetenekBarSayac = 0;
            
        }
    }
    public void CoolDown()
    {
        if (!kontrolCoolReklam&&dolarKayit>=altinCool&&yetenekLevelCool!=5)
        {
            
            yetenekLevelCool += 1;
            dolarKayit -= altinCool;
            altinCool += 200;
            yetenekLevelCoolText.text = yetenekLevelCool.ToString();
            yetenekAltinCoolText.text = altinCool.ToString();
            if (skillerKlonCool.gameObject.activeSelf==false)
            {
                skillerKlonCool.transform.position = yetenekBarArti[yetenekBarArtiSayac].transform.position;
                
                yetenekBarArtiSayac++;
            }
            
            zamanlayiciCool.GetComponent<zamanlayici>().sure--;
            kontrolCoolDown = true;
            //skillerCool.SetActive(true);
            skillerKlonCool.SetActive(true);
            ilkAcilisSkillBar.SetActive(false);
            zamanlayiciCool.SetActive(true);
            Time.timeScale = 1;
            Invoke("m", 0.3f);

            kontrolCoolReklam = true;

        }
        

    }
    public void CoolDownReklam()
    {
        if (kontrolCoolReklam&& yetenekLevelCool != 5)
        {
            

            yetenekLevelCool += 1;
            //altinCool += 200;
            yetenekLevelCoolText.text = yetenekLevelCool.ToString();
            //yetenekAltinCoolText.text = altinCool.ToString();
            //altin -= altinCool;
            
            zamanlayiciCool.GetComponent<zamanlayici>().sure--;
            kontrolCoolDown = true;
        //skillerCool.SetActive(true);
            //coolReklam.SetActive(false);
            skillerKlonCool.SetActive(true);
            ilkAcilisSkillBar.SetActive(false);
            zamanlayiciCool.SetActive(true);
            Time.timeScale = 1;
            Invoke("m", 0.3f);
            kontrolCoolReklam = false;
            ads.instance.ShowRewardedCool();
            
        }
        
    }
    public void Shield()
    {
        if (!kontrolShieldReklam&&dolarKayit>=altinShield&& yetenekLevelShield != 5)
        {
            yetenekLevelShield += 1;
            dolarKayit -= altinShield;
            altinShield += 200;
            yetenekLevelShieldText.text = yetenekLevelShield.ToString();
            yetenekAltinShieldText.text = altinShield.ToString();
            if (skillerKlonShield.activeSelf==false)
            {
                skillerKlonShield.transform.position = yetenekBarArti[yetenekBarArtiSayac].transform.position;
                
                yetenekBarArtiSayac++;
            }

            zamanlayiciShield.GetComponent<zamanlayici>().sure--;

            kontrolShild = true;
            //skillerShield.SetActive(false);
            skillerKlonShield.SetActive(true);
            ilkAcilisSkillBar2.SetActive(false);
            zamanlayiciShield.SetActive(true);
            Time.timeScale = 1;
            Invoke("m", 0.3f);
            kontrolShieldReklam = true;
        }
        
    }
    public void ShieldReklam()
    {
        if (kontrolShieldReklam&& yetenekLevelShield != 5)
        {
            yetenekLevelShield += 1;
            
            yetenekLevelShieldText.text = yetenekLevelShield.ToString();
            


            zamanlayiciShield.GetComponent<zamanlayici>().sure--;

            kontrolShild = true;
            //skillerShield.SetActive(false);
            skillerKlonShield.SetActive(true);
            ilkAcilisSkillBar2.SetActive(false);
            zamanlayiciShield.SetActive(true);
            Time.timeScale = 1;
            Invoke("m", 0.3f);
            kontrolShieldReklam = false;
            ads.instance.ShowRewardedShield();
        }

    }
    public void Health()
    {
        if (dolarKayit>=altinHealth&&!kontrolHealthReklam&& yetenekLevelHealth != 5)
        {
            yetenekLevelHealth += 1;
            dolarKayit -= altinHealth;
            altinHealth += 200;
            yetenekLevelHealthText.text = yetenekLevelHealth.ToString();
            yetenekAltinHealthText.text = altinHealth.ToString();
            if (skillerKlonHealth.activeSelf==false)
            {
                skillerKlonHealth.transform.position = yetenekBarArti[yetenekBarArtiSayac].transform.position;
                
                yetenekBarArtiSayac++;
            }

            zamanlayiciHealth.GetComponent<zamanlayici>().sure--;
            //OkHareketi.GetComponent<okhareketi>().can = 1000;
            
            effectHealth.SetActive(true);
            //skillerHealth.SetActive(false);
            skillerKlonHealth.SetActive(true);
            ilkAcilisSkillBar.SetActive(false);
            zamanlayiciHealth.SetActive(true);
            Time.timeScale = 1;
            kontrolHealthReklam = true;
            kontrolHealthYavas = true;
        }
       
        
    }
    public void HealthReklam()
    {
        if (kontrolHealthReklam&& yetenekLevelHealth != 5)
        {
            yetenekLevelHealth += 1;
            
            yetenekLevelHealthText.text = yetenekLevelHealth.ToString();
            zamanlayiciHealth.GetComponent<zamanlayici>().sure--;
            //OkHareketi.GetComponent<okhareketi>().can = 1000;
            
            effectHealth.SetActive(true);
            //skillerHealth.SetActive(false);
            skillerKlonHealth.SetActive(true);
            ilkAcilisSkillBar.SetActive(false);
            zamanlayiciHealth.SetActive(true);
            Time.timeScale = 1;
            kontrolHealthReklam = false;
            kontrolHealthYavas = true;
            ads.instance.ShowRewardedHealth();
        }


    }
    public void Fire()
    {
        if (dolarKayit>=altinFire&&!kontrolFireReklam&& yetenekLevelFire != 5)
        {
            yetenekLevelFire++;
            dolarKayit -= altinFire;
            altinFire += 200;
            yetenekLevelFireText.text = yetenekLevelFire.ToString();
            yetenekAltinFireText.text = altinFire.ToString();
            if (skillerKlonFire.activeSelf==false)
            {
                skillerKlonFire.transform.position = yetenekBarArti[yetenekBarArtiSayac].transform.position;
                
                yetenekBarArtiSayac++;
            }

            zamanlayiciFire.GetComponent<zamanlayici>().sure--;
            kontrolFire = true;
            skillerKlonFire.SetActive(true);
            ilkAcilisSkillBar.SetActive(false);
            zamanlayiciFire.SetActive(true);
            Time.timeScale = 1;
            Invoke("m", 0.3f);
            kontrolFireReklam = true;
        }
        
        //skillerFire.SetActive(false);
        
    }
    public void FireReklam()
    {
        if (kontrolFireReklam&& yetenekLevelFire != 5)
        {
            yetenekLevelFire++;
            
            yetenekLevelFireText.text = yetenekLevelFire.ToString();
            zamanlayiciFire.GetComponent<zamanlayici>().sure--;
            kontrolFire = true;
            skillerKlonFire.SetActive(true);
            ilkAcilisSkillBar.SetActive(false);
            zamanlayiciFire.SetActive(true);
            Time.timeScale = 1;
            Invoke("m", 0.3f);
            kontrolFireReklam = false;
            ads.instance.ShowRewardedFire();
        }

        //skillerFire.SetActive(false);

    }
    public void Electro()
    {
        if (dolarKayit>=altinElectro&&!kontrolElectroReklam&& yetenekLevelElectro != 5)
        {
            yetenekLevelElectro++;
            dolarKayit -= altinElectro;
            altinElectro += 200;
            yetenekLevelElectroText.text = yetenekLevelElectro.ToString();
            yetenekAltinElectroText.text = altinElectro.ToString();
            zamanlayiciElectro.GetComponent<zamanlayici>().sure--;
            if (skillerKlonElectro.activeSelf==false)
            {
                skillerKlonElectro.transform.position = yetenekBarArti[yetenekBarArtiSayac].transform.position;
                
                yetenekBarArtiSayac++;
            }

            kontrolElectro = true;
            //skillerElectro.SetActive(false);
            skillerKlonElectro.SetActive(true);
            ilkAcilisSkillBar2.SetActive(false);
            zamanlayiciElectro.SetActive(true);
            Time.timeScale = 1;
            Invoke("m", 0.3f);
            kontrolElectroReklam = true;

        }
        
    }
    public void ElectroReklam()
    {
        if (kontrolElectroReklam&& yetenekLevelElectro != 5)
        {
            yetenekLevelElectro++;
            
            yetenekLevelElectroText.text = yetenekLevelElectro.ToString();
            
            zamanlayiciElectro.GetComponent<zamanlayici>().sure--;


            kontrolElectro = true;
            //skillerElectro.SetActive(false);
            skillerKlonElectro.SetActive(true);
            ilkAcilisSkillBar2.SetActive(false);
            zamanlayiciElectro.SetActive(true);
            Time.timeScale = 1;
            Invoke("m", 0.3f);
            kontrolElectroReklam = false;
            ads.instance.ShowRewardedElectro();
        }

    }
    public void Poison()
    {
        if (dolarKayit>=altinPoison&&!kontrolPoisonReklam&& yetenekLevelPoison != 5)
        {
            yetenekLevelPoison++;
            dolarKayit -= altinPoison;
            altinPoison += 200;
            yetenekLevelPoisonText.text = yetenekLevelPoison.ToString();
            yetenekAltinPoisonText.text = altinPoison.ToString();
            if (skillerKlonPoison.activeSelf==false)
            {
                skillerKlonPoison.transform.position = yetenekBarArti[yetenekBarArtiSayac].transform.position;
                
                yetenekBarArtiSayac++;
            }
            zamanlayiciPoison.GetComponent<zamanlayici>().sure--;
            kontrolPoison = true;
            //skillerPoison.SetActive(false);
            skillerKlonPoison.SetActive(true);
            ilkAcilisSkillBar2.SetActive(false);
            zamanlayiciPoison.SetActive(true);
            Time.timeScale = 1;
            Invoke("m", 0.3f);
            kontrolPoisonReklam = true;
        }
        
    }
    public void PoisonReklam()
    {
        if (kontrolPoisonReklam&& yetenekLevelPoison != 5)
        {
            yetenekLevelPoison++;
            
            yetenekLevelPoisonText.text = yetenekLevelPoison.ToString();
            
            zamanlayiciPoison.GetComponent<zamanlayici>().sure--;
            kontrolPoison = true;
            //skillerPoison.SetActive(false);
            skillerKlonPoison.SetActive(true);
            ilkAcilisSkillBar2.SetActive(false);
            zamanlayiciPoison.SetActive(true);
            Time.timeScale = 1;
            Invoke("m", 0.3f);
            kontrolPoisonReklam = false;
            ads.instance.ShowRewardedPoison();
        }

    }
    public void YenidenOyna()
    {
        kaybetmePanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SonrakiLevel()
    {
        kazanmaPanel.SetActive(false);
        SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name + 1));
    }
    void h()
    {
        kontrolShild = false;
    }
    void c()
    {
        kontrolCoolDown = false;
    }
    void f()
    {
        kontrolFire = false;
    }
    void e()
    {
        OkHareketi.GetComponent<okhareketi>().okunGidecegiMesafe = new Vector3(0, 0, -20);
    }
    void m()
    {
        OkHareketi.GetComponent<okhareketi>().kontrolMouse = true;
    }

    void i()
    {
        ikinciEl.SetActive(false);
    }
    public void Effect()
    {
        //Instantiate(effect, transform.position, transform.rotation);
        effect.SetActive(true);
    }
    void ilk()
    {
        ilkAcilisSkillBar.SetActive(true);
        OkHareketi.GetComponent<okhareketi>().kontrolMouse = false;
        Time.timeScale = 0;
    }
    public void DIK()
    {
        for (int i = 0; i < dalgalarIsim.Length; i++)
        {
            dalgalarIsim[i].SetActive(false);
        }
    }
    public void d()
    {
        dalgalarIsim[dalgalarIsimSayac].SetActive(true);
        dalgalarIsimSayac++;
    }
}
