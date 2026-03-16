using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiseManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private int indexForHighligh;
    [HideInInspector] public string[] ChoiseTextCard;
    [HideInInspector] public Sprite changeImage;
    private float speedText;
    private Color color;
    private int indexChoise;
    private CardManager cardManager;
    public Image image;

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
