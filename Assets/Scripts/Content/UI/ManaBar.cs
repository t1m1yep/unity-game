using System;
using System.Collections.Generic;
using UnityEngine;
using Entities;

namespace Content.UI
{
    public class ManaBar : MonoBehaviour
    {
        public static int ManaPoint;
        public static ManaBar instance;
        public GameObject prefabMana;
        private int drawnObjects = 0;
        public AudioClip noManaSound;
        
        void onManaChanging(int eatingMana) => RedrawMana(eatingMana);

        private void Awake()
        {
            ManaPoint = 10;
        }
        
        private void Start()
        {
            instance = this;
            try
            { 
                Player.instance.onManaChange += onManaChanging; 
                Debug.Log("action was called");
            }
            catch(NullReferenceException)
            { 
                Debug.Log("Got NullReferenceException oh no");
            }
            RedrawMana(1);
        }
        
        public void RedrawMana(int eatingMana)
        {
            ManaPoint = ManaPoint - eatingMana;
            Debug.Log($"mana :{ManaPoint}");
            GarbageCleaner();
            for (int i = 0; i < ManaPoint; i++)
            {
                GameObject clone = Instantiate(prefabMana);
                clone.transform.SetParent(gameObject.transform);
                drawnObjects++;
            }

            if (ManaPoint < 1)
            {
                Player.instance.PlaySound(noManaSound);
            }
        }

        private void GarbageCleaner()
        {
            for (int i = 0; i < drawnObjects; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            drawnObjects = 0;
        }
    }
}