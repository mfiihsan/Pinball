using Project_Pinball.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_Pinball.Core
{
    public class EmitEventOnTrigger : MonoBehaviour
    {
        [SerializeField] GameEvent emittedEvent;
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Player")) emittedEvent?.Raise(this, null);
        }
    }
}
