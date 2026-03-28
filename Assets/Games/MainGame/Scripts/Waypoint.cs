using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D mapBoundary;
    [SerializeField] private CinemachineConfiner2D confiner;
    [SerializeField] private GameObject pressButton;
    [SerializeField] private GameObject gate;
    [SerializeField] private Animator gateAnim;
    [SerializeField] private storyEnd storyEnd;
    [SerializeField] private GameObject boundry;

    private bool inCollision = false;
    public int _a;
    public int _b;
    public int _c;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        pressButton.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && !inCollision)
            {
                boundry.SetActive(true);
                inCollision = true;
                ApplyBoundary(mapBoundary);
                StartCoroutine(openGate());
                storyEnd.a += _a;
                storyEnd.b += _b;
                storyEnd.c += _c;
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        pressButton.SetActive(false);

        }
    }

    private void ApplyBoundary(PolygonCollider2D boundary)
    {
        if (confiner != null)
        {
            confiner.BoundingShape2D = boundary;
            confiner.InvalidateBoundingShapeCache();
        }
    }

    private IEnumerator openGate()
    {
        gateAnim.SetTrigger("OpenGate");
        yield return new WaitForSeconds(1.5f);
        gate.SetActive(false);
    }

}