using UnityEngine;

public class ActivateHorizontalBoundry : MonoBehaviour
{
    [SerializeField] private GameObject vertical;
    [SerializeField] private GameObject horizontal;
    [SerializeField] private GameObject BridgeFront;
    [SerializeField] private GameObject BridgeBack;
    void OnTriggerEnter2D(Collider2D collision)
    {
        vertical.SetActive(false);
        horizontal.SetActive(true);
        BridgeFront.SetActive(true);
        BridgeBack.SetActive(false);
        gameObject.SetActive(false);
    }

}
