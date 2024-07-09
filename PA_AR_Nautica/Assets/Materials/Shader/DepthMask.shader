Shader "AR/CustomDepthMask" {
   
    SubShader {
        // Render the mask after regular geometry, but before masked geometry and
        // transparent things.
       
        Tags {"Queue" = "Geometry-10" }
       
        // Turn off lighting       
        Lighting Off

        // Draw into the depth buffer in the usual way

        ZTest Always
        ZWrite On

        // Don't draw anything into the RGBA channels. 
		// ColorMask = 0 lets us avoid writing to anything except
        // the depth buffer.

        ColorMask 0
        Pass {}
    }
}
