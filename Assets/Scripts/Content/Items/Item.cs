using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Content
{
    [CreateAssetMenu(fileName = "ItemData", menuName = "ScriptableObject")]
    public sealed class Item : ScriptableObject
    {
        public string title = "item";
        public Sprite icon;
        public float weight;
        public GameObject prefab;
    }
}