using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class ActionHitBox : WeaponComponent<ActionHitboxData, AttackActionHitBox>
    {
        public event Action<Collider2D[]> OnDetectedCollider2d;

        private CoreComp<Movement> movement;

        private Vector2 offset;

        private Collider2D[] detected;

        private void HandleAttackAction()
        {
            offset.Set(transform.position.x + (currentAttackData.HitBox.center.x * movement.Comp.FacingDirection),
                    transform.position.y + currentAttackData.HitBox.center.y);

            detected = Physics2D.OverlapBoxAll(offset, currentAttackData.HitBox.size, 0f, data.DetectableLayers);

            if (detected.Length == 0)
                return;

            OnDetectedCollider2d?.Invoke(detected);
        }
        protected override void Start()
        {
            base.Start();

            movement = new CoreComp<Movement>(Core);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            eventHandler.OnAttackAction += HandleAttackAction;
        }
        protected override void OnDisable()
        {
            base.OnDisable();

            eventHandler.OnAttackAction -= HandleAttackAction;

        }

        private void OnDrawGizmosSelected()
        {
            if (data == null)
                return;

            foreach(var item in data.AttackData)
            {
                if (!item.Debug)
                    continue;
                Gizmos.DrawWireCube(transform.position + (Vector3)item.HitBox.center, item.HitBox.size);
            }
        }
}

