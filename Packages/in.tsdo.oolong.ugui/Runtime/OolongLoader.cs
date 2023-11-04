using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TSF.Oolong.UGUI
{
    public abstract class OolongLoader
    {
        private bool _isLayoutDirty;
        protected bool IsLayoutDirty
        {
            get { return _isLayoutDirty; }
            set
            {
                if (_isLayoutDirty == value) return;
                _isLayoutDirty = value;
                if (_isLayoutDirty)
                    DocumentUtils.OnDocumentUpdate += OnLayout;
                else
                    DocumentUtils.OnDocumentUpdate -= OnLayout;
            }
        }

        protected virtual void OnLayout() { IsLayoutDirty = false; }

        private bool _isLayoutDirtyLate;
        protected bool IsLayoutDirtyLate
        {
            get { return _isLayoutDirtyLate; }
            set
            {
                if (_isLayoutDirtyLate == value) return;
                _isLayoutDirtyLate = value;
                if (_isLayoutDirtyLate)
                    DocumentUtils.OnDocumentLateUpdate += OnLateLayout;
                else
                    DocumentUtils.OnDocumentLateUpdate -= OnLateLayout;
            }
        }
        protected virtual void OnLateLayout() { IsLayoutDirtyLate = false; }

        public virtual void Release()
        {
            IsLayoutDirty = false;
            IsLayoutDirtyLate = false;
        }

        public abstract void Reset();
        public abstract void Reuse();
    }
}
