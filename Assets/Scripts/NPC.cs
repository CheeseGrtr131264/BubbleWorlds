using System;
using System.Collections;
using Ink.Runtime;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    //[SerializeField] Dialog _dialogueHandler;
    [SerializeField] private TextAsset _inkFile;
    [SerializeField] private bool _hasRunDialogue;
    [SerializeField] private Sprite _characterSprite;

    private Story _myStory;
    private SpriteRenderer _spriteRenderer;
    private Animator _anim;
    private float _walkSpeed = 1.5f;
    private float _walkDist = 1f;
    public Story MyStory => _myStory;

    private void Awake()
    {
        _myStory = new Story(_inkFile.text);
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.enabled = false;

        _anim = GetComponent<Animator>();
    }

    void IInteractable.Interact(Inventory playerInventory)
    {
        if (!_spriteRenderer.enabled)
        {
            StartCoroutine(WalkIn(playerInventory));
        }
        else
        {
            StartDialogue(playerInventory);
        }
    }

    private IEnumerator WalkIn(Inventory playerInventory)
    {
        _spriteRenderer.enabled = true;
        _anim.Play("Walk");
        
        Vector3 destination = transform.position + Vector3.down * _walkDist;
        
        while ((destination - transform.position).magnitude > 0.1f)
        {
            Vector3 travelVec = destination - transform.position;
            transform.position += travelVec.normalized * _walkSpeed * Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        transform.position = destination;
        _anim.Play("Idle");
        StartDialogue(playerInventory);
    }

    private void StartDialogue(Inventory playerInventory)
    {
        DialogueManager.Instance.StartDialogue(playerInventory, _myStory, _characterSprite);
        DialogueManager.Instance.AddDialogueDoneListener(DialogueDone);
        _hasRunDialogue = true;
    }

    private void DialogueDone()
    {
        Debug.Log("Dialogue done");
        DialogueManager.Instance.RemoveListener(DialogueDone);
        FinishedInteracting?.Invoke(this);
    }

    public event Action<IInteractable> FinishedInteracting;
}
