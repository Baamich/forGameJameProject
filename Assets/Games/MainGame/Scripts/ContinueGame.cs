using UnityEngine;

public class ContinueGame : MonoBehaviour
{
    [SerializeField] Movement movement;
    [SerializeField] Animator animMove;
    [SerializeField] GameObject objLearn;
    public void ContinueGameClick()
    {
        movement.enabled = true;
        animMove.enabled = true;
        objLearn.SetActive(false);
        Time.timeScale = 1f;
    }
}
