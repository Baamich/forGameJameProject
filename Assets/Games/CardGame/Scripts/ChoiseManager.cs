using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiseManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text; // текст выводимый в зоне
    [SerializeField] private int indexForHighligh; // индекс зоны (0/1) в зависимости от кол-ва зон
    [HideInInspector] public string[] ChoiseTextCard; // текст для ввода, который выводится в зоне
    [HideInInspector] public Sprite changeImage; // спрайт для обновления UI обьекта
    private float speedText; // скорость текста по дефолту 0
    private Color color; // локальная переменная для цвета
    private int indexChoise; // локальная переменная для текста
    private CardManager cardManager; // скрипт 
    public Image image; // наш обьект зоны

    void Start()
    {
        cardManager = FindAnyObjectByType<CardManager>();
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
            
            text.alpha = 0.9f;
            
            text.text = "";
            StartCoroutine(TypeLine0());
            
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "CardImage")
        {
            cardManager.zoneHighlight.ResetHighlight();

            color = image.color;
            color.a = 0.5f;
            image.color = color;

            text.alpha = 0f;
        }
    }
}
