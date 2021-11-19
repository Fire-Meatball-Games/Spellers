using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventSystem;

namespace Runtime.CombatSystem
{
    public class SpellerAnimator : MonoBehaviour
    {
        private Animator animator;

        private void Start()
        {
            animator = GetComponentInChildren<Animator>();
        }

        private void OnEnable()
        {
            Events.OnBattleBegins.AddListener(SetinitAnim);

        }

        private void OnDisable()
        {
            Events.OnBattleBegins.RemoveListener(SetinitAnim);
        }


        private void SetinitAnim()
        {
            animator.SetTrigger("Init");
        }

        public void SetUseSpellAnim()
        {
            animator.SetTrigger("UseSpell");
        }

        public void SetDamagedAnim()
        {
            Debug.Log("EEEEEEE");
            animator.SetTrigger("Damaged");
        }

        public void SetWinAnim()
        {
            animator.SetTrigger("Win");
        }

        public void SetLostAnim()
        {
            animator.SetTrigger("Lost");
        }
    }

}