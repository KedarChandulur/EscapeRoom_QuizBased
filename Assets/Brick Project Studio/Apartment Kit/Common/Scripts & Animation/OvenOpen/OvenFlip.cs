using System.Collections;
using UnityEngine;

public class OvenFlip : Openable
{
    void Start()
    {
        base.Setup(15.0f);
    }

    protected override IEnumerator OpenAnim()
    {
        base.PlayAnimation("OpenOven");
        yield return new WaitForSeconds(.5f);
    }

    protected override IEnumerator CloseAnim()
    {
        base.PlayAnimation("ClosingOven");
        yield return new WaitForSeconds(.5f);
    }
}