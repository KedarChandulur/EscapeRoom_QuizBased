using System.Collections;
using UnityEngine;

public class opencloseDoor : Openable
{
    [SerializeField]
    private bool canOpen = true;

    void Start()
    {
        base.Setup(15.0f);
    }

    protected override bool IsEligibleToOpen()
    {
        return canOpen;
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