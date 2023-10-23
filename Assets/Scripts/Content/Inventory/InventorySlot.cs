using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace Content.Inventory
{
    public sealed class InventorySlot : MonoBehaviour
    {
        public static InventorySlot instance;
        public static int selectedSlot;
        public int slotNumberClicked;

        private void Awake()
        {
            selectedSlot = -1;
            instance = this;
            GetComponent<Button>().onClick.AddListener(SelectSlot);
        }

        private void SelectSlot()
        {
            Debug.Log($"clicked slot with id {slotNumberClicked}");
            selectedSlot = slotNumberClicked;
        }
    }
}