using Godot;
using System.Collections.Generic;

namespace GettingstartedwithGodot4
{
    internal static class ResourceHelper
    {
        private static Dictionary<string, PackedScene> preloadedScenes = new Dictionary<string, PackedScene>();

        public static T CreateResource<T>(string resourceName) where T : class
        {
            GD.Print($"creating {resourceName}");
            
            if (preloadedScenes.ContainsKey(resourceName))
            {
                return preloadedScenes[resourceName].Instantiate<T>();
                
            }

            var resourcePath = $"res://{resourceName}.tscn";
            var resource = ResourceLoader.Load<Godot.PackedScene>(resourcePath);
            preloadedScenes.Add(resourceName, resource);

            return resource.Instantiate<T>(); 
        }
    }
}
