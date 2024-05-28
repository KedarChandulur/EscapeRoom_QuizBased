using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    private Button generalKnowledge;
    [SerializeField]
    private Button animals;
    [SerializeField]
    private Button books;
    [SerializeField]
    private Button flim;
    [SerializeField]
    private Button music;
    [SerializeField]
    private Button musicals_Theatres;
    [SerializeField]
    private Button television;
    [SerializeField]
    private Button videogames;
    [SerializeField]
    private Button boardgames;
    [SerializeField]
    private Button science_Nature;
    [SerializeField]
    private Button computers;
    [SerializeField]
    private Button mathematics;
    [SerializeField]
    private Button mythology;
    [SerializeField]
    private Button sports;
    [SerializeField]
    private Button geography;
    [SerializeField]
    private Button history;
    [SerializeField]
    private Button politics;
    [SerializeField]
    private Button art;
    [SerializeField]
    private Button celebrities;

    [SerializeField]
    private GameObject secondPanel;

    [SerializeField]
    private GameObject firstPanel;

    [SerializeField]
    private Button back;

    [SerializeField]
    private Button startGameButton;

    [SerializeField]
    private Button quitButton;

    void Start()
    {
        startGameButton.onClick.RemoveAllListeners();
        startGameButton.onClick.AddListener(() => { firstPanel.SetActive(false); secondPanel.SetActive(true); });

        back.onClick.RemoveAllListeners();
        back.onClick.AddListener(() => { secondPanel.SetActive(false); firstPanel.SetActive(true); });

        quitButton.onClick.RemoveAllListeners();
        quitButton.onClick.AddListener(() => GameManager.instance.QuitGame());

        generalKnowledge.onClick.RemoveAllListeners();
        generalKnowledge.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=9"); SceneManager.LoadScene("MainScene"); });

        animals.onClick.RemoveAllListeners();
        animals.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=27"); SceneManager.LoadScene("MainScene"); });

        books.onClick.RemoveAllListeners();
        books.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=10"); SceneManager.LoadScene("MainScene"); });

        flim.onClick.RemoveAllListeners();
        flim.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=11"); SceneManager.LoadScene("MainScene"); });

        music.onClick.RemoveAllListeners();
        music.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=12"); SceneManager.LoadScene("MainScene"); });

        musicals_Theatres.onClick.RemoveAllListeners();
        musicals_Theatres.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=13"); SceneManager.LoadScene("MainScene"); });

        television.onClick.RemoveAllListeners();
        television.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=14"); SceneManager.LoadScene("MainScene"); });

        videogames.onClick.RemoveAllListeners();
        videogames.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=15"); SceneManager.LoadScene("MainScene"); });

        boardgames.onClick.RemoveAllListeners();
        boardgames.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=16"); SceneManager.LoadScene("MainScene"); });

        science_Nature.onClick.RemoveAllListeners();
        science_Nature.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=17"); SceneManager.LoadScene("MainScene"); });

        computers.onClick.RemoveAllListeners();
        computers.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=18"); SceneManager.LoadScene("MainScene"); });

        mathematics.onClick.RemoveAllListeners();
        mathematics.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=19"); SceneManager.LoadScene("MainScene"); });

        mythology.onClick.RemoveAllListeners();
        mythology.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=20"); SceneManager.LoadScene("MainScene"); });

        sports.onClick.RemoveAllListeners();
        sports.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=21"); SceneManager.LoadScene("MainScene"); });

        geography.onClick.RemoveAllListeners();
        geography.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=22"); SceneManager.LoadScene("MainScene"); });

        history.onClick.RemoveAllListeners();
        history.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=23"); SceneManager.LoadScene("MainScene"); });

        politics.onClick.RemoveAllListeners();
        politics.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=24"); SceneManager.LoadScene("MainScene"); });

        art.onClick.RemoveAllListeners();
        art.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=25"); SceneManager.LoadScene("MainScene"); });

        celebrities.onClick.RemoveAllListeners();
        celebrities.onClick.AddListener(() => { GameManager.instance.UpdateAPI("https://opentdb.com/api.php?amount=10&category=26"); SceneManager.LoadScene("MainScene"); });

        secondPanel.SetActive(false); 
        firstPanel.SetActive(true);
    }

    void OnDestroy()
    {
        startGameButton.onClick.RemoveAllListeners();
        back.onClick.RemoveAllListeners();
        quitButton.onClick.RemoveAllListeners();

        generalKnowledge.onClick.RemoveAllListeners();
        animals.onClick.RemoveAllListeners();
        books.onClick.RemoveAllListeners();
        flim.onClick.RemoveAllListeners();
        music.onClick.RemoveAllListeners();
        musicals_Theatres.onClick.RemoveAllListeners();
        television.onClick.RemoveAllListeners();
        videogames.onClick.RemoveAllListeners();
        boardgames.onClick.RemoveAllListeners();
        science_Nature.onClick.RemoveAllListeners();
        computers.onClick.RemoveAllListeners();
        mathematics.onClick.RemoveAllListeners();
        mythology.onClick.RemoveAllListeners();
        sports.onClick.RemoveAllListeners();
        geography.onClick.RemoveAllListeners();
        history.onClick.RemoveAllListeners();
        politics.onClick.RemoveAllListeners();
        art.onClick.RemoveAllListeners();
        celebrities.onClick.RemoveAllListeners();
    }
}
