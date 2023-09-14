using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UI
{
    [RequireComponent(typeof(RectTransform), typeof(Graphic)), DisallowMultipleComponent]
    [AddComponentMenu("")]
    public class FlipGraphic : BaseMeshEffect
    {
        [SerializeField] private bool _flipX = false;
        [SerializeField] private bool _flipY = false;

        public bool FlipX
        {
            get { return this._flipX; }
            set
            {
                this._flipX = value;
                this.GetComponent<Graphic>().SetVerticesDirty();
            }
        }

        public bool FlipY
        {
            get { return this._flipY; }
            set
            {
                this._flipY = value;
                this.GetComponent<Graphic>().SetVerticesDirty();
            }
        }

        public override void ModifyMesh(VertexHelper verts)
        {
            var rt = this.GetComponent<RectTransform>();
            if (rt == null) return;

            for (var i = 0; i < verts.currentVertCount; ++i)
            {
                var uiVertex = new UIVertex();
                verts.PopulateUIVertex(ref uiVertex, i);

                // Modify positions
                uiVertex.position = new Vector3(
                    (this._flipX ? (uiVertex.position.x + (rt.rect.center.x - uiVertex.position.x) * 2) : uiVertex.position.x),
                    (this._flipY ? (uiVertex.position.y + (rt.rect.center.y - uiVertex.position.y) * 2) : uiVertex.position.y),
                    uiVertex.position.z
                );

                // Apply
                verts.SetUIVertex(uiVertex, i);
            }
        }
    }
}
