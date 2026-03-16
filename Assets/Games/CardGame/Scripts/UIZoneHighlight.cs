using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIZoneHighlight : MonoBehaviour
{
    [SerializeField] private Image[] zoneImage;        
    [SerializeField] private Color highlightColor = Color.yellow; 
    [SerializeField] private float transitionDuration = 0.5f; // скорость смены цвета

    private Color originalColor;
    private Coroutine currentCoroutine;
    public int index;
    private void Awake()
    {
        if (zoneImage != null)
            originalColor = zoneImage[index].color;
    }

    // Включаем подсветку
    public void Highlight()
    {
        // Останавливаем текущую корутину, если есть
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(ChangeColor(zoneImage[index].color, highlightColor));
    }

    // Выключаем подсветку (плавно возвращаемся к исходному цвету)
    public void ResetHighlight()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(ChangeColor(zoneImage[index].color, originalColor));
    }

    // Общая корутина для плавного перехода
    private IEnumerator ChangeColor(Color from, Color to)
    {
        float timer = 0f;

        while (timer < transitionDuration)
        {
            timer += Time.deltaTime;
            zoneImage[index].color = Color.Lerp(from, to, timer / transitionDuration);
            yield return null;
        }

        zoneImage[index].color = to;
        currentCoroutine = null;
    }
}