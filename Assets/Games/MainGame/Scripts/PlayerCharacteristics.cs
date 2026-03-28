using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacteristics : MonoBehaviour
{   
    [SerializeField] private AudioSource audioSource;
    public AudioSource audioSourceBelching;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private Image heroImage;
    [SerializeField] private Image AttackImage;
    [SerializeField] private Sprite[] AttackSprite;
    [SerializeField] private Image moneyImage;
    [SerializeField] private Sprite[] hpSprites;
    [SerializeField] private Image healImage;
    [SerializeField] private TextMeshProUGUI healText;
    [SerializeField] private Animator animTextEror;
    [SerializeField] private TextMeshProUGUI textError;
    [SerializeField] private GameObject textErrorObj;
    [SerializeField] private Animator HeroAnimator;
    [SerializeField] private Animator ClipClapAnim;

    private Color color;
    private Color color2;
    public int hpMax;
    public int hp;
    public int heals;
    public TextMeshProUGUI healsText;
    public int attack;
    public int money;

    public bool stop = false;

    void Update()
    {       
        CheckHp();
        CheckAttack();
        Healing();
        CheckHeals();
        CheckMoney();
    }

    private void CheckHp()
    {
        if(hp == 1)
        {
            heroImage.sprite = hpSprites[0];
        }else if (hp == 2)
        {
            heroImage.sprite = hpSprites[1];  
        }else if (hp == 3)
        {
            heroImage.sprite = hpSprites[2];  
        }else if (hp == 4)
        {
            heroImage.sprite = hpSprites[3];  
        }else if (hp == 5)
        {
            heroImage.sprite = hpSprites[4];  
        }else if (hp == 0)
        {
            heroImage.sprite = hpSprites[5];  
        }
    }

    private void CheckAttack()
    {
        if(attack == 0)
        {
            AttackImage.sprite = AttackSprite[0];
        }else if(attack == 1)
        {
            AttackImage.sprite = AttackSprite[1];
        }else if(attack == 2)
        {
            AttackImage.sprite = AttackSprite[2];
        }else if(attack == 3)
        {
            AttackImage.sprite = AttackSprite[3];
        }
    }
    
    private void Healing()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            
            if(heals > 0 && hp < hpMax)
            {
                hp++;
                heals--;
                audioSource.clip = audioClips[0];
                audioSource.Play();
            }else if(heals <= 0)
            {
                textError.text = "У вас закончились грибы";
                StartCoroutine(changeVisible());
            }else if(hp == hpMax)
            {
                textError.text = "У вас максимальное количество здоровья";
                StartCoroutine(changeVisible());
            }
        }
    }


    private void CheckHeals()
    {
        if ( heals > 0)
        {
            color = healImage.color;
                color.a = 1;
                healImage.color = color;
                healText.text = $"x{heals}";
        }else if (heals <= 0)
        {       color = healImage.color;
                color.a = 0.5f;
                healImage.color = color;
                healsText.text = ($"");
        }
    }

    public void CheckMoney()
    {
        if(money > 0)
        {
            color2 = moneyImage.color;
            color2.a = 1f;
            moneyImage.color = color2;
        }else if(money < 0)
        {
            color2 = moneyImage.color;
            color2.a = 0f;
            moneyImage.color = color2;
        }
    }

    public IEnumerator changeVisible()
    {
        textErrorObj.SetActive(true);
        animTextEror.SetTrigger("Error");
        yield return new WaitForSeconds(2f);
        textErrorObj.SetActive(false);
    }


    public void takeCard()
    {
        audioSource.clip = audioClips[1];
        audioSource.Play();
    }

    public void takeDmgTrap()
    {
        audioSource.clip = audioClips[2];
        audioSource.Play();
    }

    // public void Moving()
    // {
    //     audioSource.clip = audioClips[3];
    //     audioSource.loop = true;
    //     audioSource.Play();
    // }

    // public void MovingStop()
    // {
    //     audioSource.clip = audioClips[3];
    //     audioSource.loop = false;
    //     audioSource.Stop();
    // }

    public IEnumerator timerBelching()
    {
        while (true)
        {
            
            if(stop == true)
            {
                break;
            } else if (stop == false)
            {
            int random = UnityEngine.Random.Range(20, 31);
            yield return new WaitForSeconds(random);
            audioSourceBelching.clip = audioClips[4];
            audioSourceBelching.Play();
            }
            
            
        }
    }


    
    public void dmgEnemy()
    {
        float originalVolume = audioSource.volume;
        audioSource.volume += 0.15f;

        audioSource.PlayOneShot(audioClips[5]); // вместо clip + Play
        StartCoroutine(RestoreVolume(originalVolume, 1f));
    }

    private IEnumerator RestoreVolume(float originalVolume, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioSource.volume = originalVolume; // возвращаем исходное значение
    }
    public void HeroAttack()
    {
        audioSource.clip = audioClips[6];
        audioSource.Play();
    }

    public void changeSkinBelching()
    {
        HeroAnimator.SetTrigger("Belching");
    }

    public void changeSkinWizzard()
    {
        HeroAnimator.SetTrigger("Mage");
    }

    public IEnumerator ClipClapStart()
    {
        while (true)
        {
            int random = UnityEngine.Random.Range(10, 41);
            yield return new WaitForSeconds(random);

            ClipClapAnim.SetTrigger("ClipClap");
            yield return new WaitForSeconds(1f);
            ClipClapAnim.SetTrigger("End");
        }
    }

    
}
