using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Project_Pinball.UI.VFX
{
    public class scoreText : MonoBehaviour
    {
        [SerializeField] TextMeshPro _text;
        void Start()
        {
            Invoke("stopVFX", 1f);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void init(int score)
        {
            _text.text = score.ToString();
        }

        void stopVFX()
        {
            Destroy(gameObject);
        }
    }
}
