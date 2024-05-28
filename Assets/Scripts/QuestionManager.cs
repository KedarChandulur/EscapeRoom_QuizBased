public class QuestionManager
{
    private UnityEngine.GameObject questionPreset;

    private TMPro.TextMeshProUGUI questionText;

    private UnityEngine.UI.Button firstButton;
    private TMPro.TextMeshProUGUI firstButtonText;

    private UnityEngine.UI.Button secondButton;
    private TMPro.TextMeshProUGUI secondButtonText;

    private UnityEngine.UI.Button thirdButton;
    private TMPro.TextMeshProUGUI thirdButtonText;

    private UnityEngine.UI.Button fourthButton;
    private TMPro.TextMeshProUGUI fourthButtonText;

    private UnityEngine.UI.Button closeButton;

    private readonly LivesManager livesManager = new LivesManager();

    public static System.Action<int, Question, bool> OnQuestionExit;

    private Question currentQuestion;
    private int currentInstanceID = 0;

    public void Initialize(UnityEngine.Transform questionPresetRef, UIManager uiManagerRef)
    {
        livesManager.Initialize(uiManagerRef);

        if (questionPresetRef == null)
        {
            UnityEngine.Debug.LogError("Error setting the question preset.");

            GameManager.instance.QuitGame();
            return;
        }

        questionPreset = questionPresetRef.gameObject;

        if(questionPreset.transform.childCount != 2)
        {
            UnityEngine.Debug.LogError("Error with the question preset child count.");

            GameManager.instance.QuitGame();
            return;
        }

        if(!questionPreset.transform.GetChild(0).TryGetComponent<TMPro.TextMeshProUGUI>(out questionText))
        {
            UnityEngine.Debug.LogError("Error with the question text.");

            GameManager.instance.QuitGame();
            return;
        }

        UnityEngine.Transform optionsTransform = questionPreset.transform.GetChild(1);

        if (optionsTransform.transform.childCount != 5)
        {
            UnityEngine.Debug.LogError("Error with the options Transform.");

            GameManager.instance.QuitGame();
            return;
        }

        if (!optionsTransform.transform.GetChild(0).TryGetComponent<UnityEngine.UI.Button>(out firstButton))
        {
            UnityEngine.Debug.LogError("Error with the first options button.");

            GameManager.instance.QuitGame();
            return;
        }

        if (!optionsTransform.transform.GetChild(1).TryGetComponent<UnityEngine.UI.Button>(out secondButton))
        {
            UnityEngine.Debug.LogError("Error with the second options button.");

            GameManager.instance.QuitGame();
            return;
        }

        if (!optionsTransform.transform.GetChild(2).TryGetComponent<UnityEngine.UI.Button>(out thirdButton))
        {
            UnityEngine.Debug.LogError("Error with the third options button.");

            GameManager.instance.QuitGame();
            return;
        }

        if (!optionsTransform.transform.GetChild(3).TryGetComponent<UnityEngine.UI.Button>(out fourthButton))
        {
            UnityEngine.Debug.LogError("Error with the fourth options button.");

            GameManager.instance.QuitGame();
            return;
        }

        if (!optionsTransform.transform.GetChild(4).TryGetComponent<UnityEngine.UI.Button>(out closeButton))
        {
            UnityEngine.Debug.LogError("Error with the close options button.");

            GameManager.instance.QuitGame();
            return;
        }

        closeButton.onClick.RemoveAllListeners();
        closeButton.onClick.AddListener(() => { this.ResetAndDecrementUI(false, false); });

        if (!firstButton.transform.GetChild(0).TryGetComponent<TMPro.TextMeshProUGUI>(out firstButtonText))
        {
            UnityEngine.Debug.LogError("Error setting the first button text.");

            GameManager.instance.QuitGame();
            return;
        }

        if (!secondButton.transform.GetChild(0).TryGetComponent<TMPro.TextMeshProUGUI>(out secondButtonText))
        {
            UnityEngine.Debug.LogError("Error setting the second button text.");

            GameManager.instance.QuitGame();
            return;
        }

        if (!thirdButton.transform.GetChild(0).TryGetComponent<TMPro.TextMeshProUGUI>(out thirdButtonText))
        {
            UnityEngine.Debug.LogError("Error setting the third button text.");

            GameManager.instance.QuitGame();
            return;
        }

        if (!fourthButton.transform.GetChild(0).TryGetComponent<TMPro.TextMeshProUGUI>(out fourthButtonText))
        {
            UnityEngine.Debug.LogError("Error setting the fourth button text.");

            GameManager.instance.QuitGame();
            return;
        }

        this.Reset();
    }

    public void OnDestroyCall()
    {
        this.Reset();
        closeButton.onClick.RemoveAllListeners();
    }

    public bool IsShowingQuestion()
    {
        return questionPreset.activeSelf;
    }

    public void ShowQuestion(Question questionRef, int instanceID)
    {
        this.Reset();

        if (questionRef == null)
        {
            UnityEngine.Debug.LogError("No question received.");

            GameManager.instance.QuitGame();
            return;
        }

        this.questionText.text = questionRef.question;

        if (questionRef.incorrect_answers.Count == 1)
        {
            firstButton.gameObject.SetActive(true);
            secondButton.gameObject.SetActive(true);

            Set2Questions(questionRef.correct_answer);
        }

        if(questionRef.incorrect_answers.Count == 3)
        {
            Set4Questions(questionRef);

            firstButton.gameObject.SetActive(true);
            secondButton.gameObject.SetActive(true);
            thirdButton.gameObject.SetActive(true);
            fourthButton.gameObject.SetActive(true);
        }

        questionPreset.SetActive(true);

        this.currentQuestion = questionRef;
        this.currentInstanceID = instanceID;
    }

    private void Set2Questions(string correct_answer)
    {
        if (correct_answer == "True")
        {
            // Correct Answer.
            firstButtonText.text = "True";
            firstButton.onClick.AddListener(() => { this.ResetAndDecrementUI(false, true); });

            // Wrong Answer.
            secondButtonText.text = "False";
            secondButton.onClick.AddListener(() => { this.ResetAndDecrementUI(true, false); });
        }
        else
        {
            // Wrong Answer.
            firstButtonText.text = "True";
            firstButton.onClick.AddListener(() => { this.ResetAndDecrementUI(true, false); });

            // Correct Answer.
            secondButtonText.text = "False";
            secondButton.onClick.AddListener(() => { this.ResetAndDecrementUI(false, true); });
        }
    }

    private void Set4Questions(Question question)
    {
        int randomValue = UnityEngine.Random.Range(1, 5);

        switch (randomValue)
        {
            case 1:
                firstButtonText.text = question.correct_answer;
                firstButton.onClick.AddListener(() => { this.ResetAndDecrementUI(false, true); });

                secondButtonText.text = question.incorrect_answers[0];
                secondButton.onClick.AddListener(() => { this.ResetAndDecrementUI(true, false); });

                thirdButtonText.text = question.incorrect_answers[1];
                thirdButton.onClick.AddListener(() => { this.ResetAndDecrementUI(true, false); });

                fourthButtonText.text = question.incorrect_answers[2];
                fourthButton.onClick.AddListener(() => { this.ResetAndDecrementUI(true, false); });

                break;

            case 2:
                firstButtonText.text = question.incorrect_answers[2];
                firstButton.onClick.AddListener(() => { this.ResetAndDecrementUI(true, false); });

                secondButtonText.text = question.correct_answer;
                secondButton.onClick.AddListener(() => { this.ResetAndDecrementUI(false, true); });

                thirdButtonText.text = question.incorrect_answers[0];
                thirdButton.onClick.AddListener(() => { this.ResetAndDecrementUI(true, false); });

                fourthButtonText.text = question.incorrect_answers[1];
                fourthButton.onClick.AddListener(() => { this.ResetAndDecrementUI(true, false); });

                break;
            case 3:
                firstButtonText.text = question.incorrect_answers[1];
                firstButton.onClick.AddListener(() => { this.ResetAndDecrementUI(true, false); });

                secondButtonText.text = question.incorrect_answers[2];
                secondButton.onClick.AddListener(() => { this.ResetAndDecrementUI(true, false); });

                thirdButtonText.text = question.correct_answer;
                thirdButton.onClick.AddListener(() => { this.ResetAndDecrementUI(false, true); });

                fourthButtonText.text = question.incorrect_answers[0];
                fourthButton.onClick.AddListener(() => { this.ResetAndDecrementUI(true, false); });

                break;

            case 4:
                firstButtonText.text = question.incorrect_answers[0];
                firstButton.onClick.AddListener(() => { this.ResetAndDecrementUI(true, false); });

                secondButtonText.text = question.incorrect_answers[1];
                secondButton.onClick.AddListener(() => { this.ResetAndDecrementUI(true, false); });

                thirdButtonText.text = question.incorrect_answers[2];
                thirdButton.onClick.AddListener(() => { this.ResetAndDecrementUI(true, false); });

                fourthButtonText.text = question.correct_answer;
                fourthButton.onClick.AddListener(() => { this.ResetAndDecrementUI(false, true); });

                break;

            default:
                UnityEngine.Debug.LogError("Some thing went wrong with random number selection.");

                GameManager.instance.QuitGame();
                break;
        }
    }

    private void Reset()
    {
        questionPreset.SetActive(false);

        questionText.text = string.Empty;

        firstButton.gameObject.SetActive(false);
        secondButton.gameObject.SetActive(false);
        thirdButton.gameObject.SetActive(false);
        fourthButton.gameObject.SetActive(false);

        firstButtonText.text = string.Empty;
        secondButtonText.text = string.Empty;
        thirdButtonText.text = string.Empty;
        fourthButtonText.text = string.Empty;

        firstButton.onClick.RemoveAllListeners();
        secondButton.onClick.RemoveAllListeners();
        thirdButton.onClick.RemoveAllListeners();
        fourthButton.onClick.RemoveAllListeners();
    }

    private void ResetAndDecrementUI(bool decrementTries, bool isSuccessful)
    {
        questionPreset.SetActive(false);

        questionText.text = string.Empty;

        firstButton.gameObject.SetActive(false);
        secondButton.gameObject.SetActive(false);
        thirdButton.gameObject.SetActive(false);
        fourthButton.gameObject.SetActive(false);

        firstButtonText.text = string.Empty;
        secondButtonText.text = string.Empty;
        thirdButtonText.text = string.Empty;
        fourthButtonText.text = string.Empty;

        firstButton.onClick.RemoveAllListeners();
        secondButton.onClick.RemoveAllListeners();
        thirdButton.onClick.RemoveAllListeners();
        fourthButton.onClick.RemoveAllListeners();

        if (decrementTries)
        {
            livesManager.DecrementLives();
        }

        OnQuestionExit?.Invoke(currentInstanceID, currentQuestion, isSuccessful);
    }
}
