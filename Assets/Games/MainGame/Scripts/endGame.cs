using UnityEngine;

public class endGame : MonoBehaviour
{
    [SerializeField] private PlayerCharacteristics playerCharacteristics;
    [SerializeField] private GameObject endGamObj;
    [SerializeField] private AudioSource endAudio;
    [SerializeField] private AudioSource backAudio;

    private bool started = false;
    void Update()
    {
        if(playerCharacteristics.hp <= 0 && !started)
        {
            started = true;
            endGamObj.SetActive(true);
            backAudio.Stop();
            endAudio.Play();
            Time.timeScale = 0f;
        }
    }
    
}
