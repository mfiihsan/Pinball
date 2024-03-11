using Project_Pinball.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project_Pinball.UI.getScore
{
    public class getScore : MonoBehaviour
    {
        [SerializeField] int score;
        [SerializeField] GameEvent onScoreIncreased;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                onScoreIncreased?.Raise(this,score);
            }
        }
    }
}
