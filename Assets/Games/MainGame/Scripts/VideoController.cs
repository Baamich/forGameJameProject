using UnityEngine;
using UnityEngine.Video;
using System.IO;

public class VideoController : MonoBehaviour
{
    private const string PREF_KEY = "HasLaunchedGame";

    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject videoObject;

    [Header("Player Control")]
    [SerializeField] private Movement playerMovement;
    [SerializeField] private Animator playerAnimator;

    [Header("Audio")]
    [SerializeField] private AudioSource backgroundMusic;

    private bool canSkip = false;
    private string savePath;

    void Start()
    {
        savePath = Path.Combine(Application.persistentDataPath, "saveData.json");

        bool hasSave = File.Exists(savePath);

        // 👉 Читаем из PlayerPrefs
        bool hasLaunchedBefore = PlayerPrefs.GetInt(PREF_KEY, 0) == 1;

        // 🟢 Есть сохранение → НЕ показываем видео
        if (hasSave)
        {
            videoObject.SetActive(false);
            return;
        }

        // 🔴 Нет сохранения → показываем видео
        videoPlayer.loopPointReached += OnVideoEnd;

        StartVideo();

        // 🔥 Если уже запускали игру раньше (значит умерли)
        if (hasLaunchedBefore)
        {
            canSkip = true; // можно сразу скипать
        }
        else
        {
            Invoke(nameof(EnableSkip), 0.5f); // первый запуск
        }

        // 💾 Запоминаем что игра уже запускалась
        PlayerPrefs.SetInt(PREF_KEY, 1);
        PlayerPrefs.Save();
    }

    void StartVideo()
    {
        Time.timeScale = 0f;
        LockPlayer();

        if (backgroundMusic != null)
            backgroundMusic.Pause();

        videoPlayer.Play();
    }

    void LockPlayer()
    {
        if (playerMovement != null)
            playerMovement.enabled = false;

        if (playerAnimator != null)
            playerAnimator.enabled = false;
    }

    void UnlockPlayer()
    {
        if (playerMovement != null)
            playerMovement.enabled = true;

        if (playerAnimator != null)
            playerAnimator.enabled = true;
    }

    void Update()
    {
        if (!canSkip) return;

        if (Input.GetKeyDown(KeyCode.Space) ||
            Input.GetKeyDown(KeyCode.Escape) ||
            Input.GetMouseButtonDown(0))
        {
            SkipVideo();
        }
    }

    void EnableSkip()
    {
        canSkip = true;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        FinishVideo();
    }

    void SkipVideo()
    {
        FinishVideo();
    }

    void FinishVideo()
    {
        videoPlayer.Stop();
        videoObject.SetActive(false);

        Time.timeScale = 1f;
        UnlockPlayer();

        if (backgroundMusic != null)
            backgroundMusic.Play();

        // 💾 создаём сохранение после видео
        FindAnyObjectByType<SaveController>().SaveGame();
    }
}