using System.Collections;
using UnityEngine;

public class TableFlipL : Openable
{
    void Start()
    {
        base.Setup(15.0f);
    }

    protected override IEnumerator OpenAnim()
    {
        base.PlayAnimation("Lup");
        yield return new WaitForSeconds(.5f);
    }

    protected override IEnumerator CloseAnim()
    {
        base.PlayAnimation("Ldown");
        yield return new WaitForSeconds(.5f);
    }
}