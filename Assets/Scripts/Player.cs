using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private LightDetector _lightDetector;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _playerLightSource;
    [SerializeField] private PlayerLightController _playerLightController;
    [SerializeField] private float _moveTime;
    [SerializeField] private Vector2 _moveAwayDistance;

    private void Start()
    {
        _health.OnDied += _playerController.Health_OnDied;
        _lightDetector.OnLightChecked += _health.LightDetector_OnLightChecked;
        _lightDetector.OnLightSourceReached += _playerController.LightDetector_OnLightSourceReached;
        _health.OnHealthChanged += _playerLightController.Health_OnHealthChanged;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            StartCoroutine(MoveToInteractable(collision.gameObject, interactable));
        }
    }
    
    IEnumerator MoveToInteractable(GameObject obj, IInteractable interactable)
    {
        _playerController.enabled = false;
        
        Vector3 destPos = obj.transform.position + new Vector3(0, 0.93499f, 0);
        
        GetComponent<Rigidbody2D>().DOMove(destPos, _moveTime);
        yield return new WaitForSeconds(_moveTime);
        
        interactable.Interact(_inventory);
        interactable.FinishedInteracting += StopInteracting;
        
    }
    
    private void StopInteracting(IInteractable interactable)
    {
        interactable.FinishedInteracting -= StopInteracting;
        Debug.Log("Running away");
        //StartCoroutine(MoveAwayFromInteractable());
    }
    
    IEnumerator MoveAwayFromInteractable()
    {
        
        Vector2 startPos = transform.position;
        GetComponent<Rigidbody2D>().DOMove(startPos + _moveAwayDistance, _moveTime);
        yield return new WaitForSeconds(_moveTime);
        
        _playerController.enabled = true;
    }
}
