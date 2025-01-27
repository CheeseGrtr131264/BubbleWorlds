using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private LightDetector _lightDetector;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _playerLightSource;
    [SerializeField] private PlayerLightController _playerLightController;
    // [SerializeField] private float _moveTime;
    // [SerializeField] private Vector2 _moveAwayDistance;

    private void Start()
    {
        _health.OnDied += _playerController.Health_OnDied;
        _lightDetector.OnLightChecked += _health.LightDetector_OnLightChecked;
        _lightDetector.OnLightSourceReached += _playerController.LightDetector_OnLightSourceReached;
        _health.OnHealthChanged += _playerLightController.Health_OnHealthChanged;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            var interactables = collision.gameObject.GetComponents<IInteractable>();
            foreach(var interactable in interactables)
            {
                interactable.Interact(_inventory);
                // StartCoroutine(MoveToInteractable(other.gameObject, interactable));
            }
        }
        catch
        {
            Debug.Log("NOOOOOOOO");
        }
    }
    
    // IEnumerator MoveToInteractable(GameObject obj, IInteractable interactable)
    // {
    //     _playerController.enabled = false;
    //     
    //     GetComponent<Rigidbody2D>().DOMove(obj.transform.position, _moveTime);
    //     yield return new WaitForSeconds(_moveTime);
    //     
    //     interactable.Interact(_inventory);
    //     
    //     interactable.FinishedInteracting += StopInteracting;
    // }
    //
    // private void StopInteracting(IInteractable interactable)
    // {
    //     interactable.FinishedInteracting -= StopInteracting;
    //     StartCoroutine(MoveAwayFromInteractable());
    // }
    //
    // IEnumerator MoveAwayFromInteractable()
    // {
    //     
    //     Vector2 startPos = transform.position;
    //     GetComponent<Rigidbody2D>().DOMove(startPos + _moveAwayDistance, _moveTime);
    //     yield return new WaitForSeconds(_moveTime);
    //     
    //     _playerController.enabled = true;
    // }
}
