using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(AllMyReponses))]
public class Popuate : Editor
{
    AllMyReponses targetA;

    private void OnEnable()
    {
        targetA = target as AllMyReponses;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Populate")){ ReadCSV.ReadCsv(out targetA.answers); }
        EditorUtility.SetDirty(targetA);
        serializedObject.ApplyModifiedProperties();
        
    }
}
