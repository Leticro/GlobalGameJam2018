using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingDialogue : MonoBehaviour
{
    
    public string dialogue;
    public int charsPerSec = 8;
    public Text text;

    private int dialogueIndex = 0;
    private float timer;
    private float charRate;

	// Use this for initialization
	void Start ()
    {

	}

    private void Awake()
    {
        dialogueIndex = 0;
        timer = 0f;
        charRate = 1f/charsPerSec;
    }

    // Update is called once per frame
    void Update ()
    {
        if (dialogueIndex < dialogue.Length - 1)
        {
            timer += Time.deltaTime;
            if (timer >= charRate)
            {
                text.text = dialogue.Substring(0, ++dialogueIndex);
                timer -= charRate;
            }
        }		
	}

}
