using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using Hello_OpenTK.Componentes;

namespace Hello_OpenTK
{
    public struct Carga
    {
        public static Objeto CargarTV(Vector Position = default) 
        {
            Objeto TV = new Objeto(Position);
            TV.m_Componentes = new Dictionary<string, Components>()
            {
                ["Soporte1"] = new Components(TV.m_Position + new Vector(0.0f, 0.0f, 0.0f)),
                ["Soporte2"] = new Components(TV.m_Position),
                ["DownEdge"] = new Components(TV.m_Position),
                ["LeftEdge"] = new Components(TV.m_Position),
                ["UpEdge"] = new Components(TV.m_Position),
                ["RightEdge"] = new Components(TV.m_Position),
                ["Screen"] = new Components(TV.m_Position),
                ["Back"] = new Components(TV.m_Position)
            };
            TV.m_Componentes["Soporte1"].m_Faces = new Dictionary<string, Face>()
            {
                ["Back"] = new Face(TV.m_Position + TV.m_Componentes["Soporte1"].m_Position),
                ["Right"] = new Face(TV.m_Position + TV.m_Componentes["Soporte1"].m_Position),
                ["Front"] = new Face(TV.m_Position + TV.m_Componentes["Soporte1"].m_Position),
                ["Left"] = new Face(TV.m_Position + TV.m_Componentes["Soporte1"].m_Position),
                ["Top"] = new Face(TV.m_Position + TV.m_Componentes["Soporte1"].m_Position),
                ["Bottom"] = new Face(TV.m_Position + TV.m_Componentes["Soporte1"].m_Position)
            };


            TV.m_Componentes["Soporte1"].m_Faces["Back"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.25f, -0.875f, -0.125f), new Vector(-0.25f,  -0.75f, -0.125f), new Vector( 0.25f,  -0.75f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["Soporte1"].m_Position + TV.m_Componentes["Soporte1"].m_Faces["Back"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.25f, -0.875f, -0.125f), new Vector( 0.25f, -0.875f, -0.125f), new Vector( 0.25f,  -0.75f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["Soporte1"].m_Position + TV.m_Componentes["Soporte1"].m_Faces["Back"].m_Position),
            };

            TV.m_Componentes["Soporte1"].m_Faces["Right"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector( 0.25f, -0.875f, -0.125f), new Vector( 0.25f,  -0.75f, -0.125f), new Vector( 0.25f, -0.75f,   0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["Soporte1"].m_Position + TV.m_Componentes["Soporte1"].m_Faces["Right"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector( 0.25f, -0.875f, -0.125f), new Vector( 0.25f, -0.875f,  0.125f), new Vector( 0.25f, -0.75f,   0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["Soporte1"].m_Position + TV.m_Componentes["Soporte1"].m_Faces["Right"].m_Position),
            };

            TV.m_Componentes["Soporte1"].m_Faces["Front"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector( 0.25f, -0.875f,  0.125f), new Vector( 0.25f, -0.75f,   0.125f), new Vector(-0.25f, -0.75f,   0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["Soporte1"].m_Position + TV.m_Componentes["Soporte1"].m_Faces["Front"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector( 0.25f, -0.875f,  0.125f), new Vector(-0.25f, -0.875f,  0.125f), new Vector(-0.25f, -0.75f,   0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["Soporte1"].m_Position + TV.m_Componentes["Soporte1"].m_Faces["Front"].m_Position),
            };

            TV.m_Componentes["Soporte1"].m_Faces["Left"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.25f, -0.875f,  0.125f), new Vector(-0.25f, -0.75f,   0.125f), new Vector(-0.25f,  -0.75f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["Soporte1"].m_Position + TV.m_Componentes["Soporte1"].m_Faces["Left"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.25f, -0.875f,  0.125f), new Vector(-0.25f, -0.875f, -0.125f), new Vector(-0.25f,  -0.75f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["Soporte1"].m_Position + TV.m_Componentes["Soporte1"].m_Faces["Left"].m_Position),
            };

            TV.m_Componentes["Soporte1"].m_Faces["Top"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.25f,  -0.75f, -0.125f), new Vector(-0.25f, -0.75f,   0.125f), new Vector( 0.25f, -0.75f,   0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["Soporte1"].m_Position + TV.m_Componentes["Soporte1"].m_Faces["Top"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.25f,  -0.75f, -0.125f), new Vector( 0.25f,  -0.75f, -0.125f), new Vector( 0.25f, -0.75f,   0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["Soporte1"].m_Position + TV.m_Componentes["Soporte1"].m_Faces["Top"].m_Position),
            };

            TV.m_Componentes["Soporte1"].m_Faces["Bottom"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.25f, -0.875f, -0.125f), new Vector(-0.25f, -0.875f,  0.125f), new Vector( 0.25f, -0.875f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["Soporte1"].m_Position + TV.m_Componentes["Soporte1"].m_Faces["Bottom"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.25f, -0.875f, -0.125f), new Vector( 0.25f, -0.875f, -0.125f), new Vector( 0.25f, -0.875f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["Soporte1"].m_Position + TV.m_Componentes["Soporte1"].m_Faces["Bottom"].m_Position),
            };

            TV.m_Componentes["Soporte2"].m_Faces = new Dictionary<string, Face>()
            {
                ["Back"] = new Face(TV.m_Position + TV.m_Componentes["Soporte2"].m_Position),
                ["Right"] = new Face(TV.m_Position + TV.m_Componentes["Soporte2"].m_Position),
                ["Front"] = new Face(TV.m_Position + TV.m_Componentes["Soporte2"].m_Position),
                ["Left"] = new Face(TV.m_Position + TV.m_Componentes["Soporte2"].m_Position),
            };

            TV.m_Componentes["Soporte2"].m_Faces["Back"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.0625f, -0.75f,   -0.125f), new Vector(-0.0625f, -0.5625f, -0.125f), new Vector( 0.0625f, -0.5625f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
               TV.m_Position + TV.m_Componentes["Soporte2"].m_Position + TV.m_Componentes["Soporte2"].m_Faces["Back"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.0625f, -0.75f,   -0.125f), new Vector( 0.0625f, -0.75f,   -0.125f), new Vector( 0.0625f, -0.5625f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                   TV.m_Position + TV.m_Componentes["Soporte2"].m_Position + TV.m_Componentes["Soporte2"].m_Faces["Back"].m_Position),
            };

            TV.m_Componentes["Soporte2"].m_Faces["Right"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector( 0.0625f, -0.75f,   -0.125f), new Vector( 0.0625f, -0.5625f, -0.125f), new Vector(0.0625f, -0.5625f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["Soporte2"].m_Position + TV.m_Componentes["Soporte2"].m_Faces["Right"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector( 0.0625f, -0.75f,   -0.125f), new Vector(0.0625f, -0.75f,    0.125f), new Vector(0.0625f, -0.5625f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["Soporte2"].m_Position + TV.m_Componentes["Soporte2"].m_Faces["Right"].m_Position),
            };

            TV.m_Componentes["Soporte2"].m_Faces["Front"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.0625f, -0.75f,    0.125f), new Vector(0.0625f, -0.5625f,  0.125f), new Vector(-0.0625f, -0.5625f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["Soporte2"].m_Position + TV.m_Componentes["Soporte2"].m_Faces["Front"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.0625f, -0.75f,    0.125f), new Vector(-0.0625f, -0.75f,    0.125f), new Vector(-0.0625f, -0.5625f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["Soporte2"].m_Position + TV.m_Componentes["Soporte2"].m_Faces["Front"].m_Position),
            };

            TV.m_Componentes["Soporte2"].m_Faces["Left"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.0625f, -0.75f,    0.125f), new Vector(-0.0625f, -0.5625f,  0.125f), new Vector(-0.0625f, -0.5625f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["Soporte2"].m_Position + TV.m_Componentes["Soporte2"].m_Faces["Left"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.0625f, -0.75f,    0.125f), new Vector(-0.0625f, -0.75f,   -0.125f), new Vector(-0.0625f, -0.5625f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["Soporte2"].m_Position + TV.m_Componentes["Soporte2"].m_Faces["Left"].m_Position),
            };

            TV.m_Componentes["DownEdge"].m_Faces = new Dictionary<string, Face>()
            {
                ["Back"] = new Face(TV.m_Position + TV.m_Componentes["DownEdge"].m_Position),
                ["Right"] = new Face(TV.m_Position + TV.m_Componentes["DownEdge"].m_Position),
                ["Front"] = new Face(TV.m_Position + TV.m_Componentes["DownEdge"].m_Position),
                ["Left"] = new Face(TV.m_Position + TV.m_Componentes["DownEdge"].m_Position),
                ["Bottom"] = new Face(TV.m_Position + TV.m_Componentes["DownEdge"].m_Position)
            };

            TV.m_Componentes["DownEdge"].m_Faces["Back"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, -1.0625f + 0.5f,    -0.125f), new Vector(-0.5625f, -1.0625f + 0.5625f, -0.125f), new Vector( 0.5625f, -1.0625f + 0.5625f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["DownEdge"].m_Position + TV.m_Componentes["DownEdge"].m_Faces["Back"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, -1.0625f + 0.5f,    -0.125f), new Vector( 0.5625f, -1.0625f + 0.5f,    -0.125f), new Vector( 0.5625f, -1.0625f + 0.5625f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["DownEdge"].m_Position + TV.m_Componentes["DownEdge"].m_Faces["Back"].m_Position),
            };

            TV.m_Componentes["DownEdge"].m_Faces["Right"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector( 0.5625f, -1.0625f + 0.5f,    -0.125f), new Vector( 0.5625f, -1.0625f + 0.5625f, -0.125f), new Vector(0.5625f, -1.0625f + 0.5625f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["DownEdge"].m_Position + TV.m_Componentes["DownEdge"].m_Faces["Right"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector( 0.5625f, -1.0625f + 0.5f,    -0.125f), new Vector(0.5625f, -1.0625f + 0.5f,     0.125f), new Vector(0.5625f, -1.0625f + 0.5625f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["DownEdge"].m_Position + TV.m_Componentes["DownEdge"].m_Faces["Right"].m_Position),
            };

            TV.m_Componentes["DownEdge"].m_Faces["Front"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.5625f, -1.0625f + 0.5f,     0.125f), new Vector(0.5625f, -1.0625f + 0.5625f,  0.125f), new Vector(-0.5625f, -1.0625f + 0.5625f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["DownEdge"].m_Position + TV.m_Componentes["DownEdge"].m_Faces["Front"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.5625f, -1.0625f + 0.5f,     0.125f), new Vector(-0.5625f, -1.0625f + 0.5f,     0.125f), new Vector(-0.5625f, -1.0625f + 0.5625f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["DownEdge"].m_Position + TV.m_Componentes["DownEdge"].m_Faces["Front"].m_Position),
            };

            TV.m_Componentes["DownEdge"].m_Faces["Left"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, -1.0625f + 0.5f,     0.125f), new Vector(-0.5625f, -1.0625f + 0.5625f,  0.125f), new Vector(-0.5625f, -1.0625f + 0.5625f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["DownEdge"].m_Position + TV.m_Componentes["DownEdge"].m_Faces["Left"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, -1.0625f + 0.5f,     0.125f), new Vector(-0.5625f, -1.0625f + 0.5f,    -0.125f), new Vector(-0.5625f, -1.0625f + 0.5625f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["DownEdge"].m_Position + TV.m_Componentes["DownEdge"].m_Faces["Left"].m_Position),
            };

            TV.m_Componentes["DownEdge"].m_Faces["Bottom"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector( 0.5625f, -1.0625f + 0.5f,    -0.125f), new Vector(-0.5625f, -1.0625f + 0.5f,    -0.125f), new Vector(-0.5625f, -1.0625f + 0.5f,     0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["DownEdge"].m_Position + TV.m_Componentes["DownEdge"].m_Faces["Bottom"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector( 0.5625f, -1.0625f + 0.5f,    -0.125f), new Vector(0.5625f, -1.0625f + 0.5f,     0.125f), new Vector(-0.5625f, -1.0625f + 0.5f,     0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["DownEdge"].m_Position + TV.m_Componentes["DownEdge"].m_Faces["Bottom"].m_Position),
            };

            TV.m_Componentes["LeftEdge"].m_Faces = new Dictionary<string, Face>()
            {
                ["Back"] = new Face(TV.m_Position + TV.m_Componentes["LeftEdge"].m_Position),
                ["Left"] = new Face(TV.m_Position + TV.m_Componentes["LeftEdge"].m_Position),
                ["Front"] = new Face(TV.m_Position + TV.m_Componentes["LeftEdge"].m_Position),
            };

            TV.m_Componentes["LeftEdge"].m_Faces["Back"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, -0.5f, -0.125f), new Vector(-0.5625f,  0.5f,  -0.125f), new Vector(-0.5f,     0.5f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["LeftEdge"].m_Position + TV.m_Componentes["LeftEdge"].m_Faces["Back"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, -0.5f, -0.125f), new Vector(-0.5f,    -0.5f, -0.125f), new Vector(-0.5f,     0.5f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["LeftEdge"].m_Position + TV.m_Componentes["LeftEdge"].m_Faces["Back"].m_Position),
            };

            TV.m_Componentes["LeftEdge"].m_Faces["Left"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, -0.5f, 0.125f), new Vector(-0.5625f,  0.5f, 0.125f), new Vector(-0.5625f,  0.5f,  -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["LeftEdge"].m_Position + TV.m_Componentes["LeftEdge"].m_Faces["Left"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, -0.5f, 0.125f), new Vector(-0.5625f, -0.5f, -0.125f), new Vector(-0.5625f,  0.5f,  -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["LeftEdge"].m_Position + TV.m_Componentes["LeftEdge"].m_Faces["Left"].m_Position),
            };

            TV.m_Componentes["LeftEdge"].m_Faces["Front"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, -0.5f, 0.125f), new Vector(-0.5625f,  0.5f, 0.125f), new Vector(-0.5f,     0.5f, 0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["LeftEdge"].m_Position + TV.m_Componentes["LeftEdge"].m_Faces["Front"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, -0.5f, 0.125f), new Vector(-0.5f,    -0.5f, 0.125f), new Vector(-0.5f,     0.5f, 0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["LeftEdge"].m_Position + TV.m_Componentes["LeftEdge"].m_Faces["Front"].m_Position),
            };

            TV.m_Componentes["UpEdge"].m_Faces = new Dictionary<string, Face>()
            {
                ["Back"] = new Face(TV.m_Position + TV.m_Componentes["UpEdge"].m_Position),
                ["Left"] = new Face(TV.m_Position + TV.m_Componentes["UpEdge"].m_Position),
                ["Front"] = new Face(TV.m_Position + TV.m_Componentes["UpEdge"].m_Position),
                ["Right"] = new Face(TV.m_Position + TV.m_Componentes["UpEdge"].m_Position),
                ["Top"] = new Face(TV.m_Position + TV.m_Componentes["UpEdge"].m_Position),
            };

            TV.m_Componentes["UpEdge"].m_Faces["Back"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, 0.5f,    -0.125f), new Vector(-0.5625f, 0.5625f, -0.125f), new Vector( 0.5625f, 0.5625f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["UpEdge"].m_Position + TV.m_Componentes["UpEdge"].m_Faces["Back"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, 0.5f,    -0.125f), new Vector( 0.5625f, 0.5f,    -0.125f), new Vector( 0.5625f, 0.5625f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["UpEdge"].m_Position + TV.m_Componentes["UpEdge"].m_Faces["Back"].m_Position),
            };

            TV.m_Componentes["UpEdge"].m_Faces["Left"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, 0.5f,    0.125f), new Vector(-0.5625f, 0.5625f,  0.125f), new Vector(-0.5625f, 0.5625f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["UpEdge"].m_Position + TV.m_Componentes["UpEdge"].m_Faces["Left"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, 0.5f,    0.125f), new Vector(-0.5625f, 0.5f,    -0.125f), new Vector(-0.5625f, 0.5625f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["UpEdge"].m_Position + TV.m_Componentes["UpEdge"].m_Faces["Left"].m_Position),
            };

            TV.m_Componentes["UpEdge"].m_Faces["Front"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, 0.5f,    0.125f), new Vector(-0.5625f, 0.5625f,  0.125f), new Vector(0.5625f,  0.5625f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["UpEdge"].m_Position + TV.m_Componentes["UpEdge"].m_Faces["Front"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, 0.5f,    0.125f), new Vector(0.5625f,  0.5f,    0.125f), new Vector(0.5625f,  0.5625f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["UpEdge"].m_Position + TV.m_Componentes["UpEdge"].m_Faces["Front"].m_Position),
            };

            TV.m_Componentes["UpEdge"].m_Faces["Right"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector( 0.5625f, 0.5f,    -0.125f), new Vector( 0.5625f, 0.5625f, -0.125f), new Vector(0.5625f,  0.5625f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["UpEdge"].m_Position + TV.m_Componentes["UpEdge"].m_Faces["Right"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector( 0.5625f, 0.5f,    -0.125f), new Vector(0.5625f,  0.5f,    0.125f), new Vector(0.5625f,  0.5625f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["UpEdge"].m_Position + TV.m_Componentes["UpEdge"].m_Faces["Right"].m_Position),
            };

            TV.m_Componentes["UpEdge"].m_Faces["Top"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, 0.5625f, -0.125f), new Vector(-0.5625f, 0.5625f,  0.125f), new Vector(0.5625f,  0.5625f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["UpEdge"].m_Position + TV.m_Componentes["UpEdge"].m_Faces["Top"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f, 0.5625f, -0.125f), new Vector( 0.5625f, 0.5625f, -0.125f), new Vector(0.5625f,  0.5625f,  0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["UpEdge"].m_Position + TV.m_Componentes["UpEdge"].m_Faces["Top"].m_Position),
            };

            TV.m_Componentes["RightEdge"].m_Faces = new Dictionary<string, Face>()
            {
                ["Back"] = new Face(TV.m_Position + TV.m_Componentes["RightEdge"].m_Position),
                ["Right"] = new Face(TV.m_Position + TV.m_Componentes["RightEdge"].m_Position),
                ["Front"] = new Face(TV.m_Position + TV.m_Componentes["RightEdge"].m_Position),
            };

            TV.m_Componentes["RightEdge"].m_Faces["Back"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f + 1.0625f, -0.5f, -0.125f), new Vector(-0.5625f + 1.0625f,  0.5f,  -0.125f), new Vector(-0.5f + 1.0625f,     0.5f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["RightEdge"].m_Position + TV.m_Componentes["RightEdge"].m_Faces["Back"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f + 1.0625f, -0.5f, -0.125f), new Vector(-0.5f + 1.0625f,    -0.5f, -0.125f), new Vector(-0.5f + 1.0625f,     0.5f, -0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["RightEdge"].m_Position + TV.m_Componentes["RightEdge"].m_Faces["Back"].m_Position),
            };

            TV.m_Componentes["RightEdge"].m_Faces["Right"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5f + 1.0625f,    -0.5f, -0.125f), new Vector(-0.5f + 1.0625f,     0.5f, -0.125f), new Vector(-0.5f + 1.0625f,     0.5f, 0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["RightEdge"].m_Position + TV.m_Componentes["RightEdge"].m_Faces["Right"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5f + 1.0625f,    -0.5f, -0.125f), new Vector(-0.5f + 1.0625f,    -0.5f, 0.125f), new Vector(-0.5f + 1.0625f,     0.5f, 0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["RightEdge"].m_Position + TV.m_Componentes["RightEdge"].m_Faces["Right"].m_Position),
            };

            TV.m_Componentes["RightEdge"].m_Faces["Front"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f + 1.0625f, -0.5f, 0.125f), new Vector(-0.5625f + 1.0625f,  0.5f, 0.125f), new Vector(-0.5f + 1.0625f,     0.5f, 0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                TV.m_Position + TV.m_Componentes["RightEdge"].m_Position + TV.m_Componentes["RightEdge"].m_Faces["Front"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5625f + 1.0625f, -0.5f, 0.125f), new Vector(-0.5f + 1.0625f,    -0.5f, 0.125f), new Vector(-0.5f + 1.0625f,     0.5f, 0.125f)
                }, new Vector(0.2f, 0.2f, 0.2f),
                    TV.m_Position + TV.m_Componentes["RightEdge"].m_Position + TV.m_Componentes["RightEdge"].m_Faces["Front"].m_Position),
            };

            TV.m_Componentes["Screen"].m_Faces = new Dictionary<string, Face>()
            {
                ["Front"] = new Face(TV.m_Position + TV.m_Componentes["Screen"].m_Position),
            };

            TV.m_Componentes["Screen"].m_Faces["Front"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5f, -0.5f, 0.125f), new Vector(-0.5f,  0.5f, 0.125f), new Vector(0.5f,  0.5f, 0.125f)
                }, new Vector(0.5f, 0.5f, 0.5f),
                TV.m_Position + TV.m_Componentes["Screen"].m_Position + TV.m_Componentes["Screen"].m_Faces["Front"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5f, -0.5f, 0.125f), new Vector(0.5f, -0.5f, 0.125f), new Vector(0.5f,  0.5f, 0.125f)
                }, new Vector(0.5f, 0.5f, 0.5f),
                    TV.m_Position + TV.m_Componentes["Screen"].m_Position + TV.m_Componentes["Screen"].m_Faces["Front"].m_Position),
            };

            TV.m_Componentes["Back"].m_Faces = new Dictionary<string, Face>()
            {
                ["Back"] = new Face(TV.m_Position + TV.m_Componentes["Back"].m_Position),
                ["Left"] = new Face(TV.m_Position + TV.m_Componentes["Back"].m_Position),
                ["Right"] = new Face(TV.m_Position + TV.m_Componentes["Back"].m_Position),
                ["Top"] = new Face(TV.m_Position + TV.m_Componentes["Back"].m_Position),
                ["Bottom"] = new Face(TV.m_Position + TV.m_Componentes["Back"].m_Position),
            };

            TV.m_Componentes["Back"].m_Faces["Back"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5f, -0.5f,  -0.25f), new Vector(-0.5f,  0.5f, -0.25f), new Vector(0.5f,  0.5f,  -0.25f)
                }, new Vector(0.18f, 0.18f, 0.18f),
                TV.m_Position + TV.m_Componentes["Back"].m_Position + TV.m_Componentes["Back"].m_Faces["Back"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5f, -0.5f,  -0.25f), new Vector(0.5f, -0.5f,  -0.25f), new Vector(0.5f,  0.5f,  -0.25f)
                }, new Vector(0.18f, 0.18f, 0.18f),
                    TV.m_Position + TV.m_Componentes["Back"].m_Position + TV.m_Componentes["Back"].m_Faces["Back"].m_Position),
            };

            TV.m_Componentes["Back"].m_Faces["Left"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5f, -0.5f, -0.25f), new Vector(-0.5f,  0.5f,  -0.25f), new Vector(-0.5f,  0.5f, -0.25f + 0.125f)
                }, new Vector(0.18f, 0.18f, 0.18f),
                TV.m_Position + TV.m_Componentes["Back"].m_Position + TV.m_Componentes["Back"].m_Faces["Left"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5f, -0.5f,  -0.25f), new Vector(-0.5f, -0.5f, -0.25f + 0.125f), new Vector(-0.5f,  0.5f, -0.25f + 0.125f)
                }, new Vector(0.18f, 0.18f, 0.18f),
                    TV.m_Position + TV.m_Componentes["Back"].m_Position + TV.m_Componentes["Back"].m_Faces["Left"].m_Position),
            };

            TV.m_Componentes["Back"].m_Faces["Right"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.5f, -0.5f, -0.25f + 0.125f), new Vector(0.5f,  0.5f, -0.25f + 0.125f), new Vector(0.5f,  0.5f,  -0.25f)
                }, new Vector(0.18f, 0.18f, 0.18f),
                TV.m_Position + TV.m_Componentes["Back"].m_Position + TV.m_Componentes["Back"].m_Faces["Right"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.5f, -0.5f, -0.25f + 0.125f), new Vector(0.5f, -0.5f,  -0.25f), new Vector(0.5f,  0.5f, -0.25f)
                }, new Vector(0.18f, 0.18f, 0.18f),
                    TV.m_Position + TV.m_Componentes["Back"].m_Position + TV.m_Componentes["Back"].m_Faces["Right"].m_Position),
            };

            TV.m_Componentes["Back"].m_Faces["Top"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5f,  0.5f, -0.25f + 0.125f), new Vector(-0.5f,  0.5f, -0.25f), new Vector(0.5f,  0.5f,  -0.25f)
                }, new Vector(0.18f, 0.18f, 0.18f),
                TV.m_Position + TV.m_Componentes["Back"].m_Position + TV.m_Componentes["Back"].m_Faces["Top"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5f,  0.5f, -0.25f + 0.125f), new Vector(0.5f,  0.5f, -0.25f + 0.125f), new Vector(0.5f,  0.5f,  -0.25f)
                }, new Vector(0.18f, 0.18f, 0.18f),
                    TV.m_Position + TV.m_Componentes["Back"].m_Position + TV.m_Componentes["Back"].m_Faces["Top"].m_Position),
            };

            TV.m_Componentes["Back"].m_Faces["Bottom"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5f, -0.5f, -0.25f + 0.125f), new Vector(-0.5f, -0.5f, -0.25f), new Vector(0.5f, -0.5f, -0.25f)
                }, new Vector(0.18f, 0.18f, 0.18f),
                TV.m_Position + TV.m_Componentes["Back"].m_Position + TV.m_Componentes["Back"].m_Faces["Bottom"].m_Position),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.5f, -0.5f, -0.25f + 0.125f), new Vector(0.5f, -0.5f, -0.25f + 0.125f), new Vector(0.5f, -0.5f, -0.25f)
                }, new Vector(0.18f, 0.18f, 0.18f),
                    TV.m_Position + TV.m_Componentes["Back"].m_Position + TV.m_Componentes["Back"].m_Faces["Bottom"].m_Position),
            };

            return TV;
        }

        public static Objeto CargarFlorero(Vector Position = default)
        {
            Objeto Florero = new Objeto(new Vector (0.0f, 0.9125f, 0.0f));

            Florero.m_Componentes = new Dictionary<string, Components>()
            {
                ["Base"] = new Components(),
                ["Base2"] = new Components(new Vector(0.0f, 0.0f, 0.0f)),
            };

            Florero.m_Componentes["Base"].m_Faces = new Dictionary<string, Face>()
            {
                ["Back"] = new Face(),
                ["Right"] = new Face(),
                ["Front"] = new Face(),
                ["Left"] = new Face(),
            };


            Florero.m_Componentes["Base"].m_Faces["Back"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.125f,  -0.35f, -0.125f), new Vector(-0.325f,  0.35f, -0.225f), new Vector(0.325f,  0.35f, -0.225f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.125f,  -0.35f, -0.125f), new Vector(0.125f,  -0.35f, -0.125f), new Vector(0.325f,  0.35f, -0.225f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
            };

            Florero.m_Componentes["Base"].m_Faces["Right"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.125f,  -0.35f, -0.125f), new Vector(0.325f,  0.35f, -0.225f), new Vector(0.325f,  0.35f,  0.225f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.125f,  -0.35f, -0.125f), new Vector(0.125f,  -0.35f,  0.125f), new Vector(0.325f,  0.35f,  0.225f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
            };

            Florero.m_Componentes["Base"].m_Faces["Front"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.125f,  -0.35f,  0.125f), new Vector(-0.325f,  0.35f,  0.225f), new Vector(0.325f,  0.35f,  0.225f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.125f,  -0.35f,  0.125f), new Vector(0.125f,  -0.35f,  0.125f), new Vector(0.325f,  0.35f,  0.225f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
            };

            Florero.m_Componentes["Base"].m_Faces["Left"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.125f,  -0.35f,  0.125f), new Vector(-0.325f,  0.35f,  0.225f), new Vector(-0.325f,  0.35f, -0.225f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.125f,  -0.35f,  0.125f), new Vector(-0.125f,  -0.35f, -0.125f), new Vector(-0.325f,  0.35f, -0.225f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
            };

            Florero.m_Componentes["Base2"].m_Faces = new Dictionary<string, Face>()
            {
                ["Back"] = new Face(),
                ["Right"] = new Face(),
                ["Front"] = new Face(),
                ["Left"] = new Face(),
                ["TopBack"] = new Face(),
                ["TopRight"] = new Face(),
                ["TopFront"] = new Face(),
                ["TopLeft"] = new Face(),
                ["Tierra"] = new Face(),
            };


            Florero.m_Componentes["Base2"].m_Faces["Back"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.125f - 0.0150f,  0.05f, -0.125f + 0.0450f), new Vector(-0.325f + 0.0450f,  0.35f, -0.225f + 0.0450f), new Vector(0.325f - 0.0450f,  0.35f, -0.225f + 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)
                ),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.125f - 0.0150f,  0.05f, -0.125f + 0.0450f), new Vector(0.125f + 0.0150f,  0.05f, -0.125f + 0.0450f), new Vector(0.325f - 0.0450f,  0.35f, -0.225f + 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)
                ),
            };

            Florero.m_Componentes["Base2"].m_Faces["Right"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.125f + 0.0150f,  0.05f, -0.125f + 0.0450f), new Vector(0.325f - 0.0450f,  0.35f, -0.225f + 0.0450f), new Vector(0.325f - 0.0450f,  0.35f,  0.225f - 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)
                ),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.125f + 0.0150f,  0.05f, -0.125f + 0.0450f), new Vector(0.125f + 0.0150f,  0.05f,  0.125f - 0.0450f), new Vector(0.325f - 0.0450f,  0.35f,  0.225f - 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)
                ),
            };

            Florero.m_Componentes["Base2"].m_Faces["Front"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.125f - 0.0150f,  0.05f,  0.125f - 0.0450f), new Vector(-0.325f + 0.0450f,  0.35f,  0.225f - 0.0450f), new Vector(0.325f - 0.0450f,  0.35f,  0.225f - 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.125f - 0.0150f,  0.05f,  0.125f - 0.0450f), new Vector(0.125f + 0.0150f,  0.05f,  0.125f - 0.0450f), new Vector(0.325f - 0.0450f,  0.35f,  0.225f - 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
            };

            Florero.m_Componentes["Base2"].m_Faces["Left"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.125f - 0.0150f,  0.05f,  0.125f - 0.0450f), new Vector(-0.325f + 0.0450f,  0.35f,  0.225f - 0.0450f), new Vector(-0.325f + 0.0450f,  0.35f, -0.225f + 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.125f - 0.0150f,  0.05f,  0.125f - 0.0450f), new Vector(-0.125f - 0.0150f,  0.05f, -0.125f + 0.0450f), new Vector(-0.325f + 0.0450f,  0.35f, -0.225f + 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
            };

            Florero.m_Componentes["Base2"].m_Faces["TopBack"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.325f,  0.35f, -0.225f), new Vector(-0.325f + 0.0450f,  0.35f, -0.225f + 0.0450f), new Vector(0.325f - 0.0450f,  0.35f, -0.225f + 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.325f,  0.35f, -0.225f), new Vector(0.325f,  0.35f, -0.225f), new Vector(0.325f - 0.0450f,  0.35f, -0.225f + 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
            };

            Florero.m_Componentes["Base2"].m_Faces["TopRight"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.325f,  0.35f, -0.225f), new Vector(0.325f - 0.0450f,  0.35f, -0.225f + 0.0450f), new Vector(0.325f - 0.0450f,  0.35f,  0.225f - 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.325f,  0.35f, -0.225f), new Vector(0.325f,  0.35f,  0.225f), new Vector(0.325f - 0.0450f,  0.35f,  0.225f - 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
            };

            Florero.m_Componentes["Base2"].m_Faces["TopFront"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.325f,  0.35f,  0.225f), new Vector(0.325f - 0.0450f,  0.35f,  0.225f - 0.0450f), new Vector(-0.325f + 0.0450f,  0.35f,  0.225f - 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.325f,  0.35f,  0.225f), new Vector(-0.325f,  0.35f,  0.225f), new Vector(-0.325f + 0.0450f,  0.35f,  0.225f - 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
            };

            Florero.m_Componentes["Base2"].m_Faces["TopLeft"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.325f,  0.35f,  0.225f), new Vector(-0.325f + 0.0450f,  0.35f,  0.225f - 0.0450f), new Vector(-0.325f + 0.0450f,  0.35f, -0.225f + 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.325f,  0.35f,  0.225f), new Vector(-0.325f,  0.35f, -0.225f), new Vector(-0.325f + 0.0450f,  0.35f, -0.225f + 0.0450f)
                }, new Vector(0.2f, 0.7f, 0.85f)),
            };

            Florero.m_Componentes["Base2"].m_Faces["Tierra"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.125f - 0.0150f,  0.05f, -0.125f + 0.0450f), new Vector(-0.125f - 0.0150f,  0.05f,  0.125f - 0.0450f), new Vector(0.125f + 0.0150f,  0.05f,  0.125f - 0.0450f)
                }, new Vector(00.4f, 0.2f, 0.2f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.125f - 0.0150f,  0.05f, -0.125f + 0.0450f), new Vector(0.125f + 0.0150f,  0.05f, -0.125f + 0.0450f), new Vector(0.125f + 0.0150f,  0.05f,  0.125f - 0.0450f)
                }, new Vector(0.4f, 0.2f, 0.2f)),
            };


            return Florero;
        }
        public static Objeto CargarParlante(Vector Position = default)
        {
            Objeto Parlante = new Objeto(new Vector(0.0f, -1.875f, 0.0f));

            Parlante.m_Componentes = new Dictionary<string, Components>()
            {
                ["Base"] = new Components(new Vector(0.0f)),
                ["MidRange"] = new Components(new Vector(0.0f, 0.5f, -0.54f)),
                ["Woofer"] = new Components(new Vector(0.0f, -0.5f, -0.54f)),
            };

            Parlante.m_Componentes["Base"].m_Faces = new Dictionary<string, Face>()
            {
                ["Back"] = new Face(),
                ["Right"] = new Face(),
                ["Front"] = new Face(),
                ["Left"] = new Face(),
                ["Top"] = new Face(),
                ["Bottom"] = new Face(),
            };

            Parlante.m_Componentes["Base"].m_Faces["Back"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.75f, -1.0f, -0.525f), new Vector(-0.75f, 1.0f, -0.525f), new Vector(0.75f, 1.0f, -0.525f)
                }, new Vector(0.1f, 0.1f, 0.1f), new Vector()),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.75f, -1.0f, -0.525f), new Vector(0.75f, -1.0f, -0.525f), new Vector(0.75f, 1.0f, -0.525f)
                }, new Vector(0.1f, 0.1f, 0.1f), new Vector()),
            };

            Parlante.m_Componentes["Base"].m_Faces["Right"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.75f, -1.0f, -0.525f), new Vector(-0.75f, 1.0f, -0.525f), new Vector(0.75f, 1.0f, -0.525f)
                }, new Vector(0.1f, 0.1f, 0.1f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.75f, -1.0f, -0.525f), new Vector(0.75f, -1.0f, -0.525f), new Vector(0.75f, 1.0f, -0.525f)
                }, new Vector(0.1f, 0.1f, 0.1f))
            };

            Parlante.m_Componentes["Base"].m_Faces["Front"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.75f, -1.0f, -0.525f), new Vector(0.75f, 1.0f, -0.525f), new Vector(0.75f, 1.0f,  0.525f)
                }, new Vector(0.1f, 0.1f, 0.1f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.75f, -1.0f, -0.525f), new Vector(0.75f, -1.0f,  0.525f), new Vector(0.75f, 1.0f,  0.525f)
                }, new Vector(0.1f, 0.1f, 0.1f)),
            };

            Parlante.m_Componentes["Base"].m_Faces["Left"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.75f, -1.0f,  0.525f), new Vector(0.75f, 1.0f,  0.525f), new Vector(-0.75f, 1.0f,  0.525f)
                }, new Vector(0.1f, 0.1f, 0.1f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(0.75f, -1.0f,  0.525f), new Vector(-0.75f, -1.0f,  0.525f), new Vector(-0.75f, 1.0f,  0.525f)
                }, new Vector(0.1f, 0.1f, 0.1f)),
            };

            Parlante.m_Componentes["Base"].m_Faces["Right"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.75f, -1.0f,  0.525f), new Vector(-0.75f, 1.0f,  0.525f), new Vector(-0.75f, 1.0f, -0.525f)
                }, new Vector(0.1f, 0.1f, 0.1f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.75f, -1.0f,  0.525f), new Vector(-0.75f, -1.0f, -0.525f), new Vector(-0.75f, 1.0f, -0.525f)
                }, new Vector(0.1f, 0.1f, 0.1f)),
            };

            Parlante.m_Componentes["Base"].m_Faces["Top"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.75f, 1.0f, -0.525f), new Vector(-0.75f, 1.0f,  0.525f), new Vector(0.75f, 1.0f,  0.525f)
                }, new Vector(0.1f, 0.1f, 0.1f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.75f, 1.0f, -0.525f), new Vector(0.75f, 1.0f, -0.525f), new Vector(0.75f, 1.0f,  0.525f)
                }, new Vector(0.1f, 0.1f, 0.1f)),
            };

            Parlante.m_Componentes["Base"].m_Faces["Bottom"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.75f, -1.0f, -0.525f), new Vector(-0.75f, -1.0f,  0.525f), new Vector(0.75f, -1.0f,  0.525f)
                }, new Vector(0.1f, 0.1f, 0.1f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.75f, -1.0f, -0.525f), new Vector(0.75f, -1.0f, -0.525f), new Vector(0.75f, -1.0f,  0.525f)
                }, new Vector(0.1f, 0.1f, 0.1f)),
            };

            Parlante.m_Componentes["MidRange"].m_Faces = new Dictionary<string, Face>()
            {
                ["Cuadrado1"] = new Face(),
                ["Cuadrado2"] = new Face(),
            };

            Parlante.m_Componentes["MidRange"].m_Faces["Cuadrado1"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.2f, -0.2f, 0.0f), new Vector(-0.2f, 0.2f, 0.0f), new Vector(0.2f, 0.2f, 0.0f)
                }, new Vector(0.6f, 0.6f, 0.6f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.2f, -0.2f, 0.0f), new Vector(0.2f, -0.2f, 0.0f), new Vector(0.2f, 0.2f, 0.0f)
                }, new Vector(0.6f, 0.6f, 0.6f)),
            };

            Parlante.m_Componentes["MidRange"].m_Faces["Cuadrado2"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.1f, -0.1f, -0.01f), new Vector(-0.1f, 0.1f, -0.01f), new Vector(0.1f, 0.1f, -0.01f)
                }, new Vector(0.8f, 0.8f, 0.8f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.1f, -0.1f, -0.01f), new Vector(0.1f, -0.1f, -0.01f), new Vector(0.1f, 0.1f, -0.01f)
                }, new Vector(0.8f, 0.8f, 0.8f)),
            };

            Parlante.m_Componentes["Woofer"].m_Faces = new Dictionary<string, Face>()
            {
                ["Cuadrado1"] = new Face(),
                ["Cuadrado2"] = new Face(),
            };

            Parlante.m_Componentes["Woofer"].m_Faces["Cuadrado1"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.4f, -0.4f, 0.0f), new Vector(-0.4f, 0.4f, 0.0f), new Vector(0.4f, 0.4f, 0.0f)
                }, new Vector(0.6f, 0.6f, 0.6f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.4f, -0.4f, 0.0f), new Vector(0.4f, -0.4f, 0.0f), new Vector(0.4f, 0.4f, 0.0f)
                }, new Vector(0.6f, 0.6f, 0.6f)),
            };

            Parlante.m_Componentes["Woofer"].m_Faces["Cuadrado2"].m_Triangles = new Dictionary<string, Triangle>()
            {
                ["Trian1"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.3f, -0.3f, -0.01f), new Vector(-0.3f, 0.3f, -0.01f), new Vector(0.3f, 0.3f, -0.01f)
                }, new Vector(0.8f, 0.8f, 0.8f)),
                ["Trian2"] = new Triangle(new List<Vector>()
                {
                    new Vector(-0.3f, -0.3f, -0.01f), new Vector(0.3f, -0.3f, -0.01f), new Vector(0.3f, 0.3f, -0.01f)
                }, new Vector(0.8f, 0.8f, 0.8f)),
            };

            return Parlante;
        }
    }

}
