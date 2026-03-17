using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSrc;
    public float musicVolume = 0.5f;
    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
