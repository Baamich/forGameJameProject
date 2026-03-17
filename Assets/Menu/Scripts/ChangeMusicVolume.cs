using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ChangeMusicVolume : MonoBehaviour
{
   [SerializeField] private Slider volume;
   [SerializeField] private TMP_InputField inputText;
   private void Start()
    {
        // Инициализируем поле ввода значением слайдера
        inputText.text = volume.value.ToString("F2");

        // Подписываемся на изменения слайдера
        volume.onValueChanged.AddListener(SliderChangeVolume);

        // Подписываемся на изменения поля ввода
        inputText.onEndEdit.AddListener(InputChangeVolume);
    }

   public void SliderChangeVolume(float value)
    {
        AudioListener.volume = value;
        inputText.text = value.ToString("F3");
    }

    public void InputChangeVolume(string text)
    {
        if(float.TryParse(text, out float value))
        {
            value = Mathf.Clamp(value, 0f, 1f); //ограничение от 0 до 1
            volume.value = value;
            AudioListener.volume = value;

            inputText.text = value.ToString("F3");
        }
        else
        {
            inputText.text = volume.value.ToString("F3");
        }
    }
}
