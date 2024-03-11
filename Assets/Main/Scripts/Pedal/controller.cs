using Project_Pinball.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_Pinball.Pedal
{
    public class controller : MonoBehaviour
    {
        [SerializeField] private KeyCode desired_input;
        [SerializeField] AudioClip sfx;
        AudioSource aud;
        HingeJoint joint;
        // Start is called before the first frame update
        void Start()
        {
            aud = GetComponent<AudioSource>();
            joint = GetComponent<HingeJoint>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(desired_input))
            {
                aud.PlayOneShot(sfx);
            }
            if (Input.GetKey(desired_input))
            {
                joint.useSpring = true;
            }
            else if (Input.GetKeyUp(desired_input))
            {
                joint.useSpring = false;
            }
        }

    }
}
