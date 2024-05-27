using System.Collections;
using UnityEngine;

public class opencloseDoor1 : Openable
{
    void Start()
    {
        base.Setup(15.0f);
    }

    protected override IEnumerator OpenAnim()
    {
        base.PlayAnimation("Opening 1");
        yield return new WaitForSeconds(.5f);
    }

    protected override IEnumerator CloseAnim()
    {
        base.PlayAnimation("Closing 1");
        yield return new WaitForSeconds(.5f);
    }
}