using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    private Button retryButton;
    private Button quitButton;

    void Start()
    {
        if(this.transform.childCount != 2)
        {
            Debug.LogError("Error with the end UI setup");

            GameManager.QuitGame();
            return;
        }

        if(!this.transform.GetChild(0).TryGetComponent<Button>(out retryButton))
        {
            Debug.LogError("Error with the retry button setup");

            GameManager.QuitGame();
            return;
        }

        if (!this.transform.GetChild(1).TryGetComponent<Button>(out quitButton))
        {
            Debug.LogError("Error with the quit button setup");

            GameManager.QuitGame();
            return;
        }

        retryButton.onClick.RemoveAllListeners();
        retryButton.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));

        quitButton.onClick.RemoveAllListeners();
        quitButton.onClick.AddListener(() => GameManager.QuitGame());
    }

    void OnDestroy()
    {
        retryButton.onClick.RemoveAllListeners();
        quitButton.onClick.RemoveAllListeners();
    }
}
