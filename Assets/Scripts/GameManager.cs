using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private JsonParser jsonParser = new JsonParser();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
            return;
        }

        SceneManager.activeSceneChanged += OnSceneChanged;
        LivesManager.AllLivesEndEvent += AllLivesEndEvent;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
        LivesManager.AllLivesEndEvent -= AllLivesEndEvent;
    }

    private void OnSceneChanged(Scene arg0, Scene newSceneName)
    {
        if(newSceneName.buildIndex == 1)
        {
            StartCoroutine(jsonParser.FetchData());
        }
    }

    public static void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InstantiateGameManager()
    {
        if (instance == null)
        {
            GameObject gameManagerObject = new GameObject("GameManager");
            gameManagerObject.AddComponent<GameManager>();
            gameManagerObject.tag = "GameController";
            DontDestroyOnLoad(gameManagerObject);
        }
    }

    private void AllLivesEndEvent()
    {
        Debug.LogError("Game Over");
        SceneManager.LoadScene("EndGame");
    }
}