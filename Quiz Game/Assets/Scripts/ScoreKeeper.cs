using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers = 0;
    int questionsSeen = 0;

    public int GetCorrectAnswers()
    {
        return correctAnswers;
    }

    public void IncrementCorrectAnswers()
    {
        correctAnswers++;
    }

    public int GetQuestionSeen()
    {
        return questionsSeen;
    }

    public void IncrementQuestionSeen()
    {
        questionsSeen++;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(correctAnswers / (float)questionsSeen * 100); // Mathf.RoundToInt: https://docs.unity3d.com/ScriptReference/Mathf.RoundToInt.html
                                                                              // Casting and type conversions: https://learn.microsoft.com/vi-vn/dotnet/csharp/programming-guide/types/casting-and-type-conversions 
    }
}
