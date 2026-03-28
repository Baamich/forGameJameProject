using UnityEngine;

public class MenuShow : MonoBehaviour
{
   [SerializeField] private GameObject Menu;
   [SerializeField] private Animator playerMovementAnim;
   [SerializeField] private Movement playerMovement;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerMovement.enabled = false;
            playerMovementAnim.enabled = false;
            Menu.SetActive(true);
            Time.timeScale = 0f;
            
        }
    }
    
}
