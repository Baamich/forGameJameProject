using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Heal : MonoBehaviour
{
     private PlayerCharacteristics playerCharacteristics;
    [SerializeField] private GameObject MedPackObj;
    [SerializeField] private TextMeshProUGUI textError;

    private void Start()
    {
        playerCharacteristics = GameObject.FindWithTag("Player").GetComponent<PlayerCharacteristics>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(playerCharacteristics.heals >= 3)
            {
                textError.text = "У вас максимальное количество грибов";
                playerCharacteristics.StartCoroutine(playerCharacteristics.changeVisible());
            }
            if(playerCharacteristics.heals < 3){
            playerCharacteristics.heals++;
            MedPackObj.SetActive(false);
            playerCharacteristics.healsText.text = $"x{playerCharacteristics.heals}";
            }
        }
    }
}
