using Entities;
using UnityEngine;

namespace Content.UI
{
    public sealed class HPBar : MonoBehaviour
    {
        public static HPBar instance;
        private void Awake()
        {
            instance = this;
        }
        public void HPRedraw()
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}