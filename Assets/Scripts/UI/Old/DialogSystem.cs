
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI组件")] 
    public TMP_Text textLabel;
    public Image faceImage;

    [Header("文本文件")] 
    public TextAsset[] textFiles;
    public int index;
    public int line;
    public float textSpeed;

    [Header("头像")] 
    public Sprite face01;
    public Sprite face02;

    private bool textFinished;
    private bool cancelTypeing;

    private List<string> textList = new List<string>();

    private void OnEnable()
    {
        GetTextFormFile(textFiles[index]);
        StartCoroutine(SetTextUI());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (line == textList.Count)
            {
                gameObject.SetActive(false);
                line = 0;
                if (index < textFiles.Length - 1)
                {
                    index++;
                }
                return;
            }
            if (textFinished && !cancelTypeing)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished && !cancelTypeing)
            {
                cancelTypeing = !cancelTypeing;
            }
        }
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        line = 0;

        var lineData = file.text.Split('\n');

        foreach (var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";
        switch (textList[line].Trim())
        {
            case"0":
                faceImage.sprite = face01;
                line++;
                break;

            case "1":
                faceImage.sprite = face02;
                line++;
                break;
        }
        
        int letter = 0;
        while (!cancelTypeing && letter < textList[line].Length - 1)
        {
            textLabel.text += textList[line][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }

        textLabel.text = textList[line];
        cancelTypeing = false;
        textFinished = true;
        line++;
    }
}
