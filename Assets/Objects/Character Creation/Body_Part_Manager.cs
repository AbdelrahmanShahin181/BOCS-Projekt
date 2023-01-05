using System.Collections.Generic;
using UnityEngine;

public class Body_Part_Manager : MonoBehaviour
{
    // ~~ 1. Updates All Animations to Match Player Selections

    [SerializeField] private SO_Character_Build characterBuild;
    [SerializeField] private SO_CharacterColors characterColor;

    // String Arrays
    [SerializeField] private string[] bodyPartTypes;
    [SerializeField] private string[] characterStates;
    [SerializeField] private string[] characterDirections;
    
    // Animation
    private Animator animator;
    private AnimationClip animationClip;
    private AnimatorOverrideController animatorOverrideController;
    private AnimationClipOverrides defaultAnimationClips;
    public string[] colors = new string[] {"_ColorHair", "_ColorSkin", "_ColorShirt", "_ColorPants"};

    private void Start()
    {
        // Set animator
        animator = GetComponent<Animator>();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        defaultAnimationClips = new AnimationClipOverrides(animatorOverrideController.overridesCount);
        animatorOverrideController.GetOverrides(defaultAnimationClips);

        // Set Colors
        for(int i=0; i<4; i++) {
            transform.GetChild(i).GetComponent<SpriteRenderer>().material.SetColor(colors[0], characterColor.Colors[0]);
            transform.GetChild(i).GetComponent<SpriteRenderer>().material.SetColor(colors[1], characterColor.Colors[1]);
            transform.GetChild(i).GetComponent<SpriteRenderer>().material.SetColor(colors[2], characterColor.Colors[2]);
            transform.GetChild(i).GetComponent<SpriteRenderer>().material.SetColor(colors[3], characterColor.Colors[3]);
        }

        // Set body part animations
        UpdateBodyParts();
    }

    public void UpdateBodyParts()
    {
        // Override default animation clips with character body parts
        for (int partIndex = 0; partIndex < bodyPartTypes.Length; partIndex++)
        {
            // Get current body part
            string partType = bodyPartTypes[partIndex];
            // Get current body part ID
            string partID = characterBuild.characterBodyParts[partIndex].bodyPart.bodyPartAnimationID.ToString();

            for (int stateIndex = 0; stateIndex < characterStates.Length; stateIndex++)
            {
                string state = characterStates[stateIndex];
                for (int directionIndex = 0; directionIndex < characterDirections.Length; directionIndex++)
                {
                    string direction = characterDirections[directionIndex];

                    // Get players animation from player body
                    // ***NOTE: Unless Changed Here, Animation Naming Must Be: "[Type]_[Index]_[state]_[direction]" (Ex. Body_0_idle_down)
                    animationClip = Resources.Load<AnimationClip>("PlayerAnimations/" + partType + "/" + partID + "/" + partType + "_" + partID + "_" + state + "_" + direction);

                    // Override default animation
                    defaultAnimationClips[partType + "_" + 0 + "_" + state + "_" + direction] = animationClip;
                    //Debug.Log(partType + "_" + 0 + "_" + state + "_" + direction);
                }
            }
        }

        // Apply updated animations
        animatorOverrideController.ApplyOverrides(defaultAnimationClips);
    }

    public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
    {
        public AnimationClipOverrides(int capacity) : base(capacity) { }

        public AnimationClip this[string name]
        {
            get { return this.Find(x => x.Key.name.Equals(name)).Value; }
            set
            {
                int index = this.FindIndex(x => x.Key.name.Equals(name));
                if (index != -1)
                    this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
            }
        }
    }
}
