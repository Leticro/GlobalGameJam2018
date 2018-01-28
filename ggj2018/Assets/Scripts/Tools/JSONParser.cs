using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONParser : MonoBehaviour 
{
	public static SceneData GetSceneData(string sceneName)
	{
		string fileName = "JSON/" + sceneName + ".json";
		string path = Path.Combine(Application.dataPath, fileName);
		if (File.Exists (path)) {
			string dataAsJson = File.ReadAllText (path);
			return JsonUtility.FromJson<SceneData> (dataAsJson);
		} 
		else 
		{
			Debug.Log ("Failed to load " + path);
		}
		return null;
	}

	public void SaveSceneData()
	{
		SceneData testData = new SceneData();
		testData.text = new string[2]{"Ohai","mark"};
		testData.cutscene = new int[2]{ 0, 0 };
		testData.nextAction ="Load";
		testData.nextSceneName = "Hub_0";
		string str = JsonUtility.ToJson(testData);

		string fileName = "JSON/intro.json";
		string path = Path.Combine(Application.dataPath, fileName);

		File.WriteAllText(path,str);
	}
}
