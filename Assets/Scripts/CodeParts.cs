using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class CodeParts : MonoBehaviour
{
    [SerializeField]
    private ushort index = 0;

    private void Awake()
    {
        CodeManager.OnCodeSet += OnCodeSet;
    }

    private void OnDestroy()
    {
        CodeManager.OnCodeSet -= OnCodeSet;
    }

    private void OnCodeSet(string code)
    {
        this.GetComponent<TextMeshPro>().text = code[index].ToString();
    }
}
