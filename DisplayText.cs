using System.Collections;
using UnityEngine;
using TMPro;

public class DisplayText : MonoBehaviour
{
    private TextMeshProUGUI DialogueText;
    private bool IsDisplaying = false;

    #region Dialogues
    private string Dialogue01 = "You really don’t remember me? How rude, considering how I saved your life.R";
    private string Dialogue02 = "Your wounds still haven’t completely healed. I won’t tell you to back down, but try not to overdo it. I can’t have you dying before you pay me back for my… services…R";
    private string Dialogue03 = "Wai…! What was all that about? And what is this weird sensation I feel boiling inside?L";
    private string Dialogue04 = "Kekeke… You actually did it.R";
    private string Dialogue05 = "Who are you, anyway? What do you want from me?L";
    private string Dialogue06 = "I have been called many names, but they usually call me Kokugami.R";
    private string Dialogue07 = "You could consider subscribing and liking its free and it will help me a lot!! :D.R";
    private string[] DialogueArray;
    #endregion

    public AudioSource DemonSound;
    public AudioSource GuySound;
    public AudioSource Sound1;
    public AudioSource Sound2;
    public AudioSource Sound3;
    public AudioSource Sound4;

    private void Start()
    {
        DialogueText = GameObject.FindGameObjectWithTag("Text").GetComponent<TextMeshProUGUI>();

        DialogueArray = new string[7];
        DialogueArray[0] = Dialogue01;
        DialogueArray[1] = Dialogue02;
        DialogueArray[2] = Dialogue03;
        DialogueArray[3] = Dialogue04;
        DialogueArray[4] = Dialogue05;
        DialogueArray[5] = Dialogue06;
        DialogueArray[6] = Dialogue07;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && IsDisplaying == false)
        {
            IsDisplaying = true;
            StartCoroutine(DialogueDisplay(DialogueArray));
        }
    }

    private IEnumerator DialogueDisplay(string[] Dialogue)
    {
        for (int i = 0; i < Dialogue.Length; i++)
        {
            StringSplitter(Dialogue[i]);
            string[] Characters = new string[Dialogue[i].Length];

            yield return new WaitForSeconds((Characters.Length + 45) * 0.035f);
        }
    }

    private void StringSplitter(string Sentence)
    {
        DialogueText.text = "";
        string[] Characters = new string[Sentence.Length];

        for (int i = 0; i < Sentence.Length; i++)
        {
            Characters[i] = System.Convert.ToString(Sentence[i]);
        }
        StartCoroutine(StringDisplayDelay(Characters));
    }

    private IEnumerator StringDisplayDelay(string[] Characters)
    {
        for (int i = 0; i < Characters.Length - 1; i++)
        {
            DialogueText.text += Characters[i];

            if (Characters[Characters.Length - 1] == "R")
            {
                if (i % 6 == 0) DemonSound.Play();
                if (i % 3 == 0)
                {
                    int Randomint = Random.Range(0, 2);
                    if (Randomint == 0) Sound1.Play();                  
                    else Sound2.Play();
                }
            }
            else if (Characters[Characters.Length - 1] == "L")
            {
                if (i % 6 == 0) GuySound.Play();
                if (i % 3 == 0)
                {
                    int Randomint = Random.Range(0, 2);
                    if (Randomint == 0) Sound3.Play();
                    else Sound4.Play();
                }
            }

            yield return new WaitForSecondsRealtime(0.025f);
        }

        IsDisplaying = false;
    }
}
