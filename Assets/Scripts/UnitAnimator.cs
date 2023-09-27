using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;
    Vector3 oldPos;
    // Start is called before the first frame update
    void Start()
    {
        oldPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SetMovement();
    }

    public virtual void SetMovement()
    {
        if (Vector3.Distance(oldPos,transform.position) > 0.1f * Time.deltaTime)
        {
            animator.SetBool("isRunning",true);
        }
        else
        {
            animator.SetBool("isRunning",false);
        }
        oldPos = transform.position;
    }
    public virtual void AnimateGotHit()
    {
        animator.SetTrigger("gotHit");
    }
    public virtual void AnimateBowAttack()
    {
        animator.SetTrigger("bowAttack");
    }
    public virtual void AnimateMelleeAttack()
    {
        animator.SetTrigger("melleAttack");
    }

    public void AnimateDeath()
    {
        animator.SetTrigger("isDead");
    }
}
