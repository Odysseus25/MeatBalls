using UnityEngine;
using System.Collections;

//by Joseph Jacir, adapted in part from Unity docs for ParticleSystem.GetParticles().
//Place this on an object to which you want to attract particles emitted from a specified ParticleSystem.
//Use sparingly: this may be slow, as it addresses each particle's position individually.

public class ParticleAttractor : MonoBehaviour
{

    //public GameObject psys1;
    public ParticleSystem pSys;
    public float attraction = 2.0f;
    public bool worldSpaceParticles = false;

    private ParticleSystem sys;
    private ParticleSystem.Particle[] m_Particles;

    /* void Start() {
         pSys = psys1.GetComponent<ParticleSystem>();
     }*/

    void OnTriggerEnter(Collider col) {
        if (col.tag.Equals("Meat")) {
            sys = Instantiate(pSys, transform.position, Quaternion.identity) as ParticleSystem;
        }
    }

    void LateUpdate()
    {
        if (sys == null)
        {
            return;
        }

        InitializeIfNeeded();

        if (m_Particles.Length < 1)
        {
            return;
        }

        int numParticlesAlive = sys.GetParticles(m_Particles);


        Vector3 target = transform.position;
        if (!worldSpaceParticles)
        {
            target = target - sys.transform.position;
        }

        // Change only the particles that are alive
        for (int i = 0; i < numParticlesAlive; i++)
        {
            m_Particles[i].position = Vector3.MoveTowards(m_Particles[i].position, target, Time.deltaTime * attraction);
        }

        // Apply the particle changes to the particle system
        sys.SetParticles(m_Particles, numParticlesAlive);

    }

    void InitializeIfNeeded()
    {

        if (m_Particles == null || m_Particles.Length < sys.maxParticles)
        {
            m_Particles = new ParticleSystem.Particle[sys.maxParticles];
        }
    }

}