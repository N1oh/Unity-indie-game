using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // ���� �Ͻ� ���� UI�� ������ GameObject ����
    public GameObject PauseUI;

    // ������ �Ͻ� �����Ǿ������� ��Ÿ���� �Ҹ��� ����
    private bool paused = false;

    // Start �Լ��� ó�� �� �� ȣ��˴ϴ�.
    void Start()
    {
        // ���� �� �Ͻ� ���� UI�� ��Ȱ��ȭ�մϴ�.
        PauseUI.SetActive(false);
    }

    // Update �Լ��� �� �����Ӹ��� ȣ��˴ϴ�.
    void Update()
    {
        // "Pause" �Է��� �����Ǹ�
        if (Input.GetButtonDown("Pause"))
        {
            // �Ͻ� ���� ���¸� ������ŵ�ϴ�.
            paused = !paused;
        }

        // ���� ������ �Ͻ� ���� ���¶��
        if (paused)
        {
            // �Ͻ� ���� UI�� Ȱ��ȭ�ϰ� �ð��� ����ϴ�.
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        else // �Ͻ� ���� ���°� �ƴ϶��
        {
            // �Ͻ� ���� UI�� ��Ȱ��ȭ�ϰ� �ð��� ���������� �����մϴ�.
            PauseUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    // Resume �Լ��� �簳 ��ư�� ������ �� ȣ��˴ϴ�.
    public void Resume()
    {
        // �Ͻ� ���� ���¸� ������ŵ�ϴ�.
        paused = !paused;
    }
}
