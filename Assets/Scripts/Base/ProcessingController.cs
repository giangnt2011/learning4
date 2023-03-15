using UnityEngine;

public class ProcessingController : MonoBehaviour
{
    [SerializeField] public float currentValue;
    [SerializeField] public float maxValue;

    private void Awake()
    {
        DisplayProcessing();
    }

    public void SetValue(float currentValue)
    {
        this.currentValue = currentValue;
        this.maxValue = currentValue;
        DisplayProcessing();
    }
    public void ChangeValue(float newValue)
    {
        currentValue = newValue;
        DisplayProcessing();
        if (currentValue < 0) currentValue = 0;
        if (currentValue > maxValue) currentValue = maxValue;

    }
    public void DisplayProcessing()
    {
        if (maxValue == 0) return;
        transform.localScale = new Vector3((float)0.5 * currentValue / maxValue, transform.localScale.y, 1);
    }
}
