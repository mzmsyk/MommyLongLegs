using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleton : MonoBehaviour
{
    public static singleton instance;

    public bool isFirstTime = true;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance != null)
            Destroy(gameObject);

        else
            instance = this;
    }
}
