using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

using System;

namespace TeleporatationRunes
{
    public class ParticleFactory
    {
        private static SimpleParticleProperties _teleportingParticles;
        private static SimpleParticleProperties _teleportedParticles;
        private static SimpleParticleProperties _detachedParticles;

        public static SimpleParticleProperties Get(ParticleType type, EntityAgent byEntity)
        {
            SimpleParticleProperties particles = null;
            switch (type)
            {
                case ParticleType.TELEPORTING:
                    particles = GetTeleporting();
                    break;
                case ParticleType.TELEPORTED:
                    particles = GetTeleported();
                    break;
                case ParticleType.DETACHED:
                    particles = GetDetached();
                    break;
                default:
                    particles = new SimpleParticleProperties();
                    break;
            }
            particles.MinPos = byEntity.Pos.XYZ.AddCopy(-0.05, -0.05, -0.05);
            particles.AddPos.Set(1, 1, 1);
            return particles;
        }

        private static SimpleParticleProperties GetTeleporting()
        {
            if (_teleportingParticles != null)
            {
                return _teleportingParticles;
            }
            _teleportingParticles = GetDefaultParticles();
            Random rand = new Random();
            _teleportingParticles.Color = ColorUtil.ColorFromRgba(rand.Next(240, 255), rand.Next(0, 50), rand.Next(0, 50), 200);
            _teleportingParticles.OpacityEvolve = new EvolvingNatFloat(EnumTransformFunction.LINEAR, -255);
            _teleportingParticles.SizeEvolve = EvolvingNatFloat.create(EnumTransformFunction.SINUS, 0.5f);
            return _teleportingParticles;
        }

        private static SimpleParticleProperties GetTeleported()
        {
            if (_teleportedParticles != null)
            {
                return _teleportedParticles;
            }
            _teleportedParticles = GetDefaultParticles();
            _teleportedParticles.OpacityEvolve = new EvolvingNatFloat(EnumTransformFunction.LINEAR, -255);
            Random rand = new Random();
            _teleportedParticles.LifeLength = 0.9f;
            _teleportedParticles.SelfPropelled = true;
            _teleportedParticles.GravityEffect = 0f;
            _teleportedParticles.MinVelocity = new Vec3f((float)(rand.NextDouble() - 0.5), 1f, (float)(rand.NextDouble() - 0.5));
            _teleportedParticles.Color = ColorUtil.ColorFromRgba(rand.Next(0, 90), rand.Next(240, 255), rand.Next(0, 90), 250);
            _teleportedParticles.SizeEvolve = EvolvingNatFloat.create(EnumTransformFunction.SINUS, 0.5f);
            _teleportedParticles.MinQuantity = 40;
            _teleportedParticles.MinQuantity = 80;
            return _teleportedParticles;
        }

        private static SimpleParticleProperties GetDetached()
        {
            if (_detachedParticles != null)
            {
                return _detachedParticles;
            }
            Random rand = new Random();
            _teleportedParticles.Color = ColorUtil.ColorFromRgba(rand.Next(0, 90), rand.Next(240, 255), rand.Next(240, 255), 250);
            _teleportingParticles.OpacityEvolve = new EvolvingNatFloat(EnumTransformFunction.LINEAR, -255);
            _teleportingParticles.SizeEvolve = EvolvingNatFloat.create(EnumTransformFunction.SINUS, 0.5f);
            return _detachedParticles;
        }

        private static SimpleParticleProperties GetDefaultParticles()
        {
            return new SimpleParticleProperties(
                minQuantity: 1,
                maxQuantity: 3,
                color: ColorUtil.WhiteAhsl,
                minPos: new Vec3d(),
                maxPos: new Vec3d(),
                minVelocity: new Vec3f(-0.25f, 0.1f, -0.25f),
                maxVelocity: new Vec3f(0.25f, 0.1f, 0.25f),
                lifeLength: 0.2f,
                gravityEffect: 0.075f,
                minSize: 0.1f,
                maxSize: 0.1f,
                model: EnumParticleModel.Quad);
        }
    }
}