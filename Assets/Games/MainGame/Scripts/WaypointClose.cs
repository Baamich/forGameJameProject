using Unity.Cinemachine;
using UnityEngine;

public class WaypointClose : MonoBehaviour
{
    [SerializeField] private Animator closeGateAnim;
    [SerializeField] private GameObject closeGate;
    [SerializeField] private CinemachineConfiner2D confiner;
    [SerializeField] private PolygonCollider2D mapBoundary;
    [SerializeField] private storyEnd storyEnd;
    [SerializeField] private GameObject boundry;
    public int _a;
    public int _b;
    public int _c;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boundry.SetActive(false);
            closeGate.SetActive(true);
            closeGateAnim.SetTrigger("CloseGate");
            ApplyBoundary(mapBoundary);
            storyEnd.a += _a;
            storyEnd.b += _b;
            storyEnd.c += _c;
            gameObject.SetActive(false);
        }
    }

    private void ApplyBoundary(PolygonCollider2D boundary)
    {
        if(boundary == null || confiner == null) return;
        if (confiner != null)
        {
            confiner.BoundingShape2D = boundary;
            confiner.InvalidateBoundingShapeCache();
        }
    }
}
