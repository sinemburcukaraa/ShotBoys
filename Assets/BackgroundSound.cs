using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSound : MonoBehaviour
{
    private static BackgroundSound instance;

    public static BackgroundSound Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject soundManagerObject = new GameObject("SoundManager");
                instance = soundManagerObject.AddComponent<BackgroundSound>();
                DontDestroyOnLoad(soundManagerObject);
            }
            return instance;
        }
    }

    // ... (di�er de�i�kenler ve fonksiyonlar)

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ... (di�er fonksiyonlar ve kodlar)
}

