using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Runtime
{
    namespace CombatSystem
    {
        namespace UI
        {
            public class SpellBoardGUI : MonoBehaviour
            {

                #region Public variables

                public const float SPACING = 0.01f;
                public GameObject pnl_word, pnl_keys;
                public GameObject prefab;

                #endregion

                #region Private fields

                private SpellerPlayer player;
                private List<GameObject> keyButtons;
                private List<GameObject> wordLetters;

                #endregion

                #region Unity CallBacks and public methods

                // Inicializa las estructuras de datos
                public void Awake()
                {
                    keyButtons = new List<GameObject>();
                    wordLetters = new List<GameObject>();
                    FindObjectOfType<Battle>().OnSetSpellerPlayerEvent += (_) => SubscribeToEvents();
                }

                // Suscribe el controlador GUI a los eventos del jugador
                public void SubscribeToEvents()
                {
                    Debug.Log("Tablero suscrito a eventos del jugador");
                    player = FindObjectOfType<SpellerPlayer>();
                    player.board.OnGenerateBoardEvent += GenerateBoardGUI;
                    player.board.OnHitKeyEvent += DisableKeyButton;
                    player.board.OnFailKeyEvent += DisableLayout;
                    player.board.OnCompleteWordEvent += DisableLayout;
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

                // Genera la palabra de la cabecera
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
                private void DisableKeyButton(int id, int currentCharIdx)
                {
                    keyButtons[id].SetActive(false);
                    wordLetters[currentCharIdx].SetActive(false);
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

                // Pone la letra correspondiente al botón
                private void SetText(Text text, char c)
                {
                    text.text = "" + c;
                }

                // Establece el evento de pulsar tecla para el boton correspondiente
                private void SetEvent(Button b, int i, int j)
                {
                    b.onClick.AddListener(() => player?.OnKey(i, j));
                }

                #endregion
            }
        } 
    }
}