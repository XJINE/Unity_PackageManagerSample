using UnityEngine;

namespace PackageManagerSample
{
    public class SampleRuntimeScript : MonoBehaviour
    {
        public static void Bowwow()
        {
            Debug.Log("Bowwow");
        }

        void Start()
        {
            Debug.Log(typeof(SampleRuntimeScript).Name);
        }
    }
}