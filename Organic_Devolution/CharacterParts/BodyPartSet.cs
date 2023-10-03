namespace Organic_Devolution;

public class BodyPartSet
{
    
    
    
    BodyPart Head { get; set; } = new(bodyPartType.Head, 50, 80);
    BodyPart Torso { get; set; } = new(bodyPartType.Torso, 200, 20);
    BodyPart Heart { get; set; } = new(bodyPartType.Heart, 50, 50);
    BodyPart LeftArm { get; set; } = new(bodyPartType.LeftArm, 100, 30);
    BodyPart RightArm { get; set; } = new(bodyPartType.RightArm, 100, 30);
    BodyPart LeftHand { get; set; } = new(bodyPartType.LeftHand, 50, 50);
    BodyPart RightHand { get; set; } = new(bodyPartType.RightHand, 50, 50);
    BodyPart LeftLeg { get; set; } = new(bodyPartType.LeftLeg, 100, 30);
    BodyPart RightLeg { get; set; } = new(bodyPartType.RightLeg, 100, 30);
    BodyPart LeftFoot { get; set; } = new(bodyPartType.LeftFoot, 50, 50);
    BodyPart RightFoot { get; set; } = new(bodyPartType.RightFoot, 50, 50);
    BodyPart LeftEye { get; set; } = new(bodyPartType.LeftEye, 50, 90);
    BodyPart RightEye { get; set; } = new(bodyPartType.RightEye, 50, 90);
    BodyPart LeftEar { get; set; } = new(bodyPartType.LeftEar, 50, 90);
    BodyPart RightEar { get; set; } = new(bodyPartType.RightEar, 50, 90);
    BodyPart LeftLung { get; set; } = new(bodyPartType.LeftLung, 50, 50);
    BodyPart RightLung { get; set; } = new(bodyPartType.RightLung, 50, 50);
    BodyPart Stomach { get; set; } = new(bodyPartType.Stomach, 50, 50);
    BodyPart Liver { get; set; } = new(bodyPartType.Liver, 50, 50);
    BodyPart Kidney { get; set; } = new(bodyPartType.Kidney, 50, 50);
    BodyPart Spleen { get; set; } = new(bodyPartType.Spleen, 50, 50);
    BodyPart Pancreas { get; set; } = new(bodyPartType.Pancreas, 50, 50);

    public BodyPartSet() 
    {
        
    }
    
}