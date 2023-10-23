using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Content.Toolshed;
using Content.UI;
using Entities.Mouse;
using Unity.VisualScripting;

namespace Entities
{
    public class Player : MonoBehaviour
    {
        public static Player instance;
        Rigidbody2D rb;
        public float speed;
        public float jumpPower;
        bool groundCheck;
		public bool canMove;
        public int maxhp;
        public int curhp;
        public int manaEating;
        public GameObject bulletPrefab;
        public GameObject shootPos;
        public Action<int> onManaChange;
        public float gunCooldown;
        public bool ableToShoot = true;
        
		void Awake()        
		{
			instance = this;
		}
        void Start()
        {
            canMove = true;
            rb = GetComponent<Rigidbody2D>();
            maxhp = 10;
            curhp = maxhp;
        }
        void Update()
        {
            Jump();
            Flip();
            if (curhp < 1)
            {
                ManageScene.instance.RestartScene(); // using singleton
            }
            if (Input.GetMouseButton(0) && ableToShoot)
            {
                Shoot();
                ableToShoot = false;
                StartCoroutine(GunCooldown());
            }
        }
        void FixedUpdate() {
			if(canMove)
			{
				rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
			}
        }
        void Flip() {
            if(Input.GetAxis("Horizontal") > 0 && canMove)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if(Input.GetAxis("Horizontal") < 0 && canMove)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
        void Jump() {
            if(Input.GetKeyDown(KeyCode.Space) && Content.Toolshed.Physics.CheckGround(transform.GetChild(0)) && canMove) 
            {
                rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            }
        }

        public void GetDamage(int damage)
        {
            if (curhp > 1)
            {
                curhp = curhp - damage;
                HPBar.instance.HPRedraw();
                Debug.Log($"Player got damage: {curhp + damage} - {damage} = {curhp}");
            }
            else
            {
                ManageScene.instance.RestartScene();
            }
        }
		void OnCollisionEnter2D(Collision2D col) 
		{ 
			if (col.gameObject.tag == "Mouse") // checking if collisionTag is col
            {
                MouseSystem.instance.OnStart();
                Debug.Log($" Entered collison of Mouse");
            }
        }
        private void Shoot()
        {
            if (ManaBar.ManaPoint > 0)
            {
                Instantiate(bulletPrefab, shootPos.transform.position, Quaternion.identity);
                onManaChange?.Invoke(manaEating);
            }
            else
            {
                Debug.Log("Not enough mana");
            }
        }

        IEnumerator GunCooldown()
        {
            yield return new WaitForSeconds(gunCooldown);
            ableToShoot = true;
        }

        public void PlaySound(AudioClip sound)
        {
            GetComponent<AudioSource>().PlayOneShot(sound);
        }
    }
}

