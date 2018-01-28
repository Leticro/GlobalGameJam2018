using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SceneData
{
	public string[]  text;
	public int[] cutscene;
	public string[] outcome_text;
	public string[] outcome_scene;
   // public string textAV = "sc1_hub2";
   // public string textAN = "sc1_hub2";
   // public string textCV = "sc1_hub2";
   // public string textCN = "sc1_hub2";
   // public string textWV = "sc1_hub2";
   // public string textWN = "sc1_hub2";

    public int GetSpriteIndex(int key)
	{
		if (key >= cutscene.Length)
			return cutscene [cutscene.Length - 1];
		
		return cutscene [key];
	}

	public string GetOutcomeText(int outcome)
	{
		return outcome_text [outcome];
	}

	public string GetOutcomeScene(int outcome)
	{
		if (outcome >= outcome_scene.Length) 
		{
			Debug.Log (outcome + " is out of array bounds");
			return "sc1_hub_1";
		}
		return outcome_scene [outcome];
	}
}
