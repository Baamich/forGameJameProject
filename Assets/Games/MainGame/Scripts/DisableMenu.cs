using System;
using UnityEditor;
using UnityEngine;

public class DisableMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuObj;
    [SerializeField] private Animator playerMovementAnim;
    [SerializeField] private Movement playerMovement;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerMovement.enabled = true;
            playerMovementAnim.enabled = true;
            menuObj.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void DisableMenuObj()
    {
        playerMovement.enabled = true;
        playerMovementAnim.enabled = true;
        menuObj.SetActive(false);
        Time.timeScale = 1f;
    }
}
