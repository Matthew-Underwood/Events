using UnityEngine;

namespace Munderwood.Events.Bootstrap
{
    public class Init : MonoBehaviour
    {
        public void Start()
        {
            Object.Instantiate(Resources.Load<GameObject>("EventSystem"));
        }
    }
}