using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient; //for change color of the bar
    public Image fill;

    public void SetMaxOxygen(float oxygen)
    {
        slider.maxValue = oxygen;
        slider.value = oxygen;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetOxygen(float oxygen)
    {
        slider.value = oxygen;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
