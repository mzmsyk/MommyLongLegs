using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class rota : MonoBehaviour
{
    public Transform[] yol;
    int sayac=0;
    bool kontrol = true;
    bool kontrol2 = false;
    Animator anim;
    public float dusmanHiz;
    GameObject duvar;
    GameObject Player;
    GameObject OyunYoneticisi;
    public static float hasar;
    public float hasarGercek;
    public static int sonObjeSayac;
    public static rota instance;
    public float dusmanCan;
    public GameObject effectAtes;
    public GameObject effectElectro;
    public GameObject effectPoison;

    public bool kontrolFire = false;
    public bool kontrolElectro = false;
    public bool kontrolPoison = false;
    public GameObject girisYeri;
    public HapticTypes hapticTypes2 = HapticTypes.SoftImpact;
    void Start()
    {
        anim = GetComponent<Animator>();
        duvar = GameObject.FindGameObjectWithTag("duvar");
        Player = GameObject.FindGameObjectWithTag("Player");
        OyunYoneticisi = GameObject.FindGameObjectWithTag("oyunyoneticisi");
        //hasar=Player.GetComponent<okhareketi>().hasar;
        hasar = hasarGercek;
        dusmanCan = 100;
        //sonObjeSayac = 0;
    }

    
    void Update()
    {
        if (PlayerPrefs.GetInt("titresimDurum") == 1)
        {
            okhareketi.kontrolTitresim = false;
        }
        if (PlayerPrefs.GetInt("titresimDurum") == 0)
        {
            okhareketi.kontrolTitresim = true;
        }

        if (Vector3.Distance(transform.position,girisYeri.transform.position)<=10&&oyunyoneticisi.kontrolFire)
        {
            DusmanCan();
            //oyunyoneticisi.kontrolFire = false;
            Debug.Log("fonksiyon");
            kontrolFire = true;
        }
        if (Vector3.Distance(transform.position, girisYeri.transform.position) <= 10 && oyunyoneticisi.kontrolElectro)
        {
            DusmanCanElectro();
            //oyunyoneticisi.kontrolFire = false;
            Debug.Log("fonksiyon");
            kontrolElectro = true;
        }
        if (Vector3.Distance(transform.position, girisYeri.transform.position) <= 10 && oyunyoneticisi.kontrolPoison)
        {
            DusmanCanPoison();
            //oyunyoneticisi.kontrolFire = false;
            Debug.Log("fonksiyon");
            kontrolPoison = true;
        }
        if (kontrolFire)
        {
            //Instantiate(effect, transform.position, transform.rotation);
            //kontrolFire = false;
            this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        if (kontrolElectro)
        {
            //Instantiate(effect, transform.position, transform.rotation);
            //kontrolFire = false;
            this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
        }
        if (kontrolPoison)
        {
            //Instantiate(effect, transform.position, transform.rotation);
            //kontrolFire = false;
            this.gameObject.transform.GetChild(4).gameObject.SetActive(true);
        }
        if (!oyunyoneticisi.kontrolFire)
        {
            //dusmanCan *=4;
            Invoke("effectyoketfire", 3);
        }
        if (!oyunyoneticisi.kontrolElectro)
        {
            //dusmanCan *=4;
            Invoke("effectyoketelectro", 3);
        }
        if (!oyunyoneticisi.kontrolPoison)
        {
            //dusmanCan *=4;
            Invoke("effectyoketpoison", 3);
        }
        //effect.transform.position = transform.position;
        //DusmanCan();
        if (dusmanCan<=0)
        {
            kontrol = false;
            anim.SetBool("atack", true);
            anim.SetBool("run", false);
           // Invoke("Olme", 1.2f);
        }
        

        if (kontrol&&oyunyoneticisi.kontrolCoolDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, yol[sayac].position, dusmanHiz*Time.deltaTime/2);
            transform.LookAt(yol[sayac].position);
            anim.speed = 0.5f;
            
            anim.SetBool("run", true);
        }
        if (kontrol && !oyunyoneticisi.kontrolCoolDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, yol[sayac].position, dusmanHiz * Time.deltaTime);
            transform.LookAt(yol[sayac].position);
            anim.speed = 1f;
            
            anim.SetBool("run", true);
        }

        float mesafe = Vector3.Distance(transform.position, yol[sayac].position);
        if (mesafe < 0.2f)
        {

            sayac++;
            if (sayac == yol.Length)
            {
                
                kontrol = false;
                anim.SetBool("run", false);
                kontrol2 = true;
                sayac = 0;
                if (kontrol2)
                {
                    anim.SetBool("atack", true);
                    this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                    if (okhareketi.kontrolTitresim == true)
                    {
                        MMVibrationManager.Haptic(hapticTypes2, false, true, this);
                    }
                    Invoke("Olme", 1.2f);
                }
            }
        }





    }
    public void DusmanCan()
    {
        if (oyunyoneticisi.kontrolFire)
        {
            
            Debug.Log("fonksiyona girildi");
            dusmanCan =dusmanCan-dusmanCan/4;
            Debug.Log("dusman can: " + dusmanCan);
            //Instantiate(effect, transform.position, transform.rotation);
            //oyunyoneticisi.kontrolFire = false;
        }
        //if (!oyunyoneticisi.kontrolFire)
        //{
        //    //dusmanCan *=4;
        //    Invoke("effectyoketfire", 3);
        //}
    }
    public void DusmanCanElectro()
    {
        if (oyunyoneticisi.kontrolElectro)
        {

            Debug.Log("fonksiyona girildi");
            dusmanCan = dusmanCan - dusmanCan / 4;
            Debug.Log("dusman can: " + dusmanCan);
            //Instantiate(effect, transform.position, transform.rotation);
            //oyunyoneticisi.kontrolFire = false;
        }
        //if (!oyunyoneticisi.kontrolElectro)
        //{
        //    //dusmanCan *=4;
        //    Invoke("effectyoketelectro", 3);
        //}
    }
    public void DusmanCanPoison()
    {
        if (oyunyoneticisi.kontrolPoison)
        {

            Debug.Log("fonksiyona girildi");
            dusmanCan = dusmanCan - dusmanCan / 4;
            Debug.Log("dusman can: " + dusmanCan);
            //Instantiate(effect, transform.position, transform.rotation);
            //oyunyoneticisi.kontrolFire = false;
        }
        //if (!oyunyoneticisi.kontrolPoison)
        //{
        //    //dusmanCan *=4;
        //    Invoke("effectyoketpoison", 3);
        //}
    }
    private void OnTriggerEnter(Collider col)
    {
        
    }
    void Olme()
    {
        if (oyunyoneticisi.kontrolShild)
        {
            Player.GetComponent<okhareketi>().can -= hasar/4;
        }
        if(!oyunyoneticisi.kontrolShild)
        {
            Player.GetComponent<okhareketi>().can -= hasar;
        }
        
        //okhareketi.sonObjeSayac++;
        sonObjeSayac++;

        Debug.Log("sonobjesayacRota: " + sonObjeSayac);
        Destroy(this.gameObject);
    }
    void effectyoketfire()
    {
        kontrolFire = false;
        effectAtes.SetActive(false);
        this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
        //Destroy(effect.gameObject);
    }
    void effectyoketelectro()
    {
        kontrolElectro = false;
        effectElectro.SetActive(false);
        this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
        //Destroy(effect.gameObject);
    }
    void effectyoketpoison()
    {
        kontrolPoison = false;
        effectPoison.SetActive(false);
        this.gameObject.transform.GetChild(4).gameObject.SetActive(false);
        //Destroy(effect.gameObject);
    }
}
