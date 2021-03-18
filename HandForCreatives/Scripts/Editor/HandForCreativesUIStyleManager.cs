using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SquareDino.HandForCreatives
{
    public class HandForCreativesUIStyleManager : MonoBehaviour
    {
        public static GameObject handView;

        static HandForCreativesUIStyleManager()
        {
            var tmproAssetFolderPath = HandForCreativesEditorUtility.packageRelativePath;

            handView = AssetDatabase.LoadAssetAtPath(tmproAssetFolderPath + "/Editor Resources/HandView", typeof(GameObject)) as GameObject;
        }
    }
}