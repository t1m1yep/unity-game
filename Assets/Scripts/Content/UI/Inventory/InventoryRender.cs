using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Content.Inventory;

namespace Content.UI
{
    public sealed class InventoryRender : MonoBehaviour
    {
        [SerializeField] private RectTransform ItemPanel;
        private readonly List<Item> drawnObjects = new List<Item>();
        private InventorySlot[] slotChildList;
        [SerializeField] public Sprite slotImage;
        void Redraw()
        {
            GarbageCleaner();
            for(int i = 0; i < InventorySystem.instance.UserPack.Count; i++)
            {
                var item = InventorySystem.instance.UserPack[i];
                var slot = ItemPanel.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>();
                slot.sprite = item.icon;
                drawnObjects.Add(item);
                Debug.Log($"Redrawn. Items count are {drawnObjects.Count}");
            }
        }
        void OnItemAdded(Item obj) => Redraw();
        void OnItemRemoved(Item obj) => Redraw();
        void Start()
        {
            var slots = transform.GetChild(0);
            slotChildList = slots.GetComponentsInChildren<InventorySlot>();
            Debug.Log($"kids are {slotChildList.Length} today");
            InventorySystem.instance.onItemAdded += OnItemAdded;
            InventorySystem.instance.onItemRemoved += OnItemRemoved;
            Redraw();
            for (int i = 0; i < slotChildList.Length; i++)
            {
                slots.transform.GetChild(i).GetComponent<InventorySlot>().slotNumberClicked = i;
            }
        }

        void GarbageCleaner()
        {
            for (int i = 0; i < drawnObjects.Count; i++)
            {
                var slot = ItemPanel.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>();
                slot.sprite = slotImage;
            }

            drawnObjects.Clear();
            Debug.Log("Redrawn items.");
        }
    }
}