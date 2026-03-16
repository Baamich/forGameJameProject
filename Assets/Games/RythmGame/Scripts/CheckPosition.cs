using UnityEngine;

public class CheckPosition : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform targetPoint;
    private BeatMover beatMover;
    private GameManager game;
    void Start()
    {
        beatMover = FindAnyObjectByType<BeatMover>();
        game = FindAnyObjectByType<GameManager>();
        CalculateCheckedTime();       
    }

    private void CalculateCheckedTime()
    {

        float distance = Vector2.Distance(spawnPoint.position, targetPoint.position);
        game.checkedTime = distance / beatMover.speed;

        Debug.Log($"Расчет checkedTime: {game.checkedTime:F3} секунд (distance = {distance:F2}, speed = {beatMover.speed})");
    }
}
