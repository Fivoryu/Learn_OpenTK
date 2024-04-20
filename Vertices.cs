using Hello_OpenTK.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace Hello_OpenTK
{
    public class Vertices2
    {
        public static List<Vertex2> Cubo = new List<Vertex2>()
        {
            new Vertex2(new Vector3(-0.5f, -0.5f, 0.5f), new Vector3(0.0f, 0.0f, 0.0f)),
            new Vertex2(new Vector3(-0.5f,  0.5f,  0.5f), new Vector3(0.0f, 0.0f, 0.0f)),
            new Vertex2(new Vector3( 0.5f,  0.5f,  0.5f), new Vector3(1.0f, 1.0f, 1.0f)),
            new Vertex2(new Vector3( 0.5f, -0.5f, 0.5f), new Vector3(1.0f, 1.0f, 1.0f)),

            new Vertex2(new Vector3( 0.5f,  0.5f, -0.5f), new Vector3(1.0f, 1.0f, 1.0f)),
            new Vertex2(new Vector3( 0.5f, -0.5f, -0.5f), new Vector3(1.0f, 1.0f, 1.0f)),

            new Vertex2(new Vector3(-0.5f,  0.5f, -0.5f), new Vector3(0.0f, 1.0f, 1.0f)),
            new Vertex2(new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(0.0f, 1.0f, 1.0f)),
        };
        public static List<uint> Indices = new List<uint>{ // Note that we start from 0!        
            0, 1, 2,    // First triangle 
            0, 3, 2,     // Second triangle

            3, 2, 4,    // Right
            3, 5, 4,

            5, 4, 6,    // Back
            5, 7, 6,

            7, 6, 1,    // Left
            7, 0, 1,

            1, 6, 4,    // Top
            1, 2, 4,

            0, 7, 5,    // Bottom
            0, 3, 5
        };

        public static List<Vertex2> TV = new List<Vertex2>()
        {
            // Supports
            new Vertex2(new Vector3(-0.25f, -0.875f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 0
            new Vertex2(new Vector3(-0.25f,  -0.75f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 1
            new Vertex2(new Vector3( 0.25f,  -0.75f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 2
            new Vertex2(new Vector3( 0.25f, -0.875f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 3

            new Vertex2(new Vector3( 0.25f, -0.75f,   0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 4
            new Vertex2(new Vector3( 0.25f, -0.875f,  0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 5

            new Vertex2(new Vector3(-0.25f, -0.75f,   0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 6
            new Vertex2(new Vector3(-0.25f, -0.875f,  0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 7
            /////////////////////////////////////////////////////////////////////////////////////////
            new Vertex2(new Vector3(-0.0625f, -0.75f,   -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 8
            new Vertex2(new Vector3(-0.0625f, -0.5625f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 9
            new Vertex2(new Vector3( 0.0625f, -0.5625f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 10
            new Vertex2(new Vector3( 0.0625f, -0.75f,   -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 11

            new Vertex2(new Vector3(-0.0625f, -0.75f,    0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 12
            new Vertex2(new Vector3(-0.0625f, -0.5625f,  0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 13

            new Vertex2(new Vector3(0.0625f, -0.5625f,  0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 14
            new Vertex2(new Vector3(0.0625f, -0.75f,    0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 15
            //////////////////////////////////////////////////////////////////////////////////////////
            // Edges
            // Down -1.0625f
            new Vertex2(new Vector3(-0.5625f, -1.0625f + 0.5f,    -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 16
            new Vertex2(new Vector3(-0.5625f, -1.0625f + 0.5625f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 17
            new Vertex2(new Vector3( 0.5625f, -1.0625f + 0.5625f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 18
            new Vertex2(new Vector3( 0.5625f, -1.0625f + 0.5f,    -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 19

            new Vertex2(new Vector3(-0.5625f, -1.0625f + 0.5f,     0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 20
            new Vertex2(new Vector3(-0.5625f, -1.0625f + 0.5625f,  0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 21

            new Vertex2(new Vector3(0.5625f, -1.0625f + 0.5625f,  0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 22
            new Vertex2(new Vector3(0.5625f, -1.0625f + 0.5f,     0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 23
            //////////////////////////////////////////////////////////////////////////////////////////
            // Left
            new Vertex2(new Vector3(-0.5625f, -0.5f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 24
            new Vertex2(new Vector3(-0.5625f,  0.5f,  -0.125f), new Vector3(0.2f, 0.2f, 0.2f)), // 25
            new Vertex2(new Vector3(-0.5f,     0.5f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 26
            new Vertex2(new Vector3(-0.5f,    -0.5f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 27

            new Vertex2(new Vector3(-0.5625f, -0.5f, 0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 28
            new Vertex2(new Vector3(-0.5625f,  0.5f, 0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 29

            new Vertex2(new Vector3(-0.5f,     0.5f, 0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 30
            new Vertex2(new Vector3(-0.5f,    -0.5f, 0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 31
            //////////////////////////////////////////////////////////////////////////////////////////
            // Up 
            new Vertex2(new Vector3(-0.5625f, 0.5f,    -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 32
            new Vertex2(new Vector3(-0.5625f, 0.5625f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 33
            new Vertex2(new Vector3( 0.5625f, 0.5625f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 34
            new Vertex2(new Vector3( 0.5625f, 0.5f,    -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 35

            new Vertex2(new Vector3(-0.5625f, 0.5f,    0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 36
            new Vertex2(new Vector3(-0.5625f, 0.5625f,  0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 37

            new Vertex2(new Vector3(0.5625f,  0.5625f,  0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 38
            new Vertex2(new Vector3(0.5625f,  0.5f,    0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 39
            //////////////////////////////////////////////////////////////////////////////////////////
            // Right + 1.0625f
            new Vertex2(new Vector3(-0.5625f + 1.0625f, -0.5f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 40
            new Vertex2(new Vector3(-0.5625f + 1.0625f,  0.5f,  -0.125f), new Vector3(0.2f, 0.2f, 0.2f)), // 41
            new Vertex2(new Vector3(-0.5f + 1.0625f,     0.5f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 42
            new Vertex2(new Vector3(-0.5f + 1.0625f,    -0.5f, -0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 43

            new Vertex2(new Vector3(-0.5625f + 1.0625f, -0.5f, 0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 44
            new Vertex2(new Vector3(-0.5625f + 1.0625f,  0.5f, 0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 45

            new Vertex2(new Vector3(-0.5f + 1.0625f,     0.5f, 0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 46
            new Vertex2(new Vector3(-0.5f + 1.0625f,    -0.5f, 0.125f), new Vector3(0.2f, 0.2f, 0.2f)),  // 47
            //////////////////////////////////////////////////////////////////////////////////////////
            // Screen
            new Vertex2(new Vector3(-0.5f, -0.5f, -0.125f), new Vector3(0.5f, 0.5f, 0.5f)),  // 48
            new Vertex2(new Vector3(-0.5f,  0.5f, -0.125f), new Vector3(0.5f, 0.5f, 0.5f)), // 49
            new Vertex2(new Vector3( 0.5f,  0.5f, -0.125f), new Vector3(0.5f, 0.5f, 0.5f)),  // 50
            new Vertex2(new Vector3( 0.5f, -0.5f, -0.125f), new Vector3(0.5f, 0.5f, 0.5f)),  // 51

            new Vertex2(new Vector3(-0.5f, -0.5f,  0.125f), new Vector3(0.5f, 0.5f, 0.5f)),  // 52
            new Vertex2(new Vector3(-0.5f,  0.5f,  0.125f), new Vector3(0.5f, 0.5f, 0.5f)),  // 53

            new Vertex2(new Vector3(0.5f,  0.5f,  0.125f), new Vector3(0.5f, 0.5f, 0.5f)),  // 54
            new Vertex2(new Vector3(0.5f, -0.5f,  0.125f), new Vector3(0.5f, 0.5f, 0.5f)),  // 55
            //////////////////////////////////////////////////////////////////////////////////////////
            // Back + 0.125f
            new Vertex2(new Vector3(-0.5f, -0.5f, -0.125f + 0.125f), new Vector3(0.18f, 0.18f, 0.18f)),  // 56
            new Vertex2(new Vector3(-0.5f,  0.5f, -0.125f + 0.125f), new Vector3(0.18f, 0.18f, 0.18f)),  // 57
            new Vertex2(new Vector3( 0.5f,  0.5f, -0.125f + 0.125f), new Vector3(0.18f, 0.18f, 0.18f)),  // 58
            new Vertex2(new Vector3( 0.5f, -0.5f, -0.125f + 0.125f), new Vector3(0.18f, 0.18f, 0.18f)),  // 59

            new Vertex2(new Vector3(-0.5f, -0.5f,  0.125f + 0.125f), new Vector3(0.18f, 0.18f, 0.18f)),  // 60
            new Vertex2(new Vector3(-0.5f,  0.5f,  0.125f + 0.125f), new Vector3(0.18f, 0.18f, 0.18f)),  // 61

            new Vertex2(new Vector3(0.5f,  0.5f,  0.125f + 0.125f), new Vector3(0.18f, 0.18f, 0.18f)),   // 62
            new Vertex2(new Vector3(0.5f, -0.5f,  0.125f + 0.125f), new Vector3(0.18f, 0.18f, 0.18f)),   // 63
        };

        public static List<uint> TVIndices = new List<uint>{ // Note that we start from 0!
            // Supports
            0, 1, 2,    // First triangle 
            0, 3, 2,     // Second triangle

            3, 2, 4,    // Right
            3, 5, 4,

            5, 4, 6,    // Back
            5, 7, 6,

            7, 6, 1,    // Left
            7, 0, 1,

            1, 6, 4,    // Top
            1, 2, 4,

            0, 7, 5,    // Bottom
            0, 3, 5,

            8, 9, 10,
            8, 11, 10,

            11, 10, 14,
            11, 15, 14,

            15, 14, 13,
            15, 12, 13,

            12, 13, 9,
            12, 8, 9,
            // EdgeDown
            16, 17, 18,
            16, 19, 18,

            19, 18, 22,
            19, 23, 22,

            23, 22, 21,
            23, 20, 21,

            20, 21, 17,
            20, 16, 17,

            19, 16, 20,
            19, 23, 20,
            // EdgeLeft
            24, 25, 26,     // Back
            24, 27, 26,

            31, 30, 29,     
            31, 28, 29,

            28, 29, 25, 
            28, 24, 25,

            25, 29, 30,
            25, 26, 30,

            24, 28, 31,
            24, 27, 31,
            // Edde Up
            32, 33, 34,
            32, 35, 34,

            35, 34, 38,
            35, 39, 38,

            39, 38, 37,
            39, 36, 37,

            36, 37, 33, 
            36, 32, 33,

            33, 37, 38,
            33, 34, 38,
            // Edge Left
            40, 41, 42,
            40, 43, 42,

            43, 42, 46,
            43, 47, 46,

            47, 46, 45,
            47, 44, 45,
            // Screen
            48, 49, 50,
            48, 51, 50,

            55, 54, 53,
            55, 52, 53,
            // Back
            59, 58, 62, 
            59, 63, 62,

            63, 62, 61,
            63, 60, 61,

            60, 61, 57,
            60, 56, 57,

            57, 61, 62, 
            57, 58, 62,

            56, 60, 63,
            56, 59, 63,
        };

        public static List<Vertex2> Florero = new List<Vertex2>
        {
            new Vertex2(new Vector3(-0.125f,  0.5625f, -0.125f), new Vector3(0.2f, 0.7f, 0.85f)),  // 0
            new Vertex2(new Vector3(-0.325f,  1.2625f, -0.225f), new Vector3(0.2f, 0.7f, 0.85f)),  // 1
            new Vertex2(new Vector3( 0.325f,  1.2625f, -0.225f), new Vector3(0.2f, 0.7f, 0.85f)),  // 2
            new Vertex2(new Vector3( 0.125f,  0.5625f, -0.125f), new Vector3(0.2f, 0.7f, 0.85f)),  // 3
            ////////////////////////////////////////////////////////////////////////////////////
            new Vertex2(new Vector3(-0.125f,  0.5625f,  0.125f), new Vector3(0.2f, 0.7f, 0.85f)),  // 4
            new Vertex2(new Vector3(-0.325f,  1.2625f,  0.225f), new Vector3(0.2f, 0.7f, 0.85f)),  // 5

            new Vertex2(new Vector3( 0.325f,  1.2625f,  0.225f), new Vector3(0.2f, 0.7f, 0.85f)),  // 6
            new Vertex2(new Vector3( 0.125f,  0.5625f,  0.125f), new Vector3(0.2f, 0.7f, 0.85f)),  // 7
            ////////////////////////////////////////////////////////////////////////////////////
            new Vertex2(new Vector3(-0.125f - 0.0150f,  0.9625f, -0.125f + 0.0450f), new Vector3(0.2f, 0.7f, 0.85f)),  // 8
            new Vertex2(new Vector3(-0.325f + 0.0450f,  1.2625f, -0.225f + 0.0450f), new Vector3(0.2f, 0.7f, 0.85f)),  // 9
            new Vertex2(new Vector3( 0.325f - 0.0450f,  1.2625f, -0.225f + 0.0450f), new Vector3(0.2f, 0.7f, 0.85f)),  // 10
            new Vertex2(new Vector3( 0.125f + 0.0150f,  0.9625f, -0.125f + 0.0450f), new Vector3(0.2f, 0.7f, 0.85f)),  // 11
            ///////////////////////////////////////////////////////////////////////////////////
            new Vertex2(new Vector3(-0.125f - 0.0150f,  0.9625f,  0.125f - 0.0450f), new Vector3(0.2f, 0.7f, 0.85f)),  // 12
            new Vertex2(new Vector3(-0.325f + 0.0450f,  1.2625f,  0.225f - 0.0450f), new Vector3(0.2f, 0.7f, 0.85f)),  // 13

            new Vertex2(new Vector3( 0.325f - 0.0450f,  1.2625f,  0.225f - 0.0450f), new Vector3(0.2f, 0.7f, 0.85f)),  // 14
            new Vertex2(new Vector3( 0.125f + 0.0150f,  0.9625f,  0.125f - 0.0450f), new Vector3(0.2f, 0.7f, 0.85f)),  // 15
            ///////////////////////////////////////////////////////////////////////////////////
            new Vertex2(new Vector3(-0.125f - 0.0150f,  0.9625f, -0.125f + 0.0450f), new Vector3(0.4f, 0.2f ,0.2f)),  // 16
            new Vertex2(new Vector3(-0.125f - 0.0150f,  0.9625f,  0.125f - 0.0450f), new Vector3(0.4f, 0.2f ,0.2f)),  // 17
            new Vertex2(new Vector3( 0.125f + 0.0150f,  0.9625f,  0.125f - 0.0450f), new Vector3(0.4f, 0.2f ,0.2f)),  // 18
            new Vertex2(new Vector3( 0.125f + 0.0150f,  0.9625f, -0.125f + 0.0450f), new Vector3(0.4f, 0.2f ,0.2f)),  // 19
        };

        public static List<uint> FloreroIndices = new List<uint>
        {
            0, 1, 2,
            0, 3, 2,

            3, 2, 6,
            3, 7, 6,

            7, 6, 5,
            7, 4, 5,

            4, 5, 1, 
            4, 0, 1,

            8, 9, 10,
            8, 11, 10,

            11, 10, 14,
            11, 15, 14,

            15, 14, 13,
            15, 12, 13,

            12, 13, 9,
            12, 8, 9,

            1, 9, 10,
            1, 2, 10,

            2, 10, 14,
            2, 6, 14,

            6, 14, 13,
            6, 5, 13,
            
            5, 13, 9,
            5, 1, 9,

            16, 17, 18,
            16, 19, 18,
        };

        public static List<Vertex2> Altavoz = new List<Vertex2>
        {
            new Vertex2(new Vector3(-0.75f, -2.875f, -0.525f), new Vector3(0.1f, 0.1f, 0.1f)),  // 0
            new Vertex2(new Vector3(-0.75f, -0.875f, -0.525f), new Vector3(0.1f, 0.1f, 0.1f)),  // 1
            new Vertex2(new Vector3( 0.75f, -0.875f, -0.525f), new Vector3(0.1f, 0.1f, 0.1f)),  // 2
            new Vertex2(new Vector3( 0.75f, -2.875f, -0.525f), new Vector3(0.1f, 0.1f, 0.1f)),  // 3

            new Vertex2(new Vector3(-0.75f, -2.875f,  0.525f), new Vector3(0.1f, 0.1f, 0.1f)),  // 4
            new Vertex2(new Vector3(-0.75f, -0.875f,  0.525f), new Vector3(0.1f, 0.1f, 0.1f)),  // 5

            new Vertex2(new Vector3( 0.75f, -0.875f,  0.525f), new Vector3(0.1f, 0.1f, 0.1f)),  // 6
            new Vertex2(new Vector3( 0.75f, -2.875f,  0.525f), new Vector3(0.1f, 0.1f, 0.1f)),  // 7

            new Vertex2(new Vector3( -0.2f, -1.5f, -0.535f), new Vector3(0.6f, 0.6f, 0.6f)),    // 8
            new Vertex2(new Vector3( -0.2f, -1.1f, -0.535f), new Vector3(0.6f, 0.6f, 0.6f)),    // 9
            new Vertex2(new Vector3(  0.2f, -1.1f, -0.535f), new Vector3(0.6f, 0.6f, 0.6f)),    // 10
            new Vertex2(new Vector3(  0.2f, -1.5f, -0.535f), new Vector3(0.6f, 0.6f, 0.6f)),    // 11

            new Vertex2(new Vector3( -0.1f, -1.4f, -0.545f), new Vector3(0.8f, 0.8f, 0.8f)),    // 12
            new Vertex2(new Vector3( -0.1f, -1.2f, -0.545f), new Vector3(0.8f, 0.8f, 0.8f)),    // 13
            new Vertex2(new Vector3(  0.1f, -1.2f, -0.545f), new Vector3(0.8f, 0.8f, 0.8f)),    // 14
            new Vertex2(new Vector3(  0.1f, -1.4f, -0.545f), new Vector3(0.8f, 0.8f, 0.8f)),    // 15

            new Vertex2(new Vector3( -0.4f, -2.5f, -0.535f), new Vector3(0.6f, 0.6f, 0.6f)),    // 16
            new Vertex2(new Vector3( -0.4f, -1.7f, -0.535f), new Vector3(0.6f, 0.6f, 0.6f)),    // 17
            new Vertex2(new Vector3(  0.4f, -1.7f, -0.535f), new Vector3(0.6f, 0.6f, 0.6f)),    // 18
            new Vertex2(new Vector3(  0.4f, -2.5f, -0.535f), new Vector3(0.6f, 0.6f, 0.6f)),    // 19

            new Vertex2(new Vector3( -0.3f, -2.4f, -0.545f), new Vector3(0.8f, 0.8f, 0.8f)),    // 20
            new Vertex2(new Vector3( -0.3f, -1.8f, -0.545f), new Vector3(0.8f, 0.8f, 0.8f)),    // 21
            new Vertex2(new Vector3(  0.3f, -1.8f, -0.545f), new Vector3(0.8f, 0.8f, 0.8f)),    // 22
            new Vertex2(new Vector3(  0.3f, -2.4f, -0.545f), new Vector3(0.8f, 0.8f, 0.8f)),    // 23
        };

        public static List<uint> AltavozIndices = new List<uint>
        {
            0, 1, 2,
            0, 3, 2,

            3, 2, 6,
            3, 7, 6,

            7, 6, 5,
            7, 4, 5,

            4, 5, 1, 
            4, 0, 1,

            1, 5, 6,
            1, 2, 6,

            0, 4, 7,
            0, 3, 7,

            8, 9, 10,
            8, 11, 10,

            12, 13, 14,
            12, 15, 14,

            16, 17, 18,
            16, 19, 18,

            20, 21, 22,
            20, 23, 22,
        };

        public Vertices2() { }
    }
}
