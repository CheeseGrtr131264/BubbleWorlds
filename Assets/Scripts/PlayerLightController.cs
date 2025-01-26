using UnityEngine;

public class PlayerLightController : MonoBehaviour
{
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D _playerLightSource;

    private float _startingLightScale;
    private float _lightScale;
    private float _lightMinScale = 10.0f;
    private float _lightMaxScale = 40.0f;

    private void Start()
    {
        _startingLightScale = transform.localScale.x;
        _lightScale = transform.localScale.x;
    }

    public void Health_OnHealthChanged(object sender, Health health)
    {
        Vector3 newVector3 = new Vector3(health._health, health._health, health._health);
        _playerLightSource.transform.localScale = newVector3;
    }
}
