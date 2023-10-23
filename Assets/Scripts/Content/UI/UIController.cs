using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Content.UI
{
    public sealed class UIController : MonoBehaviour
    {
        public GameObject inventory;
        void Start()
        {
            inventory.SetActive(false);
        }
        void Update()
        {
            if(Input.GetButton("ExitButton"))
            {
                CloseInventory();
            }
        }
        public void CloseInventory()
        {
            inventory.SetActive(false);
        }
        public void OpenInventory()
        {
            inventory.SetActive(true);
        }
    }
}