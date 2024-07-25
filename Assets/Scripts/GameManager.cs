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

        jsonParser.Initialize();

        SceneManager.activeSceneChanged += OnSceneChanged;
        LivesManager.AllLivesEndEvent += AllLivesEndEvent;
    }

    private void OnDestroy()
    {
        jsonParser.OnDestroyCall();

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

    public void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }

    private void AllLivesEndEvent()
    {
        Debug.LogError("Game Over");
        SceneManager.LoadScene("EndGame");
    }

    public Question GetQuestion()
    {
        return jsonParser.GetQuestion();
    }

    public void UpdateAPI(string value)
    {
        jsonParser.SetURL(value);
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
}