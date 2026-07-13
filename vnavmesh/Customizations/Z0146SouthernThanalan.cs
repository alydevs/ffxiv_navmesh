using System.Collections.Generic;

namespace Navmesh.Customizations;

[CustomizationTerritory(146)]
internal class Z0146SouthernThanalan : NavmeshCustomization
{
    public override int Version => 4;

    public override void CustomizeScene(SceneExtractor scene)
    {
        if (scene.Meshes.TryGetValue("<box>", out var mesh))
            mesh.Instances.RemoveAll(i => i.Material == 0x206406);

        // the ground directly in front of the bridge next to the amalj'aa camp has two triangles that cannot be landed on
        if (scene.Meshes.TryGetValue("bg/ffxiv/wil_w1/fld/w1f4/collision/tr1610.pcb", out var mesh2))
            foreach (var inst in mesh2.Instances)
                inst.ForceClearPrimFlags |= SceneExtractor.PrimitiveFlags.Unlandable;
    }
    
    public override void CustomizeMesh(Navmesh mesh, List<uint> festivalLayers)
    {
        // lower bridge to ruined stone structure
        LinkPoints(mesh, new(-62.317863f, -16.855253f, -172.60663f), new(-64.9727f, -15.593737f, -171.45671f), Navmesh.AreaId.Default);
        LinkPoints(mesh, new(-64.9727f, -15.593737f, -171.45671f), new(-62.317863f, -16.855253f, -172.60663f), Navmesh.AreaId.Default);
    }
}
