using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Ferula.GameManagement
{

    public class GameManager : MonoBehaviour
    {
        [SerializeField] private bool _showControls = false;
        [SerializeField] private GameObject _UIControls;
        [SerializeField] private PlayerManager _antPlayerManager;
        [SerializeField] private PlayerManager _billPlayerManager;

        private void Awake()
        {
            if (!_UIControls)
            {
                Debug.LogWarning("WARNING THERE IS NO UI CONTROLS");
                return;
            }

            if (_showControls)
            {
                _UIControls.SetActive(true);
            } else
            {
                _UIControls.SetActive(false);
            }
        }

        private void GetKeys()
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                _showControls = !_showControls;
            }
            if(Input.GetKeyDown(KeyCode.R)) 
            {
                _antPlayerManager.RestartPlayer();
                _billPlayerManager.RestartPlayer();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                _antPlayerManager.StartAnimation();
                _billPlayerManager.StartAnimation();
            }
        }

        private void Update()
        {
            GetKeys();
        }



    }
}
