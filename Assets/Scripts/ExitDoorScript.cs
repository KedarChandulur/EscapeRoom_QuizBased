using System;
using System.Collections;
using UnityEngine;

public class ExitDoorScript : Openable
{
    public static Action ShowCodePanel;
    [SerializeField]
    private string openAnimName = "";
    [SerializeField]
    private string closeAnimName = "";
    [SerializeField]
    private bool canOpen = false;

    void Start()
    {
        CodeManager.OnCodePanelExit += OnCodePanelExit;
        base.Setup(15.0f);
    }

    private void OnDestroy()
    {
        CodeManager.OnCodePanelExit -= OnCodePanelExit;
    }

    protected override void ProcessOpenable()
    {
        if (canOpen)
        {
            base.ProcessOpenable();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ShowCodePanel?.Invoke();
            }
        }
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

    private void OnCodePanelExit(bool value)
    {
        this.canOpen = value;
    }
}
