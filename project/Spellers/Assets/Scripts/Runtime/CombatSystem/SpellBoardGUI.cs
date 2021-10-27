using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime.CombatSystem
{
    public class SpellBoardGUI : MonoBehaviour
    {

        #region Public variables

        public const float SPACING = 0.01f;
        public GameObject pnl_word, pnl_keys;
        public GameObject prefab;
        public SpellerPlayer speller;

        #endregion

        #region Private fields

        private List<GameObject> keyButtons;
        private List<GameObject> wordLetters;

        #endregion

        #region Unity CallBacks

        public void Awake()
        {
            keyButtons = new List<GameObject>();
            wordLetters = new List<GameObject>();
            speller.board.OnGenerateBoardEvent += GenerateBoardGUI;
            speller.board.OnHitKeyEvent += DisableKeyButton;
            speller.board.OnCompleteWordEvent += DisableLayout;
        }
       
        #endregion

        #region Private Methods

        // Genera los botones del teclado
        private void GenerateBoardGUI(char[] keys, int dim, string word)
        {
            GenerateHeader(word);
            float size = Mathf.Max((1 - (dim - 1) * SPACING) / dim, 0);
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    var go = Instantiate(prefab, pnl_keys.transform);
                    keyButtons.Add(go);
                    var rt = go.GetComponent<RectTransform>();
                    rt.anchorMin = new Vector2(j * (size + SPACING), i * (size + SPACING));
                    rt.anchorMax = rt.anchorMin + new Vector2(size, size);

                    var button = go.GetComponent<Button>();
                    SetEvent(button, j, i);

                    var text = go.GetComponentInChildren<Text>();
                    SetText(text, keys[i * dim + j]);
                }
            }
        }

        private void GenerateHeader(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                var go = Instantiate(prefab, pnl_word.transform);
                wordLetters.Add(go);
                var rt = go.GetComponent<RectTransform>();
                rt.anchorMin = new Vector2(i * 0.1f + 0.05f, 0.05f);
                rt.anchorMax = rt.anchorMin + new Vector2(0.09f, 0.9f);

                var text = go.GetComponentInChildren<Text>();
                SetText(text, s[i]);
            }
        }

        // Desactiva un boton
        private void DisableKeyButton(int id)
        {
            keyButtons[id].SetActive(false);
        }


        // Desactiva el teclado
        private void DisableLayout()
        {
            foreach (var go in keyButtons)
            {
                Destroy(go);
            }
            keyButtons.Clear();
            foreach (var go in wordLetters)
            {
                Destroy(go);
            }
            wordLetters.Clear();

        }

        private void SetText(Text text, char c)
        {
            text.text = "" + c;
        }

        private void SetEvent(Button b, int i, int j)
        {
            b.onClick.AddListener(() => speller.OnKey(i, j));
        }

        #endregion
    }
}