using UnityEngine;

public class cameraFix : MonoBehaviour
{
    void LateUpdate()
    {
        float ppu = 240f;

        var pos = transform.position;
        pos.x = Mathf.Round(pos.x * ppu) / ppu;
        pos.y = Mathf.Round(pos.y * ppu) / ppu;

        transform.position = pos;
    }
}
