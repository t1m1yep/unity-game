using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Content.Toolshed
{
    public sealed class ManageScene : MonoBehaviour
    {
        public static ManageScene instance; // creating singleton

        void Start()
        {
            instance = this; // making a definition for singleton
        }
        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Getting active scene and restarting it
            Debug.Log("Succesfully restarted scene"); 
        }
    }
}