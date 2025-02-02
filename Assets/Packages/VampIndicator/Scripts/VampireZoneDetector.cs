using System;
using UnityEngine;

namespace VampireIndicator
{
    public class VampireZoneDetector : MonoBehaviour
    {
        public event Action<ItemDetector> Detected;
        public event Action Undetected;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.TryGetComponent(out ItemDetector itemDetector))
                Detected?.Invoke(itemDetector);                
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.transform.TryGetComponent<ItemDetector>(out _))
                Undetected?.Invoke();
        }
    }
}