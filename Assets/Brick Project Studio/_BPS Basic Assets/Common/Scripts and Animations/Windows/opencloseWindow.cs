using System.Collections;
using UnityEngine;

public class opencloseWindow : Openable
{
    void Start()
    {
        base.Setup(15.0f);
    }

    protected override IEnumerator OpenAnim()
    {
        base.PlayAnimation("Openingwindow");
        yield return new WaitForSeconds(.5f);
    }

    protected override IEnumerator CloseAnim()
    {
        base.PlayAnimation("Closingwindow");
        yield return new WaitForSeconds(.5f);
    }
}