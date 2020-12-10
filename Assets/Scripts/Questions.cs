using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Question",menuName ="Quiz")]
public class Questions : ScriptableObject
{
    public string question;
    public string[] answers;
    public string correctAnswer;
}
