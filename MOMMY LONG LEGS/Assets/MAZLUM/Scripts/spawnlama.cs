using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnlama : MonoBehaviour
{
    public Transform baslangic;
    public GameObject objectSpawn;
    //public int[] kacTaneObje;
    public int kacTaneObje;
    int dalgaSayisi;
    public float spZamani, spGeciskmesi;
    int spSayac=0;
    public static int dalgaObjeSayisi;
    public static int dg;
    GameObject OyunYonetiicisi;
    public static bool kontrol=false;
    void Start()
    {
        
        OyunYonetiicisi = GameObject.FindGameObjectWithTag("oyunyoneticisi");
        InvokeRepeating("Spawn", spZamani, spGeciskmesi);
        dalgaObjeSayisi = 0;
    }

    
    void Update()
    {
        
    }
   void Spawn()
    {
        GameObject obje = Instantiate(objectSpawn, baslangic.position, objectSpawn.transform.rotation);
        obje.SetActive(true);
        spSayac++;
        dalgaObjeSayisi++;
        
        if (spSayac == kacTaneObje)
        {
            if (!obje.activeSelf)
            {
                Debug.Log("aktifmi");
            }
            spSayac = 0;
            dalgaSayisi++;
            kontrol = true;
           // Debug.Log("kaçýncý dalga: " + dalgaSayisi);
            CancelInvoke("Spawn");
            if (dalgaSayisi == 5)
            {
                dg++;
               // Debug.Log("dg: " + dg);
               // Debug.Log("dalgalar Bitti: " + dalgaSayisi);
                
            }

        }
       // Debug.Log("sayac: " + spSayac);




















        //if (kacTaneObje[dalgaSayisi] != 0)
        //{
        //    GameObject obje = Instantiate(objectSpawn, baslangic.position, objectSpawn.transform.rotation);
        //    obje.SetActive(true);
        //    spSayac++;
        //    if (spSayac == kacTaneObje[dalgaSayisi])
        //    {
        //        spSayac = 0;
        //        dalgaSayisi++;
        //        kontrol = true;
        //        Debug.Log("kaçýncý dalga: " + dalgaSayisi);
        //        if (dalgaSayisi == kacTaneObje.Length)
        //        {
        //            dg++;
        //            Debug.Log("dg: " + dg);
        //            Debug.Log("dalgalar Bitti: " + dalgaSayisi);
        //            CancelInvoke("Spawn");
        //        }

        //    }
        //    Debug.Log("sayac: " + spSayac);
        //}
        //else
        //{
        //    if (kontrol)
        //    {
        //        dalgaSayisi++;
        //        kontrol = false;
        //    }

        //}


    }
}
