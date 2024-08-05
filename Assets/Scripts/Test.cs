using System;
using DBU;
using UnityEngine;

namespace DefaultNamespace
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log(TryGetComponent<UIBaseLifetimeScope>(out var c));
        }
    }
}