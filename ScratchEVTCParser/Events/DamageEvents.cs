using ScratchEVTCParser.Model;
using ScratchEVTCParser.Model.Agents;

namespace ScratchEVTCParser.Events
{
	public class IgnoredPhysicalDamageEvent : DamageEvent
	{
		public enum Reason
		{
			Blocked,
			Evaded,
			Absorbed,
			Missed,
		}

		public Reason IgnoreReason { get; }
		public int IgnoredDamage { get; }
		public int ShieldDamage { get; }

		public IgnoredPhysicalDamageEvent(long time, Agent attacker, Agent defender, int damage, bool isMoving,
			bool isNinety, bool isFlanking, int shieldDamage, Reason reason) : base(time, attacker, defender, 0, isMoving, isNinety,
			isFlanking)
		{
			IgnoreReason = reason;
			IgnoredDamage = damage;
			ShieldDamage = shieldDamage;
		}
	}

	public class PhysicalDamageEvent : DamageEvent
	{
		public enum Result
		{
			Normal,
			Critical,
			Glance,
			Interrupt,
			DowningBlow,
			KillingBlow,
		}

		public Result HitResult { get; }
		public int ShieldDamage { get; }

		public PhysicalDamageEvent(long time, Agent attacker, Agent defender, int damage, bool isMoving, bool isNinety,
			bool isFlanking, int shieldDamage, Result result) : base(time, attacker, defender, damage, isMoving, isNinety, isFlanking)
		{
			ShieldDamage = shieldDamage;
			HitResult = result;
		}
	}

	public class IgnoredBuffDamageEvent : BuffDamageEvent
	{
		public enum Reason
		{
			InvulnerableBuff,
			InvulnerableSkill
		}

		public Reason IgnoreReason { get; }
		public int IgnoredDamage { get; }

		public IgnoredBuffDamageEvent(long time, Agent attacker, Agent defender, int damage, int buffId, bool isMoving,
			bool isNinety, bool isFlanking, Reason reason) : base(time, attacker, defender, 0, buffId, isMoving,
			isNinety, isFlanking)
		{
			IgnoredDamage = damage;
			IgnoreReason = reason;
		}
	}

	public class BuffDamageEvent : DamageEvent
	{
		public int BuffId { get; }

		public BuffDamageEvent(long time, Agent attacker, Agent defender, int damage, int buffId, bool isMoving,
			bool isNinety, bool isFlanking) : base(time, attacker, defender, damage, isMoving, isNinety, isFlanking)
		{
			BuffId = buffId;
		}
	}

	public class OffCycleBuffDamageEvent : BuffDamageEvent
	{
		public OffCycleBuffDamageEvent(long time, Agent attacker, Agent defender, int damage, int buffId, bool isMoving,
			bool isNinety, bool isFlanking) : base(time, attacker, defender, damage, buffId, isMoving, isNinety,
			isFlanking)
		{
		}
	}

	public abstract class DamageEvent : Event
	{
		public Agent Attacker { get; }
		public Agent Defender { get; }
		public int Damage { get; }
		public bool IsMoving { get; }
		public bool IsNinety { get; }
		public bool IsFlanking { get; }

		protected DamageEvent(long time, Agent attacker, Agent defender, int damage, bool isMoving, bool isNinety,
			bool isFlanking) : base(time)
		{
			Attacker = attacker;
			Defender = defender;
			Damage = damage;
			IsMoving = isMoving;
			IsNinety = isNinety;
			IsFlanking = isFlanking;
		}
	}
}