using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Project_Pinball.Core
{
    public class GameEventListener : MonoBehaviour, IGameEventListener
    {
        public GameEvent gameEvent;
        public customGameEvent response;

        private void OnEnable()
        {
            gameEvent.registerListener(this);
        }
        private void OnDisable()
        {
            gameEvent.unregisterListener(this);
        }
        public void OnEventRaised(Component sender, object data)
        {
            response.Invoke(sender, data);
        }
    }
    [System.Serializable]
    public class customGameEvent : UnityEvent<Component, object> { }

    public interface IGameEventListener
    {
        public void OnEventRaised(Component sender, object data);

    }
}
