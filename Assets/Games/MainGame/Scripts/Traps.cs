using UnityEngine;
using UnityEngine.UI;

public class Traps : MonoBehaviour
{
    [SerializeField] private Transform target; 
    [SerializeField] private SpriteRenderer img;

    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private float smoothSpeed = 5f;

    private float targetAlpha = 0f;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float distance = Vector2.Distance(collision.transform.position, target.position);

            float t = 1 - Mathf.Clamp01(distance / maxDistance);
            targetAlpha = Mathf.Lerp(0.4f, 1f, t);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetAlpha = 0f;
        }
    }

    void Update()
    {
        Color color = img.color;
        color.a = Mathf.Lerp(color.a, targetAlpha, Time.deltaTime * smoothSpeed);
        img.color = color;
    }
}