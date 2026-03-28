using UnityEngine;
using System.IO;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    [SerializeField] Movement playerMovement;
    [SerializeField] storyEnd storyEnd;
    private string saveLocation;
    public CinemachineConfiner2D mapBoundaryCollider;
    public AudioSource audioSrcGeneral;
    void Start()
    {
        Time.timeScale = 1f;
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
        LoadGame(); 
    }

    public void SaveGame()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        PlayerCharacteristics player = playerObj.GetComponent<PlayerCharacteristics>();

        SaveData saveData = new SaveData
        {
            playerPosition = playerObj.transform.position,
            mapBoundary = FindAnyObjectByType<CinemachineConfiner2D>().BoundingShape2D.gameObject.name,
            musicVolume = audioSrcGeneral != null ? audioSrcGeneral.volume : AudioListener.volume,

            // Сохраняем характеристики игрока
            hp = player.hp,
            hpMax = player.hpMax,
            heals = player.heals,
            attack = player.attack,
            a = storyEnd.a,
            b = storyEnd.b,
            c = storyEnd.c,
        };

        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    public void LoadGame()
    {
        if(File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));
            
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            PlayerCharacteristics player = playerObj.GetComponent<PlayerCharacteristics>();

            // Восстанавливаем позицию
            playerObj.transform.position = saveData.playerPosition;

            // Восстанавливаем характеристики
            player.hp = saveData.hp;
            player.hpMax = saveData.hpMax;
            player.heals = saveData.heals;
            player.attack = saveData.attack;

            storyEnd.a = saveData.a;
            storyEnd.b = saveData.b;
            storyEnd.c = saveData.c;

            // Восстанавливаем границы карты
            FindAnyObjectByType<CinemachineConfiner2D>().BoundingShape2D = GameObject.Find(saveData.mapBoundary).GetComponent<PolygonCollider2D>();
            playerMovement.enabled = true;
            // Восстанавливаем громкость
            if(audioSrcGeneral != null)
                audioSrcGeneral.volume = saveData.musicVolume;
            else
                AudioListener.volume = saveData.musicVolume;
        }
        else
        {
            Debug.Log("No save file found");
        }
    }

    public void DeleteSaveAndReset()
    {
        // 1. Удаляем файл сохранения
        if (File.Exists(saveLocation))
        {
            File.Delete(saveLocation);
        }
        else
        {
        }

        // 2. Перезапускаем сцену (самый простой и правильный способ)
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
        Time.timeScale = 1f;
    }

    public void DeleteSaveAndStartMenu()
    {
        // 1. Удаляем файл сохранения
        if (File.Exists(saveLocation))
        {
            File.Delete(saveLocation);
        }
        else
        {
        }
        
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1f;
        
    }
}