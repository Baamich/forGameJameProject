using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayStory : MonoBehaviour
{
    [SerializeField] private GameObject videoObj;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private VideoClip[] videoClip;
    [SerializeField] private storyEnd story;
    [SerializeField] private AudioSource offBackMusic;
    [SerializeField] private PlayerCharacteristics playerCharacteristics;

    private bool isPlaying = false;

    void Start()
    {     
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        offBackMusic.Stop();
        if (!collision.CompareTag("Player") || isPlaying) return;
        playerCharacteristics.stop = true;
        playerCharacteristics.StartCoroutine(playerCharacteristics.timerBelching());
        playerCharacteristics.audioSourceBelching.enabled = false;
        isPlaying = true;

        if (story.a >= 3)
        {
            videoPlayer.clip = videoClip[0];
        }
        else if (story.b >= 3)
        {
            videoPlayer.clip = videoClip[1];
        }
        else if (story.c >= 3)
        {
            videoPlayer.clip = videoClip[2];
        }

        videoObj.SetActive(true);
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene("StartScene");
    }
}