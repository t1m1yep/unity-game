using System;
using Content.UI;
using UnityEditor;
using UnityEngine;
using Entities.Enemies;

namespace Entities
{
    public class Gun : MonoBehaviour
    {
        public static Gun instance;
        private Vector3 dif;
        public float bulletSpeed;
        private Rigidbody2D rb;
        public AudioClip shotSound;
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            instance = this;
        }
        void Start()
        {
            dif = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotateZ = Mathf.Atan2(dif.y, dif.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ - 90); 
            rb.velocity = transform.up * bulletSpeed;
            GetComponent<AudioSource>().PlayOneShot(shotSound);
            Destroy(gameObject, 10f);
        }
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "Enemy")
            {
                col.GetComponent<Enemy>().RecountHp(1);
                Destroy(gameObject);
            }
            else if (col.tag == "Tilemap")
            {
                Destroy(gameObject);
            }
        }
    }
}