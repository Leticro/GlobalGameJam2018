using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public string sectionName = "Intro";
    public Image _image;
    public Sprite[] sprites;

    private int sceneIndex = 0;
    private int sceneCount = 0;

    public void StartScene(string sceneName)
    {
        sectionName = sceneName+"-Image";
        sceneIndex = -1;
        sceneCount = INIParser.IniSectionCount(sectionName);
        NextSection();
    }

    public bool NextSection()
    {
        if (++sceneIndex < sceneCount)
        {
            string txt = INIParser.IniReadValue(sectionName, GetSectionKey());
            if (txt == null)
                txt = "0";
            sceneIndex = Int32.Parse(txt);

            if (sceneIndex < 0 || sceneIndex >= sprites.Length)
                return false;

            _image.sprite = sprites[sceneIndex];
            return true;
        }
        return false;
    }

    private string GetSectionKey()
    {
        return "scene_" + sceneIndex;
    }
}
