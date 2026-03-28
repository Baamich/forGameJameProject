using UnityEngine;
using UnityEngine.Video;

public class PlayVideoOnce : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Video;
    private VideoPlayer videoPlayer;

    // Статическая переменная — хранит состояние на время сессии
    private static bool videoPlayed = false;

    void Start()
    {
        if (videoPlayed)
        {
            // Видео уже проиграно в этой сессии
            Video.SetActive(false);
            Menu.SetActive(true);
            return;
        }

        // Видео ещё не проиграно
        Video.SetActive(true);
        Menu.SetActive(false);

        videoPlayer = Video.GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Video.SetActive(false);
        Menu.SetActive(true);

        // Отмечаем, что видео проигралось в этой сессии
        videoPlayed = true;
    }
}