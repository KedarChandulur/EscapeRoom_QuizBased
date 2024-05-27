using System.Collections;
using UnityEngine;

public class opencloseStallDoor : Openable
{
    void Start()
    {
        base.Setup(15.0f);
    }

    protected override IEnumerator OpenAnim()
    {
        base.PlayAnimation("OpeningStall");
        yield return new WaitForSeconds(.5f);
    }

    protected override IEnumerator CloseAnim()
    {
        base.PlayAnimation("ClosingStall");
        yield return new WaitForSeconds(.5f);
    }
}