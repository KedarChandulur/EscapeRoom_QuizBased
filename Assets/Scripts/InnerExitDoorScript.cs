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
        QuestionManager.OnQuestionExit += SetIsOpenOnQuestionClose;
        base.Setup(15.0f);
    }

    private void OnDestroy()
    {
        QuestionManager.OnQuestionExit -= SetIsOpenOnQuestionClose;
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

    private void SetIsOpenOnQuestionClose(int instanceID, Question question, bool questionCorrect)
    {
        if(this.GetInstanceID() == instanceID)
        {
            canOpen = questionCorrect;
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

