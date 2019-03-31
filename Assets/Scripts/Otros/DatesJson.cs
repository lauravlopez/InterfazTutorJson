using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DatesJson : MonoBehaviour {

    string filePath;
    string jsonString;

    void Awake() {
        filePath = Application.streamingAssetsPath + "/Dates.json";
        jsonString = File.ReadAllText(filePath);
        Dates dates = JsonUtility.FromJson<Dates>(jsonString);
        print(dates);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    [System.Serializable]
    public class Dates {
        public string messajeText;
        public override string ToString()
        {
            return string.Format("{0}", messajeText);
        }
    }

}
