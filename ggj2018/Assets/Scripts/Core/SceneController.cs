using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public string sectionName = "Intro";
    public Image image;
    public Sprite[] sprites;
	private SceneData data;
	private int imageIndex;

	public void StartSequence(SceneData data)
    {
		this.data = data;
		if (data == null) 
		{
			Debug.Log ("No Scene Data Found!");
			return;
		}
		imageIndex = -1;
        NextSection();
    }

    public bool NextSection()
    {
		imageIndex++;
		int nextId = data.GetSpriteIndex (imageIndex);
		if (nextId!=-1)
        {
            image.sprite = sprites[nextId];
            return true;
        }
        return false;
    }

	public string GetSequenceName()
	{
		return sectionName;
	}
}
