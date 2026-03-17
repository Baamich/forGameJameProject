using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxTextManager : MonoBehaviour
{
    [SerializeField] private string[] lines; // текст который будет выводиться
    private float speedText; // скорость текста по дефолту 0
    private int index; // индекс для ввода текста по дефолту 0
    public string _nameObj; // имя обьекта
    public TextMeshProUGUI dialogueText; // текст который выводится в боксе
    public Image backBoxGround; // фон бокса для текста

    private void Start()
    {
        dialogueText.text = "";
        StartDialogue();
    }

    private void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    
    private IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    public IEnumerator ChangeText(int i)
    {
        dialogueText.text = "";
        foreach (char c in lines[i].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(speedText);
        }
    }

    
}
