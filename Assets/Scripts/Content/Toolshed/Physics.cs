using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Content.Toolshed
{
    public sealed class Physics : MonoBehaviour {
        static public bool CheckGround(Transform ent) 
        {
            bool isGround;
            Collider2D[] col = Physics2D.OverlapCircleAll(ent.position, 0.3f);
            isGround = col.Length > 1;
            return isGround;
        }
    }
}