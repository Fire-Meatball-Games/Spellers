using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpellSystem;

namespace Runtime.CombatSystem
{
    public class SpellerPlayer : Speller
    {
        public SpellTable table;
        public SpellBoard board;

        [SerializeField] List<Spell> spells;

        public delegate void OnUseSpellDelegate();
        public event OnUseSpellDelegate OnUseSpellEvent;

        public override void Init()
        {
            base.Init();
            target = FindObjectOfType<SpellerNPC>();
            table = new SpellTable(new SpellDeck(spells));
            board = new SpellBoard();
        }

        private void Start()
        {
            InitializeTable();
        }

        // Usa el hechizo seleccionado en la mesa:

        public void LaunchSpell()
        {
            UseSpell(table.GetSelectedSpell());
            IEnumerator corroutine = LaunchingSpell();
            StartCoroutine(corroutine);
        }

        // Selecciona el hechizo en la posición idx de la mesa.
        // Activa el tablero correspondiente al tipo de hechizo seleccionado

        public void SelectSpell(int idx)
        {
            table.SelectSpellSlot(idx);
            board.GenerateBoard(table.GetSelectedSpell().lvl);
        }

        // Pulsa la tecla (x, y) del tablero de juego

        public void OnKey(int column, int row)
        {
            board.CheckCharacterKey(column, row);
        }

        private void InitializeTable()
        {
            table.Initialize();
        }

        private IEnumerator LaunchingSpell()
        {
            yield return new WaitForSeconds(2);
            OnUseSpellEvent?.Invoke();
        }

        
    } 
}
