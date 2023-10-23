using UnityEngine;
using UnityEngine.UI;

namespace Content.UI
{
    public sealed class PlayerText : MonoBehaviour
    {
        public static PlayerText instance;
        void Awake()
        {
            instance = this;
        }
        public void ChangeText(string UserDisplayText)
        {
            gameObject.GetComponent<Text>().text = UserDisplayText;
            Debug.Log($"Changed text to {UserDisplayText}");
        }
    }
}