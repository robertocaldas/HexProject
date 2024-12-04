using System;
using System.Collections;
using System.Collections.Generic;
using johnny.HexProject.Logic;
using UnityEditor;
using UnityEngine;

namespace johnny.HexProject.Visuals
{
    public class TileBehaviour : MonoBehaviour
    {
        public void SetPosition(IPosition position)
        {
            var (x, y, z) = position.To3D();
            transform.position = new Vector3(x, y, z);
        }

        private void OnDrawGizmos()
        {
            Handles.Label(transform.position - new Vector3(-0.25f, 0f, 0f), name);
        }
    }
}