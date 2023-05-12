using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Dialogsystem : MonoBehaviour
{
    [Header("UI assets")]
    public TMP_Text textLabel;
    public Image faceImage;
    public Image imgPicture;

    [Header("Text assets")]
    public TextAsset textFile;
    public int index;
    public float textSpeed;

    [Header("Face")]
    public Sprite face01, face02;

    bool textFinished;
    bool cancelTyping;

    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFormFile(textFile);
    }
    private void OnEnable()
    {
        //textLabel.text = textList[index];
        //index++;
        textFinished = true;
        StartCoroutine(SetTextUI());
        imgPicture.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && index == textList.Count )
        {
            gameObject.SetActive(false);
            index = 0;
            return;
        }
        //if(Input.GetKeyDown(KeyCode.F) && textFinished)
        //{
        //textLabel.text = textList[index];
        //index++;
        //StartCoroutine(SetTextUI());
        //}    
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (textFinished && !cancelTyping)
            {
                StartCoroutine(SetTextUI());
            }
            else if (!textFinished && !cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var LineDate = file.text.Split('\n');

        foreach (var line in LineDate)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";

        switch (textList [index].Trim().ToString())
        {
            case "Lady":
                faceImage.sprite = face01;
                index++;
                break;

            case "Baker":
                faceImage.sprite = face02;
                index++;
                break;

            case "HidePicture":
                imgPicture.DOFade(0, 0.5f);
                yield return new WaitForSeconds(0.5f);
                imgPicture.gameObject.SetActive(false);
                index++;
                yield return StartCoroutine(SetTextUI());
                yield break;
            case "PictureNoWait":
                imgPicture.gameObject.SetActive(true);
                index++;
                imgPicture.sprite = Resources.Load<Sprite>(textList[index].Trim().ToString());
                imgPicture.DOFade(1f, 0.5f);
                index++;
                yield return StartCoroutine(SetTextUI());
                yield break;
            case "Picture":
                imgPicture.gameObject.SetActive(true);
                index++;
                imgPicture.sprite = Resources.Load<Sprite>(textList[index].Trim().ToString());
                imgPicture.DOFade(1f, 0.5f);
                index++;
                cancelTyping = false;
                textFinished = true;
                yield break;
        }

        //for (int i = 0; i < textList[index].Length; i ++)
        //{
        //textLabel.text += textList[index][i];

        //yield return new WaitForSeconds(textSpeed);
        //}

        int letter = 0;
        while (!cancelTyping && letter < textList[index].Length -1)
        {
            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }
        textLabel.text = textList[index];
        cancelTyping = false;
        textFinished = true;
        index++;
    }
}
