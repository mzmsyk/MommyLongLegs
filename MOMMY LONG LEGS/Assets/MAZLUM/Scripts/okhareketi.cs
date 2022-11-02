using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class okhareketi : MonoBehaviour
{
    Rigidbody fizik;
    public Vector3 okunGidecegiMesafe;
    bool kontrolIleriGitme = false;
    bool kontrolGeriGelme = false;
    public bool kontrolMouse = true;
    bool kontrolDusmanYakalama = false;
    public Transform cikisYeri;
    public Transform cikisYeri2;
    public Transform girisYeri;
    public float hiz;
    public Vector3 ilkPos;
    Vector3 sonPos;
    Animator anim;
    public GameObject canBar;
    public float can;
    public float hasar;
    public static int sonObjeSayac;
    public static okhareketi instante;
    public GameObject[] noktalar;
    public GameObject atesElEffect;
    public GameObject electroElEffect;
    public GameObject effectCool;
    public GameObject poisonElEffect;
    public ParticleSystem efect;
    GameObject OyunYoneticisi;
    GameObject Dusman;
    public int levelSayac;
    public static int altin;
    //float hasar;
    public static bool kontrolHlt=false;
    [Header("SES")]
    public AudioSource sesDogru;
    public AudioSource sesYanlis;
    public AudioSource sesKazanma;
    [Header("TÝTREÞÝM")]
    public static bool kontrolTitresim=true;
    //public HapticTypes hapticTypes3 = HapticTypes.LightImpact;
    //public HapticTypes hapticTypes2 = HapticTypes.SoftImpact;
    public HapticTypes hapticTypes1 = HapticTypes.RigidImpact;
    public static int canavarOldurme;
    void Start()
    {
        canavarOldurme = 0;
        altin = 0;
        OyunYoneticisi = GameObject.FindGameObjectWithTag("oyunyoneticisi");
        Dusman = GameObject.FindGameObjectWithTag("dusman");
        fizik = GetComponent<Rigidbody>();
        ilkPos = transform.position;
        anim = GetComponent<Animator>();
        can = 1000;
        //hasar = Dusman.GetComponent<rota>().hasar;
        sonObjeSayac = 0;
        kontrolMouse = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("sesDurum") == 1)
        {
            sesDogru.mute = true;
            sesKazanma.mute = true;
            sesYanlis.mute = true;
        }
        if (PlayerPrefs.GetInt("sesDurum") == 0)
        {
            sesDogru.mute = false;
            sesKazanma.mute = false;
            sesYanlis.mute = false;
        }
        if (PlayerPrefs.GetInt("titresimDurum") == 1)
        {
            kontrolTitresim = false;
        }
        if (PlayerPrefs.GetInt("titresimDurum") == 0)
        {
            kontrolTitresim = true;
        }








        canBar.transform.localScale = new Vector3(can/1000, 1, 1);

        if (can>=1000)
        {
            can = 1000;
        }
        if (can<=0)
        {
            can = 0;
        }

       
        if (Input.GetMouseButtonUp(0)&&kontrolMouse)
        {
            kontrolIleriGitme = true;
            kontrolMouse = false;
            oyunyoneticisi.kontrolElUzama = true;
            kontrolHlt = false;
            ilkPos = transform.position;
            //kontrolHlt = true;
           
        }
        if (kontrolIleriGitme)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
            ElHareketIptal();
            fizik.velocity = transform.forward * -hiz;
            kontrolMouse = false;
            if (transform.position.z>okunGidecegiMesafe.z)
            {
                sonPos = transform.position;
                
                fizik.velocity = Vector3.zero;
                kontrolIleriGitme = false;
                kontrolGeriGelme = true;
                anim.SetBool("tutma", true);
                if (oyunyoneticisi.kontrolFire)
                {
                    atesElEffect.SetActive(true);
                    
                    //efect.Play();
                }
                else
                {
                    atesElEffect.SetActive(false);
                   // efect.Stop();
                }
                if (oyunyoneticisi.kontrolElectro)
                {
                    electroElEffect.SetActive(true);
                    //efect.Play();
                }
                else
                {
                    electroElEffect.SetActive(false);
                    // efect.Stop();
                }
                if (oyunyoneticisi.kontrolCoolDown)
                {
                    effectCool.SetActive(true);
                    //efect.Play();
                }
                else
                {
                    effectCool.SetActive(false);
                    // efect.Stop();
                }
                if (oyunyoneticisi.kontrolPoison)
                {
                    poisonElEffect.SetActive(true);
                    //efect.Play();
                }
                else
                {
                    poisonElEffect.SetActive(false);
                    // efect.Stop();
                }

            }
            for (int i = 0; i < noktalar.Length; i++)
            {
                noktalar[i].SetActive(false);
            }
            
        }
        //atesElEffect.transform.position = sonPos;
        //electroElEffect.transform.position = sonPos;
        //effectCool.transform.position = sonPos;
        if (kontrolGeriGelme)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            fizik.velocity = transform.forward * hiz;
            if (ilkPos.z>=transform.position.z)
            {
                oyunyoneticisi.kontrolFire = false;
                oyunyoneticisi.kontrolElectro = false;
                oyunyoneticisi.kontrolPoison = false;
                kontrolHlt = true;
                transform.position = ilkPos;
                fizik.velocity = Vector3.zero;
                kontrolGeriGelme = false;
                ElHareket();
                
                anim.SetBool("tutma", false);
                kontrolDusmanYakalama = true;
                OyunYoneticisi.GetComponent<oyunyoneticisi>().ikinciEl.SetActive(false);
                for (int i = 0; i < noktalar.Length; i++)
                {
                    noktalar[i].SetActive(true);
                }

                //atesElEffect.SetActive(false);
                //electroElEffect.SetActive(false);
                //effectCool.SetActive(false);
                //poisonElEffect.SetActive(false);

                //atesElEffect.transform.parent = null;
                //electroElEffect.transform.parent = null;
                //effectCool.transform.parent = null;

                kontrolMouse = true;
                //efect.Stop();
                
            }
            

        }
        
        if (kontrolDusmanYakalama)
        {
            for (int i = 0; i < 100; i++)
            {
                this.gameObject.transform.GetChild(3).transform.GetChild(i).gameObject.SetActive(false);
                anim.SetBool("tutma", false);
                kontrolDusmanYakalama = false;
                this.gameObject.transform.GetChild(3).transform.GetChild(i).gameObject.transform.position= new Vector3(transform.position.x * Mathf.Cos(0), transform.position.y * Mathf.Sin(0), transform.position.z );
            }
            
        }
    }
    public void ElHareketIptal()
    {
        elhareket elHareket = FindObjectOfType<elhareket>();
        elHareket.GetComponent<elhareket>().sag2 = false;
        elHareket.GetComponent<elhareket>().sol2 = false;
        elHareket.GetComponent<elhareket>().orta2 = false;
    }
    public void ElHareket()
    {
        elhareket elHareket = FindObjectOfType<elhareket>();
        elHareket.GetComponent<elhareket>().sag2 = true;
        elHareket.GetComponent<elhareket>().sol2 = true;
        elHareket.GetComponent<elhareket>().orta2 = true;
    }
    IEnumerator OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="dusman")
        {
            //hasar += 5;
            //can -= hasar;
            canavarOldurme++;
            col.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            anim.SetBool("tutma", true);
            col.gameObject.transform.parent = this.gameObject.transform.GetChild(3).transform;
            col.gameObject.transform.position = this.gameObject.transform.GetChild(3).transform.position;
            sonObjeSayac++;
            Debug.Log("sonobjesayacOk: " + sonObjeSayac);
            //Dusman.GetComponent<rota>().kontrolFire = false;
            OyunYoneticisi.GetComponent<oyunyoneticisi>().YetenekBarDolumu();
            if (kontrolTitresim == true)
            {
                MMVibrationManager.Haptic(hapticTypes1, false, true, this);
            }
            if (levelSayac==1)
            {
                oyunyoneticisi.altin += 30;
                altin += 30;
                oyunyoneticisi.kontrolreklam = true;
            }
            else if (levelSayac==2)
            {
                oyunyoneticisi.altin += 50;
                oyunyoneticisi.kontrolreklam = true;
                altin += 50;
            }
            
            for (int i = 0; i < 3; i++)
            {
                //this.gameObject.transform.GetChild(3).transform.GetChild(i).transform.position = new Vector3(transform.position.x*Mathf.Cos(i), transform.position.y*Mathf.Sin(i), transform.position.z +i+1);
                col.gameObject.transform.GetComponent<Animator>().speed = 0;
                yield return new WaitForSeconds(3f);
                
                Destroy(col.gameObject);
            }
        }
    }
}
