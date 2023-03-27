using Presenter.Interfaces;
using UnityEngine;
using View.Interfaces;
using Zenject;

namespace Services
{
    public class CollisionDetectorView : MonoBehaviour, ICollisionDetectorView
    {
        [SerializeField] private float _force;

        [Inject] private ICollisionDetectorPresenter _collisionDetectorPresenter;

        private void OnCollisionEnter(Collision collision)
        {
            _collisionDetectorPresenter.TriggerGameOver(_force);
        }
    }
}