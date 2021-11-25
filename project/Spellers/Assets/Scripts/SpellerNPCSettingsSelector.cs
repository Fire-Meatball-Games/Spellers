using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Runtime;
using SpellSystem;
using UIManagement;
using CustomEventSystem;
using UnityEngine.UI;

public class SpellerNPCSettingsSelector : MonoBehaviour
{
    public List<EnemyConfiguration> enemies;
    [SerializeField] public List<SpellerNPCSettings> easy_setting_list;
    [SerializeField] public List<SpellerNPCSettings> normal_setting_list;
    [SerializeField] public List<SpellerNPCSettings> hard_setting_list;

    public Button btn_play;


    private List<(int, int)> selected_settings;

    public void Start()
    {
        selected_settings = new List<(int, int)>();
        selected_settings.Add((0, 0));
        SpellerNPCSettings settings = GetSetting(0, 0);
        Events.OnChangeSpellerNPCSettings.Invoke(0, settings);
        for (int i = 0; i < enemies.Count; i++)
        {            
            int idx = i;
            enemies[idx].diff_slider.value = 0;
            enemies[idx].diff_slider.onValueChanged.AddListener((diff) => ChangeDifficulty(idx, (int)diff));            
            enemies[idx].l_button.onClick.AddListener(() => GetPreviousSetting(idx));
            enemies[idx].r_button.onClick.AddListener(() => GetNextSetting(idx));
            enemies[idx].random_button.onClick.AddListener(() => GetRandomSetting(idx));
            enemies[idx].add_button?.onClick.AddListener(() => ShowSetting(idx));
            enemies[idx].remove_button?.onClick.AddListener(() => HideSetting(idx));

        }
        btn_play.onClick.AddListener(SetGame);
    }


    // Carga la partida:
    private void SetGame()
    {
        GameSettings.combatSettings = new CombatSettings();
        GameSettings.combatSettings.speller_Settings = new List<SpellerNPCSettings>(); 
        foreach (var item in selected_settings)
        {
            SpellerNPCSettings setting = GetSetting(item.Item1, item.Item2);
            GameSettings.combatSettings.speller_Settings.Add(setting);            
        }
        Debug.Log("A�adido " + selected_settings.Count + " enemigos" );
        GameSettings.combatSettings.playerDeck = PlayerSettings.deck;
       //GameController.instance.LoadCombat();
    }


    // Cambiar la dificultad de un enemigo:
    private void ChangeDifficulty(int idx, int diff)
    {
        Debug.Log("Cambiando la dificultad de " + idx + " a " + diff);
        List<SpellerNPCSettings> list = GetListByDifficulty(diff);
        int newIdx = Random.Range(0, list.Count);
        selected_settings[idx] = (diff, newIdx);
        SpellerNPCSettings selected_setting = GetSetting(diff, newIdx);
        Events.OnChangeSpellerNPCSettings.Invoke(idx, selected_setting);

    }

    // Cambiar un enemigo
    private void GetNextSetting(int idx)
    {
        int index = (selected_settings[idx].Item2 + 1) % GetListByDifficulty(selected_settings[idx].Item1).Count;
        selected_settings[idx] = (selected_settings[idx].Item1, index);

        SpellerNPCSettings selected_setting = GetSetting(selected_settings[idx].Item1, index);
        Events.OnChangeSpellerNPCSettings.Invoke(idx, selected_setting);
    }

    // Cambiar un enemigo
    private void GetPreviousSetting(int idx)
    {
        int index = (selected_settings[idx].Item2 - 1 + GetListByDifficulty(selected_settings[idx].Item1).Count) % GetListByDifficulty(selected_settings[idx].Item1).Count;
        selected_settings[idx] = (selected_settings[idx].Item1, index);

        SpellerNPCSettings selected_setting = GetSetting(selected_settings[idx].Item1, index);
        Events.OnChangeSpellerNPCSettings.Invoke(idx, selected_setting);
    }

    // Cambiar un enemigo
    private void GetRandomSetting(int idx)
    {
        int newIdx = Random.Range(0, GetListByDifficulty(selected_settings[idx].Item1).Count);        
        selected_settings[idx] = (selected_settings[idx].Item1, newIdx);

        SpellerNPCSettings selected_setting = GetSetting(selected_settings[idx].Item1, newIdx);
        Events.OnChangeSpellerNPCSettings.Invoke(idx, selected_setting);
    }



    private SpellerNPCSettings GetSetting(int diff, int idx)
    {
        List<SpellerNPCSettings> list = GetListByDifficulty(diff);
        int item_idx = Mathf.Min(idx, list.Count - 1);
        return list[item_idx];
    }

    private List<SpellerNPCSettings> GetListByDifficulty(int diff)
    {
        switch (diff)
        {
            case 0: return easy_setting_list;
            case 1: return normal_setting_list;
            case 2: return hard_setting_list;
            default: return easy_setting_list; 
        }
    }

    // Mostrar un enemigo
    private void ShowSetting(int idx)
    {
        Debug.Log("Mostrar enemigo " + idx);
        SpellerNPCSettings settings = GetSetting(0, 0);
        selected_settings.Add((0, 0));
        Events.OnChangeSpellerNPCSettings.Invoke(idx, settings);
        enemies[idx].add_button.gameObject.SetActive(false);
        enemies[idx].diff_slider.value = 0;
        if(idx + 1 < enemies.Count)
        {
            enemies[idx + 1].layout_panel.SetActive(true);
        }
        enemies[idx - 1].remove_button?.gameObject.SetActive(false);
        enemies[idx].remove_button.gameObject.SetActive(true);
    }

    // Ocultar un enemigo
    private void HideSetting(int idx)
    {
        selected_settings.RemoveAt(idx);
        enemies[idx].add_button.gameObject.SetActive(true);
        if (idx + 1 < enemies.Count)
        {
            enemies[idx + 1].layout_panel.SetActive(false);
        }
        enemies[idx - 1].remove_button?.gameObject.SetActive(true);
        enemies[idx].remove_button.gameObject.SetActive(false);
    }
}
