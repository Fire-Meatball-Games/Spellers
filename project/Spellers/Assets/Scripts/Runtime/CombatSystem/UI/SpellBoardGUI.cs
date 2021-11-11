using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CustomEventSystem;

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
                public Slider timer_slider;
                public GameObject key_prefab;

                #endregion

                #region Private fields
                private SpellBoard board;
                private List<GameObject> keyButtons;
                private List<GameObject> wordLetters;
                private int dim;
                private int current_char;

                #endregion

                #region Unity CallBacks and public methods

                // Inicializa las estructuras de datos
                public void Awake()
                {
                    keyButtons = new List<GameObject>();
                    wordLetters = new List<GameObject>();
                    Events.OnJoinPlayer.AddListener(()=> board = FindObjectOfType<SpellerPlayer>().board);
                    Events.OnGenerateBoard.AddListener(GenerateBoardGUI);
                    Events.OnGenerateWord.AddListener(GenerateWordGUI);
                    Events.OnCheckKey.AddListener((x, y, hit) =>
                    {
                        if (hit)
                            DisableKeyButton(x + dim*y);
                        else
                            DisableLayout();
                    });
                    Events.OnCompleteWord.AddListener(DisableLayout);
                    Events.OnFailSpell.AddListener(DisableLayout);
                    Events.OnSetTimer.AddListener((max) => timer_slider.maxValue = max);
                    Events.OnUpdateTimer.AddListener((value) => timer_slider.value = timer_slider.maxValue-value);
                }
                #endregion

                #region Private Methods

                // Genera los botones del teclado
                private void GenerateWordGUI(string word, bool flip = false)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        var go = Instantiate(key_prefab, pnl_word.transform);
                        wordLetters.Add(go);
                        var rt = go.GetComponent<RectTransform>();
                        rt.anchorMin = new Vector2(i * 0.1f + 0.05f, 0.05f);
                        rt.anchorMax = rt.anchorMin + new Vector2(0.09f, 0.9f);
                        if (flip) rt.localScale = new Vector3(-1, 1, 1);
                        var text = go.GetComponentInChildren<Text>();
                        SetText(text, word[i]);
                    }
                }

                private void GenerateBoardGUI(char[] keys, int dim)
                {
                    this.dim = dim;
                    this.current_char = 0;
                    float size = Mathf.Max((1 - (dim - 1) * SPACING) / dim, 0);
                    for (int i = 0; i < dim; i++)
                    {
                        for (int j = 0; j < dim; j++)
                        {
                            var go = Instantiate(key_prefab, pnl_keys.transform);
                            keyButtons.Add(go);
                            var rt = go.GetComponent<RectTransform>();
                            rt.anchorMin = new Vector2(j * (size + SPACING), 1 - ((i + 1) * size + i * SPACING));
                            rt.anchorMax = rt.anchorMin + new Vector2(size, size);

                            var button = go.GetComponent<Button>();
                            SetEvent(button, j, i);

                            var text = go.GetComponentInChildren<Text>();
                            SetText(text, keys[i * dim + j]);
                        }
                    }
                }

                // Desactiva un boton
                private void DisableKeyButton(int id)
                {
                    keyButtons[id].SetActive(false);
                    wordLetters[current_char].SetActive(false);
                    current_char++;
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
                    b.onClick.AddListener(() => FindObjectOfType<SpellerPlayer>()?.OnKey(i, j));
                }

                #endregion
            }
        } 
    }
}