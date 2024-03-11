using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_Pinball.Core.cam
{
    public class cameraController : MonoBehaviour
    {
        float default_FOV = 60;
        float target_FOV = 20;
        Vector3 default_position;
        [SerializeField] Camera cam;
        [SerializeField] cameraState current_state;
        [SerializeField] Transform target;
        [SerializeField] Vector3 target_offset;
        GameObject cam_obj;
        Vector3 target_pos;
        private void Start()
        {
            cam_obj = cam.gameObject;
            default_position = new Vector3(0, 11, -3);
        }

        private void Update()
        {
            switch (current_state)
            {
                case cameraState.Follow: OnFollowBall(); break;
                case cameraState.EagleView: OnEagleView(); break;
            }
        }

        void OnEagleView()
        {
            if (cam.fieldOfView != default_FOV) cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, default_FOV, 0.1f);
            cam_obj.transform.position = new Vector3(Mathf.Lerp(cam_obj.transform.position.x, default_position.x, 0.1f), cam_obj.transform.position.y, Mathf.Lerp(cam_obj.transform.position.z, default_position.z, 0.1f));
        }

        void OnFollowBall()
        {
            target_pos = target.position + target_offset;
            if (cam.fieldOfView != target_FOV) cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, target_FOV, 0.1f);
            cam_obj.transform.position = new Vector3(Mathf.Lerp(cam_obj.transform.position.x, target_pos.x, 1f), cam_obj.transform.position.y, Mathf.Lerp(cam_obj.transform.position.z, target_pos.z, 1f));
        }

        IEnumerator setState(cameraState state)
        {
            yield return new WaitForSeconds(0.5f);
            current_state = state;
        }

        public void changeState(Component sender, object state)
        {
            if (state is not cameraState) return;
            if(current_state != (cameraState)state) StartCoroutine(setState((cameraState)state));
        }
    }

    public enum cameraState
    {
        Follow,
        EagleView
    }
}
