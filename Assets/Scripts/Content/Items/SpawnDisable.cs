using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Entities;

namespace Content.Items
{
    public class SpawnDisable : MonoBehaviour
    {
        private float cooldown = 3;
        void Awake()
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(Wait(cooldown));
        }
        IEnumerator Wait(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
}