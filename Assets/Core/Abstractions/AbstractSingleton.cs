using UnityEngine;

/// <summary>
/// This class implements the Singleton pattern in a generic way for Unity MonoBehaviour classes.
/// It ensures that only one instance of a class derived from AbstractSingleton can exist in the scene.
/// The generic type parameter TDesiredSingletonClass ensures type safety for derived classes.
/// </summary>
public class AbstractSingleton<TDesiredSingletonClass> : MonoBehaviour where TDesiredSingletonClass : AbstractSingleton<TDesiredSingletonClass>
{
    /// <summary>
    /// Static property to hold the single instance of the derived class.
    /// </summary>
    public static TDesiredSingletonClass Instance;

    /// <summary>
    /// Awake method is called when the object is initialized.
    /// It checks if there's already an instance.
    /// If another instance exists, it destroys the current object to maintain singularity.
    /// If no other instance exists, it sets the current instance and keeps it active between scene changes.
    /// </summary>
    protected virtual void Awake()
    {
        if (Instance is not null && Instance != this)
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
