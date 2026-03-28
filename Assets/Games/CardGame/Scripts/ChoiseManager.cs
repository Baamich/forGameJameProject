using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class ChoiseManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text; // текст выводимый в зоне
    [SerializeField] private Image textBox; // текст выводимый в боксе зоны
    [SerializeField] private RectTransform cardTransform; // текст выводимый в зоне
    [SerializeField] private int indexForHighligh; // индекс зоны (0/1) в зависимости от кол-ва зон
    [HideInInspector] public string[] ChoiseTextCard; // текст для ввода, который выводится в зоне
    [HideInInspector] public int indexChoise; // локальная переменная для текста
    
    private float speedText; // скорость текста по дефолту 0
    private Color color; // локальная переменная для цвета
    private Color color2; // локальная переменная для цвета
    private CardManager cardManager; // скрипт 
    public Image image; // наш обьект зоны

    private Vector3 originalScale; // cохраняем исходный масштаб
    private Vector3 minScale;      // минимальный размер

    void OnEnable()
    {
        cardManager = FindAnyObjectByType<CardManager>();
        originalScale = cardTransform.localScale;
        minScale = originalScale * 0.5f; // не меньше половины исходного размера
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "CardImage")
        {
            cardManager.zoneHighlight.Highlight();
            cardManager.zoneHighlight.index = indexForHighligh;
            color = image.color;
            color.a = 0.9f;
            image.color = color;

            color2 = textBox.color;
            color2.a = 0.9f;
            textBox.color = color2;
            
            text.alpha = 0.9f;
            
            text.text = "";
            StartCoroutine(TypeLine0());

            // Плавное уменьшение с ограничением
        Vector3 targetScale = new Vector3(
            Mathf.Max(cardTransform.localScale.x * 0.5f, minScale.x),
            Mathf.Max(cardTransform.localScale.y * 0.5f, minScale.y),
            Mathf.Max(cardTransform.localScale.z * 0.5f, minScale.z)
        );

        StartCoroutine(ScaleTo(cardTransform, targetScale, 0.5f));
            
        }
    
    }

    IEnumerator TypeLine0()
    {
        foreach (char c in ChoiseTextCard[indexChoise].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    IEnumerator ScaleTo(Transform target, Vector3 targetScale, float duration)
    {
        Vector3 startScale = target.localScale;
        float time = 0;

        while (time < duration)
        {
            target.localScale = Vector3.Lerp(startScale, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        target.localScale = targetScale;
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "CardImage")
        {
            cardManager.zoneHighlight.ResetHighlight();

            color = image.color;
            color.a = 0.5f;
            image.color = color;

            color2 = textBox.color;
            color2.a = 0f;
            textBox.color = color2;

            text.alpha = 0f;

            // Возвращаем исходный размер
            StartCoroutine(ScaleTo(cardTransform, originalScale, 0.5f));
        }
    }
}
