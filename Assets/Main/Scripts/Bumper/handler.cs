using Project_Pinball.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_Pinball.Bumper
{
    public class Handler : MonoBehaviour
    {
        [SerializeField] float bumperForce;
        [SerializeField] GameEvent onBump;
        [SerializeField] AudioClip sfx_on_bump;
        [SerializeField] AudioSource sfx_source;
        [SerializeField] int score_on_bump;
        Animator anim;
        Light _light;
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            anim = GetComponent<Animator>();
            _light = GetComponentInChildren<Light>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                anim.SetTrigger("Bump");
                bumpLight();
                sfx_source.PlayOneShot(sfx_on_bump);
                onBump?.Raise(this,score_on_bump);
                collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(bumperForce, transform.position, 1);
            }
        }

        void bumpLight()
        {
            StopAllCoroutines();
            _light.intensity = 1;
            StartCoroutine(turn_off());
        }

        IEnumerator turn_off()
        {
            yield return new WaitForSeconds(0.25f);
            _light.intensity = 0;
        }
    }
}
