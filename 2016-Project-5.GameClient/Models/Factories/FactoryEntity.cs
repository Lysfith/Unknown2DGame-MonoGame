using _2016_Project_5.ECS;
using _2016_Project_5.ECS.Models;
using _2016_Project_5.GameClient.Models.Enums;
using _2016_Project_5.GameClient.Models.Systems.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2016_Project_5.GameClient.Models.Factories
{
    public class FactoryEntity
    {
        public static void CreatePlayer(World world, GameObject entity)
        {
            entity.AddComponent(
                new TransformComponent()
                {
                    X = 1,
                    Y = 1,
                    Rotation = 0
                });

            entity.AddComponent(
                new SpriteComponent()
                {
                    SpriteIndex = 0,
                    Visible = true,
                    OriginX = 0.5f,
                    OriginY = 0.5f,
                    ScaleX = 1.0f,
                    ScaleY = 1.0f,
                    Effect = SpriteEffects.None,
                    Color = Color.White
                });

            entity.AddComponent(
                new SpriteAnimationComponent()
                {
                    SpriteIndexStart = 0,
                    SpriteIndexEnd = 1,
                    IntervalBetweenFrame = 0.5
                });

            entity.AddComponent(
               new TypeEntityComponent()
               {
                   TypeEntity = EnumTypeEntity.Player
               });

            entity.AddComponent(
               new InputComponent());
        }

        public static void CreateHardWall(World world, GameObject entity, int x, int y)
        {
            entity.AddComponent(
                new TransformComponent()
                {
                    X = x,
                    Y = y,
                    Rotation = 0
                });

            entity.AddComponent(
                new SpriteComponent()
                {
                    SpriteIndex = 32,
                    Visible = true,
                    OriginX = 0.5f,
                    OriginY = 0.5f,
                    ScaleX = 1.0f,
                    ScaleY = 1.0f,
                    Effect = SpriteEffects.None,
                    Color = Color.White
                });

            entity.AddComponent(
               new TypeEntityComponent()
               {
                   TypeEntity = EnumTypeEntity.HardWall
               });
        }

        public static void CreateSoftWall(World world, GameObject entity, int x, int y)
        {
            entity.AddComponent(
                new TransformComponent()
                {
                    X = x,
                    Y = y,
                    Rotation = 0
                });

            entity.AddComponent(
                new SpriteComponent()
                {
                    SpriteIndex = 34,
                    Visible = true,
                    OriginX = 0.5f,
                    OriginY = 0.5f,
                    ScaleX = 1.0f,
                    ScaleY = 1.0f,
                    Effect = SpriteEffects.None,
                    Color = Color.White
                });


            entity.AddComponent(
               new SpriteAnimationComponent()
               {
                   SpriteIndexStart = 34,
                   SpriteIndexEnd = 37,
                   IntervalBetweenFrame = 0.1
               });

            entity.AddComponent(
               new TypeEntityComponent()
               {
                   TypeEntity = EnumTypeEntity.SoftWall
               });
        }

        public static void CreateBomb(World world, GameObject entity, int x, int y)
        {
            entity.AddComponent(
                new TransformComponent()
                {
                    X = x,
                    Y = y,
                    Rotation = 0
                });

            entity.AddComponent(
                new SpriteComponent()
                {
                    SpriteIndex = 96,
                    Visible = true,
                    OriginX = 0.5f,
                    OriginY = 0.5f,
                    ScaleX = 1.0f,
                    ScaleY = 1.0f,
                    Effect = SpriteEffects.None,
                    Color = Color.White
                });

            entity.AddComponent(
               new TypeEntityComponent()
               {
                   TypeEntity = EnumTypeEntity.Bomb
               });

        }
    }
}
