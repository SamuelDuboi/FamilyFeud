using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Reponses 
{
    public string[] answers;
    public int[] purcentages;
    public string question;
    public Reponses(string[]a,int[]p,string q)
    {
        answers = a;
        purcentages = p;
        question = q;
    }
}
