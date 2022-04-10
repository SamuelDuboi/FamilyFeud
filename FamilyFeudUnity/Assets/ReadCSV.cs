using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
public class ReadCSV : MonoBehaviour
{
    public List<Reponses> reponses = new List<Reponses>();
    // Start is called before the first frame update
    void Start()
    {
        ReadCsv();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReadCsv()
    {
        var csv = new List<string[]>(); // or, List<YourClass>
        var guiPath = AssetDatabase.FindAssets("Answers");
        var dataPath = AssetDatabase.GUIDToAssetPath(guiPath[0]);
        var lines = File.ReadAllLines(dataPath);
        foreach (string line in lines)
            csv.Add(line.Split(';')); // or, populate YourClass
        csv.RemoveAt(0);
        //save = new Save();
        foreach (var answer in csv)
        {
            var reponse = new List<string>();
            var pourcentage = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                reponse.Add(answer[1 + 2 * i]);
                pourcentage.Add(int.Parse(answer[2 + 2 * i]));
            }
            reponses.Add(new Reponses(reponse.ToArray(), pourcentage.ToArray(), answer[0]));
        }

    }
}
