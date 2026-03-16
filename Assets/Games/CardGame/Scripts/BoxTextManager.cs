using System.Collections;
using UnityEngine;
using TMPro;

public class BoxTextManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private string[]lines;
    private float speedText;
    private int index;
    public string _nameObj;

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
