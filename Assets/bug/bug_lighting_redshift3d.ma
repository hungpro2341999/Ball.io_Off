//Maya ASCII 2014 scene
//Name: bug_lighting_redshift3d.ma
//Last modified: Fri, Dec 21, 2018 11:43:25 AM
//Codeset: 1252
file -rdi 1 -ns "bug_rig" -rfn "bug_rigRN" "D:/EVERYDAY 4/FREE 3D Models/Bug/bug//bug_rig.ma";
file -r -ns "bug_rig" -dr 1 -rfn "bug_rigRN" "D:/EVERYDAY 4/FREE 3D Models/Bug/bug//bug_rig.ma";
requires maya "2014";
requires -nodeType "RedshiftOptions" -nodeType "RedshiftProxyMesh" -nodeType "RedshiftVisibility"
		 -nodeType "RedshiftMeshParameters" -nodeType "RedshiftMatteParameters" -nodeType "RedshiftObjectId"
		 -nodeType "RedshiftBakeSet" -nodeType "RedshiftAOV" -nodeType "RedshiftAmbientOcclusion"
		 -nodeType "RedshiftArchitectural" -nodeType "RedshiftCarPaint" -nodeType "RedshiftIncandescent"
		 -nodeType "RedshiftSubSurfaceScatter" -nodeType "RedshiftMaterialBlender" -nodeType "RedshiftPhotographicExposure"
		 -nodeType "RedshiftBokeh" -nodeType "RedshiftLensDistortion" -nodeType "RedshiftPhysicalSky"
		 -nodeType "RedshiftPhysicalSun" -nodeType "RedshiftIESLight" -nodeType "RedshiftPortalLight"
		 -nodeType "RedshiftPhysicalLight" -nodeType "RedshiftDomeLight" -nodeType "RedshiftEnvironment"
		 -nodeType "RedshiftBumpMap" -nodeType "RedshiftNormalMap" -nodeType "RedshiftBumpBlender"
		 -nodeType "RedshiftRaySwitch" -nodeType "RedshiftCameraMap" -nodeType "RedshiftMatteShadowCatcher"
		 -nodeType "RedshiftSprite" -nodeType "RedshiftDisplacement" -nodeType "RedshiftDisplacementBlender"
		 -nodeType "RedshiftLightGobo" -nodeType "RedshiftHair" -nodeType "RedshiftHairRandomColor"
		 -nodeType "RedshiftHairPosition" -nodeType "RedshiftVolumeScattering" -nodeType "RedshiftVertexColor"
		 -nodeType "RedshiftShave" -nodeType "RedshiftSkin" -nodeType "RedshiftFresnel" -nodeType "RedshiftRoundCorners"
		 -nodeType "RedshiftAttributeLookup" -nodeType "RedshiftUserDataColor" -nodeType "RedshiftUserDataVector"
		 -nodeType "RedshiftUserDataScalar" -nodeType "RedshiftUserDataInteger" -nodeType "RedshiftShaderSwitch"
		 -nodeType "RedshiftWireFrame" -nodeType "RedshiftCurvature" -nodeType "RedshiftTriPlanar"
		 -nodeType "RedshiftColorLayer" -nodeType "RedshiftColorCorrection" -nodeType "RedshiftNoise"
		 -nodeType "RedshiftVolume" -nodeType "RedshiftVolumeShape" -nodeType "RedshiftState"
		 -nodeType "RedshiftMaterial" "redshift4maya" "2.5.46";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2014";
fileInfo "version" "2014 x64";
fileInfo "cutIdentifier" "201303010241-864206";
fileInfo "osv" "Microsoft Windows 8 Business Edition, 64-bit  (Build 9200)\n";
createNode transform -s -n "persp";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -10.510591291218178 9.0698595961452302 41.467405680298072 ;
	setAttr ".r" -type "double3" -0.93835272960240779 -14.200000000000117 9.73987003147331e-016 ;
createNode camera -s -n "perspShape" -p "persp";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 45.808519361528404;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 100.1 0 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
createNode transform -s -n "front";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 100.1 ;
createNode camera -s -n "frontShape" -p "front";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
createNode transform -s -n "side";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 100.1 0 0 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
createNode transform -n "camera1";
	setAttr ".t" -type "double3" -7.3051390379316157 10.465800129116097 34.913031640134427 ;
	setAttr ".r" -type "double3" -4.1999999999999869 -10.79999999999994 5.0592295543896569e-017 ;
createNode camera -n "cameraShape1" -p "camera1";
	setAttr -k off ".v";
	setAttr ".cap" -type "double2" 1.41732 0.94488 ;
	setAttr ".ff" 0;
	setAttr ".ovr" 1.3;
	setAttr ".coi" 33.880423827546238;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "camera1";
	setAttr ".den" -type "string" "camera1_depth";
	setAttr ".man" -type "string" "camera1_mask";
	setAttr ".dr" yes;
createNode transform -n "rsDomeLight1";
	setAttr ".r" -type "double3" 0 10.994874104241022 0 ;
createNode RedshiftDomeLight -n "rsDomeLightShape1" -p "rsDomeLight1";
	setAttr -k off ".v";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".viewportResolution" 1024;
	setAttr ".tex0" -type "string" "D:/EVERYDAY 4/FREE 3D Models/Bug/bug//hdr.hdr";
	setAttr ".background_enable" no;
createNode lightLinker -s -n "lightLinker1";
	setAttr -s 40 ".lnk";
	setAttr -s 40 ".slnk";
createNode displayLayerManager -n "layerManager";
	setAttr -s 2 ".dli[1]"  1;
	setAttr -s 2 ".dli";
createNode displayLayer -n "defaultLayer";
createNode renderLayerManager -n "renderLayerManager";
createNode renderLayer -n "defaultRenderLayer";
	setAttr ".g" yes;
createNode reference -n "bug_rigRN";
	setAttr -s 46 ".phl";
	setAttr ".phl[1]" 0;
	setAttr ".phl[2]" 0;
	setAttr ".phl[3]" 0;
	setAttr ".phl[4]" 0;
	setAttr ".phl[5]" 0;
	setAttr ".phl[6]" 0;
	setAttr ".phl[7]" 0;
	setAttr ".phl[8]" 0;
	setAttr ".phl[9]" 0;
	setAttr ".phl[10]" 0;
	setAttr ".phl[11]" 0;
	setAttr ".phl[12]" 0;
	setAttr ".phl[13]" 0;
	setAttr ".phl[14]" 0;
	setAttr ".phl[15]" 0;
	setAttr ".phl[16]" 0;
	setAttr ".phl[17]" 0;
	setAttr ".phl[18]" 0;
	setAttr ".phl[19]" 0;
	setAttr ".phl[20]" 0;
	setAttr ".phl[21]" 0;
	setAttr ".phl[22]" 0;
	setAttr ".phl[23]" 0;
	setAttr ".phl[24]" 0;
	setAttr ".phl[25]" 0;
	setAttr ".phl[26]" 0;
	setAttr ".phl[27]" 0;
	setAttr ".phl[28]" 0;
	setAttr ".phl[29]" 0;
	setAttr ".phl[30]" 0;
	setAttr ".phl[31]" 0;
	setAttr ".phl[32]" 0;
	setAttr ".phl[33]" 0;
	setAttr ".phl[34]" 0;
	setAttr ".phl[35]" 0;
	setAttr ".phl[36]" 0;
	setAttr ".phl[37]" 0;
	setAttr ".phl[38]" 0;
	setAttr ".phl[39]" 0;
	setAttr ".phl[40]" 0;
	setAttr ".phl[41]" 0;
	setAttr ".phl[42]" 0;
	setAttr ".phl[43]" 0;
	setAttr ".phl[44]" 0;
	setAttr ".phl[45]" 0;
	setAttr ".phl[46]" 0;
	setAttr ".ed" -type "dataReferenceEdits" 
		"bug_rigRN"
		"bug_rigRN" 0
		"bug_rigRN" 114
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:faceBase|bug_rig:faceBaseShape" 
		"instObjGroups.objectGroups" " -s 4"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:antena|bug_rig:antenaShape" "instObjGroups.objectGroups" 
		" -s 8"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:antena|bug_rig:antenaShape" "rsEnableSubdivision" 
		" 1"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:legs|bug_rig:legsShape" "instObjGroups.objectGroups" 
		" -s 6"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:legs|bug_rig:legsShape" "rsEnableSubdivision" 
		" 1"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:pinkyFinger|bug_rig:pinkyFingerShape" 
		"instObjGroups.objectGroups" " -s 6"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:pinkyFinger|bug_rig:pinkyFingerShape" 
		"rsEnableSubdivision" " 1"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:middleFinger|bug_rig:middleFingerShape" 
		"instObjGroups.objectGroups" " -s 6"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:middleFinger|bug_rig:middleFingerShape" 
		"rsEnableSubdivision" " 1"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:firstFinger|bug_rig:firstFingerShape" 
		"instObjGroups.objectGroups" " -s 6"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:firstFinger|bug_rig:firstFingerShape" 
		"rsEnableSubdivision" " 1"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:arms|bug_rig:armsShape" "instObjGroups.objectGroups" 
		" -s 6"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:arms|bug_rig:armsShape" "rsEnableSubdivision" 
		" 1"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:wings|bug_rig:wingsShape" "instObjGroups.objectGroups" 
		" -s 6"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:wings|bug_rig:wingsShape" "rsEnableSubdivision" 
		" 1"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:face|bug_rig:faceShape" "instObjGroups.objectGroups" 
		" -s 42"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:face|bug_rig:faceShape" "rsEnableSubdivision" 
		" 1"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_r|bug_rig:eye_rShape" "instObjGroups.objectGroups" 
		" -s 8"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_r|bug_rig:eye_rShape" "rsEnableSubdivision" 
		" 1"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_l|bug_rig:eye_lShape" "instObjGroups.objectGroups" 
		" -s 8"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_l|bug_rig:eye_lShape" "rsEnableSubdivision" 
		" 1"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:body|bug_rig:bodyShape" "instObjGroups.objectGroups" 
		" -s 6"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:body|bug_rig:bodyShape" "rsEnableSubdivision" 
		" 1"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:teethSetup|bug_rig:follicle1_grp|bug_rig:grpTeeth1_conZERO|bug_rig:teeth1_con|bug_rig:teeth1|bug_rig:teethShape1" 
		"instObjGroups.objectGroups[0].objectGrpCompList" " -type \"componentList\" 1 \"f[0:79]\""
		
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:teethSetup|bug_rig:follicle1_grp|bug_rig:grpTeeth1_conZERO|bug_rig:teeth1_con|bug_rig:teeth1|bug_rig:teethShape1" 
		"rsEnableSubdivision" " 1"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:teethSetup|bug_rig:follicle2_grp|bug_rig:grpTeeth2_conZERO|bug_rig:teeth2_con|bug_rig:teeth2|bug_rig:teethShape2" 
		"instObjGroups.objectGroups[0].objectGrpCompList" " -type \"componentList\" 1 \"f[0:79]\""
		
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:teethSetup|bug_rig:follicle2_grp|bug_rig:grpTeeth2_conZERO|bug_rig:teeth2_con|bug_rig:teeth2|bug_rig:teethShape2" 
		"rsEnableSubdivision" " 1"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:neck_|bug_rig:neck_Shape" "instObjGroups.objectGroups" 
		" -s 8"
		2 "|bug_rig:Group|bug_rig:Geometry|bug_rig:neck_|bug_rig:neck_Shape" "rsEnableSubdivision" 
		" 1"
		2 "bug_rig:geo" "displayType" " 0"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_l|bug_rig:eye_lShape.instObjGroups.objectGroups[1]" 
		"bug_rig:blinn4SG.dagSetMembers" "-na"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_r|bug_rig:eye_rShape.instObjGroups.objectGroups[1]" 
		"bug_rig:blinn4SG.dagSetMembers" "-na"
		3 "bug_rig:blinn3SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:face|bug_rig:faceShape.instObjGroups.objectGroups[0].objectGrpColor" 
		""
		3 "bug_rig:blinn3SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:antena|bug_rig:antenaShape.instObjGroups.objectGroups[0].objectGrpColor" 
		""
		3 "bug_rig:blinn3SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_r|bug_rig:eye_rShape.instObjGroups.objectGroups[0].objectGrpColor" 
		""
		3 "bug_rig:blinn4SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_r|bug_rig:eye_rShape.instObjGroups.objectGroups[1].objectGrpColor" 
		""
		3 "bug_rig:blinn3SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:teethSetup|bug_rig:follicle1_grp|bug_rig:grpTeeth1_conZERO|bug_rig:teeth1_con|bug_rig:teeth1|bug_rig:teethShape1.instObjGroups.objectGroups[0].objectGrpColor" 
		""
		3 "bug_rig:groupId394.groupId" "|bug_rig:Group|bug_rig:Geometry|bug_rig:teethSetup|bug_rig:follicle1_grp|bug_rig:grpTeeth1_conZERO|bug_rig:teeth1_con|bug_rig:teeth1|bug_rig:teethShape1.instObjGroups.objectGroups[0].objectGroupId" 
		""
		3 "bug_rig:blinn3SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:body|bug_rig:bodyShape.instObjGroups.objectGroups[0].objectGrpColor" 
		""
		3 "bug_rig:blinn3SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:pinkyFinger|bug_rig:pinkyFingerShape.instObjGroups.objectGroups[0].objectGrpColor" 
		""
		3 "bug_rig:blinn3SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:firstFinger|bug_rig:firstFingerShape.instObjGroups.objectGroups[0].objectGrpColor" 
		""
		3 "bug_rig:blinn3SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:arms|bug_rig:armsShape.instObjGroups.objectGroups[0].objectGrpColor" 
		""
		3 "bug_rig:blinn3SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:neck_|bug_rig:neck_Shape.instObjGroups.objectGroups[0].objectGrpColor" 
		""
		3 "bug_rig:blinn3SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_l|bug_rig:eye_lShape.instObjGroups.objectGroups[0].objectGrpColor" 
		""
		3 "bug_rig:blinn4SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_l|bug_rig:eye_lShape.instObjGroups.objectGroups[1].objectGrpColor" 
		""
		3 "bug_rig:blinn3SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:wings|bug_rig:wingsShape.instObjGroups.objectGroups[0].objectGrpColor" 
		""
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:teethSetup|bug_rig:follicle2_grp|bug_rig:grpTeeth2_conZERO|bug_rig:teeth2_con|bug_rig:teeth2|bug_rig:teethShape2.instObjGroups.objectGroups[0]" 
		"bug_rig:blinn3SG.dagSetMembers" "-na"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:neck_|bug_rig:neck_Shape.instObjGroups.objectGroups[0]" 
		"bug_rig:blinn3SG.dagSetMembers" "-na"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:teethSetup|bug_rig:follicle1_grp|bug_rig:grpTeeth1_conZERO|bug_rig:teeth1_con|bug_rig:teeth1|bug_rig:teethShape1.instObjGroups.objectGroups[0]" 
		"bug_rig:blinn3SG.dagSetMembers" "-na"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:body|bug_rig:bodyShape.instObjGroups.objectGroups[0]" 
		"bug_rig:blinn3SG.dagSetMembers" "-na"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_l|bug_rig:eye_lShape.instObjGroups.objectGroups[0]" 
		"bug_rig:blinn3SG.dagSetMembers" "-na"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_r|bug_rig:eye_rShape.instObjGroups.objectGroups[0]" 
		"bug_rig:blinn3SG.dagSetMembers" "-na"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:firstFinger|bug_rig:firstFingerShape.instObjGroups.objectGroups[0]" 
		"bug_rig:blinn3SG.dagSetMembers" "-na"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:wings|bug_rig:wingsShape.instObjGroups.objectGroups[0]" 
		"bug_rig:blinn3SG.dagSetMembers" "-na"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:arms|bug_rig:armsShape.instObjGroups.objectGroups[0]" 
		"bug_rig:blinn3SG.dagSetMembers" "-na"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:pinkyFinger|bug_rig:pinkyFingerShape.instObjGroups.objectGroups[0]" 
		"bug_rig:blinn3SG.dagSetMembers" "-na"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:middleFinger|bug_rig:middleFingerShape.instObjGroups.objectGroups[0]" 
		"bug_rig:blinn3SG.dagSetMembers" "-na"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:faceBase|bug_rig:faceBaseShape.instObjGroups.objectGroups[0]" 
		"bug_rig:blinn3SG.dagSetMembers" "-na"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:face|bug_rig:faceShape.instObjGroups.objectGroups[0]" 
		"bug_rig:blinn3SG.dagSetMembers" "-na"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:antena|bug_rig:antenaShape.instObjGroups.objectGroups[0]" 
		"bug_rig:blinn3SG.dagSetMembers" "-na"
		3 "|bug_rig:Group|bug_rig:Geometry|bug_rig:legs|bug_rig:legsShape.instObjGroups.objectGroups[0]" 
		"bug_rig:blinn3SG.dagSetMembers" "-na"
		3 "bug_rig:groupId395.message" "bug_rig:blinn3SG.groupNodes" "-na"
		3 "bug_rig:groupId394.message" "bug_rig:blinn3SG.groupNodes" "-na"
		3 "bug_rig:blinn3SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:middleFinger|bug_rig:middleFingerShape.instObjGroups.objectGroups[0].objectGrpColor" 
		""
		3 "bug_rig:blinn3SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:legs|bug_rig:legsShape.instObjGroups.objectGroups[0].objectGrpColor" 
		""
		3 "bug_rig:blinn3SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:faceBase|bug_rig:faceBaseShape.instObjGroups.objectGroups[0].objectGrpColor" 
		""
		3 "bug_rig:blinn3SG.memberWireframeColor" "|bug_rig:Group|bug_rig:Geometry|bug_rig:teethSetup|bug_rig:follicle2_grp|bug_rig:grpTeeth2_conZERO|bug_rig:teeth2_con|bug_rig:teeth2|bug_rig:teethShape2.instObjGroups.objectGroups[0].objectGrpColor" 
		""
		3 "bug_rig:groupId395.groupId" "|bug_rig:Group|bug_rig:Geometry|bug_rig:teethSetup|bug_rig:follicle2_grp|bug_rig:grpTeeth2_conZERO|bug_rig:teeth2_con|bug_rig:teeth2|bug_rig:teethShape2.instObjGroups.objectGroups[0].objectGroupId" 
		""
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Main|bug_rig:MotionSystem|bug_rig:ClusterSystem|bug_rig:lipUpperExtra01Attach_R|bug_rig:lipUpperExtra01Offset_R|bug_rig:lipUpperExtra01Subtract_R|bug_rig:lipUpperExtra01_R.drawOverride" 
		"bug_rigRN.placeHolderList[1]" ""
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Main|bug_rig:MotionSystem|bug_rig:ClusterSystem|bug_rig:lipUpperExtra01Attach_L|bug_rig:lipUpperExtra01Offset_L|bug_rig:lipUpperExtra01Subtract_L|bug_rig:lipUpperExtra01_L.drawOverride" 
		"bug_rigRN.placeHolderList[2]" ""
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Main|bug_rig:MotionSystem|bug_rig:ClusterSystem|bug_rig:lipUpperExtra02Attach_R|bug_rig:lipUpperExtra02Offset_R|bug_rig:lipUpperExtra02Subtract_R|bug_rig:lipUpperExtra02_R.drawOverride" 
		"bug_rigRN.placeHolderList[3]" ""
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Main|bug_rig:MotionSystem|bug_rig:ClusterSystem|bug_rig:lipUpperExtra02Attach_L|bug_rig:lipUpperExtra02Offset_L|bug_rig:lipUpperExtra02Subtract_L|bug_rig:lipUpperExtra02_L.drawOverride" 
		"bug_rigRN.placeHolderList[4]" ""
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Main|bug_rig:MotionSystem|bug_rig:ClusterSystem|bug_rig:lipUpperExtra03Attach_R|bug_rig:lipUpperExtra03Offset_R|bug_rig:lipUpperExtra03Subtract_R|bug_rig:lipUpperExtra03_R.drawOverride" 
		"bug_rigRN.placeHolderList[5]" ""
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Main|bug_rig:MotionSystem|bug_rig:ClusterSystem|bug_rig:lipUpperExtra03Attach_L|bug_rig:lipUpperExtra03Offset_L|bug_rig:lipUpperExtra03Subtract_L|bug_rig:lipUpperExtra03_L.drawOverride" 
		"bug_rigRN.placeHolderList[6]" ""
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Main|bug_rig:MotionSystem|bug_rig:ClusterSystem|bug_rig:lipUpperMidAttach_M|bug_rig:lipUpperMidOffset_M|bug_rig:lipUpperMidSubtract_M|bug_rig:lipUpperMid_M.drawOverride" 
		"bug_rigRN.placeHolderList[7]" ""
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Main|bug_rig:MotionSystem|bug_rig:ClusterSystem|bug_rig:lipLowerExtra01Attach_R|bug_rig:lipLowerExtra01Offset_R|bug_rig:lipLowerExtra01Subtract_R|bug_rig:lipLowerExtra01_R.drawOverride" 
		"bug_rigRN.placeHolderList[8]" ""
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Main|bug_rig:MotionSystem|bug_rig:ClusterSystem|bug_rig:lipLowerExtra01Attach_L|bug_rig:lipLowerExtra01Offset_L|bug_rig:lipLowerExtra01Subtract_L|bug_rig:lipLowerExtra01_L.drawOverride" 
		"bug_rigRN.placeHolderList[9]" ""
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Main|bug_rig:MotionSystem|bug_rig:ClusterSystem|bug_rig:lipLowerExtra02Attach_R|bug_rig:lipLowerExtra02Offset_R|bug_rig:lipLowerExtra02Subtract_R|bug_rig:lipLowerExtra02_R.drawOverride" 
		"bug_rigRN.placeHolderList[10]" ""
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Main|bug_rig:MotionSystem|bug_rig:ClusterSystem|bug_rig:lipLowerExtra02Attach_L|bug_rig:lipLowerExtra02Offset_L|bug_rig:lipLowerExtra02Subtract_L|bug_rig:lipLowerExtra02_L.drawOverride" 
		"bug_rigRN.placeHolderList[11]" ""
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Main|bug_rig:MotionSystem|bug_rig:ClusterSystem|bug_rig:lipLowerExtra03Attach_R|bug_rig:lipLowerExtra03Offset_R|bug_rig:lipLowerExtra03Subtract_R|bug_rig:lipLowerExtra03_R.drawOverride" 
		"bug_rigRN.placeHolderList[12]" ""
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Main|bug_rig:MotionSystem|bug_rig:ClusterSystem|bug_rig:lipLowerExtra03Attach_L|bug_rig:lipLowerExtra03Offset_L|bug_rig:lipLowerExtra03Subtract_L|bug_rig:lipLowerExtra03_L.drawOverride" 
		"bug_rigRN.placeHolderList[13]" ""
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Main|bug_rig:MotionSystem|bug_rig:ClusterSystem|bug_rig:lipLowerMidAttach_M|bug_rig:lipLowerMidOffset_M|bug_rig:lipLowerMidSubtract_M|bug_rig:lipLowerMid_M.drawOverride" 
		"bug_rigRN.placeHolderList[14]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:faceBase|bug_rig:faceBaseShape.instObjGroups.objectGroups[0]" 
		"bug_rigRN.placeHolderList[15]" "bug_rig:blinn3SG.dsm"
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:faceBase|bug_rig:faceBaseShape.instObjGroups.objectGroups[0].objectGrpColor" 
		"bug_rigRN.placeHolderList[16]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:antena|bug_rig:antenaShape.instObjGroups.objectGroups[0]" 
		"bug_rigRN.placeHolderList[17]" "bug_rig:blinn3SG.dsm"
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:antena|bug_rig:antenaShape.instObjGroups.objectGroups[0].objectGrpColor" 
		"bug_rigRN.placeHolderList[18]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:legs|bug_rig:legsShape.instObjGroups.objectGroups[0]" 
		"bug_rigRN.placeHolderList[19]" "bug_rig:blinn3SG.dsm"
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:legs|bug_rig:legsShape.instObjGroups.objectGroups[0].objectGrpColor" 
		"bug_rigRN.placeHolderList[20]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:pinkyFinger|bug_rig:pinkyFingerShape.instObjGroups.objectGroups[0]" 
		"bug_rigRN.placeHolderList[21]" "bug_rig:blinn3SG.dsm"
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:pinkyFinger|bug_rig:pinkyFingerShape.instObjGroups.objectGroups[0].objectGrpColor" 
		"bug_rigRN.placeHolderList[22]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:middleFinger|bug_rig:middleFingerShape.instObjGroups.objectGroups[0]" 
		"bug_rigRN.placeHolderList[23]" "bug_rig:blinn3SG.dsm"
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:middleFinger|bug_rig:middleFingerShape.instObjGroups.objectGroups[0].objectGrpColor" 
		"bug_rigRN.placeHolderList[24]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:firstFinger|bug_rig:firstFingerShape.instObjGroups.objectGroups[0]" 
		"bug_rigRN.placeHolderList[25]" "bug_rig:blinn3SG.dsm"
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:firstFinger|bug_rig:firstFingerShape.instObjGroups.objectGroups[0].objectGrpColor" 
		"bug_rigRN.placeHolderList[26]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:arms|bug_rig:armsShape.instObjGroups.objectGroups[0]" 
		"bug_rigRN.placeHolderList[27]" "bug_rig:blinn3SG.dsm"
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:arms|bug_rig:armsShape.instObjGroups.objectGroups[0].objectGrpColor" 
		"bug_rigRN.placeHolderList[28]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:wings|bug_rig:wingsShape.instObjGroups.objectGroups[0]" 
		"bug_rigRN.placeHolderList[29]" "bug_rig:blinn3SG.dsm"
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:wings|bug_rig:wingsShape.instObjGroups.objectGroups[0].objectGrpColor" 
		"bug_rigRN.placeHolderList[30]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:face|bug_rig:faceShape.instObjGroups.objectGroups[0]" 
		"bug_rigRN.placeHolderList[31]" "bug_rig:blinn3SG.dsm"
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:face|bug_rig:faceShape.instObjGroups.objectGroups[0].objectGrpColor" 
		"bug_rigRN.placeHolderList[32]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_r|bug_rig:eye_rShape.instObjGroups.objectGroups[0]" 
		"bug_rigRN.placeHolderList[33]" "bug_rig:blinn3SG.dsm"
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_r|bug_rig:eye_rShape.instObjGroups.objectGroups[0].objectGrpColor" 
		"bug_rigRN.placeHolderList[34]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_r|bug_rig:eye_rShape.instObjGroups.objectGroups[1]" 
		"bug_rigRN.placeHolderList[35]" "bug_rig:blinn4SG.dsm"
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_r|bug_rig:eye_rShape.instObjGroups.objectGroups[1].objectGrpColor" 
		"bug_rigRN.placeHolderList[36]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_l|bug_rig:eye_lShape.instObjGroups.objectGroups[0]" 
		"bug_rigRN.placeHolderList[37]" "bug_rig:blinn3SG.dsm"
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_l|bug_rig:eye_lShape.instObjGroups.objectGroups[0].objectGrpColor" 
		"bug_rigRN.placeHolderList[38]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_l|bug_rig:eye_lShape.instObjGroups.objectGroups[1]" 
		"bug_rigRN.placeHolderList[39]" "bug_rig:blinn4SG.dsm"
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:eye_l|bug_rig:eye_lShape.instObjGroups.objectGroups[1].objectGrpColor" 
		"bug_rigRN.placeHolderList[40]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:body|bug_rig:bodyShape.instObjGroups.objectGroups[0]" 
		"bug_rigRN.placeHolderList[41]" "bug_rig:blinn3SG.dsm"
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:body|bug_rig:bodyShape.instObjGroups.objectGroups[0].objectGrpColor" 
		"bug_rigRN.placeHolderList[42]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:teethSetup|bug_rig:follicle1_grp|bug_rig:grpTeeth1_conZERO|bug_rig:teeth1_con|bug_rig:teeth1|bug_rig:teethShape1.instObjGroups" 
		"bug_rigRN.placeHolderList[43]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:teethSetup|bug_rig:follicle2_grp|bug_rig:grpTeeth2_conZERO|bug_rig:teeth2_con|bug_rig:teeth2|bug_rig:teethShape2.instObjGroups" 
		"bug_rigRN.placeHolderList[44]" ""
		5 3 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:neck_|bug_rig:neck_Shape.instObjGroups.objectGroups[0]" 
		"bug_rigRN.placeHolderList[45]" "bug_rig:blinn3SG.dsm"
		5 4 "bug_rigRN" "|bug_rig:Group|bug_rig:Geometry|bug_rig:neck_|bug_rig:neck_Shape.instObjGroups.objectGroups[0].objectGrpColor" 
		"bug_rigRN.placeHolderList[46]" "";
	setAttr ".ptag" -type "string" "";
lockNode -l 1 ;
createNode script -n "uiConfigurationScriptNode";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"top\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n"
		+ "                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 32768\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -maxConstantTransparency 1\n                -rendererName \"base_OpenGL_Renderer\" \n"
		+ "                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n"
		+ "                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n            modelEditor -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 1\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -maxConstantTransparency 1\n"
		+ "            -rendererName \"base_OpenGL_Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n"
		+ "            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels `;\n"
		+ "\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"side\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 32768\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n"
		+ "                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -maxConstantTransparency 1\n                -rendererName \"base_OpenGL_Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n"
		+ "                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n            modelEditor -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n"
		+ "                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 1\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n"
		+ "            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -maxConstantTransparency 1\n            -rendererName \"base_OpenGL_Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n"
		+ "            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"front\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n"
		+ "                -textureMaxSize 32768\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -maxConstantTransparency 1\n                -rendererName \"base_OpenGL_Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n"
		+ "                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n"
		+ "                -shadows 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n            modelEditor -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 1\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n"
		+ "            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -maxConstantTransparency 1\n            -rendererName \"base_OpenGL_Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n"
		+ "            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n"
		+ "        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"camera1\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n"
		+ "                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 32768\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -maxConstantTransparency 1\n                -rendererName \"base_OpenGL_Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n"
		+ "                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n"
		+ "                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n            modelEditor -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"camera1\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n"
		+ "            -bufferMode \"double\" \n            -twoSidedLighting 1\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -maxConstantTransparency 1\n            -rendererName \"base_OpenGL_Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n"
		+ "            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n"
		+ "            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `outlinerPanel -unParent -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            outlinerEditor -e \n                -docTag \"isolOutln_fromSeln\" \n                -showShapes 0\n                -showReferenceNodes 1\n                -showReferenceMembers 1\n                -showAttributes 0\n                -showConnected 0\n                -showAnimCurvesOnly 0\n                -showMuteInfo 0\n"
		+ "                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 1\n                -showAssets 1\n                -showContainedOnly 1\n                -showPublishedAsConnected 0\n                -showContainerContents 1\n                -ignoreDagHierarchy 0\n                -expandConnections 0\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 0\n                -highlightActive 1\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"defaultSetFilter\" \n                -showSetMembers 1\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n"
		+ "                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 1\n                -niceNames 0\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 0\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -docTag \"isolOutln_fromSeln\" \n            -showShapes 0\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n"
		+ "            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n"
		+ "            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 1\n            -niceNames 0\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"graphEditor\" -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n"
		+ "                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n"
		+ "                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n"
		+ "                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n"
		+ "                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n"
		+ "                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -stackedCurves 0\n"
		+ "                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dopeSheetPanel\" -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n"
		+ "                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n"
		+ "                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n"
		+ "                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n"
		+ "                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                $editorName;\n"
		+ "\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"clipEditorPanel\" -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n"
		+ "            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 0 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"sequenceEditorPanel\" -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 1 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n"
		+ "                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"hyperGraphPanel\" -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n"
		+ "                -showConnectionToSelected 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n"
		+ "                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"hyperShadePanel\" -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\tif ($useSceneConfig) {\n\t\tscriptedPanel -e -to $panelName;\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"visorPanel\" -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"nodeEditorPanel\" -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -defaultPinnedState 0\n                -ignoreAssets 1\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -keyReleaseCommand \"nodeEdKeyReleaseCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -island 0\n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n"
		+ "                -showTransforms 1\n                -syncedSelection 1\n                -extendToShapes 1\n                $editorName;;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -defaultPinnedState 0\n                -ignoreAssets 1\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -keyReleaseCommand \"nodeEdKeyReleaseCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -island 0\n"
		+ "                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -syncedSelection 1\n                -extendToShapes 1\n                $editorName;;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"createNodePanel\" -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Texture Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"polyTexturePlacementPanel\" -l (localizedPanelLabel(\"UV Texture Editor\")) -mbv $menusOkayInPanels `;\n"
		+ "\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Texture Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"renderWindowPanel\" -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"blendShapePanel\" (localizedPanelLabel(\"Blend Shape\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\tblendShapePanel -unParent -l (localizedPanelLabel(\"Blend Shape\")) -mbv $menusOkayInPanels ;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tblendShapePanel -edit -l (localizedPanelLabel(\"Blend Shape\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dynRelEdPanel\" -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"relationshipPanel\" -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels `;\n"
		+ "\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"referenceEditorPanel\" -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"componentEditorPanel\" -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels `;\n"
		+ "\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dynPaintScriptedPanelType\" -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"scriptEditorPanel\" -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels `;\n"
		+ "\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"Stereo\" (localizedPanelLabel(\"Stereo\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"Stereo\" -l (localizedPanelLabel(\"Stereo\")) -mbv $menusOkayInPanels `;\nstring $editorName = ($panelName+\"Editor\");\n            stereoCameraView -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n"
		+ "                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 32768\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -maxConstantTransparency 1\n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 4 4 \n                -bumpResolution 4 4 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 0\n"
		+ "                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n"
		+ "                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -displayMode \"centerEye\" \n                -viewColor 0 0 0 1 \n                -useCustomBackground 1\n                $editorName;\n            stereoCameraView -e -viewSelected 0 $editorName;\n            stereoCameraView -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Stereo\")) -mbv $menusOkayInPanels  $panelName;\nstring $editorName = ($panelName+\"Editor\");\n            stereoCameraView -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n"
		+ "                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 32768\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -maxConstantTransparency 1\n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 4 4 \n"
		+ "                -bumpResolution 4 4 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 0\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n"
		+ "                -dynamics 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -displayMode \"centerEye\" \n                -viewColor 0 0 0 1 \n                -useCustomBackground 1\n                $editorName;\n            stereoCameraView -e -viewSelected 0 $editorName;\n            stereoCameraView -e \n                -pluginObjects \"gpuCacheDisplayFilter\" 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n"
		+ "        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-defaultImage \"vacantCell.xP:/\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -camera \\\"camera1\\\" \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 1\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -maxConstantTransparency 1\\n    -rendererName \\\"base_OpenGL_Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -camera \\\"camera1\\\" \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 1\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -maxConstantTransparency 1\\n    -rendererName \\\"base_OpenGL_Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        setFocus `paneLayout -q -p1 $gMainPane`;\n        sceneUIReplacement -deleteRemaining;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 24 -ast 1 -aet 48 ";
	setAttr ".st" 6;
createNode RedshiftOptions -s -n "redshiftOptions";
	addAttr -ci true -h true -sn "physicalSky" -ln "physicalSky" -at "message";
	setAttr ".imageFilePrefix" -type "string" "bug_aniation";
	setAttr ".imageFormat" 5;
	setAttr ".unifiedMinSamples" 8;
	setAttr ".unifiedMaxSamples" 128;
	setAttr ".primaryGIEngine" 4;
createNode RedshiftMaterial -n "rsBody";
	setAttr ".v" 1;
	setAttr ".refl_roughness" 0.24701195955276489;
createNode shadingEngine -n "rsMaterial1SG";
	setAttr ".ihi" 0;
	setAttr -s 11 ".dsm";
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo1";
createNode RedshiftAmbientOcclusion -n "rsAmbientOcclusion1";
	setAttr ".bright" -type "float3" 0 0.4509804 0 ;
	setAttr ".dark" -type "float3" 0 0.4509804 0 ;
createNode RedshiftMaterial -n "rsMaterial2";
	setAttr ".v" 1;
	setAttr ".refl_weight" 0;
createNode shadingEngine -n "rsMaterial2SG";
	setAttr ".ihi" 0;
	setAttr -s 2 ".dsm";
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo2";
createNode RedshiftAmbientOcclusion -n "rsAmbientOcclusion2";
	setAttr ".bright" -type "float3" 0 0 0 ;
createNode RedshiftMaterial -n "rsTeeth";
	setAttr ".v" 1;
createNode shadingEngine -n "rsMaterial3SG";
	setAttr ".ihi" 0;
	setAttr -s 4 ".dsm";
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo3";
createNode RedshiftAmbientOcclusion -n "rsAmbientOcclusion3";
	setAttr ".bright" -type "float3" 0.91600001 0.91600001 0.91600001 ;
	setAttr ".dark" -type "float3" 0.91600001 0.91600001 0.91600001 ;
createNode displayLayer -n "layer1";
	setAttr ".v" no;
	setAttr ".do" 1;
select -ne :time1;
	setAttr ".o" 1;
	setAttr ".unw" 1;
select -ne :renderPartition;
	setAttr -s 40 ".st";
select -ne :initialShadingGroup;
	setAttr -s 21 ".dsm";
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultShaderList1;
	setAttr -s 28 ".s";
select -ne :defaultTextureList1;
select -ne :lightList1;
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
	setAttr -s 4 ".u";
select -ne :defaultRenderingList1;
	setAttr -s 2 ".r";
select -ne :renderGlobalsList1;
select -ne :defaultRenderGlobals;
	setAttr ".ren" -type "string" "redshift";
	setAttr ".outf" 51;
	setAttr ".imfkey" -type "string" "tif";
	setAttr ".an" yes;
	setAttr ".pff" yes;
	setAttr ".ifp" -type "string" "bug_aniation";
select -ne :defaultResolution;
	setAttr ".w" 1280;
	setAttr ".h" 720;
	setAttr ".pa" 1;
	setAttr ".dar" 1.7769999504089355;
select -ne :defaultLightSet;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 18 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surfaces" "Particles" "Fluids" "Image Planes" "UI:" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 18 0 1 1 1 1 1
		 1 0 0 0 0 0 0 0 0 0 0 0 ;
select -ne :defaultHardwareRenderGlobals;
	setAttr ".fn" -type "string" "im";
	setAttr ".res" -type "string" "ntsc_4d 646 485 1.333";
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "layer1.di" "bug_rigRN.phl[1]";
connectAttr "layer1.di" "bug_rigRN.phl[2]";
connectAttr "layer1.di" "bug_rigRN.phl[3]";
connectAttr "layer1.di" "bug_rigRN.phl[4]";
connectAttr "layer1.di" "bug_rigRN.phl[5]";
connectAttr "layer1.di" "bug_rigRN.phl[6]";
connectAttr "layer1.di" "bug_rigRN.phl[7]";
connectAttr "layer1.di" "bug_rigRN.phl[8]";
connectAttr "layer1.di" "bug_rigRN.phl[9]";
connectAttr "layer1.di" "bug_rigRN.phl[10]";
connectAttr "layer1.di" "bug_rigRN.phl[11]";
connectAttr "layer1.di" "bug_rigRN.phl[12]";
connectAttr "layer1.di" "bug_rigRN.phl[13]";
connectAttr "layer1.di" "bug_rigRN.phl[14]";
connectAttr "bug_rigRN.phl[15]" "rsMaterial1SG.dsm" -na;
connectAttr "rsMaterial1SG.mwc" "bug_rigRN.phl[16]";
connectAttr "bug_rigRN.phl[17]" "rsMaterial1SG.dsm" -na;
connectAttr "rsMaterial1SG.mwc" "bug_rigRN.phl[18]";
connectAttr "bug_rigRN.phl[19]" "rsMaterial1SG.dsm" -na;
connectAttr "rsMaterial1SG.mwc" "bug_rigRN.phl[20]";
connectAttr "bug_rigRN.phl[21]" "rsMaterial1SG.dsm" -na;
connectAttr "rsMaterial1SG.mwc" "bug_rigRN.phl[22]";
connectAttr "bug_rigRN.phl[23]" "rsMaterial1SG.dsm" -na;
connectAttr "rsMaterial1SG.mwc" "bug_rigRN.phl[24]";
connectAttr "bug_rigRN.phl[25]" "rsMaterial1SG.dsm" -na;
connectAttr "rsMaterial1SG.mwc" "bug_rigRN.phl[26]";
connectAttr "bug_rigRN.phl[27]" "rsMaterial1SG.dsm" -na;
connectAttr "rsMaterial1SG.mwc" "bug_rigRN.phl[28]";
connectAttr "bug_rigRN.phl[29]" "rsMaterial1SG.dsm" -na;
connectAttr "rsMaterial1SG.mwc" "bug_rigRN.phl[30]";
connectAttr "bug_rigRN.phl[31]" "rsMaterial1SG.dsm" -na;
connectAttr "rsMaterial1SG.mwc" "bug_rigRN.phl[32]";
connectAttr "bug_rigRN.phl[33]" "rsMaterial3SG.dsm" -na;
connectAttr "rsMaterial3SG.mwc" "bug_rigRN.phl[34]";
connectAttr "bug_rigRN.phl[35]" "rsMaterial2SG.dsm" -na;
connectAttr "rsMaterial2SG.mwc" "bug_rigRN.phl[36]";
connectAttr "bug_rigRN.phl[37]" "rsMaterial3SG.dsm" -na;
connectAttr "rsMaterial3SG.mwc" "bug_rigRN.phl[38]";
connectAttr "bug_rigRN.phl[39]" "rsMaterial2SG.dsm" -na;
connectAttr "rsMaterial2SG.mwc" "bug_rigRN.phl[40]";
connectAttr "bug_rigRN.phl[41]" "rsMaterial1SG.dsm" -na;
connectAttr "rsMaterial1SG.mwc" "bug_rigRN.phl[42]";
connectAttr "bug_rigRN.phl[43]" "rsMaterial3SG.dsm" -na;
connectAttr "bug_rigRN.phl[44]" "rsMaterial3SG.dsm" -na;
connectAttr "bug_rigRN.phl[45]" "rsMaterial1SG.dsm" -na;
connectAttr "rsMaterial1SG.mwc" "bug_rigRN.phl[46]";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "rsMaterial1SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "rsMaterial2SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "rsMaterial3SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "rsMaterial1SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "rsMaterial2SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "rsMaterial3SG.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "rsAmbientOcclusion1.oc" "rsBody.diffuse_color";
connectAttr "rsBody.oc" "rsMaterial1SG.ss";
connectAttr "rsMaterial1SG.msg" "materialInfo1.sg";
connectAttr "rsBody.msg" "materialInfo1.m";
connectAttr "rsAmbientOcclusion1.msg" "materialInfo1.t" -na;
connectAttr "rsAmbientOcclusion2.oc" "rsMaterial2.diffuse_color";
connectAttr "rsMaterial2.oc" "rsMaterial2SG.ss";
connectAttr "rsMaterial2SG.msg" "materialInfo2.sg";
connectAttr "rsMaterial2.msg" "materialInfo2.m";
connectAttr "rsAmbientOcclusion2.msg" "materialInfo2.t" -na;
connectAttr "rsAmbientOcclusion3.oc" "rsTeeth.diffuse_color";
connectAttr "rsTeeth.oc" "rsMaterial3SG.ss";
connectAttr "rsMaterial3SG.msg" "materialInfo3.sg";
connectAttr "rsTeeth.msg" "materialInfo3.m";
connectAttr "rsAmbientOcclusion3.msg" "materialInfo3.t" -na;
connectAttr "layerManager.dli[1]" "layer1.id";
connectAttr "rsMaterial1SG.pa" ":renderPartition.st" -na;
connectAttr "rsMaterial2SG.pa" ":renderPartition.st" -na;
connectAttr "rsMaterial3SG.pa" ":renderPartition.st" -na;
connectAttr "rsBody.msg" ":defaultShaderList1.s" -na;
connectAttr "rsMaterial2.msg" ":defaultShaderList1.s" -na;
connectAttr "rsTeeth.msg" ":defaultShaderList1.s" -na;
connectAttr "rsDomeLightShape1.ltd" ":lightList1.l" -na;
connectAttr "rsAmbientOcclusion1.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "rsAmbientOcclusion2.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "rsAmbientOcclusion3.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "rsDomeLight1.iog" ":defaultLightSet.dsm" -na;
// End of bug_lighting_redshift3d.ma
