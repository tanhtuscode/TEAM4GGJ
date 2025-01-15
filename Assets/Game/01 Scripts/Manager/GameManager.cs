using UnityEngine;
using System.Collections.Generic;

public class GameManager : SingletonBehaviour<GameManager>
{
    private InitManagerFlags _initializedFlags;
    private List<IInitializable> _managers = new List<IInitializable>();

    private void Start()
    {
        InitializeManagers();
    }

    public void RegisterManager(IInitializable manager)
    {
        if (!_managers.Contains(manager))
        {
            _managers.Add(manager);
        }
    }

    private void InitializeManagers()
    {
        foreach (var manager in _managers)
        {
            if (!manager.IsInitialized)
            {
                manager.Initialize();
                _initializedFlags |= manager.InitFlag;
            }
        }
    }

    public bool IsManagerInitialized(InitManagerFlags flag)
    {
        return (_initializedFlags & flag) == flag;
    }

    public bool AreAllManagersInitialized()
    {
        return (_initializedFlags & InitManagerFlags.All) == InitManagerFlags.All;
    }
}
