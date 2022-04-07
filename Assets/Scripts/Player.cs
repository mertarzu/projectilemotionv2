using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] ObjectPooler ballObjectPooler;
    [SerializeField] UIController uIController;
    [SerializeField] TargetInputController targetInputController;
    [SerializeField] Transform startTransform;
    [SerializeField] Transform finalTransform;
    bool isFinal;
 

    void  onTargetSelected(Vector3 target)
    {
        if (!isFinal)
        {
            startTransform.position = target;
            isFinal = true;
        }
        else
        {
            finalTransform.position = target;
            Ball ballItem = Spawn();
            if (ballItem != null)
            {
                ballItem.ProjectileMotion(startTransform, finalTransform, uIController.MaxHeight, uIController.Time);
            }
                isFinal = false;
        }
      
    }


    public void Initialize()
    {
        targetInputController.OnTriggerInput = onTargetSelected;    
    }


    public Ball Spawn()
    {
        Ball ball = (Ball)ballObjectPooler.GetPooledObject();

        //if (ball == null && tempAmountToPool < additionAmountToPool)
        //{
        //    ballObjectPooler.AddPooledObject();
        //    ball = (Ball)ballObjectPooler.GetPooledObject();
        //    ++tempAmountToPool;
        //}

        return ball;
    }
}
