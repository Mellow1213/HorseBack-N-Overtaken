using UnityEngine;

public class BoxTriggerController : MonoBehaviour
{
    public delegate void HandEventHandler(GameObject hand);
    public event HandEventHandler OnHandEntered;
    public event HandEventHandler OnHandExited;

    public int HandsCount { get; private set; } = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            HandsCount++;
            OnHandEntered?.Invoke(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            HandsCount--;
            OnHandExited?.Invoke(other.gameObject);
        }
    }
}