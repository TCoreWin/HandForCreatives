using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SquareDino.HandForCreatives
{
    public class HandForCreativesUIStyleManager : MonoBehaviour
    {
        public static Texture2D handView;

        static HandForCreativesUIStyleManager()
        {
            var tmproAssetFolderPath = HandForCreativesEditorUtility.packageRelativePath;

            handView = AssetDatabase.LoadAssetAtPath(tmproAssetFolderPath + "/Editor Resources/HandView.png", typeof(Texture2D)) as Texture2D;
        }
    }
}