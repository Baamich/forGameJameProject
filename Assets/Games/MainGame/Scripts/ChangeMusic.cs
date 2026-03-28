using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] TravelMusicChange travelMusicChange;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            travelMusicChange.changeAudioClip(_index);
            gameObject.SetActive(false);
        }
    }
}
