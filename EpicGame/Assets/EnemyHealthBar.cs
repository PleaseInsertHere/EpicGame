using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    private void Start()
    {
        // Check if the required components are assigned
        if (slider == null)
        {
            Debug.LogError("Slider component is not assigned in EnemyHealthBar.", this);
        }

        if (camera == null)
        {
            Debug.LogError("Camera component is not assigned in EnemyHealthBar.", this);
        }

        if (target == null)
        {
            Debug.LogError("Target Transform is not assigned in EnemyHealthBar.", this);
        }
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        if (slider != null && maxValue > 0)
        {
            slider.value = currentValue / maxValue;
        }
        else
        {
            Debug.LogWarning("Slider or maxValue is not set correctly in EnemyHealthBar.");
        }
    }

    private void Update()
    {
        if (camera != null && target != null)
        {
            // Update rotation to match the camera's rotation
            transform.rotation = camera.transform.rotation;
            
            // Update position with offset relative to the target
            transform.position = target.position + offset;
        }
        else
        {
            Debug.LogWarning("Camera or target Transform is not set correctly in EnemyHealthBar.");
        }
    }
}
