using UnityEngine;

public class UIManager : MonoBehaviour
{
    private TMPro.TextMeshProUGUI triesText;

    private CursorStateTracker cursorStateTracker = new CursorStateTracker();
    private QuestionManager questionManager = new QuestionManager();
    private CodeManager codeManager = new CodeManager();
    private YouWinScreen youWinScreen = new YouWinScreen();

    private void Awake()
    {
        if(this.transform.childCount != 5)
        {
            Debug.LogError("Is the UI setup Correctly?");

            GameManager.instance.QuitGame();
            return;
        }

        if(!this.transform.GetChild(2).TryGetComponent<TMPro.TextMeshProUGUI>(out triesText))
        {
            Debug.LogError("Tries Text didn't set correctly?");

            GameManager.instance.QuitGame();
            return;
        }

        youWinScreen.Initialize(this.transform.GetChild(4));
        codeManager.Initialize(this.transform.GetChild(3));
        questionManager.Initialize(this.transform.GetChild(1), this);
        cursorStateTracker.Initialize(this.transform.GetChild(0), questionManager, codeManager);

        InnerExitDoorScript.ShowQuestion += ShowQuestion;
        ExitDoorScript.ShowCodePanel += ShowCodePanel;
        ExitTrigger.OnPlayerWin += OnPlayerWin;
    }

    private void Start()
    {
        codeManager.SetCode();
    }

    private void OnDestroy()
    {
        youWinScreen.OnDestroyCall();
        codeManager.OnDestroyCall();
        questionManager.OnDestroyCall();
        cursorStateTracker.OnDestoryCall();

        InnerExitDoorScript.ShowQuestion -= ShowQuestion;
        ExitDoorScript.ShowCodePanel -= ShowCodePanel;
        ExitTrigger.OnPlayerWin -= OnPlayerWin;
    }

    private void OnPlayerWin()
    {
        youWinScreen.ShowPanel();
    }

    private void ShowQuestion(int instanceID)
    {
        questionManager.ShowQuestion(GameManager.instance.GetQuestion(), instanceID);
    }

    private void ShowCodePanel()
    {
        codeManager.ShowPanel();
    }

    private void Update()
    {
        cursorStateTracker.FrameUpdate();
    }

    public void UpdateTriesText(ushort numberOfLives)
    {
        this.triesText.text = "Tries: " + numberOfLives;
    }
}
