using UnityEngine;
using UnityEngine.UI;

public class BrightnessController : MonoBehaviour
{
    public Slider brightnessSlider;
    private float defaultBrightness = 1.0f;

    private void Start()
    {
        // Set the initial brightness value
        brightnessSlider.value = defaultBrightness;
        SetBrightness(defaultBrightness);
    }

    public void SetBrightness(float brightness)
    {
        // Adjust the brightness using the RenderSettings.ambientIntensity
        RenderSettings.ambientIntensity = brightness;
    }

    public void OnBrightnessChanged(float brightness)
    {
        SetBrightness(brightness);
    }
}