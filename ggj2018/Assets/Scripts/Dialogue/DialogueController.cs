using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
   
    public ScrollingDialogue dialogue;
	private string[] textArr;
    private int textIndex = 0;

	public void StartSequence(string[] textSeq)
    {
		textArr = textSeq;    
        textIndex = 0;
		dialogue.InitDialogue(textArr[textIndex]);
    }

    public bool NextSection()
    {
		textIndex++;
		if(textIndex < textArr.Length)
        {
			dialogue.AddDialogue(textArr[textIndex]);
            return true;
        }
        return false;
    }
}
