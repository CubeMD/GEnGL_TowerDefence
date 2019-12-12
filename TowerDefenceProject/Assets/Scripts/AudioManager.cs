using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource audiosrc;
    [SerializeField] AudioClip[] effects;
    void Awake()
    {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
    }

    public void PlaySounds (string audioname)
    {
        switch (audioname)
        {
            case "MenuSound":
                audiosrc.PlayOneShot(effects[0]);
                break;
            case "TurretShot":
                audiosrc.PlayOneShot(effects[1]);
                break;

        }
    }

}
