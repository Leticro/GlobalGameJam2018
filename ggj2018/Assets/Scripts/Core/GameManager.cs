using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = null;

    private SceneController sceneController;
    private DialogueController dialogueController;

   // public AudioSource soundManager; //thing that managers sound
    /// </summary>
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

       // DontDestroyOnLoad(soundManager.gameObject);

        InitScene();
	}
	
    private void InitScene()
    {
        sceneController = FindObjectOfType<SceneController>();
        dialogueController = FindObjectOfType<DialogueController>();
        if(sceneController) StartSequence(sceneController.sectionName);
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
        sceneController.gameObject.SetActive(false);
        //DisplayNextScene
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
