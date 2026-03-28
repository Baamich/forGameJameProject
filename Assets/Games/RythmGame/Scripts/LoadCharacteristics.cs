using System;
using UnityEngine;

public class LoadCharacteristics : MonoBehaviour
{
    //                        ============== SerializeField ===============

    [SerializeField] private GameObject rhytmGame;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SlotButton slotButton;
    [SerializeField] private AudioSourceOffOn audioSourceOffOn;
    [SerializeField] private Movement playerMovement;
    [SerializeField] private GameObject setButton;
    [SerializeField] private GameObject MoneyBuy;
    [SerializeField] private PlayerCharacteristics playerCharacteristics;
    [SerializeField] private EndRythmGame endRythmGame;
    //                        ============== Public ===============
    public Sprite _background;
    public string _enemyName;
    public Sprite _enemySprite;
    public int _enemyDmg;
    public int _enemyHp = 1;
    public int _maxHP;
    public int _selectedBeatIndex;
    public AudioClip _audioClip;
    public int _comboMax;
    public string[] _endRhytmGame;
    public bool isStarted = false;
    

    [HideInInspector]public float speed = 5f;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isStarted)
        {
            if (Input.GetKey(KeyCode.E))
            {
                isStarted = true;
                endRythmGame.ResetEndGame();
                gameManager.background.sprite = _background; // смена фона
                audioSourceOffOn.audioSource.Pause();
                gameManager.enemyName.text = _enemyName; // смена имени врага

                gameManager.enemyImage.sprite = _enemySprite; // смена спрайта врага
                gameManager.enemyImage.SetNativeSize();       // выставляем native size

                slotButton.hpEnemy = _enemyHp;
                _maxHP = _enemyHp;
                slotButton.maxEnemyHp = _maxHP;
                
                gameManager.dmgEnemy.text = _enemyDmg.ToString(); // выставляем урон
                slotButton.dmgEnemy = _enemyDmg;// выставляем урон

                slotButton.comboMax = _comboMax; // высиавояем макс комбо

                gameManager.selectedBeatFileIndex = _selectedBeatIndex; // выставляем нужную музыку
                gameManager.audioSource.clip = _audioClip; // задаём клип для игры
                gameManager.audioSource.Play(); // запускаем этот клип

                slotButton.endGame = false; 

                playerMovement.enabled = false; // отключаем движение игроку
                rhytmGame.SetActive(true);
                if(playerCharacteristics.money >= 1 && _enemyName == "Га-Га-Гарис")
                {
                    MoneyBuy.SetActive(true);
                }
                gameObject.SetActive(false);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        setButton.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        setButton.SetActive(false);
    }
}
