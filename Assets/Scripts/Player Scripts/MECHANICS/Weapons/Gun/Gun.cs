using UnityEngine;

public class Gun : MonoBehaviour
{
   public float damage = 5f;
   public float range = 100f;
   public ParticleSystem Muzzleflash;

   public Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
          Shoot_Gun();
        }
    }
    public void Shoot_Gun()
    {
      Muzzleflash.Play();//Initiate Particle
      RaycastHit hit;
      if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
      {
        Debug.Log(hit.transform.name);
        Target target = hit.transform.GetComponent<Target>();//gets target reference from target script

        if(target != null) target.TakeDamage(damage);
      }
    }
}
