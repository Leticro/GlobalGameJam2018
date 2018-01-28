using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = null;

	public ScrollingDialogue outcomeButton;
    private SceneController sceneController;
    private DialogueController dialogueController;
	private SceneData sceneData;

	private int outcomeId = 0;

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
		DisplayOutcome (0);
	}


	public void StartTurn()
	{
		
	}

	public void DisplayOutcome(int outcome)
	{
		outcomeId = outcome;
		outcomeButton.InitDialogue (sceneData.GetOutcomeText (outcomeId));
		outcomeButton.gameObject.SetActive (true);
	}

	public void ExecOutcome()
	{
		SceneManager.LoadScene (sceneData.GetOutcomeScene (outcomeId));
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
