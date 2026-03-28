using UnityEngine;

public class TravelMusicChange : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;

    void Start()
    {
         foreach(var clip in audioClips)
        {
            // это гарантирует, что Unity заранее подготовила данные
            clip.LoadAudioData();
        }
    }
    public void changeAudioClip(int index)
    {
        if(index == 0)
        {
            audioSource.Stop();
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }else if( index == 1)
        {
            audioSource.Stop();
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }else if( index == 2)
        {
            audioSource.Stop();
            audioSource.clip = audioClips[2];
            audioSource.Play();
        }
    }
}
