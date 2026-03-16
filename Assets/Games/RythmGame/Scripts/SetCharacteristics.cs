using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetCharacteristics : MonoBehaviour
{   
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audio;
    [SerializeField] private Image imgEnemy;
    [SerializeField] private Image playerImgHp;
    [SerializeField] private Sprite[] playerSpriteHp;
    [SerializeField] private Image enemyImgHp;
    [SerializeField] private Sprite[] enemySpriteHp;
    [SerializeField] private Animator animatorEnemyImg;
    [SerializeField] private GameObject[] gObj;
    [SerializeField] private TextMeshProUGUI textEnemyName;
    [SerializeField] private TextMeshProUGUI textEnemyDmg;
    [SerializeField] private Image healImg;
    [SerializeField] private TextMeshProUGUI textHeal;
    [HideInInspector] public int _indexBeatFile;
    private LoadCharacteristics loadCharacteristics;
    private int _playerHpMax;
    private int _playerHp;
    private int _enemyHp;
    private string _enemyName;
    private int _dmgEnemy;
    private int _healing;
    
    void OnEnable()
    {
        if(loadCharacteristics == null)
            loadCharacteristics = FindAnyObjectByType<LoadCharacteristics>();

        loadCharacteristics.OnCharacteristicsChanged += UpdateCharacteristics;
        UpdateCharacteristics();
    }

    void Start()
    {
        loadCharacteristics = FindAnyObjectByType<LoadCharacteristics>();

        // imgEnemy.sprite = loadCharacteristics.enemySprite;
        // _playerHp = loadCharacteristics.playerHp;
        // _enemyHp = loadCharacteristics.enemyHp;
        // _enemyName = loadCharacteristics.enemyName;
        // _dmgEnemy = loadCharacteristics.enemyDmg;
        // _indexBeatFile = loadCharacteristics.indexBeatFile;
        // textEnemyName.text = _enemyName;
        // textEnemyDmg.text = _dmgEnemy.ToString();
        
        animatorEnemyImg = gObj[0].GetComponent<Animator>();
    }

    void Update()
    {
        checkHeals();
    }
    

    void OnDisable()
    {
        if(loadCharacteristics != null)
            loadCharacteristics.OnCharacteristicsChanged -= UpdateCharacteristics;
    }

    private void checkHeals()
    {
        Color color = healImg.color;
        if(_healing > 0)
        {
            color.a = 1;
            textHeal.alpha = 1f;
            if (Input.GetKeyDown(KeyCode.H) && _healing > 0 && _playerHp < _playerHpMax)
            {
                _playerHp++;  
                textHeal.text = _healing--.ToString();      
            }
        }else if ( _healing == 0)
        {
            color.a = 0.5f;
            textHeal.alpha = 0f;            
        }
    }

    // void Update()
    // {
    //     CheckChangedName();
    //     CheckSpriteHpMaxPlayer();
    //     CheckSpriteHpMaxEnemy();
    //     CheckSound(loadCharacteristics.indexBeatFile);
    // }

    private void UpdateCharacteristics()
    {
        imgEnemy.sprite = loadCharacteristics.enemySprite;

        _enemyName = loadCharacteristics.enemyName;
        _enemyHp = loadCharacteristics.enemyHp;
        _playerHpMax = loadCharacteristics.playerHpMax;
        _playerHp = loadCharacteristics.playerHp;
        _dmgEnemy = loadCharacteristics.enemyDmg;
        _indexBeatFile = loadCharacteristics.indexBeatFile;
        _healing = loadCharacteristics.healing;

        textEnemyName.text = _enemyName;
        textEnemyDmg.text = _dmgEnemy.ToString();
        textHeal.text = _healing.ToString();
            
        SetAnimator(_enemyName);

        CheckSpriteHpMaxPlayer();
        CheckSpriteHpMaxEnemy();
        CheckSound(_indexBeatFile);
    }
    
    private void CheckSound(int i)
    {
        audioSource.clip = audio[i];
        audioSource.Play();
    }

    private void SetAnimator(string name)
    {
        animatorEnemyImg.SetTrigger(name);
    }

    private void CheckSpriteHpMaxPlayer()
    {
        if (_playerHp == 2)
        {
            playerImgHp.sprite = playerSpriteHp[0];
        }
        else if (_playerHp == 3)
        {
            playerImgHp.sprite = playerSpriteHp[1];
        }
        else if (_playerHp == 4)
        {
            playerImgHp.sprite = playerSpriteHp[2];
        }
        else if (_playerHp == 5)
        {
            playerImgHp.sprite = playerSpriteHp[3];
        }
    }

    private void CheckSpriteHpMaxEnemy()
    {
        if (_enemyHp == 8)
        {
            enemyImgHp.sprite = enemySpriteHp[0];
        }
        else if (_enemyHp == 10)
        {
            enemyImgHp.sprite = enemySpriteHp[1];
        }
        else if (_enemyHp == 12)
        {
            enemyImgHp.sprite = enemySpriteHp[2];
        }
    }
}
