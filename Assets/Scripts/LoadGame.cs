using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    //Transition from "Tutorial" Scene to "Test" (Main Game) Scene on button press
    public void onButtonPress()
    {
        SceneManager.LoadScene("Test");
    }
}
