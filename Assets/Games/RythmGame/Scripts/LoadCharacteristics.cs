using System;
using UnityEngine;

public class LoadCharacteristics : MonoBehaviour
{
    //                        ============== Public ===============

    public Sprite enemySprite;
    public int enemyAttack;
    public int enemyHp;
    public string enemyName;
    public int enemyDmg = 1;
    public int indexBeatFile = 0;
    public event Action OnCharacteristicsChanged;
     //                        ============== HideInInspector ===============
    [HideInInspector] public int playerHpMax;
    [HideInInspector] public int playerHp;
    [HideInInspector] public int healing;
    //                        ============== SerializeField ===============

    [SerializeField] private GameObject rythmGame;
    //                        ============== Private ===============

    private PlayerCharacteristics playerCharacteristics;
    
    void Start()
    {
        playerCharacteristics = FindAnyObjectByType<PlayerCharacteristics>();
        playerCharct();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                rythmGame.SetActive(true);
                OnCharacteristicsChanged?.Invoke();
            }
        }
    }

    private void playerCharct()
    {
        playerHpMax = playerCharacteristics.hpMax;
        playerHp = playerCharacteristics.hp;
        healing = playerCharacteristics.heals;
    }
}
