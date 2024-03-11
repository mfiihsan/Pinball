using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_Pinball.Core.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] AudioClip[] sfx;
        [SerializeField] AudioSource BGM_source;
        [SerializeField] AudioSource[] SFX_source;

        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void playSFX(Component sender, object index)
        {
            if (index is not int || (int)index >= sfx.Length || (int)index >= SFX_source.Length) return;
            SFX_source[(int)index].PlayOneShot(sfx[(int)index]);
        }
    }
}
