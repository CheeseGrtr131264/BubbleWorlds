using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private LightDetector _lightDetector;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _playerLightSource;
    [SerializeField] private PlayerLightController _playerLightController;

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
            }
        }
        catch
        {
            Debug.Log("NOOOOOOOO");
        }
    }
}
