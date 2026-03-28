using UnityEngine;

public class ReliableSystemCursor : MonoBehaviour
{
    public Texture2D cursorTexture; // PNG курсора
    public CursorMode cursorMode = CursorMode.Auto;

    void Awake()
    {
        if (cursorTexture != null)
        {
            // Точка клика: левый верхний угол
            Vector2 hotspot = new Vector2(0, 0);

            // Устанавливаем системный курсор с заданным hotspot
            Cursor.SetCursor(cursorTexture, hotspot, cursorMode);

            // Делаем системный курсор видимым
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Debug.LogWarning("Cursor texture не задана!");
        }
    }
}