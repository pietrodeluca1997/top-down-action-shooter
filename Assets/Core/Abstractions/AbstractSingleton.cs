using UnityEngine;

public class AbstractSingleton<TDesiredSingletonClass> : MonoBehaviour where TDesiredSingletonClass : AbstractSingleton<TDesiredSingletonClass>
{
    public static TDesiredSingletonClass Instance;

    protected virtual void Awake()
    {
        if(Instance is not null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this as TDesiredSingletonClass;

            DontDestroyOnLoad(Instance);
        }
    }
}
