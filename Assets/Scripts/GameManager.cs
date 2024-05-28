using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Response currentResponse = new Response();
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
        QuestionManager.OnQuestionCloseCallback += OnQuestionCloseCallback;
    }

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneChanged;
        LivesManager.AllLivesEndEvent -= AllLivesEndEvent;
        QuestionManager.OnQuestionCloseCallback -= OnQuestionCloseCallback;
    }

    private void OnSceneChanged(Scene arg0, Scene newSceneName)
    {
        if(newSceneName.buildIndex == 1)
        {
            StartCoroutine(jsonParser.FetchData(this.currentResponse));
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

    public Question GetQuestion()
    {
        int randomValue = UnityEngine.Random.Range(0, currentResponse.results.Count);
        return currentResponse.results[randomValue];
    }

    private void OnQuestionCloseCallback(Question question)
    {
        Debug.LogError(currentResponse.results.Count);

        currentResponse.results.Remove(question);

        Debug.LogError(currentResponse.results.Count);
    }
}