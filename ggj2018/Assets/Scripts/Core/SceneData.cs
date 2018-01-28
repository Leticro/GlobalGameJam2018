using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneAction
{
	LoadScene,
	StartTurn,
	MainMenu
}

[System.Serializable]
public class SceneData
{
	public string[]  text;
	public int[] cutscene;
	public string nextAction;
	public string nextSceneName;

	public int GetSpriteIndex(int key)
	{
		if (key >= cutscene.Length)
			return cutscene [cutscene.Length - 1];
		
		return cutscene [key];
	}

	public SceneAction GetNextAction()
	{
		switch (nextAction) 
		{
		case "Load":
			return SceneAction.LoadScene;
		case "StartTurn":
			return SceneAction.StartTurn;
		}
		return SceneAction.MainMenu;
	}

	public string GetNextSceneName()
	{
		return nextSceneName;
	}
}
