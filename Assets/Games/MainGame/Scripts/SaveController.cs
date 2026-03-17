using UnityEngine;
using System.IO;

public class SaveController : MonoBehaviour
{
    private string saveLocation;
    public PolygonCollider2D mapBoundaryCollider;
    public AudioSource audioSrcGeneral;

    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
        LoadGame(); 
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position,
            mapBoundary = mapBoundaryCollider.gameObject.name,
            musicVolume = audioSrcGeneral != null ? audioSrcGeneral.volume : AudioListener.volume
        };

        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    public void LoadGame()
    {
        if(File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));
            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;

            var boundaryObj = GameObject.Find(saveData.mapBoundary);
            if(boundaryObj != null)
            {
                mapBoundaryCollider = boundaryObj.GetComponent<PolygonCollider2D>();
            }

            if(audioSrcGeneral != null)
                audioSrcGeneral.volume = saveData.musicVolume;
            else
                AudioListener.volume = saveData.musicVolume;
        }
        else
        {
            SaveGame();
        }
    }
}