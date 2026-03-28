using UnityEngine;

public class soundButton : MonoBehaviour
{
   [SerializeField] private AudioSource audioSource;
   [SerializeField] private AudioClip audioClip;
   public void clickSound()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
