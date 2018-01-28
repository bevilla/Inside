using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioManager : MonoBehaviour {

    [SerializeField]
    AudioClip spawn;
    [SerializeField]
    AudioClip fire;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySpawn()
    {
        audioSource.spatialBlend = 0f;
        Play(spawn);
    }

    public void PlayFire()
    {
        audioSource.spatialBlend = 1f;
        Play(fire);
    }

    void Play(AudioClip audioClip)
    {
        audioSource.Stop();
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
