using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Color_Em_Up
{
    public class EnemyRenderControl : RenderControl
    {
        [SerializeField] private Material Color_A;
        [SerializeField] private Material Color_B;
        [SerializeField] private Material Color_C;

        private Dictionary<EnemyType, Material> colorTable;
        
        public override void Initialized()
        {
            colorTable = new Dictionary<EnemyType, Material>()
            {
                { EnemyType.A , Color_A },
                { EnemyType.B , Color_B },
                { EnemyType.C , Color_C },
            };
        }

        public void SetColorType(EnemyType _type)
        {
            if (colorTable.TryGetValue(_type, out var _material))
            {
                Renderer.sharedMaterial = _material;
            }
        }
    }
}
