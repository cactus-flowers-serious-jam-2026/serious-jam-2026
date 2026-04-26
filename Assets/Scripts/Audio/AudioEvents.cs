using UnityEngine;
using UnityEngine.Events;

public static class AudioEvents
{
    public static UnityEvent OnClicked = new UnityEvent();
    
    public static UnityEvent OnCanceled = new UnityEvent();
    
    public static UnityEvent OnEventPoppedUp = new UnityEvent();

    public static void InvokeOnClicked()
    {
        AudioManager.Instance.PlayOneShot("click");
        OnClicked.Invoke();
    }

    public static void InvokeOnCanceled()
    {
        AudioManager.Instance.PlayOneShot("cancel");
        OnCanceled.Invoke();
    }

    public static void InvokeOnEventPoppedUp()
    {
        AudioManager.Instance.PlayOneShot("event");
        OnEventPoppedUp.Invoke();
    }
}
