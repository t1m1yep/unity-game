using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Entities;
using Content.Inventory;
// using UnityEngine.InputSystem;

namespace Content.UI
{
    public sealed class InventoryMenu : MonoBehaviour
    {
        // private Mouse mouse = Mouse.current;
        public Text hpText;
        void Start()
        {
            hpText.text = $"HP: {Player.instance.curhp.ToString()}";
        }
        
    }
}