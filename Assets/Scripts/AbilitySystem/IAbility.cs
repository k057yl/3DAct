using System.Collections;
using UnityEngine;

public interface IAbility
{
    void ActivateAbility();
    void DeactivateAbility();
    IEnumerator ExecuteAbility(Transform targetTransform);
}
