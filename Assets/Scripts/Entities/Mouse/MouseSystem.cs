using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Content.Toolshed;

namespace Entities.Mouse
{
    public class MouseSystem : MonoBehaviour
    {
        public static MouseSystem instance;
        public GameObject player;
        public Transform startPos;
        public float speed;
        public float jumpPower;
        Rigidbody2D rb;
        public bool canMove;
        void Start()
        {
            canMove = false;
            rb = GetComponent<Rigidbody2D>();
            instance = this;
        }

        void Update()
        {
            Jump();
            Flip();
            if(Input.GetKeyDown(KeyCode.Escape) && canMove)
            {
                Debug.Log("CheckForMouseEnd called");
                OnEnd();
            }
        }
        void Jump() {
            if(Input.GetKeyDown(KeyCode.Space) && Content.Toolshed.Physics.CheckGround(transform.GetChild(0)) && canMove)
            {
                rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            }
        }   
        void Flip() {
            if(Input.GetAxis("Horizontal") < 0 && canMove)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            if(Input.GetAxis("Horizontal") > 0 && canMove)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
        public void OnStart()
        {
            if (canMove == true)
            {
                OnEnd();
                StartCoroutine(Wait(5.0f));
            }
            else
            {
                PlayerCamera.instance.ChangePos(gameObject);
                Player.instance.canMove = false;
                canMove = true;
                StartCoroutine(Wait(5.0f));
            }

        }
        void FixedUpdate() {
            if(canMove)
            { 
                rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
            }
        }
        public void OnEnd()
        {
            PlayerCamera.instance.ChangePos(player);
            Player.instance.canMove = true;
            transform.position = startPos.position;
            canMove = false;
        }

        private IEnumerator Wait(float time)
        {
            yield return new WaitForSeconds(time);
        }
    }
    
}