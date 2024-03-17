using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Update()
    {
        // Esc 키를 누르면 option 씬으로 전환
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Option");
        }
    }
}
