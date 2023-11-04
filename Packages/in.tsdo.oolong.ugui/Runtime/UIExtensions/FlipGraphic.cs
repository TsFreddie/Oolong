using UnityEngine;
using UnityEngine.UI;

namespace TSF.Oolong.UGUI
{
    [RequireComponent(typeof(RectTransform), typeof(Graphic)), DisallowMultipleComponent]
    [AddComponentMenu("")]
    public class FlipGraphic : BaseMeshEffect
    {
        [SerializeField] private bool _flipX = false;
        [SerializeField] private bool _flipY = false;

        public bool FlipX
        {
            get { return _flipX; }
            set
            {
                _flipX = value;
                GetComponent<Graphic>().SetVerticesDirty();
            }
        }

        public bool FlipY
        {
            get { return _flipY; }
            set
            {
                _flipY = value;
                GetComponent<Graphic>().SetVerticesDirty();
            }
        }

        public override void ModifyMesh(VertexHelper verts)
        {
            var rt = GetComponent<RectTransform>();
            if (rt == null) return;

            for (var i = 0; i < verts.currentVertCount; ++i)
            {
                var uiVertex = new UIVertex();
                verts.PopulateUIVertex(ref uiVertex, i);

                uiVertex.position = new Vector3(
                    (_flipX ? (uiVertex.position.x + (rt.rect.center.x - uiVertex.position.x) * 2) : uiVertex.position.x),
                    (_flipY ? (uiVertex.position.y + (rt.rect.center.y - uiVertex.position.y) * 2) : uiVertex.position.y),
                    uiVertex.position.z
                );

                verts.SetUIVertex(uiVertex, i);
            }
        }
    }
}
