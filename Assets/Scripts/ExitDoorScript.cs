using System.Collections;
using UnityEngine;

public class ExitDoorScript : Openable
{
    [SerializeField]
    private ExitDoorScript adjacentDoor;
    [SerializeField]
    private string openAnimName = "";
    [SerializeField]
    private string closeAnimName = "";
    [SerializeField]
    private bool canOpen = false;

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
        base.PlayAnimation(openAnimName);
        yield return new WaitForSeconds(.5f);
    }

    protected override IEnumerator CloseAnim()
    {
        base.PlayAnimation(closeAnimName);
        yield return new WaitForSeconds(.5f);
    }
}
