using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadCharCard : MonoBehaviour
{
    [SerializeField] private GameObject cardGame; // обьект карт игры
    public Sprite _imgSprite; // начальный спрайт карточки
    public Sprite[] _choiseImgSprite; // спрайт после выбора опредленного выбора зоны
    public string[] _choiseTextCard; // текст для зон
    public Sprite[] _choiseZoneImgSprite; // фон зоны
    public Sprite _BackGround; // фон игры
    public Sprite _backBoxGround; // фон бокса основного текста
    public string _boxText; // основной текст в боксе
    public event Action OnCharacteristicsChanged; // ивент для обновления UI 

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E)) // при нажатии на E должно произойти событие которое передаст обновление в UI для карт игры
            {
                cardGame.SetActive(true);
                OnCharacteristicsChanged?.Invoke();
            }
        }
    }
}
