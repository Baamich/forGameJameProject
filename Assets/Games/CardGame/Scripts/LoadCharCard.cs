using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class LoadCharCard : MonoBehaviour
{
    [SerializeField] private GameObject showbutton;
    [SerializeField] private GameObject cardGame; // обьект карт игры
    [SerializeField] private ChoiseManager[] choiseManager;
    [SerializeField] private CardManager cardManager;
    [SerializeField] private BoxTextManager boxTextManager;
    // [SerializeField] private Image BackgroundCardGame;
    [SerializeField] private DropZone[] dropZones;
    [SerializeField] private Movement playerMovement;
    [SerializeField] private Animator playerAnimator;

    public string[] _choiseText; // текста для карт игры 
    [TextArea(3,10)]
    public string _boxText; // основной текст в боксе
    [TextArea(3,10)]
    public string _boxText1; // основной текст в боксе
    [TextArea(3,10)]
    public string _boxText2; // основной текст в боксе
    public Sprite _changeCardSprite; // смена для карты
    public Sprite[] _spriteCardChange; // смена для карты после выбора
    // public Sprite _changeBackground; // смена фона игры
    // public Sprite[] _changeBackZone; // смена фона зоны

    public int[] HpAdd;
    public int[] HpRemove;
    
    public int[] dmgAdd;
    public int[] dmgRemove;

    public int[] _buff;
    public int[] _debuff;
    public int[] _debuff2;
    public GameObject[] _gates;
    public Animator[] _gateAnim;
    public int _openLeft;
    public int _openRight;
    private bool isStarted = false;

    public int[] moneyAdd;
    public int[] moneyRemove;

    public int[] _stickTalk;

    void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && !isStarted) // при нажатии на E должно произойти событие которое передаст обновление в UI для карт игры
            {
                isStarted = true;
                dropZones[0].dropZone[0].SetActive(true);
                dropZones[1].dropZone[1].SetActive(true);
                choiseManager[0].ChoiseTextCard[0] = _choiseText[0]; // текст для лево выбор зоны
                choiseManager[1].ChoiseTextCard[0] = _choiseText[1]; // право 

                boxTextManager.lines[0] = _boxText; // основной текст
                boxTextManager.lines[1] = _boxText1; // основной текст
                boxTextManager.lines[2] = _boxText2; // основной текст

                cardManager.img.sprite = _changeCardSprite; // смена спрайта карты вначале
                cardManager.choiseImgSprite = _spriteCardChange; // спрайт карты при выкидыванию в зону

                cardManager.stickTalk = _stickTalk;

                // BackgroundCardGame.sprite = _changeBackground; // смена спрайта фона в игре

                // choiseManager[0].image.sprite = _changeBackZone[0]; // смена спрайта фона зоны
                // choiseManager[1].image.sprite = _changeBackZone[1]; // смена спрайта фона зоны

                for (int i = 0; i < dropZones.Length; i++)
                {
                    dropZones[i].isHpAdd = (int)HpAdd[i];
                    dropZones[i].isHpRemove = (int)HpRemove[i];
                }

                for (int i = 0; i < dropZones.Length; i++)
                {
                    dropZones[i].isDmgAdd = (int)dmgAdd[i];
                    dropZones[i].isDmgRemove = (int)dmgRemove[i];

                }
                for (int i = 0; i < dropZones.Length; i++)
                {
                    dropZones[i].isMoneyAdd = (int)moneyAdd[i];
                    dropZones[i].isMoneyRemove = (int)moneyRemove[i];

                }
                for (int i = 0; i < dropZones.Length; i++)
                {
                    dropZones[i].Buff = (int)_buff[i];
                    dropZones[i].Debuff = (int)_debuff[i];
                    dropZones[i].Debuff2 = (int)_debuff2[i];

                }
                for (int i = 0; i < dropZones.Length; i++)
                {
                    dropZones[0].openLeft = _openLeft;
                    dropZones[1].openRight = _openRight;
                    
                }

                for (int i = 0; i < dropZones.Length; i++)
                {
                    if(_gates[i] == null && _gateAnim == null) return;
                    dropZones[i].gates = (GameObject)_gates[i];
                    dropZones[i].gateAnim = (Animator)_gateAnim[i];
                }
                
                playerMovement.enabled = false;
                playerAnimator.enabled = false;
                cardGame.SetActive(true);
                gameObject.SetActive(false);
                isStarted = false;               
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            showbutton.SetActive(true);
        }
    }
}
