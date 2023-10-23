using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Content.Inventory;
using Content.UI;

namespace Content.Items
{
    public sealed class ItemTaker : MonoBehaviour
    {
        public GameObject inventoryIsFullText;
        private Item addItem;

		public bool isPublic;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!gameObject.GetComponent<InventorySystem>().CheckSlots())
            {
                inventoryIsFullText.SetActive(true);
                StartCoroutine(Wait(5f));
                return;
            }
            if (col.tag != "PlayerBullet" && col.tag != "ManaItem")
            { 
                addItem = col.GetComponent<TakeableObject>().inventoryVisibleItem;
                InventorySystem.instance.AddItem(addItem, isPublic);
                Destroy(col.gameObject);
            }
            if (col.tag == "ManaItem")
            {
                ManaBar.ManaPoint = ManaBar.ManaPoint + 3;
                ManaBar.instance.RedrawMana(0);
                Destroy(col.gameObject);
            }
        }

        IEnumerator Wait(float time)
        {
            yield return new WaitForSeconds(time);
        }
    }
}