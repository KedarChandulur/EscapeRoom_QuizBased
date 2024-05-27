using System.Collections;
using UnityEngine;

public class ClosetopencloseDoor : Openable
{
    void Start()
    {
        base.Setup(15.0f);
    }

    protected override IEnumerator OpenAnim()
    {
        base.PlayAnimation("ClosetOpening");
        yield return new WaitForSeconds(.5f);
    }

    protected override IEnumerator CloseAnim()
    {
        base.PlayAnimation("ClosetClosing");
        yield return new WaitForSeconds(.5f);
    }
}