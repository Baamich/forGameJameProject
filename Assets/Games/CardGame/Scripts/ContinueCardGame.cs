using UnityEngine;

public class ContinueCardGame : MonoBehaviour
{
    [SerializeField] private Movement playerMovement;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject CardGame;
    public DialogueShow dialogueShow;
    public void OnClickContinue()
    {
        CardGame.SetActive(false);
        playerAnimator.enabled = true;
        playerMovement.enabled = true;
        dialogueShow.stickTalk = false;
        dialogueShow.ShowStick();
        gameObject.SetActive(false);

    }
}
