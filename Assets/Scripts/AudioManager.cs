using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    [SerializeField] private AudioClip[] musicList;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (audioSource.isPlaying) return;
        PlayRandomMusic();
    }

    private void PlayRandomMusic()
    {
        audioSource.PlayOneShot(musicList[Random.Range(0, musicList.Length)]);
    }
}
