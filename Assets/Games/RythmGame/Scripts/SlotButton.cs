using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotButton : MonoBehaviour
{
    [SerializeField] private PlayerCharacteristics playerCharacteristics;
    [SerializeField] private Animator anim1;
    [SerializeField] private Animator anim2;
    [SerializeField] private Animator anim3;
    public Animator animTextFail;
    public TextMeshProUGUI FailedText;
    [SerializeField] Image imageHp;
    [SerializeField] private Sprite[] hp8; // спрайты хп
    [SerializeField] private Sprite[] hp10; // спрайты хп
    [SerializeField] private Sprite[] hp12; // спрайты хп
    [SerializeField] private Image[] comboImage;
    [SerializeField] private Sprite[] comboSprites; // спрайты комбо
    [SerializeField] private Animator[] comboAnim; // спрайты комбо
    public GameManager game;
    public int combo;
    public int comboMax;
    public int hpEnemy = 1;
    public int maxEnemyHp;
    public int dmgEnemy;
    public bool endGame;

    void OnEnable()
    {
        combo = 0;
    }

    void Update()
    {
        checkHp8();
        checkHp10();
        checkHp12();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Image img = collision.GetComponentInChildren<Image>();
        if (img == null) return;

        string spriteName = img.sprite.name;

        if (spriteName == "key_up_0")
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if(combo < comboMax)
                {
                combo++;
                checkCombo();
                }
                Destroy(collision.gameObject);
                FailedText.text = "";
                StartCoroutine(animFail("Отлично"));
            }
        }
        else if (spriteName == "key_down_0")
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                if(combo < comboMax)
                {
                combo++;
                checkCombo();    
                }
                Destroy(collision.gameObject);
                FailedText.text = "";
                StartCoroutine(animFail("Отлично"));
            }
        }
        else if (spriteName == "key_right_0")
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if(combo < comboMax)
                {
                combo++;
                checkCombo();  
                }
                Destroy(collision.gameObject);
                FailedText.text = "";
                StartCoroutine(animFail("Отлично"));
            }
        }
        else if (spriteName == "key_left_0")
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if(combo < comboMax)
                {
                combo++;
                checkCombo();  
                }
                Destroy(collision.gameObject);
                FailedText.text = "";
                StartCoroutine(animFail("Отлично"));
            }
        }
        else if (spriteName == "key_claws_0")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Destroy(collision.gameObject);
                StartCoroutine(EnemyAtk());
                FailedText.text = "";
                StartCoroutine(animFail("Ошибка"));
                combo = 0;
                checkCombo();
                
            }
        }
        else if (spriteName == "key_stick_0")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Destroy(collision.gameObject);
                StartCoroutine(Attack());
                FailedText.text = "";
                StartCoroutine(animFail("Отлично"));
                combo = 0;
                checkCombo();
                playerCharacteristics.HeroAttack();
                
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    public IEnumerator EnemyAtk()
    {
        playerCharacteristics.hp -= dmgEnemy;
        playerCharacteristics.dmgEnemy();
        anim1.SetTrigger("Clicked");
        yield return new WaitForSeconds(0.2f);
        anim1.SetTrigger("End");
    }

    public IEnumerator Attack()
    {
        hpEnemy -= combo + playerCharacteristics.attack;
        if (hpEnemy < 0)
        hpEnemy = 0;
        if(hpEnemy<= 0)
        {
            endGame = true;
        }
        anim2.SetTrigger("Clicked");
        yield return new WaitForSeconds(0.2f);
        anim2.SetTrigger("End");
        anim3.SetTrigger("Attack");
        yield return new WaitForSeconds(0.2f);
        anim3.SetTrigger("End");
    }

    public IEnumerator animFail(string Text)
    {
        if (Text == "Ошибка")
        {
            FailedText.color = new Color32(255, 193, 47, 255);
        }
        else if (Text == "Отлично")
        {
            FailedText.color = new Color32(65, 255, 47, 255);
        }
        FailedText.text = $"{Text}";
        animTextFail.SetTrigger("Ошибка");
        yield return new WaitForSeconds(1f);
        animTextFail.SetTrigger("End");

    }

    public void checkCombo()
    {
        if(combo == 1)
        {
            comboAnim[0].SetTrigger("combo1");
            comboImage[0].sprite = comboSprites[0];
            StartCoroutine(AnimCombo(0));
        }else if(combo == 2)
        {
            comboAnim[1].SetTrigger("combo2");
            comboImage[1].sprite = comboSprites[1];
            StartCoroutine(AnimCombo(1));
        }else if(combo == 3)
        {
            comboAnim[2].SetTrigger("combo3");
            comboImage[2].sprite = comboSprites[2];
            StartCoroutine(AnimCombo(2));
        }else if(combo == 4)
        {
            comboAnim[3].SetTrigger("combo4");
            comboImage[3].sprite = comboSprites[3];
            StartCoroutine(AnimCombo(3));
        }else if(combo == 5)
        {
            comboAnim[4].SetTrigger("combo5");
            comboImage[4].sprite = comboSprites[4];
            StartCoroutine(AnimCombo(4));
        }
        
    }

    public IEnumerator AnimCombo(int i)
    {
        yield return new WaitForSeconds(1.5f);
        comboAnim[i].SetTrigger("comboEnd"); 
    }

    private void checkHp8()
    {
        if(maxEnemyHp == 8)
        {
            if(hpEnemy == 8)
            {
                imageHp.sprite = hp8[0];
            }else if(hpEnemy == 7)
            {
                imageHp.sprite = hp8[1];
            }else if(hpEnemy == 6)
            {
                imageHp.sprite = hp8[2];
            }else if(hpEnemy == 5)
            {
                imageHp.sprite = hp8[3];
            }else if(hpEnemy == 4)
            {
                imageHp.sprite = hp8[4];
            }else if(hpEnemy == 3)
            {
                imageHp.sprite = hp8[5];
            }else if(hpEnemy == 2)
            {
                imageHp.sprite = hp8[6];
            }else if(hpEnemy == 1)
            {
                imageHp.sprite = hp8[7];
            }else if(hpEnemy == 0)
            {
                imageHp.sprite = hp8[8];
            }
        }
    }
    
    private void checkHp10()
    {
        if(maxEnemyHp == 10)
        {
            if(hpEnemy == 8)
            {
                imageHp.sprite = hp10[0];
            }else if(hpEnemy == 7)
            {
                imageHp.sprite = hp10[1];
            }else if(hpEnemy == 6)
            {
                imageHp.sprite = hp10[2];
            }else if(hpEnemy == 5)
            {
                imageHp.sprite = hp10[3];
            }else if(hpEnemy == 4)
            {
                imageHp.sprite = hp10[4];
            }else if(hpEnemy == 3)
            {
                imageHp.sprite = hp10[5];
            }else if(hpEnemy == 2)
            {
                imageHp.sprite = hp10[6];
            }else if(hpEnemy == 1)
            {
                imageHp.sprite = hp10[7];
            }else if(hpEnemy == 0)
            {
                imageHp.sprite = hp10[8];
            }else if(hpEnemy == 9)
            {
                imageHp.sprite = hp10[9];
            }else if(hpEnemy == 10)
            {
                imageHp.sprite = hp10[10];
            }
        }
    }

    private void checkHp12()
    {
        if(maxEnemyHp == 12)
        {
            if(hpEnemy == 8)
            {
                imageHp.sprite = hp12[0];
            }else if(hpEnemy == 7)
            {
                imageHp.sprite = hp12[1];
            }else if(hpEnemy == 6)
            {
                imageHp.sprite = hp12[2];
            }else if(hpEnemy == 5)
            {
                imageHp.sprite = hp12[3];
            }else if(hpEnemy == 4)
            {
                imageHp.sprite = hp12[4];
            }else if(hpEnemy == 3)
            {
                imageHp.sprite = hp12[5];
            }else if(hpEnemy == 2)
            {
                imageHp.sprite = hp12[6];
            }else if(hpEnemy == 1)
            {
                imageHp.sprite = hp12[7];
            }else if(hpEnemy == 0)
            {
                imageHp.sprite = hp12[8];
            }else if(hpEnemy == 9)
            {
                imageHp.sprite = hp12[9];
            }else if(hpEnemy == 10)
            {
                imageHp.sprite = hp12[10];
            }else if(hpEnemy == 11)
            {
                imageHp.sprite = hp12[11];
            }else if(hpEnemy == 12)
            {
                imageHp.sprite = hp12[12];
            }
        }
    }
}
