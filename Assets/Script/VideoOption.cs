using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoOption : MonoBehaviour
{
    // ��ü ȭ�� ��带 ������ ����
    FullScreenMode screenMode;

    // �ػ� ������ ���� ��Ӵٿ� UI�� ������ ����
    public Dropdown resolutionDropdown;

    // ��ü ȭ�� ��� ��ư�� ������ ����
    public Toggle fullscreenBtn;

    // ������ �ػ� ����� ������ ����Ʈ
    List<Resolution> resolutions = new List<Resolution>();

    // ���õ� �ػ��� �ε����� ������ ����
    public int resolutionNum;

    void Start()
    {
        // UI �ʱ�ȭ �Լ� ȣ��
        InitUI();
    }

    // UI�� �ʱ�ȭ�ϴ� �Լ�
    void InitUI()
    {
        // ȭ�� �ػ� �� �ֻ����� 60�� �͸� �߰�
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRate == 60)
            {
                resolutions.Add(Screen.resolutions[i]);
            }
        }

        // ��Ӵٿ� �ɼ� �ʱ�ȭ
        resolutionDropdown.options.Clear();

        int optionNum = 0;
        // ������ �ػ� ����� ��Ӵٿ �߰��ϰ� ���� �ػ󵵿� �ش��ϴ� �ɼ��� ����
        foreach (Resolution item in resolutions)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRate + "hz";
            resolutionDropdown.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height)
            {
                resolutionDropdown.value = optionNum;
            }
            optionNum++;
        }
        // ��Ӵٿ� ���� ����
        resolutionDropdown.RefreshShownValue();

        // ��ü ȭ�� ��� ��ư �ʱ�ȭ
        fullscreenBtn.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;
    }

    // ��Ӵٿ� �ɼ��� ����Ǿ��� �� ȣ��Ǵ� �Լ�
    public void DropboxOptionChange(int x)
    {
        // ���õ� �ػ��� �ε����� ����
        resolutionNum = x;
    }

    // ��ü ȭ�� ��� ��ư�� ����Ǿ��� �� ȣ��Ǵ� �Լ�
    public void FullScreenBtn(bool isFull)
    {
        // ��ü ȭ�� ��带 ����
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    // Ȯ�� ��ư�� Ŭ���Ǿ��� �� ȣ��Ǵ� �Լ�
    public void OkBtnClick()
    {
        // ���õ� �ػ󵵿� ��ü ȭ�� ���� ȭ�� ���� ����
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, screenMode);
    }
}
