using System;
using ARKit;
using Urho;
using Urho.iOS;
using Urho.Shapes;

namespace FirstAR
{
    public class TestARApp : SimpleApplication
    {
        public TestARApp(ApplicationOptions options) : base(options)
        {
        }

        protected override void Start()
        {
            base.Start();

            try
            {
                var sphereNode = Scene.CreateChild();
                sphereNode.Position = new Vector3(0, 0, 0.5f);
                sphereNode.SetScale(0.1f); //0.1 is 10% of its original size

                var sphere = sphereNode.CreateComponent<Sphere>();
                sphere.Color = Color.Blue;

                var arKitComponent = Scene.CreateComponent<ARKitComponent>();
                arKitComponent.Orientation = UIKit.UIInterfaceOrientation.Portrait;
                arKitComponent.ARConfiguration = new ARWorldTrackingConfiguration()
                {
                    PlaneDetection = ARPlaneDetection.Horizontal,
                };
                arKitComponent.RunEngineFramesInARKitCallbakcs = Options.DelayedStart;
                arKitComponent.Run();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
