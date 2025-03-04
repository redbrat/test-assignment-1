using System.Collections.Generic;
using PictureChoosingUI;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(PicturesConfig), order = 0, fileName = nameof(PictureView))]
    public class PicturesConfig : ScriptableObject
    {
        public int PicturesCount => sprites.Count;

        [SerializeField] private List<Sprite> sprites;

        public Sprite GetPicture(int id)
        {
            return sprites[id];
        }
    }
}