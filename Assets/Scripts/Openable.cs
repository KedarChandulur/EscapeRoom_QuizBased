using System.Collections;
using UnityEngine;

public abstract class Openable : MonoBehaviour
{
    private Animator anim;
    private Transform player;
    private float interactableDistance;
    private bool isOpen;

    protected void Setup(float playerInteractableDistance)
    {
        GameObject playerGO_Ref = GameObject.FindWithTag("Player");

        if (playerGO_Ref == null)
        {
            Debug.LogError("Couldn't find the player reference on application start.");

            GameManager.QuitGame();
            return;
        }

        player = playerGO_Ref.transform;

        if (!this.transform.TryGetComponent<Animator>(out anim))
        {
            if (!this.transform.parent.TryGetComponent<Animator>(out anim))
            {
                Debug.LogError("Couldn't find the animation reference on application start.");

                GameManager.QuitGame();
                return;
            }
        }

        interactableDistance = playerInteractableDistance;
        isOpen = false;
    }

    void OnMouseOver()
    {
        ProcessOpenable();
    }

    protected virtual void ProcessOpenable()
    {
        if (!IsEligibleToOpen())
        {
            return;
        }

        if (!player)
        {
            Debug.LogError("Lost reference to player");
            return;
        }

        float dist = Vector3.Distance(player.position, this.transform.position);

        if (dist < interactableDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isOpen)
                {
                    StartCoroutine(CloseAnim());
                }
                else
                {
                    StartCoroutine(OpenAnim());
                }

                isOpen = !isOpen;
            }
        }
    }

    protected virtual bool IsEligibleToOpen()
    {
        return true;
    }

    protected void PlayAnimation(string name)
    {
        anim.Play(name);
    }

    protected abstract IEnumerator OpenAnim();
    protected abstract IEnumerator CloseAnim();
}
