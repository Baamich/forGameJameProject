using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiseManager : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] ChoiseTextCard;
    private float speedText;
    private Color color;
    private int indexChoise;
    private LoadCharCard loadCharCard;
    public Sprite changeImage;

    void Start()
    {
        loadCharCard = FindAnyObjectByType<LoadCharCard>();
        image = loadCharCard._image;
        indexChoise = loadCharCard._indexChoise;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "CardImage")
        {
            color = image.color;
            color.a = 0.9f;
            image.color = color;
            text.alpha = 0.9f;

            if (collision.name == "CardImage")
            {
                text.text = "";
                StartCoroutine(TypeLine0());
            }
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
            color = image.color;
            color.a = 0f;
            image.color = color;
            text.alpha = 0f;
        }
    }
}
