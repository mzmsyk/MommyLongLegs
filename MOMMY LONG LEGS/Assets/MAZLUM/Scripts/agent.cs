using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agent : MonoBehaviour
{
    NavMeshAgent _agent;
    Transform hedef;
    Animator anim;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        hedef = GameObject.Find("Cube").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float mesafe = Vector3.Distance(transform.position, hedef.position);
        if (mesafe<5)
        {
            anim.SetBool("atack", true);
            anim.SetBool("run", false);
        }
        else
        {
            _agent.destination = hedef.position;
            anim.SetBool("atack", false);
            anim.SetBool("run", true);
        }
        //if ()
        //{

        //}
        
    }
    
}
