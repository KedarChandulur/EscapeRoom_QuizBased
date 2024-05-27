using System.Collections;
using UnityEngine;

public class BRGlassDoor : Openable
{
    void Start()
    {
        base.Setup(15.0f);
    }

    protected override IEnumerator OpenAnim()
    {
        base.PlayAnimation("BRGlassDoorOpen");
        yield return new WaitForSeconds(.5f);
    }

    protected override IEnumerator CloseAnim()
    {
        base.PlayAnimation("BRGlassDoorClose");
        yield return new WaitForSeconds(.5f);
    }
}