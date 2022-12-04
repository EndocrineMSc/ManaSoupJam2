using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamCatcher.Graphics
{
    public class DynamicYSort : MonoBehaviour
    {
        private int _baseSortingOrder;
        private float _ySortingOffset;
        [SerializeField] private SortableSprite[] _sortableSprites;
        [SerializeField] private Transform _sortOffsetMarker;


        private void Start()
        {
            _ySortingOffset = _sortOffsetMarker.position.y;
        }

        // Update is called once per frame
        void Update()
        {
            _baseSortingOrder = transform.GetSortingOrder(_ySortingOffset);
            foreach (var sortableSprite in _sortableSprites)
            {
                sortableSprite.spriteRenderer.sortingOrder = _baseSortingOrder + sortableSprite.relativeOrder;
            }
        }

        [Serializable]
        public struct SortableSprite
        {
            public SpriteRenderer spriteRenderer;
            public int relativeOrder;
        }
    }
}
