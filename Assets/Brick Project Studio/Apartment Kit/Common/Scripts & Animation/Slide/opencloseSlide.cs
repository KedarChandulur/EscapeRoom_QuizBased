using System.Collections;
using UnityEngine;

public class opencloseSlide : Openable
{
    void Start()
    {
        base.Setup(15.0f);
    }

    protected override IEnumerator OpenAnim()
    {
        base.PlayAnimation("OpeningSlide");
        yield return new WaitForSeconds(.5f);
    }

    protected override IEnumerator CloseAnim()
    {
        base.PlayAnimation("ClosingSlide");
        yield return new WaitForSeconds(.5f);
    }
}