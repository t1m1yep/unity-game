using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Content.Toolshed
{
    public class PlayerCamera : MonoBehaviour
    {
        public static PlayerCamera instance;
        public float speed;
        public Transform target;
        void Start()
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
            instance = this;
        }
        void FixedUpdate()
        {
            Vector3 pos = target.position;
            pos.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, pos, speed * Time.deltaTime);
        }

        public void ChangePos(GameObject targetObj)
        {
            target = targetObj.transform;
            Debug.Log("Changed Camera position");
        }
    }
}