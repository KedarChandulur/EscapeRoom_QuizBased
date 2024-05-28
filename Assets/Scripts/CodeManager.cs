public class CodeManager
{
    private UnityEngine.GameObject codePreset;

    private TMPro.TMP_InputField codeInputField;

    private UnityEngine.UI.Button exitBuildingButton;

    private ushort code = 0;

    public static System.Action<bool> OnCodePanelExit;
    public static System.Action<string> OnCodeSet;

    public void Initialize(UnityEngine.Transform codePresetRef)
    {
        if (codePresetRef == null)
        {
            UnityEngine.Debug.LogError("Error setting the code preset.");

            GameManager.instance.QuitGame();
            return;
        }

        codePreset = codePresetRef.gameObject;

        if (!codePreset.transform.GetChild(1).TryGetComponent<TMPro.TMP_InputField>(out codeInputField))
        {
            UnityEngine.Debug.LogError("Error with the code inputfield.");

            GameManager.instance.QuitGame();
            return;
        }

        if (!codePreset.transform.GetChild(2).TryGetComponent<UnityEngine.UI.Button>(out exitBuildingButton))
        {
            UnityEngine.Debug.LogError("Error with the exit building button.");

            GameManager.instance.QuitGame();
            return;
        }

        exitBuildingButton.onClick.RemoveAllListeners();
        exitBuildingButton.onClick.AddListener(() =>
        {
            codeInputField.text.Trim();

            if (codeInputField.text == code.ToString())
            {
                OnCodePanelExit?.Invoke(true);
            }
            else
            {
                OnCodePanelExit?.Invoke(false);
            }

            this.Reset();
        } );

        this.Reset();
    }

    public void SetCode()
    {
        code = (ushort)UnityEngine.Random.Range(1000, 10000);

        UnityEngine.Debug.LogError(code);

        OnCodeSet?.Invoke(code.ToString());
    }

    public void OnDestroyCall()
    {
        exitBuildingButton.onClick.RemoveAllListeners();
    }

    public void ShowPanel()
    {
        this.Reset();

        codePreset.SetActive(true);
    }

    public bool IsShowingPanel()
    {
        return codePreset.activeSelf;
    }

    private void Reset()
    {
        codePreset.SetActive(false);
        codeInputField.text = string.Empty;
    }
}
