using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = null;

    private SceneController sceneController;
    private DialogueController dialogueController;
	private SceneData sceneData;

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
        
        //DontDestroyOnLoad(gameObject);

       // DontDestroyOnLoad(soundManager.gameObject);

        InitScene();
	}
	
    private void InitScene()
    {
        sceneController = FindObjectOfType<SceneController>();
        dialogueController = FindObjectOfType<DialogueController>();
		if (sceneController) 
		{
			StartSequence (sceneController.GetSequenceName ());
		}
			
    }

    public void StartSequence(string sequenceName)
    {
		sceneData = JSONParser.GetSceneData (sequenceName);
		if (sceneData == null) {
			Debug.Log ("No scene data found!");
			return;
		}
        dialogueController.StartSequence(sceneData.text);
        sceneController.StartSequence(sceneData);
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
		StartNextPhase();
        //DisplayNextScene
    }

	private void StartNextPhase()
	{
		SceneAction nextAction = sceneData.GetNextAction ();
		if (nextAction == SceneAction.LoadScene) {
			SceneManager.LoadScene (sceneData.GetNextSceneName ());
		} else if (nextAction == SceneAction.MainMenu) {
			SceneManager.LoadScene ("main");
		} else if (nextAction == SceneAction.StartTurn) {
			Debug.Log ("Starting Turn!");
		}
	}

    public void StartGame()
    {
        SceneManager.LoadScene("intro");
    }

	public void ExitGame()
	{
		Application.Quit ();
	}
}
