using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CombatComponent : MonoBehaviour
{
    private Animator characterAnimator;
    private int aimingLayerIndex;
    private const string aimingLayerName = "Aiming Layer";
    private const string aimingBoolParameterName = "IsAiming";
    private float layerWeightVelocity;
    private Rig animationRigging;

    private void Awake()
    {
        characterAnimator = GetComponent<Animator>();
        aimingLayerIndex = characterAnimator.GetLayerIndex(aimingLayerName);
        characterAnimator.SetLayerWeight(aimingLayerIndex, 0);
        animationRigging = GetComponentInChildren<Rig>();
    }

    public void StartAiming()
    {
        characterAnimator.SetBool(aimingBoolParameterName, true);
        characterAnimator.SetLayerWeight(aimingLayerIndex, Mathf.SmoothDamp(1.0f, 0.0f, ref layerWeightVelocity, 0.2f));
        animationRigging.weight = Mathf.SmoothDamp(1.0f, 0.0f, ref layerWeightVelocity, 0.2f);
    }

    public void StopAiming()
    {
        characterAnimator.SetBool(aimingBoolParameterName, false);
        characterAnimator.SetLayerWeight(aimingLayerIndex, Mathf.SmoothDamp(0.0f, 1.0f, ref layerWeightVelocity, 0.2f));
        animationRigging.weight = Mathf.SmoothDamp(0.0f, 1.0f, ref layerWeightVelocity, 0.2f);
    }
}