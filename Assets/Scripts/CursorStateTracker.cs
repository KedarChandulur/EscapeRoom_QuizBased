public class CursorStateTracker
{
    QuestionManager questionManager;
    CodeManager codeManager;
    UnityEngine.GameObject dotCursor;
    bool canRotate;
    bool cursorUpdated;

    public void Initialize(UnityEngine.Transform dotCursorRef, QuestionManager _questionManager, CodeManager _codeManager)
    {
        if (dotCursorRef == null || _questionManager == null || _codeManager == null)
        {
            UnityEngine.Debug.LogError("Error in cursor init.");

            GameManager.instance.QuitGame();
            return;
        }

        dotCursor = dotCursorRef.gameObject;
        questionManager = _questionManager;
        codeManager = _codeManager;

        UpdateCursorStateAndUI(false);

        cursorUpdated = false;

        QuestionManager.OnQuestionExit += OnQuestionExit;
        CodeManager.OnCodePanelExit += OnCodePanelExit;
    }

    public void OnDestoryCall()
    {
        QuestionManager.OnQuestionExit -= OnQuestionExit;
        CodeManager.OnCodePanelExit -= OnCodePanelExit;
    }

    public void FrameUpdate()
    {
        if(questionManager.IsShowingQuestion() || codeManager.IsShowingPanel())
        {
            if(!cursorUpdated)
            {
                UpdateCursorStateAndUI(false);
            }

            cursorUpdated = true;
        }
        else
        {
            if (UnityEngine.Input.GetMouseButtonDown(1))
            {
                UpdateCursorStateAndUI(!canRotate);
            }
        }
    }

    private void OnQuestionExit(int instanceID, Question question, bool questionCorrect)
    {
        cursorUpdated = false;

        UpdateCursorStateAndUI(true);
    }

    private void OnCodePanelExit(bool value)
    {
        UpdateCursorStateAndUI(true);

        cursorUpdated = false;
    }

    private void UpdateCursorStateAndUI(bool value)
    {
        UpdateCursorState(value);
        UpdateCursorUI();
    }

    private void UpdateCursorState(bool value)
    {
        canRotate = value;
    }

    private void UpdateCursorUI()
    {
        if (canRotate)
        {
            UnityEngine.Cursor.lockState = UnityEngine.CursorLockMode.Locked;
            dotCursor.SetActive(canRotate);
        }
        else
        {
            UnityEngine.Cursor.lockState = UnityEngine.CursorLockMode.None;
            dotCursor.SetActive(canRotate);
        }
    }
}
