using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class СontinueImage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject[] obj;
    [SerializeField] private GameObject LearningObj;
    [SerializeField] private Image imageChange;
    [SerializeField] private Sprite[] sprites;
    private int index;
    
    public void ChangeImage()
    {
        index++;
        if (index < sprites.Length)
        {
            imageChange.sprite = sprites[index];

            if (index == sprites.Length - 1)
            {
                text.text = "Выход";
            }
        }
        else
        {
            showObj();
        }
    }

    private void showObj()
    {
        for(int i = 0; i < obj.Length; i++) 
        {
            obj[i].SetActive(true);
        }

        index = 0;
        imageChange.sprite = sprites[0];
        LearningObj.SetActive(false);
        text.text = "Дальше";
    }
}

