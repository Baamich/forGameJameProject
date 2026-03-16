using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotButton : MonoBehaviour
{
    [HideInInspector] public GameManager game;
    Animator anim1;
    Animator anim2;
    Animator animTextFail;
    [SerializeField] TextMeshProUGUI FailedText;
    [SerializeField] GameObject[] screnObj;

    void Start()
    {
        game = FindAnyObjectByType<GameManager>();
        anim1 = screnObj[0].GetComponent<Animator>();
        anim2 = screnObj[1].GetComponent<Animator>();
        animTextFail = FailedText.GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Image img = collision.GetComponentInChildren<Image>();
        if (img == null) return;

        string spriteName = img.sprite.name;

        if (spriteName == "KeyUp_0")
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                Destroy(collision.gameObject);
                StartCoroutine(animFail("Correct"));
            }
        }
        else if (spriteName == "KeyDown_0")
        {
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                Destroy(collision.gameObject);
                StartCoroutine(animFail("Correct"));
            }
        }
        else if (spriteName == "KeyRight_0")
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                Destroy(collision.gameObject);
                StartCoroutine(animFail("Correct"));
            }
        }
        else if (spriteName == "KeyLeft_0")
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                Destroy(collision.gameObject);
                StartCoroutine(animFail("Correct"));
            }
        }
        else if (spriteName == "Enemy_0")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Destroy(collision.gameObject);
                StartCoroutine(EnemyAtk());
                StartCoroutine(animFail("Failed"));
            }
        }
        else if (spriteName == "Attack_0")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Destroy(collision.gameObject);
                StartCoroutine(Attack());
                StartCoroutine(animFail("Correct"));
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    private IEnumerator EnemyAtk()
    {
        screnObj[0].SetActive(true);
        anim1.SetTrigger("Clicked");
        yield return new WaitForSeconds(1f);
        screnObj[0].SetActive(false);
    }

    private IEnumerator Attack()
    {
        screnObj[1].SetActive(true);
        anim2.SetTrigger("Clicked");
        yield return new WaitForSeconds(1f);
        screnObj[1].SetActive(false);
    }

    public IEnumerator animFail(string Text)
    {
        if (Text == "Failed")
        {
            FailedText.color = new Color32(255, 193, 47, 255);
        }
        else if (Text == "Correct")
        {
            FailedText.color = new Color32(65, 255, 47, 255);
        }
        FailedText.text = $"{Text}";
        animTextFail.SetTrigger("Failed");
        yield return new WaitForSeconds(1f);
        FailedText.text = "";
        animTextFail.SetTrigger("Failed");
    }
}
