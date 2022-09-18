using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Noir
{
    public class BookClue : MonoBehaviour
    {
        [SerializeField] private StateManager _stateManage;
        private StateID _id;

        [SerializeField] private List<Sprite> _spritesNorm;
        [SerializeField] private List<Image> _imageList;
        
        [Header("Mid")]
        [SerializeField] private List<Sprite> _midSprites;
        private int _countMid;

        [Header("Right")] 
        [SerializeField] private List<Sprite> _rightSprites;
        private int _countRight;

        [Header("Left")] 
        [SerializeField] private List<Sprite> _leftSprites;
        private int _countLeft;

        private void Start()
        {
            _id = _stateManage.State[0].GetComponent<StateID>();
            print(_id.ID);
        }

        public void Down()
        {
            if (_id.ID == 1)
            {
                if (_imageList[2].sprite == _spritesNorm[1])
                {
                    print("Yes");
                }
            }
            else
            {
                if (_imageList[2].sprite == _spritesNorm[0])
                {
                    print("yes");
                }
            }
        }
        public void ChangeLeftNext()
        {
            _countLeft++;
            if (_countLeft > _leftSprites.Count - 1)
                _countLeft = 0;

            _imageList[2].sprite = _leftSprites[_countLeft];
        }

        public void ChangeLeftDown()
        {
            _countLeft--;
            if (_countLeft < 0)
                _countLeft = _leftSprites.Count - 1;

            _imageList[2].sprite = _leftSprites[_countLeft];
        }
        
        public void ChangeRightNext()
        {
            _countRight++;
            if (_countRight > _rightSprites.Count - 1)
                _countRight = 0;
            _imageList[0].sprite = _rightSprites[_countRight];
        }

        public void ChangeRightDown()
        {
            _countRight--;
            if (_countRight < 0)
                _countRight = _rightSprites.Count - 1;

            _imageList[0].sprite = _rightSprites[_countRight];
        }
        
        public void ChangeMidNext()
        {
            _countMid++;
            if (_countMid > _midSprites.Count - 1)
                _countMid = 0;
            
            _imageList[1].sprite = _midSprites[_countMid];
        }

        public void ChangeMidBack()
        {
            _countMid--;
            if (_countMid < 0)
                _countMid = _midSprites.Count - 1;

            _imageList[1].sprite = _midSprites[_countMid];
        }
    }
}
