using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadCharCard : MonoBehaviour
{
    [SerializeField] private GameObject cardGame;
    public Sprite _imgSprite;
    public Sprite[] _choiseImgSprite;
    public string[] _choiseTextCard;
    public Sprite[] _choiseZoneImgSprite;
    public event Action OnCharacteristicsChanged;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                cardGame.SetActive(true);
                OnCharacteristicsChanged?.Invoke();
            }
        }
    }
}
