using System.Collections;
using UnityEngine;

public class TableFlipR : Openable
{
    void Start()
    {
        base.Setup(15.0f);
    }

    protected override IEnumerator OpenAnim()
    {
        base.PlayAnimation("Rup");
        yield return new WaitForSeconds(.5f);
    }

    protected override IEnumerator CloseAnim()
    {
        base.PlayAnimation("Rdown");
        yield return new WaitForSeconds(.5f);
    }
}