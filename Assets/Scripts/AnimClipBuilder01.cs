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
            //The following will assign new sprites for the idle animation:
            spriteKeyFrames[0] = new ObjectReferenceKeyframe();
            spriteKeyFrames[0].time = 0;
            spriteKeyFrames[0].value = UniqueSprites[1];

            AnimationUtility.SetObjectReferenceCurve(IdleDown, spriteBinding, spriteKeyFrames);

            //The following will assign new sprites for the WalkDown animation:
            spriteKeyFrames = new ObjectReferenceKeyframe[4];
            for (int i = 0; i < 4; i++)
            {
                spriteKeyFrames[i] = new ObjectReferenceKeyframe();
                if (i == 0)
                {
                    spriteKeyFrames[i].value = UniqueSprites[0];
                    spriteKeyFrames[i].time = i / WalkDown.frameRate;
                }
                
                else if (i == 1)
                {
                    spriteKeyFrames[i].value = UniqueSprites[1];
                    spriteKeyFrames[i].time = i / WalkDown.frameRate * 2;
                }

                else if (i == 2)
                {
                    spriteKeyFrames[i].value = UniqueSprites[2];
                    spriteKeyFrames[i].time = i / WalkDown.frameRate * 2;
                }

                else if (i == 3)
                {
                    spriteKeyFrames[i].value = UniqueSprites[1];
                    spriteKeyFrames[i].time = i / WalkDown.frameRate * 2;
                }
            }

            AnimationUtility.SetObjectReferenceCurve(WalkDown, spriteBinding, spriteKeyFrames);

            //The following will assign new sprites for the WalkLeft animation:
            spriteKeyFrames = new ObjectReferenceKeyframe[4];
            for (int i = 0; i < 4; i++)
            {
                spriteKeyFrames[i] = new ObjectReferenceKeyframe();
                if (i == 0)
                {
                    spriteKeyFrames[i].value = UniqueSprites[9];
                    spriteKeyFrames[i].time = i / WalkLeft.frameRate;
                }

                else if (i == 1)
                {
                    spriteKeyFrames[i].value = UniqueSprites[10];
                    spriteKeyFrames[i].time = i / WalkLeft.frameRate * 2;
                }

                else if (i == 2)
                {
                    spriteKeyFrames[i].value = UniqueSprites[11];
                    spriteKeyFrames[i].time = i / WalkLeft.frameRate * 2;
                }

                else if (i == 3)
                {
                    spriteKeyFrames[i].value = UniqueSprites[10];
                    spriteKeyFrames[i].time = i / WalkLeft.frameRate * 2;
                }
            }

            AnimationUtility.SetObjectReferenceCurve(WalkLeft, spriteBinding, spriteKeyFrames);

            //The following will assign new sprites for the WalkRight animation:
            spriteKeyFrames = new ObjectReferenceKeyframe[4];
            for (int i = 0; i < 4; i++)
            {
                spriteKeyFrames[i] = new ObjectReferenceKeyframe();
                if (i == 0)
                {
                    spriteKeyFrames[i].value = UniqueSprites[3];
                    spriteKeyFrames[i].time = i / WalkRight.frameRate;
                }

                else if (i == 1)
                {
                    spriteKeyFrames[i].value = UniqueSprites[4];
                    spriteKeyFrames[i].time = i / WalkRight.frameRate * 2;
                }

                else if (i == 2)
                {
                    spriteKeyFrames[i].value = UniqueSprites[5];
                    spriteKeyFrames[i].time = i / WalkRight.frameRate * 2;
                }

                else if (i == 3)
                {
                    spriteKeyFrames[i].value = UniqueSprites[4];
                    spriteKeyFrames[i].time = i / WalkRight.frameRate * 2;
                }
            }

            AnimationUtility.SetObjectReferenceCurve(WalkRight, spriteBinding, spriteKeyFrames);

            //The following will assign new sprites for the WalkUp animation:
            spriteKeyFrames = new ObjectReferenceKeyframe[4];
            for (int i = 0; i < 4; i++)
            {
                spriteKeyFrames[i] = new ObjectReferenceKeyframe();
                if (i == 0)
                {
                    spriteKeyFrames[i].value = UniqueSprites[6];
                    spriteKeyFrames[i].time = i / WalkUp.frameRate;
                }

                else if (i == 1)
                {
                    spriteKeyFrames[i].value = UniqueSprites[7];
                    spriteKeyFrames[i].time = i / WalkUp.frameRate * 2;
                }

                else if (i == 2)
                {
                    spriteKeyFrames[i].value = UniqueSprites[8];
                    spriteKeyFrames[i].time = i / WalkUp.frameRate * 2;
                }

                else if (i == 3)
                {
                    spriteKeyFrames[i].value = UniqueSprites[7];
                    spriteKeyFrames[i].time = i / WalkUp.frameRate * 2;
                }
            }

            AnimationUtility.SetObjectReferenceCurve(WalkUp, spriteBinding, spriteKeyFrames);
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


