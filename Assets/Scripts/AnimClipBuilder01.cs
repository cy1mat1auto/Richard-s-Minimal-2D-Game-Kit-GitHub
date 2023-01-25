using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using UnityEditor;

public class AnimClipBuilder01 : MonoBehaviour
{
    public int PlinthNumber = 1;
    public Animator Anim;
    public AnimationClip IdleDown, WalkDown, WalkLeft, WalkRight, WalkUp;
    public Object[] UniqueSprites;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void BuildClip()
    {
        if (Anim != null)
        {
            if (IdleDown == null)
            {
                IdleDown = Anim.runtimeAnimatorController.animationClips[0];
            }

            if (WalkDown == null)
            {
                WalkDown = Anim.runtimeAnimatorController.animationClips[1];
            }

            if (WalkLeft == null)
            {
                WalkLeft = Anim.runtimeAnimatorController.animationClips[3];
            }

            if (WalkRight == null)
            {
                WalkRight = Anim.runtimeAnimatorController.animationClips[4];
            }

            if (WalkUp == null)
            {
                WalkUp = Anim.runtimeAnimatorController.animationClips[2];
            }
        }

        string PlinthPath = Application.dataPath + "/PlayerAlts/Plinth" + PlinthNumber.ToString() + "/Plinth" + PlinthNumber.ToString() + "Sprites.png";
        if (File.Exists(PlinthPath))
        {
            Debug.Log("Unique sprite sheet found for this plinth");

            UniqueSprites = AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/PlayerAlts/Plinth" + PlinthNumber.ToString() + "/Plinth" + PlinthNumber.ToString() + "Sprites.png");
            Debug.Log(UniqueSprites.Length);

            EditorCurveBinding spriteBinding = new EditorCurveBinding();
            spriteBinding.type = typeof(SpriteRenderer);
            spriteBinding.path = "";
            spriteBinding.propertyName = "m_Sprite";
            ObjectReferenceKeyframe[] spriteKeyFrames = new ObjectReferenceKeyframe[1];
            spriteKeyFrames[0] = new ObjectReferenceKeyframe();
            spriteKeyFrames[0].time = 0;
            spriteKeyFrames[0].value = UniqueSprites[0];

            AnimationUtility.SetObjectReferenceCurve(IdleDown, spriteBinding, spriteKeyFrames);
        }

        else if (File.Exists(Application.dataPath + "/PlayerAlts/"))
        {
            Debug.Log(File.Exists(Application.dataPath + "/PlayerAlts/"));
        }

        else
        {
            Debug.Log("No Sprite sheet found in" + "folder for Plinth" + PlinthNumber.ToString());
        }
    }
}

[CustomEditor(typeof(AnimClipBuilderEditorInternal))]
public class AnimClipBuilderEditorInternal : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AnimClipBuilder01 myScript = (AnimClipBuilder01)target;
        if (GUILayout.Button("Build Object"))
        {
            myScript.BuildClip();
        }
    }
}


