using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = null;

    private SceneController sceneController;
    private DialogueController dialogueController;

    // Use this for initialization
	void Awake ()
    {
	    if(_instance == null)
        {
            _instance = this;
        }	
        else if(_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        InitScene();
	}
	
    private void InitScene()
    {
        sceneController = FindObjectOfType<SceneController>();
        dialogueController = FindObjectOfType<DialogueController>();
        StartSequence(sceneController.sectionName);
    }

    public void StartSequence(string sequenceName)
    {
        dialogueController.StartScene(sequenceName);
        sceneController.StartScene(sequenceName);
    }

    public void NextSection()
    {
        sceneController.NextSection();
        if (!dialogueController.NextSection())
            OnDialogueComplete();
    }

    private void OnDialogueComplete()
    {
        dialogueController.gameObject.SetActive(false);
        //DisplayNextScene
    }



	// Update is called once per frame
	void Update () {
		
	}
}
