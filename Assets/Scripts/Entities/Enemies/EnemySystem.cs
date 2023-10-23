using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Enemies
{
    public class Enemy : MonoBehaviour 
    {
        public int maxHp;
        public int curHp;
        public int damageAmount;
        public string collisionTag;
        void Start() 
        {
            curHp = maxHp;
        }
        public void RecountHp(int hp)
        {
            if(curHp > 0)
            {
                curHp = curHp - hp;
            }
            else 
            {
                Destroy(gameObject);
            }
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == collisionTag) // checking if collisionTag is col
            {
                Player.instance.GetDamage(damageAmount); // Doing damage for collisionTag entity
                Debug.Log($"Damaged entity with tag {collisionTag} for {damageAmount}");
            }
        }
    }
}