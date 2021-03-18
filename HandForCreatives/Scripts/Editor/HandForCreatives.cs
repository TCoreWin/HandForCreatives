using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SquareDino.HFC
{   
    public class HandForCreatives : EditorWindow
    {
        private static bool enable;
        private const string enableKey = "enableHandForCreativesKey";

        private Color _color = Color.white;
        private float sizeMultiply = 1f;
        
        [MenuItem("Window/SquareDino/HandForCreatives")]
        static void Init()
        {
            HandForCreatives window = (HandForCreatives) GetWindow(typeof(HandForCreatives), false, "HandForCreatives", true);
            window.maxSize = new Vector2(300f, 120f);
            window.minSize = window.maxSize;
        }
        
        private void OnGUI()
        {
            GUILayout.BeginHorizontal("box");
                EditorGUILayout.LabelField("Icon color", GUILayout.Width(90));
                _color = EditorGUILayout.ColorField(_color);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal("box");
                EditorGUILayout.LabelField("Size multiply", GUILayout.Width(90));
                sizeMultiply = EditorGUILayout.FloatField(sizeMultiply);
            GUILayout.EndHorizontal();
            
            
            GUILayout.BeginHorizontal("box");
                GUI.enabled = !enable;
                
                if (GUILayout.Button("Enable", GUILayout.Height(50)))
                {    
                    enable = true;    
                    EditorPrefs.SetInt(enableKey, 1);
                }   
                
                GUI.enabled = enable;
                
                if (GUILayout.Button("Disable", GUILayout.Height(50)))
                {
                    enable = false;
                    EditorPrefs.SetInt(enableKey, 0);
                } 
            GUILayout.EndHorizontal();
        }
        
        private void OnEnable()
        {
            enable = EditorPrefs.GetInt(enableKey, 0) == 1;
            
            SceneManager.sceneLoaded -= SceneLoaded;
            SceneManager.sceneLoaded += SceneLoaded;
        }

        private void SceneLoaded(Scene arg0, LoadSceneMode loadSceneMode)
        {
            if(!enable) return;
            
            SpawnHand();
        }

        private void SpawnHand()
        {
            var canvasGO = new GameObject("HandCanvas");
            var mouseIconGO = new GameObject("MouseIcon");
            
            var canvas = canvasGO.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            
            var handView = mouseIconGO.AddComponent<HandView>();
            handView.transform.SetParent(canvas.transform);
            handView.Init(HandForCreativesUIStyleManager.hand_idle, HandForCreativesUIStyleManager.hand_click, _color, sizeMultiply);
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= SceneLoaded;
        }
    }
}
