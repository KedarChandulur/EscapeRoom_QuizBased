public class CursorStateTracker
{
    UnityEngine.GameObject dotCursor;
    bool canRotate;

    public void Initialize(UnityEngine.Transform dotCursorRef)
    {
        if (dotCursorRef == null)
        {
            UnityEngine.Debug.LogError("Error setting the cursor.");

            GameManager.QuitGame();
            return;
        }

        dotCursor = dotCursorRef.gameObject;
        UpdateCursorState(false);
    }

    public void FrameUpdate()
    {
        if (UnityEngine.Input.GetMouseButtonDown(1))
        {
            UpdateCursorState(!canRotate);
        }
    }

    private void UpdateCursorState(bool value)
    {
        canRotate = value;

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
