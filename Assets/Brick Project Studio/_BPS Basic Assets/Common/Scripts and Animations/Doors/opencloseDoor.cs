using System.Collections;
using UnityEngine;

public class opencloseDoor : Openable
{
    void Start()
    {
        base.Setup(15.0f);
    }

    protected override IEnumerator OpenAnim()
    {
        base.PlayAnimation("Opening");
        yield return new WaitForSeconds(.5f);
    }

    protected override IEnumerator CloseAnim()
    {
        base.PlayAnimation("Closing");
        yield return new WaitForSeconds(.5f);
    }
}