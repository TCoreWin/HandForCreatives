using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SquareDino.HFC
{
    public static class HandForCreativesUIStyleManager
    {
        public static Sprite hand_idle;
        public static Sprite hand_click;

        static HandForCreativesUIStyleManager()
        {
            var hfcAssetFolderPath = HandForCreativesEditorUtility.packageRelativePath;

            hand_idle = AssetDatabase.LoadAssetAtPath(hfcAssetFolderPath + "/Editor Resources/hand_idle.png", typeof(Sprite)) as Sprite;
            hand_click = AssetDatabase.LoadAssetAtPath(hfcAssetFolderPath + "/Editor Resources/hand_click.png", typeof(Sprite)) as Sprite;
        }
    }
}