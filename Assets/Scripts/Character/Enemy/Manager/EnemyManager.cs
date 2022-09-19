using Character.Core;
using UnityEngine;

namespace Character.Enemy.Manager
{
    public class EnemyManager : MonoBehaviour
    {
        public CoreManager CoreManager { get; private set; }
        public Animator Anim { get; private set; }
    }
}