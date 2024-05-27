using System.Collections;
using UnityEngine;

public class Drawer_Pull_Z : Openable
{
    void Start()
    {
        base.Setup(10.0f);
    }

    protected override IEnumerator OpenAnim()
    {
        base.PlayAnimation("openpull");
        yield return new WaitForSeconds(.5f);
    }

    protected override IEnumerator CloseAnim()
    {
        base.PlayAnimation("closepush");
        yield return new WaitForSeconds(.5f);
    }
}