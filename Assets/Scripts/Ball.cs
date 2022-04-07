using UnityEngine;
public abstract class PooledObject : MonoBehaviour
{
    public abstract bool IsPooledObjectTaken { get; }
    public abstract void SetActive();
    public abstract void Dismiss();

}
public class Ball : PooledObject
{
    [SerializeField] ProjectileMotion projectileMotion;

    public override bool IsPooledObjectTaken => projectileMotion.IsProjectile;

    public override void Dismiss()
    {
        gameObject.SetActive(false);
    }

    public void ProjectileMotion(Transform startTransform, Transform finalTransform, float maxHeight, float time)
     {
       projectileMotion.Navigate(startTransform, finalTransform, maxHeight, time);
        SetActive();
    }

    public override void SetActive()
    {
        gameObject.SetActive(true);
    }

}
