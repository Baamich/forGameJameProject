using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class EndRythmGame : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SlotButton slotButton;
    [SerializeField] private GameObject rythmGame;
    [SerializeField] private GameObject endRythmGameObj;
    [SerializeField] private AudioSourceOffOn audioSourceOffOn;
    [SerializeField] private Movement playerMovement;
    [SerializeField] private AudioSource audioWin;


    private bool started = false;
    void Update()
    {
        if(slotButton.endGame == true && slotButton.hpEnemy <= 0 && !started)
        {
            gameManager.ClearAllIcons();
            started = true;
            rythmGame.SetActive(false);
            endRythmGameObj.SetActive(true);
            audioWin.Play();
            gameManager.audioSource.Stop();
            
            audioSourceOffOn.audioSource.UnPause();
            gameManager._count = 0;
            gameManager._time = 0;
        }
    }

    public void ResetEndGame()
    {
        started = false;
    }

    public void onClickContinue()
    {
        endRythmGameObj.SetActive(false);
        Time.timeScale = 1f; 
        slotButton.endGame=false;
        playerMovement.enabled = true;
        started = false;
        slotButton.endGame = false;


    }
}
