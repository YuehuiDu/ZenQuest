using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Fraktalia.DreamStarGen
{
    [RequireComponent(typeof(MeshFilter))]
    public class DreamStarGenerator : MonoBehaviour
    {
        // Sid: update start 11.07
        private float originalRadius;
        private float originalA;
        void Start()
        {
            originalRadius = Radius; // Store the original radius value
            originalA = a;
            StartCoroutine(ChangeRadiusOverTime()); // Start the Coroutine to change the radius
            StartCoroutine(ChangeAOverTime());
        }

        private IEnumerator ChangeRadiusOverTime()
        {
            float elapsedTime = 0f;
            float increaseDuration = 10f;  // duration to increase the radius
            float steadyDuration = 10f;    // duration to keep the radius steady
            float decreaseDuration = 10f;  // duration to decrease the radius

            // Increase phase
            while (elapsedTime < increaseDuration)
            {
                Radius = Mathf.Lerp(originalRadius, originalRadius * 2f, elapsedTime / increaseDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Keep steady phase
            yield return new WaitForSeconds(steadyDuration);

            // Reset elapsed time for the decrease phase
            elapsedTime = 0f;

            // Decrease phase
            while (elapsedTime < decreaseDuration)
            {
                Radius = Mathf.Lerp(originalRadius * 2f, originalRadius, elapsedTime / decreaseDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Set radius back to original at the end
            Radius = originalRadius;
        }
        // Sid: update end 11.07 
        
        //yuehui added same logic as Sid's updates
        
        private IEnumerator ChangeAOverTime()
        {
            float elapsedTime = 0f;
            float increaseDuration = 10000f;  // duration to increase the radius
            float steadyDuration = 10000f;    // duration to keep the radius steady
            float decreaseDuration = 10000f;  // duration to decrease the radius

            // Increase phase
            while (elapsedTime < increaseDuration)
            {
                a = Mathf.Lerp(originalA, originalA * 2f, elapsedTime / increaseDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Keep steady phase
            yield return new WaitForSeconds(steadyDuration);

            // Reset elapsed time for the decrease phase
            elapsedTime = 0f;

            // Decrease phase
            while (elapsedTime < decreaseDuration)
            {
                a = Mathf.Lerp(originalA * 2f, originalA, elapsedTime / decreaseDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Set radius back to original at the end
            a = originalA;
        }
        
        //yuehui updates end

        public MeshFilter meshfilter;

        [Header("Base Parameters:")]
        public float Radius = 1;
        [Range(0.1f, 360)]
        public float Density = 0.1f;
        public float Width = 1;

        [Header("Star Parameters:")]
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;

        protected bool suspendGeneraton;






        private int instanceID;

        public virtual void Initialize()
        {

        }

        public virtual Vector3 StarAlgorithm(float Angle)
        {
            float r = 0;
            float radiant = Angle * Mathf.Deg2Rad * a;
            float value1 = 1;
            r = Radius * (value1);

            float x = r * Mathf.Cos(radiant);
            float y = r * Mathf.Sin(radiant);
            return new Vector3(x, y, 0);
        }






        void OnDrawGizmosSelected()
        {
            if (hasErrors()) return;
            OnDuplicate();
            _GenerateStar();
        }


        public void _GenerateStar()
        {
            if (hasErrors()) return;

            Render();
        }

        private void Render()
        {

            Initialize();

            if(suspendGeneraton)
            {
                suspendGeneraton = false;
                return;
            }

            List<Vector3> points = new List<Vector3>();
            for (float i = -Density; i < 360; i += Density)
            {
                Vector3 point = StarAlgorithm(i);
                if (float.IsNaN(point.x + point.y + point.z))
                {
                    points.Add(new Vector3(0, 0, 0));
                }
                else points.Add(StarAlgorithm(i));

            }
            Mesh mesh = meshfilter.sharedMesh;
            MeshGenerators.GenerateCurve(ref mesh, points.ToArray(), Width, transform, true);
            meshfilter.sharedMesh = mesh;
        }

        public bool hasErrors()
        {

            if (!meshfilter)
            {
                meshfilter = GetComponent<MeshFilter>();
                if (!meshfilter) meshfilter = gameObject.AddComponent<MeshFilter>();
            }

            return false;
        }

        public void OnDuplicate()
        {
#if (UNITY_EDITOR)
            if (!Application.isPlaying)//if in the editor
            {

                //if the instance ID doesnt match then this was copied!
                if (instanceID != gameObject.GetInstanceID())
                {
                    if (meshfilter)
                    {
                        meshfilter.sharedMesh = null;
                    }

                }
                instanceID = gameObject.GetInstanceID();
            }
#endif
        }
    }
}