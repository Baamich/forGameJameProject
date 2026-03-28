using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxTextManager : MonoBehaviour
{
    [HideInInspector] public string[] lines; // текст который будет выводиться
    private float speedText; // скорость текста по дефолту 0
    private int index; // индекс для ввода текста по дефолту 0
    public TextMeshProUGUI dialogueText; // текст который выводится в боксе
    private void OnEnable()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        index = 0;
        StartCoroutine(TypeLine());
        
    }

    public IEnumerator TypeLine()
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
