using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Entities;
using Content.Items;
using Unity.Mathematics;

namespace Content.Inventory
{
    public class InventorySystem : MonoBehaviour
    {
        [SerializeField] public List<Item> StarterPack = new List<Item> {};
        [SerializeField] public List<Item> UserPack = new List<Item> {};
        public static InventorySystem instance;
        public Action<Item> onItemAdded;
        public Action<Item> onItemRemoved;
        public GameObject target;
        public Item itemTarget; 

        public int UserPackLimit = 40;
        void Awake()
        {
            instance = this;
            for(int i = 0; i < StarterPack.Count; i++)
            {
                AddItem(StarterPack[i], false);
            }
        }
        public void AddItem(Item item, bool isPublic)
        {
            if (!isPublic)
            {
                UserPack.Add(item);
                Debug.Log($"Added {item} to inventory");
                onItemAdded?.Invoke(item);
            }
            else if (isPublic)
            {
                PublicInventorySystem.publicInstance.AddPublicItem(item, target);
            }
        } 
        public void RemoveItem() // called by button
        {
            if (InventorySlot.selectedSlot == -1)
            {
                return;
            }
            var selectedSlot = InventorySlot.selectedSlot;
            Item item = UserPack[selectedSlot];
            UserPack.Remove(item);
            InventorySlot.selectedSlot = -1;
            Debug.Log($"Remove {item} from inventory");
            onItemRemoved?.Invoke(item);
            var pos = new Vector3(Player.instance.transform.position.x+2f, Player.instance.transform.position.y, Player.instance.transform.position.z);
            GameObject pref = Instantiate(item.prefab, pos, Quaternion.identity);
            pref.AddComponent<SpawnDisable>();
        }

        public bool CheckSlots()
        {
            if (UserPack.Count < UserPackLimit)
            {
                return true;
            }
            else if(UserPack.Count == UserPackLimit)
            {
                return false;
            }
            return true;
        }
    }

    public sealed class PublicInventorySystem : InventorySystem
    {
        public static PublicInventorySystem publicInstance;
        void Start()
        {
            instance = this;
        }
        public void AddPublicItem(Item item, GameObject target)
        {
            target.GetComponent<InventorySystem>().UserPack.Add(item);
            Debug.Log($"Added public item {item} to userpack of {target}");
        }
    }
}