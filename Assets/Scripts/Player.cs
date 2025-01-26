using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private LightDetector _lightDetector;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _playerLightSource;

    private void Start()
    {
        _health.OnDied += _playerController.Health_OnDied;
        _lightDetector.OnLightChecked += _health.LightDetector_OnLightChecked;
        _lightDetector.OnLightSourceReached += _playerController.LightDetector_OnLightSourceReached;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IInteractable interactable))
        {
            interactable.Interact(_inventory);
        }
    }
}
