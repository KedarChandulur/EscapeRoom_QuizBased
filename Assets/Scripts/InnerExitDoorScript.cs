using System;
using System.Collections;
using UnityEngine;

public class InnerExitDoorScript : Openable
{
    public static Action<int> ShowQuestion;
    [SerializeField]
    private bool canOpen = false;

    void Start()
    {
        QuestionManager.OnQuestionClose += SetIsOpenOnQuestionClose;
        base.Setup(15.0f);
    }

    private void OnDestroy()
    {
        QuestionManager.OnQuestionClose -= SetIsOpenOnQuestionClose;
    }

    protected override void ProcessOpenable()
    {
        if(canOpen)
        {
            base.ProcessOpenable();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ShowQuestion?.Invoke(this.GetInstanceID());
            }
        }
    }

    protected override bool IsEligibleToOpen()
    {
        return canOpen;
    }

    private void SetIsOpenOnQuestionClose(int instanceID)
    {
        if(this.GetInstanceID() == instanceID)
        {
            canOpen = true;
        }
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

