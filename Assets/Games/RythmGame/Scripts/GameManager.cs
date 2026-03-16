using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //                   ============= SerializeField ================== 
    [SerializeField] private GameObject myPrefab;
    [SerializeField] private Transform canvasParent;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private TextAsset[] beatFiles;
    [SerializeField] private int selectedBeatFileIndex = 0;

    //                   ============= HideInInInspector ==================
    [HideInInspector] public GameObject gObj;
    [HideInInspector] public Image currentImg;

    //                  ============= Private ==================
    private float[] secondsToBit;
    private int _count = 0;
    private float _time;
    private SetCharacteristics setCharacteristics;

    //                  ============= Public ==================
    public float checkedTime;

    
    void Awake()
    {
        setCharacteristics = FindAnyObjectByType<SetCharacteristics>();
        selectedBeatFileIndex = setCharacteristics._indexBeatFile;
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

}