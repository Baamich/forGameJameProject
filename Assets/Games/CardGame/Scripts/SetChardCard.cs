using System;
using UnityEngine;
using UnityEngine.UI;

public class SetChardCard : MonoBehaviour
{
    [SerializeField] private Image BackGround;
    [SerializeField] private ChoiseManager[] choiseManager;
    private CardManager cardManager;
    private LoadCharCard loadCharCard;
    private BoxTextManager boxTextManager;
    void OnEnable()
    {
        cardManager = FindAnyObjectByType<CardManager>();
        loadCharCard = FindAnyObjectByType<LoadCharCard>();

        if(loadCharCard == null)
            loadCharCard = FindAnyObjectByType<LoadCharCard>();

        loadCharCard.OnCharacteristicsChanged += UpdateCharacteristics;
        UpdateCharacteristics();
    }

    void Start()
    {
        cardManager = FindAnyObjectByType<CardManager>();
        loadCharCard = FindAnyObjectByType<LoadCharCard>();
    }

    void OnDisable()
    {
        if(loadCharCard != null)
            loadCharCard.OnCharacteristicsChanged -= UpdateCharacteristics;
    }
    private void UpdateCharacteristics()
    {
        cardManager.imgSprite = loadCharCard._imgSprite;// загрузка спрайта карточки

        cardManager.choiseImgSprite = loadCharCard._choiseImgSprite; // замена спрайта после выбора в зоне 1 / зоне 2

        choiseManager[0].ChoiseTextCard[0] = loadCharCard._choiseTextCard[0]; // загрузка текста в зоне 1
        choiseManager[1].ChoiseTextCard[1] = loadCharCard._choiseTextCard[1]; //                    зоне 2

        choiseManager[0].image.sprite = loadCharCard._choiseZoneImgSprite[0]; // загрузка спрайта для фона зоны 1
        choiseManager[1].image.sprite = loadCharCard._choiseZoneImgSprite[1]; //                            зоны 2

        boxTextManager.backBoxGround.sprite = loadCharCard._backBoxGround; // загрузка фона бокса для текста
        boxTextManager.dialogueText.text = loadCharCard._boxText; // загрузка текста в бокс для текста

        BackGround.sprite = loadCharCard._backBoxGround; // загрузка фона игры
    }
}
