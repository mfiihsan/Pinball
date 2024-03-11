using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project_Pinball.launcher;

namespace Project_Pinball.Core.cam
{
    public class cameraTrigger : MonoBehaviour
    {
        [SerializeField] cameraState cameraState;
        [SerializeField] launcherState launcherState;
        [SerializeField] GameEvent onCameraViewChange;
        [SerializeField] Controller plunger;
        private void OnTriggerStay(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;
            plunger.set_state(launcherState);
            onCameraViewChange?.Raise(this, cameraState);
        }
    }
}
