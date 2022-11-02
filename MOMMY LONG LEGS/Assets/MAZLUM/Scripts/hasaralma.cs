using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hasaralma : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject karakter;
    public GameObject canBar;
    public float can;
    void Start()
    {
        karakter = GameObject.FindGameObjectWithTag("Player");
        can = 100;
    }

    // Update is called once per frame
    void Update()
    {
        canBar.transform.localScale = new Vector3(can / 100, 1, 1);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag=="dusman2")
        {
            //can -= 5;
            //Debug.Log("duvaragirildi");
        }
    }
}
