using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public int SceneIndex;
   public void playGame ()
    {
        SceneManager.LoadScene(SceneIndex);

    }
}
