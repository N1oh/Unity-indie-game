using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Update()
    {
        // Esc Ű�� ������ option ������ ��ȯ
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Option");
        }
    }
}