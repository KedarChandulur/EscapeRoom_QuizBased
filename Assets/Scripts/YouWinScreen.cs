public class YouWinScreen
{
    private UnityEngine.GameObject youWinPanel;

    public UnityEngine.UI.Button playagainButton;
    public UnityEngine.UI.Button quitGameButton;

    public void Initialize(UnityEngine.Transform youWinPanelRef)
    {
        if (youWinPanelRef == null)
        {
            UnityEngine.Debug.LogError("Error setting the you win panel.");

            GameManager.instance.QuitGame();
            return;
        }

        youWinPanel = youWinPanelRef.gameObject;

        if (youWinPanel.transform.childCount != 3)
        {
            UnityEngine.Debug.LogError("Error with the you win panel child count.");

            GameManager.instance.QuitGame();
            return;
        }

        if (!youWinPanel.transform.GetChild(1).TryGetComponent<UnityEngine.UI.Button>(out playagainButton))
        {
            UnityEngine.Debug.LogError("Error with the play again button.");

            GameManager.instance.QuitGame();
            return;
        }

        if (!youWinPanel.transform.GetChild(2).TryGetComponent<UnityEngine.UI.Button>(out quitGameButton))
        {
            UnityEngine.Debug.LogError("Error with the quit button.");

            GameManager.instance.QuitGame();
            return;
        }

        playagainButton.onClick.RemoveAllListeners();
        playagainButton.onClick.AddListener(() => { this.HidePanel(); UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene"); } );

        quitGameButton.onClick.RemoveAllListeners();
        quitGameButton.onClick.AddListener(() => { this.HidePanel(); GameManager.instance.QuitGame(); } );

        this.HidePanel();
    }

    public void OnDestroyCall()
    {
        playagainButton.onClick.RemoveAllListeners();
        quitGameButton.onClick.RemoveAllListeners();
    }

    public void ShowPanel()
    {
        this.youWinPanel.SetActive(true);
    }

    public void HidePanel()
    {
        this.youWinPanel.SetActive(false);
    }
}
