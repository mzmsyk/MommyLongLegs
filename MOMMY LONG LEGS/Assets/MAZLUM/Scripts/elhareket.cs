using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elhareket : MonoBehaviour
{
    public bool sag, sol, orta;
    public bool sag2, sol2, orta2;
    public float yanhiz;
    Vector3 touchPos;
    Rigidbody fizik;
    Vector3 direction;
    public float sensetive;
    public float hiz=10;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);
            //touchPos = Camera.main.ScreenToWorldPoint(parmak.position);

            //direction = (touchPos - transform.position);
            //fizik.velocity = new Vector3(direction.x, transform.position.y, transform.position.z) * hiz;
            //if (parmak.phase==TouchPhase.Ended)
            //{
            //    fizik.velocity = Vector3.zero;
            //}






            if (parmak.deltaPosition.x*sensetive < -10)
            {
                sol = true;
                sag = false;
                orta = false;
            }
            if (parmak.deltaPosition.x*sensetive > 10)
            {
                sol = false;
                sag = true;
                orta = false;
            }
            if (parmak.deltaPosition.x == 0)
            {
                sol = false;
                sag = false;
                orta = true;
            }
            if (sol && sol2)
            {
                Vector3 solHareket = new Vector3(-15, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, solHareket, yanhiz * Time.deltaTime);
            }
            if (sag && sag2)
            {
                Vector3 sagHareket = new Vector3(13, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, sagHareket, yanhiz * Time.deltaTime);
            }
            if (orta && orta2)
            {
                Vector3 ortaHareket = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                transform.position = ortaHareket;
            }
        }
    }
    
}
