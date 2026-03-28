using UnityEngine;

public class MoneyBuy : MonoBehaviour
{
   [SerializeField] private SlotButton slotButton;
   [SerializeField] private PlayerCharacteristics playerCharacteristics;
    public void UseMoney()
    {
        slotButton.hpEnemy = -1;
        playerCharacteristics.money = 0;
        playerCharacteristics.CheckMoney();
        gameObject.SetActive(false);
        if(slotButton.hpEnemy <= 0)
        {
            slotButton.endGame = true;
        }
    }

    public void DontUseMoney()
    {
        gameObject.SetActive(false);
    }
}
