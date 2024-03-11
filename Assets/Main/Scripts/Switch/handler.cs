using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_Pinball.Switch
{
    public class Handler : MonoBehaviour
    {
        [SerializeField] float light_on_intensity = 2;
        [SerializeField] bool is_on;
        [SerializeField] AudioClip[] sfx;
        public switchState switch_state;
        Light _light;
        private void Start()
        {
            _light = GetComponentInChildren<Light>();
            StartCoroutine(StartBlink());
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) Toggle();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player")) Toggle();
        }
        void set(bool val)
        {
            is_on = val;
            if(val)
            {
                switch_state = switchState.On;
                _light.intensity = light_on_intensity;
            }
            else
            {
                switch_state = switchState.Off;
                _light.intensity = 0;
            }
        }

        void Toggle()
        {
            
            if(switch_state == switchState.On)
            {
                GetComponent<AudioSource>().PlayOneShot(sfx[0]);
                set(false);
                StartCoroutine(StartBlink());
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(sfx[1]);
                set(true);
                StopAllCoroutines();
            }
        }

        IEnumerator StartBlink()
        {
            switch_state = switchState.Blinking;
            yield return new WaitForSeconds(2f);
            StartCoroutine(Blink());
        }

        IEnumerator Blink()
        {
            set(!is_on);
            yield return new WaitForSeconds(0.25f);
            StartCoroutine(Blink());
        }
    }

    public enum switchState
    {
        On,
        Off,
        Blinking
    }
}
