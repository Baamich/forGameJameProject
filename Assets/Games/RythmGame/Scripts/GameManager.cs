using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class GameManager : MonoBehaviour
{
    //                   ============= SerializeField ================== 
    [SerializeField] private GameObject myPrefab; // префаб спавна кнопок
    [SerializeField] private Transform canvasParent;
    [SerializeField] private Sprite[] sprites; // спрайты нажатий кнопок
    [SerializeField] private TextAsset[] beatFiles; // файл с битами
    [SerializeField] private MoneyBuy moneyBuyWindow; // ссылка на окно откупа
    //                   ============= HideInInInspector ==================
    [HideInInspector] public GameObject gObj;
    [HideInInspector] public Image currentImg;
    [HideInInspector] public int selectedBeatFileIndex = 0; // выбор файла с битами
    [HideInInspector] public int _count = 0;
    [HideInInspector] public float _time;

    //                  ============= Private ==================
    private float[] secondsToBit;
    

    //                  ============= Public ==================
    public Image background;
    public AudioSource audioSource; // источник музыки
    public Image enemyImage;
    public float checkedTime;
    public TextMeshProUGUI enemyName;
    public TextMeshProUGUI dmgEnemy;

    
    void OnEnable()
    {
        ClearAllIcons();
        LoadSelectedBeatFile();
    }



    private void RestartMusicAndBeats()
    {
        audioSource.Stop();
        audioSource.Play();

        _count = 0;
        _time = 0f;
        LoadSelectedBeatFile();
    }
    private void LoadSelectedBeatFile()
    {
        if (beatFiles == null || beatFiles.Length == 0)
        {
            Debug.LogError("Нет ни одного файла битов!");
            return;
        }

        if (selectedBeatFileIndex < 0 || selectedBeatFileIndex >= beatFiles.Length)
        {
            Debug.LogError($"Неверный индекс файла: {selectedBeatFileIndex}");
            return;
        }

        TextAsset file = beatFiles[selectedBeatFileIndex];
        if (file == null || string.IsNullOrWhiteSpace(file.text))
        {
            Debug.LogError($"Файл #{selectedBeatFileIndex} пустой или не назначен");
            return;
        }

        List<float> times = new List<float>();

        string[] lines = file.text.Split(new char[] { '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);

        foreach (string line in lines)
        {
            string trimmed = line.Trim();
            if (float.TryParse(trimmed, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out float value))
            {
                times.Add(value);
            }
            else if (!string.IsNullOrWhiteSpace(trimmed))
            {
                Debug.LogWarning($"Не удалось распарсить: \"{trimmed}\"");
            }
        }

        secondsToBit = times.ToArray();
    }

    void Update()
    {
        if (secondsToBit == null || secondsToBit.Length == 0) return;
        // Если окно MoneyBuy активно — не спавним иконки
        if (moneyBuyWindow != null && moneyBuyWindow.gameObject.activeSelf)
        return;
        // Проверяем, закончилась ли музыка
        if (!audioSource.isPlaying)
        {
            RestartMusicAndBeats();
        }

        _time += Time.deltaTime;

        while (_count < secondsToBit.Length && _time >= secondsToBit[_count] - checkedTime)
        {
            SpawnIcon();
            _count++;
        }

        
    }
    private void SpawnIcon()
    {
        gObj = Instantiate(myPrefab, canvasParent);
        currentImg = gObj.GetComponentInChildren<Image>();

        if (currentImg != null && sprites != null && sprites.Length > 0)
        {
            int idx = Random.Range(0, sprites.Length);
            currentImg.sprite = sprites[idx];
        }
    }

    public void ClearAllIcons()
{
    for (int i = canvasParent.childCount - 1; i >= 0; i--)
    {
        Transform child = canvasParent.GetChild(i);

        if (child.name.Contains("(Clone)"))
        {
            Destroy(child.gameObject);
        }
    }
}

}