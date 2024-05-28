public class CursorStateTracker
{
    QuestionManager questionManager;
    UnityEngine.GameObject dotCursor;
    bool canRotate;
    bool cursorUpdated;

    public void Initialize(UnityEngine.Transform dotCursorRef, QuestionManager _questionManager)
    {
        if (dotCursorRef == null || _questionManager == null)
        {
            UnityEngine.Debug.LogError("Error in cursor init.");

            GameManager.QuitGame();
            return;
        }

        dotCursor = dotCursorRef.gameObject;
        questionManager = _questionManager;

        UpdateCursorState(false);
        UpdateCursorUI();

        cursorUpdated = false;
    }

    public void FrameUpdate()
    {
        if(questionManager.IsShowingQuestion())
        {
            if(!cursorUpdated)
            {
                UpdateCursorState(false);
                UpdateCursorUI();
            }

            cursorUpdated = true;
        }
        else
        {
            if (UnityEngine.Input.GetMouseButtonDown(1))
            {
                UpdateCursorState(!canRotate);

                cursorUpdated = false;
            }

            UpdateCursorUI();
        }
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
