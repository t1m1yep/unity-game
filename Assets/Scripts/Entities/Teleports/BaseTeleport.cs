using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Content.UI;

namespace Entities.Teleports
{
    public class BaseTeleport : MonoBehaviour
    {
        public GameObject teleport2;
        public float cooldown = 3f;
        public bool canTeleport = true;
        public string errorText = "You cant teleport.";

        private List<string> ApprovedObjectTag = new List<string> { "Player", "Mouse" }; 
        

        private void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log("called oncollisionenter2d");
            if (ApprovedObjectTag.Contains(col.gameObject.tag))
            {
                Debug.Log($"Touched {col.gameObject.tag}");
                Teleport(col.gameObject);
            }
        }

        private void Teleport(GameObject targetObject)
        {
            if (canTeleport && teleport2.GetComponent<BaseTeleport>().canTeleport)
            {
                targetObject.transform.position = teleport2.transform.position;
                Debug.Log("Teleported object");
                canTeleport = false;
                StartCoroutine(Wait(cooldown));
            }
            else
            {
                PlayerText.instance.ChangeText(errorText);
            }
        }
        IEnumerator Wait(float time)
        {
            yield return new WaitForSeconds(time);
            canTeleport = true;
        }
    }
}
