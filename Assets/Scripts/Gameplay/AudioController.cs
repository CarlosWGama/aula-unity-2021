using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    
    private AudioSource BGM;
    private AudioSource BGS;
    private AudioSource SE;

    //Padrão Singleton
    public static AudioController Instance;

    void Awake() {
        BGM = transform.GetChild(0).GetComponent<AudioSource>();
        BGS = transform.GetChild(1).GetComponent<AudioSource>();
        SE = transform.GetChild(2).GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        if (Instance == null) Instance = this;
        else Destroy(gameObject); //Já existe um objeto criado
    }

    public void PlayBGM(AudioClip audio) {
        BGM.clip = audio;
        BGM.Play();
    }

    public void PlayBGS(AudioClip audio) {
        BGS.clip = audio;
        BGS.Play();
    }

    public void PlaySE(AudioClip audio) {
        SE.clip = audio;
        SE.Play();
    }
}
