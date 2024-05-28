using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class CodeParts : MonoBehaviour
{
    private static System.Collections.Generic.List<CodeParts> parts = new System.Collections.Generic.List<CodeParts>(4);

    private void Awake()
    {
        parts.Add(this);

        CodeManager.OnCodeSet += OnCodeSet;
    }

    private void OnDestroy()
    {
        CodeManager.OnCodeSet -= OnCodeSet;
    }

    private void OnCodeSet(string code)
    {
        int index = parts.IndexOf(this);

        this.GetComponent<TextMeshPro>().text = code[index].ToString();
    }
}
