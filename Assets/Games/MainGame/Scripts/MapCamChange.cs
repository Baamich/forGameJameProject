using UnityEngine;
using Unity.Cinemachine;

public class MapCamChange : MonoBehaviour
{
   [SerializeField] PolygonCollider2D mapBoundry;
    CinemachineConfiner2D confiner;
    private void Awake()
    {
        confiner = FindAnyObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            confiner.BoundingShape2D = mapBoundry;
        }
    }
}
