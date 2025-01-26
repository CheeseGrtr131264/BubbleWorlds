using UnityEngine;

public class PlayerLightController : MonoBehaviour
{
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _playerLightSource;

    private float _lightRadius;

    private void Start()
    {
        _lightRadius = transform.localScale.x;
    }

    public void Health_OnHealthChanged(object sender, Health health)
    {

    }
}
