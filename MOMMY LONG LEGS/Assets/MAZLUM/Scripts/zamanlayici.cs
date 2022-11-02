using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zamanlayici : MonoBehaviour
{
    public GameObject transparantImage;
    //public GameObject image;
    public float sure;
    public float zaman;
    GameObject OyunYoneticisi;
    GameObject OkHareketi;
    void Start()
    {
        zaman = sure;
        OyunYoneticisi = GameObject.FindGameObjectWithTag("oyunyoneticisi");
        OkHareketi = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SkillsTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator SkillsTimer()
    {
        while (zaman >= 0)
        {
            transparantImage.GetComponent<Image>().fillAmount = Mathf.InverseLerp(1, sure, zaman);
            //oyunyoneticisi.kontrolCoolDown = false;
            //effect.SetActive(false);
            yield return new WaitForSeconds(1f);
            zaman--;
            if (zaman == 0)
            {
                //OkHareketi.GetComponent<okhareketi>().can = 1000;
                //Effect();
                if (OyunYoneticisi.GetComponent<oyunyoneticisi>().zamanlayiciCool.activeSelf==true&& !oyunyoneticisi.kontrolCoolDown)
                {
                    oyunyoneticisi.kontrolCoolDown = true;
                    zaman = sure;
                }
                if (OyunYoneticisi.GetComponent<oyunyoneticisi>().zamanlayiciHealth.activeSelf == true)
                {
                   // oyunyoneticisi.kontrolHelath = true;
                }
                if (OyunYoneticisi.GetComponent<oyunyoneticisi>().zamanlayiciFire.activeSelf == true&&!oyunyoneticisi.kontrolFire)
                {
                    oyunyoneticisi.kontrolFire = true;
                    zaman = sure;
                }
                if (OyunYoneticisi.GetComponent<oyunyoneticisi>().zamanlayiciElectro.activeSelf == true&&!oyunyoneticisi.kontrolElectro)
                {
                    oyunyoneticisi.kontrolElectro = true;
                    zaman = sure;
                }
                if (OyunYoneticisi.GetComponent<oyunyoneticisi>().zamanlayiciPoison.activeSelf == true&&!oyunyoneticisi.kontrolPoison)
                {
                    oyunyoneticisi.kontrolPoison = true;
                    zaman = sure;
                }
                if (OyunYoneticisi.GetComponent<oyunyoneticisi>().zamanlayiciShield.activeSelf == true && !oyunyoneticisi.kontrolShild)
                {
                    oyunyoneticisi.kontrolShild = true;
                    zaman = sure;
                }
                //oyunyoneticisi.kontrolShild = true;

                //zaman = sure;
            }
        }
    }
}
