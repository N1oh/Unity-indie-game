using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Scene ���� ����� ����ϱ� ���� ���ӽ����̽� �߰�

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue; // ��ȭ ������ �����ϴ� ����
    public Sprite cg; // ��ȭ �߿� ǥ���� �̹����� �����ϴ� ����
    public bool isLeft; // �̹����� ���ʿ� ǥ������ ���θ� ��Ÿ���� ����
}

public class Dialog : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_StandingCG; // ĳ���� �̹����� ǥ���ϴ� SpriteRenderer
    [SerializeField] private SpriteRenderer sprite_DialogueBox; // ��ȭ ���ڸ� ǥ���ϴ� SpriteRenderer
    [SerializeField] private Text txt_Dialogue; // ��ȭ �ؽ�Ʈ�� ǥ���ϴ� Text ������Ʈ
    [SerializeField] private Vector2 leftPosition; // ���ʿ� ǥ���� ��ǥ
    [SerializeField] private Vector2 rightPosition;// �����ʿ� ǥ���� ��ǥ

    [SerializeField] private Dialogue[] dialogue; // ��ȭ ������ ��� �ִ� �迭


    private bool isDialogue = false; // ��ȭ ������ ���θ� ��Ÿ���� �÷���
    private int count = 0; // ���� ��ȭ �ε����� �����ϴ� ����

    // ��ȭ ���� �޼���
    public void ShowDialogue()
    {
        OnOff(true); // ��ȭ ����, ĳ���� �̹���, ��ȭ �ؽ�Ʈ�� ȭ�鿡 ǥ��
        count = 0; // ��ȭ �ε��� �ʱ�ȭ
        NextDialogue(); // ù ��° ��ȭ�� �̵�
    }

    // UI ��Ҹ� Ȱ��ȭ �Ǵ� ��Ȱ��ȭ�ϴ� �޼���
    private void OnOff(bool _flag)
    {
        sprite_DialogueBox.gameObject.SetActive(_flag);
        sprite_StandingCG.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    // ���� ��ȭ�� �̵��ϴ� �޼���
    private void NextDialogue()
    {
        txt_Dialogue.text = dialogue[count].dialogue; // ��ȭ �ؽ�Ʈ ������Ʈ
        sprite_StandingCG.sprite = dialogue[count].cg; // ĳ���� �̹��� ������Ʈ

        // �̹��� ��ġ�� ����
        if (dialogue[count].isLeft)
        {
            sprite_StandingCG.transform.localPosition = leftPosition; // ���ʿ� ǥ��
        }
        else
        {
            sprite_StandingCG.transform.localPosition = rightPosition; // �����ʿ� ǥ��
        }

        count++; // ���� ��ȭ�� �̵�
    }

    void Update()
    {
        // ������ ���� �������� Ȯ��
        if (Time.timeScale != 0)
        {
            // ��ȭ ���� ��
            if (isDialogue)
            {
                // ���콺 ���� ��ư�� Ŭ������ ��
                if (Input.GetMouseButtonDown(0))
                {
                    // ��ȭ�� �������� ���
                    if (count < dialogue.Length)
                    {
                        NextDialogue(); // ���� ��ȭ�� �̵�
                    }
                    // ��ȭ�� ������ ���
                    else
                    {
                        OnOff(false); // ��� ��ȭ�� ������ ��ȭ ����
                        SceneManager.LoadScene("BattleScene");
                    }
                }
            }
        }
    }
}

