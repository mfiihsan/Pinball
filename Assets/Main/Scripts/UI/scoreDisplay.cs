using Project_Pinball.UI.VFX;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Project_Pinball.UI.Displayer
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] GameObject scoreText;
        TextMeshProUGUI _TextMeshPro;
        float _Score;
        void Start()
        {
            _TextMeshPro = GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            _TextMeshPro.text = _Score.ToString();
        }

        public void OnScoreIncrease(Component sender, object data)
        {
            if (data is not int) return;
            else data = (int)data;
            var vfx = Instantiate(scoreText);
            vfx.transform.position = sender.transform.position;
            vfx.GetComponent<scoreText>().init((int)data);
            _Score += (int)data;
        }
    }
}
