using UnityEngine;

public class TrapHpRemove : MonoBehaviour
{
    [SerializeField] PlayerCharacteristics playerCharacteristics;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCharacteristics.hp--;
            playerCharacteristics.takeDmgTrap();
        }
    }
}
