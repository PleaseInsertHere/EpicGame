using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public Slider slider;
    [SerializeField] public Camera camera;
    [SerializeField] public Transform target;
    [SerializeField] public Vector3 offset;
    
    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue; 
    }

 
    void Update()
    {
        transform.rotation = camera.transform.rotation;
        transform.position = target.position;
    }
}
