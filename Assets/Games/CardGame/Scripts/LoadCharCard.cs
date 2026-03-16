using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadCharCard : MonoBehaviour
{
    [SerializeField] private GameObject cardGame;
    public Image _image;
    public int _indexChoise;
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
