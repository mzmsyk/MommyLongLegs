using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour
{
    VideoPlayer player;
    bool introStarted = false;
    public GameObject yuklemeEkrani;
    [Header("Referances")]
    [SerializeField] private List<GameObject> toSetActive = new List<GameObject>();
    [SerializeField] private GameObject camIntro, blackCanvas;

    void Awake()
    {
        player = GetComponent<VideoPlayer>();
    }

    void Start()
    {
        if (singleton.instance.isFirstTime)
            StartCoroutine(introo());

        else
        {
            foreach (GameObject obje in toSetActive)
            {
                obje.SetActive(true);
            }

            blackCanvas.SetActive(false);
            Destroy(camIntro);
            Destroy(gameObject);
        }
    }

    IEnumerator introo()
    {
        while (true)
        {
            // Intro videosu g�sterilmeye haz�r ama hen�z g�sterilmeye ba�lanmad��� an
            if (player.isPrepared && !introStarted)
            {

                introStarted = true;
                StartCoroutine(blackscreen());
            }
            // Intronun durdu�u an
            if (player.isPaused && introStarted)
            {
                singleton.instance.isFirstTime = false;
                foreach (GameObject obje in toSetActive)
                {
                    obje.SetActive(true);
                    //int kayitliLevel= PlayerPrefs.GetInt("kayit");
                    //if (kayitliLevel == 0)
                    //{
                    //    SceneManager.LoadScene(kayitliLevel + 1);
                    //}
                    //else
                    //{
                    //    SceneManager.LoadScene(kayitliLevel);
                    //}

                }

                Destroy(camIntro);
                Destroy(gameObject);

                break;

            }

            yield return null;
        }
    }
    // Intro g�sterimi ba�lad�ktan sonra siyah ekran�n silinmesi
    IEnumerator blackscreen()
    {
        yield return new WaitForSeconds(.1f);

        blackCanvas.SetActive(false);
        yield return new WaitForSeconds(2.2f);
        yuklemeEkrani.SetActive(true);
        //int kayitliLevel = PlayerPrefs.GetInt("kayit");
        //if (kayitliLevel == 0)
        //{
        //    SceneManager.LoadScene(kayitliLevel + 1);
        //}
        //else
        //{
        //    SceneManager.LoadScene(kayitliLevel);
        //}
    }
}
