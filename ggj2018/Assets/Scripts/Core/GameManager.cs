using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = null;

    public ScrollingDialogue selectionButton;
	public ScrollingDialogue outcomeButton;
    public CardManager cardManager;
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

        if (cardManager == null)
            cardManager = FindObjectOfType<CardManager>();
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
        if(cardManager)
        {
            Debug.Log("Starting Turn");
            StartTurn();
        }
        else if(sceneController.sectionName=="intro")
        {
            SceneManager.LoadScene("sc1_hub_1");
        }
        else
        {
            Debug.Log("Null Card Manager");
        }
	}

	public void StartTurn()
	{
        cardManager.drawHand();
    }

    public void DisplayTurnText(string turnText)
    {
        Debug.Log(turnText + "should be displayed!");
    }

    public void DisplaySelectionText(string selectText)
    {
        selectionButton.gameObject.SetActive(true);
        Debug.Log(selectText + "should be displayed");
        selectionButton.InitDialogue(selectText);
        selectionButton.gameObject.SetActive(true);
    }

    public void DisplayOutcomeText()
    {
        string outcomeText = sceneData.GetOutcomeText(cardManager.GetRouteChoiceId());
        selectionButton.gameObject.SetActive(false);
        Debug.Log(outcomeText + "should be displayed");
        outcomeButton.InitDialogue(outcomeText);
        outcomeButton.gameObject.SetActive(true);
    }

    /*
	public void DisplayOutcome(int outcome)
	{
		outcomeId = outcome;
        DisplayOutcomeText(sceneData.GetOutcomeText(outcomeId));
	}
    */

	public void ExecOutcome()
	{
        Debug.Log("trying to load");
        //cardManager.loadNextScene();
        SceneManager.LoadScene(cardManager.getSceneName());
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
