using UnityEngine;
using UnityEngine.UI;

namespace DBU
{
    [RequireComponent(typeof(Text))]
    public class IntToTextSetter : SetterBase<int>
    {
        protected override void OnResponse(int value)
        {
            throw new System.NotImplementedException();
        }
    }
}