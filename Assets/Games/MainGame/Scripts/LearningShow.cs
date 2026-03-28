using UnityEngine;
using UnityEngine.UI;

public class LearningShow : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] GameObject Learn;
    [SerializeField] Sprite LearnImg;
    [SerializeField] Movement movement;
    [SerializeField] Animator animMove;
    void OnTriggerEnter2D(Collider2D collision)
    {
        movement.enabled = false;
        animMove.enabled = false;
        Time.timeScale = 0f;
        img.sprite = LearnImg;
        img.SetNativeSize();
        Learn.SetActive(true);
        gameObject.SetActive(false);
    }
    
    
}
