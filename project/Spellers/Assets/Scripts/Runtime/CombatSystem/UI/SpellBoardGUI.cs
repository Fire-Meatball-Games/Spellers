using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CustomEventSystem;
using TMPro;

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
                public TextMeshProUGUI word_text;
                public Slider timer_slider;
                public GameObject key_prefab;

                #endregion

                #region Private fields
                private SpellBoard board;
                private List<Key> keyButtons;
                private int dim;

                #endregion

                #region Unity CallBacks and public methods

                // Inicializa las estructuras de datos
                public void Awake()
                {
                    keyButtons = new List<Key>();
                 
                }

                private void OnEnable()
                {
                    Events.OnJoinPlayer.AddListener(SetBoard);
                    Events.OnGenerateBoard.AddListener(GenerateBoardGUI);
                    Events.OnGenerateWord.AddListener(GenerateWordGUI);
                    Events.OnCheckKey.AddListener(CheckKey);
                    Events.OnCompleteWord.AddListener(DisableLayout);
                    Events.OnFailSpell.AddListener(DisableLayout);
                    Events.OnSetTimer.AddListener(SetTotalTime);
                    Events.OnUpdateTimer.AddListener(SetCurrentTime);
                }

                private void OnDisable()
                {
                    Events.OnJoinPlayer.RemoveListener(SetBoard);
                    Events.OnGenerateBoard.RemoveListener(GenerateBoardGUI);
                    Events.OnGenerateWord.RemoveListener(GenerateWordGUI);
                    Events.OnCheckKey.RemoveListener(CheckKey);
                    Events.OnCompleteWord.RemoveListener(DisableLayout);
                    Events.OnFailSpell.RemoveListener(DisableLayout);
                    Events.OnSetTimer.RemoveListener(SetTotalTime);
                    Events.OnUpdateTimer.RemoveListener(SetCurrentTime);
                }


                #endregion

                #region Private Methods

                private void SetBoard()
                {
                    board = FindObjectOfType<SpellerPlayer>().board;
                }

                private void CheckKey(int x, int y, bool hit)
                {
                    if (hit)
                        DisableKeyButton(x + dim * y);
                    else
                        DisableLayout();
                }

                private void SetTotalTime(int time) => timer_slider.maxValue = time;
                private void SetCurrentTime(int time) => timer_slider.value = timer_slider.maxValue - time;

                // Genera los botones del teclado
                private void GenerateWordGUI(string word, bool flip = false)
                {
                    word_text.text = word;
                    if (flip)
                        word_text.gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
                    //for (int i = 0; i < word.Length; i++)
                    //{
                    //    var go = Instantiate(key_prefab, pnl_word.transform);
                    //    wordLetters.Add(go);
                    //    var rt = go.GetComponent<RectTransform>();
                    //    rt.anchorMin = new Vector2(i * 0.1f + 0.05f, 0.05f);
                    //    rt.anchorMax = rt.anchorMin + new Vector2(0.09f, 0.9f);
                    //    if (flip) rt.localScale = new Vector3(-1, 1, 1);
                    //    var text = go.GetComponentInChildren<Text>();
                    //    SetText(text, word[i]);
                    //}
                }

                private void GenerateBoardGUI(char[] keys, int dim)
                {
                    this.dim = dim;
                    float size = Mathf.Max((1 - (dim - 1) * SPACING) / dim, 0);
                    for (int i = 0; i < dim; i++)
                    {
                        for (int j = 0; j < dim; j++)
                        {
                            var go = Instantiate(key_prefab, pnl_keys.transform);
                            Key key = go.GetComponent<Key>();
                            keyButtons.Add(key);
                            int row = i;
                            int column = j;
                            key.SetListener(() => FindObjectOfType<SpellerPlayer>()?.OnKey(column, row));
                            key.SetUp(keys[i * dim + j]);

                            var rt = go.GetComponent<RectTransform>();
                            rt.anchorMin = new Vector2(j * (size + SPACING), 1 - ((i + 1) * size + i * SPACING));
                            rt.anchorMax = rt.anchorMin + new Vector2(size, size);
                        }
                    }
                }

                // Desactiva un boton
                private void DisableKeyButton(int id)
                {
                    word_text.text = word_text.text.Substring(1);
                }


                // Desactiva el teclado
                private void DisableLayout()
                {
                    foreach (var go in keyButtons)
                    {
                        Destroy(go.gameObject);
                    }
                    keyButtons.Clear();
                }

                #endregion
            }
        } 
    }
}