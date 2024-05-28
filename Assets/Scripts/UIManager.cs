using UnityEngine;

public class UIManager : MonoBehaviour
{
    private TMPro.TextMeshProUGUI triesText;

    private CursorStateTracker cursorStateTracker = new CursorStateTracker();
    private QuestionManager questionManager = new QuestionManager();

    private void Awake()
    {
        if(this.transform.childCount != 3)
        {
            Debug.LogError("Is the UI setup Correctly?");

            GameManager.QuitGame();
            return;
        }

        if(!this.transform.GetChild(2).TryGetComponent<TMPro.TextMeshProUGUI>(out triesText))
        {
            Debug.LogError("Tries Text didn't set correctly?");

            GameManager.QuitGame();
            return;
        }

        questionManager.Initialize(this.transform.GetChild(1), this);
        cursorStateTracker.Initialize(this.transform.GetChild(0), questionManager);

        InnerExitDoorScript.ShowQuestion += ShowQuestion;
    }

    private void OnDestroy()
    {
        questionManager.OnDestroyCall();

        InnerExitDoorScript.ShowQuestion -= ShowQuestion;
    }

    private void ShowQuestion(int instanceID)
    {
        questionManager.ShowQuestion(GameManager.instance.GetQuestion(), instanceID);
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
