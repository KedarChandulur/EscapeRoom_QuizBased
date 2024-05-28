using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    private Button startGameButton;
    private Button quitButton;

    void Start()
    {
        if (this.transform.childCount != 2)
        {
            Debug.LogError("Error with the end UI setup");

            GameManager.QuitGame();
            return;
        }

        if (!this.transform.GetChild(0).TryGetComponent<Button>(out startGameButton))
        {
            Debug.LogError("Error with the start button setup");

            GameManager.QuitGame();
            return;
        }

        if (!this.transform.GetChild(1).TryGetComponent<Button>(out quitButton))
        {
            Debug.LogError("Error with the quit button setup");

            GameManager.QuitGame();
            return;
        }

        startGameButton.onClick.RemoveAllListeners();
        startGameButton.onClick.AddListener(() => SceneManager.LoadScene("MainScene"));

        quitButton.onClick.RemoveAllListeners();
        quitButton.onClick.AddListener(() => GameManager.QuitGame());
    }

    void OnDestroy()
    {
        startGameButton.onClick.RemoveAllListeners();
        quitButton.onClick.RemoveAllListeners();
    }
}
