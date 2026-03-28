using UnityEngine;

public class DialogueShow : MonoBehaviour
{
    public bool stickTalk;

    public void ShowStick()
    {
        if (stickTalk)
        {
            gameObject.SetActive(true);
        }else
        {
            gameObject.SetActive(false);
        }
    }
}
