using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MessageDataController : MonoBehaviour {
    public MessageRoundData[] allMessageRoundData;
    private string gameDataFileName = "DataJson.json";
   
 
	
	public MessageRoundData GetCurrentMessageRoundData (int n) {
        return allMessageRoundData[n];
	}

    public void Awake()
    {
        LoadGameData();
    }

    //cargar todos los datos de archivo json
    private void LoadGameData() {
        string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            GameData loadedData = JsonUtility.FromJson<GameData>(dataAsJson);
            allMessageRoundData = loadedData.allMessageRoundData;
        }
        else {
            Debug.LogError("Cannot load game data!");
        }
    }
}
