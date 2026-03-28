using UnityEngine;

public class CursorAutoHide : MonoBehaviour
{
    [SerializeField] private float hideDelay = 5f; // через сколько секунд скрывать

    private Vector3 lastMousePosition;
    private float timer;
    private bool isHidden = false;

    void Start()
    {
        lastMousePosition = Input.mousePosition;
        ShowCursor();
    }

    void Update()
    {
        // если мышь сдвинулась
        if (Input.mousePosition != lastMousePosition)
        {
            lastMousePosition = Input.mousePosition;
            timer = 0f;

            if (isHidden)
                ShowCursor();
        }
        else
        {
            timer += Time.deltaTime;

            if (timer >= hideDelay && !isHidden)
                HideCursor();
        }
    }

    void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None; // можно поменять при необходимости
        isHidden = true;
    }

    void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isHidden = false;
    }
}