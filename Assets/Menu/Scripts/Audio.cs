using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSrc;
    public float musicVolume = 0.1f;

    void Start()
    {
        audioSrc.Play();
    }

    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
