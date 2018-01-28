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
}
