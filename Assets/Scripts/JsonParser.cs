using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class Response
{
    public int response_code;
    public List<Question> results;
}

[Serializable]
public class Question
{
    public string category;
    public string type;
    public string difficulty;
    public string question;
    public string correct_answer;
    public List<string> incorrect_answers;
}

public class JsonParser
{
    Response currentResponse = new Response();
    private string url = "https://opentdb.com/api.php?amount=10&category=27";

    public System.Collections.IEnumerator FetchData()
    {
        using (UnityEngine.Networking.UnityWebRequest webRequest = UnityEngine.Networking.UnityWebRequest.Get(this.url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityEngine.Networking.UnityWebRequest.Result.ConnectionError || webRequest.result == UnityEngine.Networking.UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Error: {webRequest.error}");
            }
            else
            {
                HandleResponse(webRequest.downloadHandler.text);
            }
        }
    }

    void HandleResponse(string jsonResponse)
    {
        try
        {
            currentResponse = JsonUtility.FromJson<Response>(jsonResponse);

            if (currentResponse == null || currentResponse.results == null)
            {
                Debug.LogError("Response or results are null.");
                return;
            }

            foreach (var question in currentResponse.results)
            {
                if (question.incorrect_answers == null)
                {
                    question.incorrect_answers = new List<string>();
                }

                // Log or handle the questions as needed
                Debug.Log($"Category: {question.category}");
                Debug.Log($"Type: {question.type}");
                Debug.Log($"Difficulty: {question.difficulty}");
                Debug.Log($"Question: {question.question}");
                Debug.Log($"Correct Answer: {question.correct_answer}");
                Debug.Log($"Incorrect Answers: {string.Join(", ", question.incorrect_answers)}");
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Exception during JSON deserialization: {e.Message}");
        }
    }

    public void SetURL(string _url)
    {
        this.url = _url;
    }
}