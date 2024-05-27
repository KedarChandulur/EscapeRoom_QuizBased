using System.Collections;
using UnityEngine;

public class opencloseWindow1 : Openable
{
    void Start()
    {
        base.Setup(15.0f);
    }

    protected override IEnumerator OpenAnim()
    {
        base.PlayAnimation("Openingwindow 1");
        yield return new WaitForSeconds(.5f);
    }

    protected override IEnumerator CloseAnim()
    {
        base.PlayAnimation("Closingwindow 1");
        yield return new WaitForSeconds(.5f);
    }
}