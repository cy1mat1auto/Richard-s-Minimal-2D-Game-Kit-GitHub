using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


    [CustomEditor(typeof(AnimClipBuilder01))]
    public class AnimClipBuilderEditor01 : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            AnimClipBuilder01 myScript = (AnimClipBuilder01)target;
            if (GUILayout.Button("Auto Reanimate"))
            {
                myScript.BuildClip();
            }
        }
    }
