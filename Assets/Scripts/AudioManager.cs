using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioClip sonidoBomba;
    public AudioClip sonidoEstrella;

    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        // if la instancia de este script no es igual a nulo, y la instancia no es esta (refiriendose al primer srcipt game manager) me mato
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);
    }

    public void SonidoExplosion()
    {
        _audioSource.PlayOneShot(sonidoBomba);
    }

    public void SonidoRecoger()
    {
        _audioSource.PlayOneShot(sonidoEstrella);
    }
}
