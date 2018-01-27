using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
   
    public ScrollingDialogue dialogue;

    private string sectionName = "Intro";
    private int textCount = 10;
    private int textIndex = 0;

    public void StartScene(string sceneName)
    {
        sectionName = sceneName+"-Text";
        textIndex = 0;
        textCount = INIParser.IniSectionCount(sectionName);
        dialogue.InitDialogue(INIParser.IniReadValue(sectionName, GetSectionKey()));
        
    }

    public bool NextSection()
    {
        if(++textIndex < textCount)
        {
            string txt = INIParser.IniReadValue(sectionName, GetSectionKey());
            if (txt == null || txt.Length < 2)
                txt = "There was an error finding the dialogue.";
            dialogue.AddDialogue(txt);
            return true;
        }
        return false;
    }

    private string GetSectionKey()
    {
        return "text_" + textIndex;
    }
}
