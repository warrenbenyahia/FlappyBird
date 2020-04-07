using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public static class InputManager
    {
        public static bool IsAction()
        {
            return Input.GetKeyDown(KeyCode.Space)
                || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);
        }
    }
}
