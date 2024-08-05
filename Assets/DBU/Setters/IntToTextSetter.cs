using System;
using UnityEngine;
using UnityEngine.UI;

namespace DBU
{
    [RequireComponent(typeof(Text))]
    public class IntToTextSetter : SetterBase<int>
    {
        private Text _target;

        private void Awake()
        {
            _target = GetComponent<Text>();
        }

        protected override void OnResponse(int value)
        {
            _target.text = value.ToString();
        }
    }
}