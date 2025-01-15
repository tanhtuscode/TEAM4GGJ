using UnityEngine;

/// <summary>
/// Basic singleton pattern implementation
/// 
/// Usage:
/// 1. Inherit from this class:
///    public class MyManager : Singleton<MyManager> { }
/// 
/// 2. Access from anywhere:
///    MyManager.Instance.YourMethod();
/// </summary>
public class Singleton<T> where T : class, new()
{
    private static readonly object lockObject = new object();
    private static T instance;

    /// <summary>
    /// Gets the singleton instance. Creates it if it doesn't exist.
    /// Thread-safe implementation.
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new T();
                    }
                }
            }
            return instance;
        }
    }

    /// <summary>
    /// Protected constructor to prevent direct instantiation
    /// </summary>
    protected Singleton() { }
}
