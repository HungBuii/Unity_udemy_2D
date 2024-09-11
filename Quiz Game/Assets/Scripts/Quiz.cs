using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;

    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    // Start is called before the first frame update
    void Start()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>(); // Button: https://docs.unity3d.com/2019.1/Documentation/ScriptReference/UI.Button.html
            buttonText.text = question.GetAnswer(i);
        }
    }
    
    public void OnAnswerSelected(int index)
    {
        
        Image buttonImage;

        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";
            buttonImage = answerButtons[index].GetComponentInChildren<Image>(); 

            buttonImage.sprite = correctAnswerSprite; // Image.Sprite: https://docs.unity3d.com/2019.1/Documentation/ScriptReference/UI.Image-sprite.html
                                                      // Sprite: https://docs.unity3d.com/2019.1/Documentation/ScriptReference/Sprite.html
        }

        else 
        {
            correctAnswerIndex = question.GetCorrectAnswerIndex();

            questionText.text = "Sorry, the correct answer was: \n" + question.GetAnswer(correctAnswerIndex);

            buttonImage = answerButtons[correctAnswerIndex].GetComponentInChildren<Image>(); 
            buttonImage.sprite = correctAnswerSprite;
        }
    }
}
