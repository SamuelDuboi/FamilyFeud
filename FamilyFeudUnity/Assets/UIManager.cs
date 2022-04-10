using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public ReadCSV readCSV;
    public List<TextMeshProUGUI> texts;
    public TextMeshProUGUI question;
    public TextMeshProUGUI team1Score;
    public TextMeshProUGUI team2Score;
    public TMP_InputField currentSlide;
    public int currentNumber;
    public GameObject titre;
    public AudioSource mainSound;
    public AudioSource yes;
    public AudioSource no;

    // Update is called once per frame
    void Update()
    {
        #region player1
        if (Input.GetKeyDown(KeyCode.A))
        {
            ActiveNumber1(0);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ActiveNumber1(1);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActiveNumber1(2);

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ActiveNumber1(3);

        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            ActiveNumber1(4);

        }
        #endregion
        #region player2
        if (Input.GetKeyDown(KeyCode.W))
        {
            ActiveNumber2(0);

        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ActiveNumber2(1);

        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ActiveNumber2(2);

        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            ActiveNumber2(3);

        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            ActiveNumber2(4);

        }
        #endregion
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeNumber(1);
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            no.Play();
    }
    private void ActiveNumber1(int number )
    {
        if (texts[number].text != number.ToString())
            return;
        yes.Play();
        texts[number].text = readCSV.reponses[currentNumber].answers[number] + " " + readCSV.reponses[currentNumber].purcentages[number];
        int score = int.Parse(team1Score.text);
        score += readCSV.reponses[currentNumber].purcentages[number];
        team1Score.text = score.ToString();
    }
    private void ActiveNumber2(int number)
    {
        if (texts[number].text != number.ToString())
            return;
        yes.Play();
        texts[number].text = readCSV.reponses[currentNumber].answers[number] + " " + readCSV.reponses[currentNumber].purcentages[number];
        int score = int.Parse(team2Score.text);
        score += readCSV.reponses[currentNumber].purcentages[number];
        team2Score.text = score.ToString();
    }

    public void ChangeNumber()
    {
        titre.SetActive(false);
        mainSound.Stop();
        string value = currentSlide.text;
        currentNumber =(int) float.Parse(value);
        question.text = readCSV.reponses[currentNumber].question;
        for (int i = 0; i < texts.Count; i++)
        {
            texts[i].text = (i+1).ToString();
        }
    }
    public void ChangeNumber(int nextNumber)
    {
        titre.SetActive(false);
        mainSound.Stop();
        currentNumber += nextNumber;
        currentSlide.text = currentNumber.ToString();
        question.text = readCSV.reponses[currentNumber].question;
        for (int i = 0; i < texts.Count; i++)
        {
            texts[i].text = i.ToString();
        }
    }
}
