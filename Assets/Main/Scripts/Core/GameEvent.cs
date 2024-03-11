using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_Pinball.Core
{
    [CreateAssetMenu(menuName = "GameEventSignal")]
    public class GameEvent : ScriptableObject
    {
        public List<IGameEventListener> listeners = new List<IGameEventListener>();

        public void Raise(Component sender, object data)
        {
            for (int i = listeners.Count - 1; i >= 0; i--) listeners[i].OnEventRaised(sender, data);
        }

        public void registerListener(IGameEventListener target)
        {
            if (!listeners.Contains(target)) listeners.Add(target);
        }

        public void unregisterListener(IGameEventListener target)
        {
            if (listeners.Contains(target)) listeners.Remove(target);
        }

        public void xxUnRegisteredListener()
        {
            listeners.Clear();
        }
    }
}
