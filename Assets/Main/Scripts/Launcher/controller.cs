using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_Pinball.launcher
{
    public class Controller : MonoBehaviour
    {
        [SerializeField] GameObject plunger;
        [SerializeField] Transform charge_pos;
        [SerializeField] launcherState current_state;
        [Header("Value")]
        [SerializeField] float power;
        [SerializeField] float power_delta;
        [SerializeField] float max_power;
        [SerializeField] float launch_time_recover_time;
        Vector3 idlePos;
        // Start is called before the first frame update
        void Start()
        {
            current_state = launcherState.Idle;
            idlePos = plunger.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if(current_state == launcherState.Chargeable && Input.GetKey(KeyCode.Space))
            {
                if (current_state != launcherState.Launching) current_state = launcherState.Launching;
            }
            if(Input.GetKeyUp(KeyCode.Space) && power > 0f)
            {
                launch();
            }
            switch (current_state)
            {
                case launcherState.Idle: break;
                case launcherState.Launching: OnLaunching(); break;
                case launcherState.Recover: OnRecover(); break;
                case launcherState.Chargeable: plunger.GetComponent<Rigidbody>().velocity = Vector3.zero; break;
            }
        }

        void OnLaunching()
        {
            if (current_state != launcherState.Launching) return;
            if (Vector3.Distance(plunger.transform.position, charge_pos.position) > 0.25f) plunger.GetComponent<Rigidbody>().velocity = (charge_pos.position - plunger.transform.position).normalized * 2.5f;
            else
            {
                plunger.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (power < max_power) power += power_delta * Time.deltaTime;
        }

        void OnRecover()
        {
            if (current_state != launcherState.Recover) return;
            if (Vector3.Distance(plunger.transform.position, idlePos) > 0.25f) plunger.GetComponent<Rigidbody>().velocity = (idlePos - plunger.transform.position).normalized * 10f;
            else { plunger.GetComponent<Rigidbody>().velocity = Vector3.zero; current_state = launcherState.Idle; }
        }

        void launch()
        {
            current_state = launcherState.Launch;
            var plunge = plunger.GetComponent<Rigidbody>();
            plunge.AddForce(power * new Vector3(0, 0, 1),ForceMode.Impulse);
            StartCoroutine(recover());
        }

        IEnumerator recover()
        {
            yield return new WaitForSeconds(launch_time_recover_time);
            current_state = launcherState.Recover;
            power = 0;
        }

        public void set_state(launcherState state)
        {
            if(current_state != state && (current_state == launcherState.Chargeable || current_state == launcherState.Idle)) current_state = state;
        }
    }

    public enum launcherState
    {
        Idle,
        Chargeable,
        Launching,
        Launch,
        Recover
    }
}
