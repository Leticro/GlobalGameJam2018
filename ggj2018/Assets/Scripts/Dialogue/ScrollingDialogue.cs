using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingDialogue : MonoBehaviour
{

    public string dialogue = "";
    public int charsPerSec = 8;
    public int maxCharCount = 232;
    public Text text;

    private int dialogueIndex = 0;
    private float timer;
    private float charRate;
    private string oldText = "";
    private List<int> sectionLengths;
    // Update is called once per frame
    void Update()
    {
        if (dialogueIndex < dialogue.Length)
        {
            timer += Time.deltaTime;
            if (timer >= charRate)
            {
                text.text = oldText + dialogue.Substring(0, ++dialogueIndex);
                timer -= charRate;
            }
        }
    }

    public void InitDialogue(string newText)
    {
        sectionLengths = new List<int>();
        AddDialogue(newText);
    }

    public void AddDialogue(string newText)
    {
     
        sectionLengths.Add(newText.Length+2);
        if(dialogue.Length>0)
            oldText +=dialogue + "\n\n";
        while (oldText.Length + newText.Length > maxCharCount)
        {
            PushSection();
        }
        dialogue = newText;
        dialogueIndex = 0;
        timer = 0f;
        charRate = 1f / charsPerSec;
    }

    private void PushSection()
    {
        oldText = oldText.Substring(sectionLengths[0]);
        sectionLengths.RemoveAt(0);
    }
}
