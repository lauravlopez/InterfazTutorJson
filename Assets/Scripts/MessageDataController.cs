using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MessageDataController : MonoBehaviour {
    private MessageRoundData[] allMessageRoundData;
    private string gameDataFileName = "DataJson.json";
 
	// Update is called once per frame
	public MessageRoundData GetCurrentMessageRoundData () {
        return allMessageRoundData[0];
	}

    public void Awake()
    {
        LoadGameData();
    }

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
