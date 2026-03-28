using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusicVolume : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private Slider volumeBack;
    [SerializeField] private TMP_InputField inputText;

    [Header("Sound (SFX)")]
    [SerializeField] private Slider volumeSound;
    [SerializeField] private TMP_InputField inputTextSound;
    [SerializeField] private AudioSource audioSound; // может быть NULL (это ок)

    private const string musicPrefKey = "MusicVolume";
    private const string soundPrefKey = "SoundVolume";

    private void Start()
    {
        // ===== MUSIC =====
        float savedMusic = PlayerPrefs.HasKey(musicPrefKey) 
            ? PlayerPrefs.GetFloat(musicPrefKey) 
            : 0.1f;

        volumeBack.value = savedMusic;
        inputText.text = savedMusic.ToString("F3");
        AudioListener.volume = savedMusic;

        volumeBack.onValueChanged.AddListener(OnMusicSlider);
        inputText.onEndEdit.AddListener(OnMusicInput);

        // ===== SOUND =====
        float savedSound = PlayerPrefs.HasKey(soundPrefKey) 
            ? PlayerPrefs.GetFloat(soundPrefKey) 
            : 0.1f;

        volumeSound.value = savedSound;
        inputTextSound.text = savedSound.ToString("F3");

        // Применяем только если есть источник
        if (audioSound != null)
            audioSound.volume = savedSound;

        volumeSound.onValueChanged.AddListener(OnSoundSlider);
        inputTextSound.onEndEdit.AddListener(OnSoundInput);
    }

    // ===== MUSIC =====
    public void OnMusicSlider(float value)
    {
        AudioListener.volume = value;
        inputText.text = value.ToString("F3");
        PlayerPrefs.SetFloat(musicPrefKey, value);
    }

    private void OnMusicInput(string text)
    {
        if (float.TryParse(text, out float value))
        {
            value = Mathf.Clamp(value, 0f, 1f);

            volumeBack.value = value;
            AudioListener.volume = value;

            inputText.text = value.ToString("F3");
            PlayerPrefs.SetFloat(musicPrefKey, value);
        }
        else
        {
            inputText.text = volumeBack.value.ToString("F3");
        }
    }

    // ===== SOUND (SFX) =====
    private void OnSoundSlider(float value)
    {
        // ВСЕГДА обновляем UI и сохраняем
        inputTextSound.text = value.ToString("F3");
        PlayerPrefs.SetFloat(soundPrefKey, value);

        // Применяем только если есть AudioSource
        if (audioSound != null)
            audioSound.volume = value;
    }

    private void OnSoundInput(string text)
    {
        if (float.TryParse(text, out float value))
        {
            value = Mathf.Clamp(value, 0f, 1f);

            volumeSound.value = value;
            inputTextSound.text = value.ToString("F3");
            PlayerPrefs.SetFloat(soundPrefKey, value);

            if (audioSound != null)
                audioSound.volume = value;
        }
        else
        {
            inputTextSound.text = volumeSound.value.ToString("F3");
        }
    }
}