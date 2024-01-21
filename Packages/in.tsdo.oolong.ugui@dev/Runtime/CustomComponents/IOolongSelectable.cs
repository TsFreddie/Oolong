using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ReSharper disable InconsistentNaming

namespace TSF.Oolong.UGUI
{
    public delegate void CanvasGroupChanged();

    public interface IOolongSelectable
    {
        public event CanvasGroupChanged OnCanvasGroupChange;

        public bool enabled { get; set; }
        public Transform transform { get; }
        public GameObject gameObject { get; }


        public ColorBlock colors { get; set; }
        public SpriteState spriteState { get; set; }
        public Selectable.Transition transition { get; set; }
        public Graphic targetGraphic { get; set; }
        public bool interactable { get; set; }
        public Image image { get; set; }

        public bool IsInteractable();
    }
}
