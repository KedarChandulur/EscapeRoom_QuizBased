using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InstantiateGameManager()
    {
        if(instance == null)
        {
            GameObject gameManagerObject = new GameObject("GameManager");
            gameManagerObject.AddComponent<GameManager>();

            gameManagerObject.AddComponent<JsonParser>();

            gameManagerObject.tag = "GameController";
            DontDestroyOnLoad(gameManagerObject);
        }
    }

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
    }

//    void Update()
//    {
////        if(Input.GetKeyDown(KeyCode.Escape)) 
////        {
////#if UNITY_EDITOR
////            //UnityEditor.EditorApplication.ExitPlaymode();
////#else
////            Application.Quit();
////#endif
////        }
//    }
}