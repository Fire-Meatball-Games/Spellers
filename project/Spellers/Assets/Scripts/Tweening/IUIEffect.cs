using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tweening
{
    public interface IUIEffect
    {
        public IEnumerator Execute();
    }

}