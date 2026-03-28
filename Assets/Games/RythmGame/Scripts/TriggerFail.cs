using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TriggerFail : MonoBehaviour
{   
    private SlotButton slotButton;

    void OnEnable()
    {
        slotButton = FindAnyObjectByType<SlotButton>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Image img = collision.GetComponentInChildren<Image>();
        if (img == null) return;

        string spriteName = img.sprite.name;

        if (slotButton.game.currentImg.sprite.name == "key_claws_0")
        {
                slotButton.FailedText.text = "";
            StartCoroutine(slotButton.animFail("Отлично"));
            if(slotButton.combo < slotButton.comboMax)
                {
                slotButton.combo++;
                slotButton.checkCombo();                    
                }
            Destroy(collision.gameObject);
        }else if (spriteName == "key_up_0" || spriteName == "key_down_0" || 
                    spriteName == "key_right_0" || spriteName == "key_left_0" ||spriteName == "key_stick_0"){
            StartCoroutine(slotButton.animFail("Ошибка"));
            StartCoroutine(slotButton.EnemyAtk());
            slotButton.combo = 0;
            Destroy(collision.gameObject);
        }
    }
}
