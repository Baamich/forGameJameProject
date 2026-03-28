using UnityEngine;

public class ActivateVerticalBoundry : MonoBehaviour
{
    [SerializeField] private GameObject vertical;
    [SerializeField] private GameObject horizontal;
    [SerializeField] private GameObject BridgeFront;
    [SerializeField] private GameObject BridgeBack;
    void OnTriggerEnter2D(Collider2D collision)
    {
        vertical.SetActive(true);
        horizontal.SetActive(false);
        BridgeBack.SetActive(true);
        BridgeFront.SetActive(false);
        gameObject.SetActive(false);
    }
}
