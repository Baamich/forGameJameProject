using UnityEngine;

public class TriggerFail : MonoBehaviour
{
    private SlotButton slotButton;

    void Start()
    {
        slotButton = FindAnyObjectByType<SlotButton>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (slotButton.game.currentImg.sprite.name == "image 37_0")
        {
            StartCoroutine(slotButton.animFail("Correct"));
        }else{
            StartCoroutine(slotButton.animFail("Failed"));
        }
    }
}
