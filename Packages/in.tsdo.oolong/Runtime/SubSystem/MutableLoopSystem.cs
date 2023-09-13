using System;
using System.Collections.Generic;
using UnityEngine.LowLevel;

namespace TSF.Oolong
{
    /// <summary>
    /// A representation of a PlayerLoopSystem, but with dynamically allocated lists to make modification easier
    /// </summary>
    public class MutableLoopSystem
    {
        public Type Type { get; }
        public PlayerLoopSystem.UpdateFunction UpdateDelegate { get; }
        public IntPtr UpdateFunction { get; }
        public IntPtr LoopConditionFunction { get; }

        public List<MutableLoopSystem> SubSystemList { get; private set; }
        public override string ToString() => this.Type?.Name ?? "Null System";

        public MutableLoopSystem(PlayerLoopSystem system)
        {
            Type = system.type;
            UpdateDelegate = system.updateDelegate;
            UpdateFunction = system.updateFunction;
            LoopConditionFunction = system.loopConditionFunction;

            var subSystems = system.subSystemList;
            if (system.subSystemList == null)
                return;

            SubSystemList = new List<MutableLoopSystem>();
            var subSystemCount = subSystems.Length;
            for (var i = 0; i < subSystemCount; i++)
                SubSystemList.Add(new MutableLoopSystem(subSystems[i]));
        }

        public MutableLoopSystem(OolongSubSystem oolongSubSystem)
        {
            Type = oolongSubSystem.GetType();
            UpdateDelegate = oolongSubSystem.GetUpdateDelegate();
            UpdateFunction = default;
            LoopConditionFunction = default;
            SubSystemList = null;
        }

        /// <summary>
        /// Find a LoopSystem recursively
        /// </summary>
        public bool TryGetSystem<T>(out MutableLoopSystem system)
        {
            if (Type == typeof(T))
            {
                system = this;
                return true;
            }

            if (SubSystemList == null)
            {
                system = null;
                return false;
            }

            var subSystemCount = SubSystemList.Count;
            for (var i = 0; i < subSystemCount; i++)
            {
                if (SubSystemList[i].TryGetSystem<T>(out system))
                    return true;
            }

            system = null;
            return false;
        }

        /// <summary>
        /// Find a LoopSystem and Insert a new LoopSystem before the found LoopSystem
        /// </summary>
        public bool InsertBefore<T>(MutableLoopSystem newSystem)
        {
            if (SubSystemList == null)
                return false;

            var subSystemCount = SubSystemList.Count;
            for (var i = 0; i < subSystemCount; i++)
            {
                var subSystem = SubSystemList[i];
                if (subSystem.Type == typeof(T))
                {
                    SubSystemList.Insert(i, newSystem);
                    return true;
                }

                if (subSystem.InsertBefore<T>(newSystem))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Find a LoopSystem and Insert a new LoopSystem after the found LoopSystem
        /// </summary>
        public bool InsertAfter<T>(MutableLoopSystem newSystem)
        {
            if (SubSystemList == null)
                return false;

            var subSystemCount = SubSystemList.Count;
            for (var i = 0; i < subSystemCount; i++)
            {
                var subSystem = SubSystemList[i];
                if (subSystem.Type == typeof(T))
                {
                    SubSystemList.Insert(i + 1, newSystem);
                    return true;
                }

                if (subSystem.InsertAfter<T>(newSystem))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Find a LoopSystem and add a new LoopSystem as it's sub-system.
        /// </summary>
        public bool AddTo<T>(MutableLoopSystem newSystem, bool addToBeginning = false)
        {
            if (TryGetSystem<T>(out var system))
            {
                if (system.SubSystemList == null)
                    system.SubSystemList = new List<MutableLoopSystem>();

                if (addToBeginning)
                    system.SubSystemList.Insert(0, newSystem);
                else
                    system.SubSystemList.Add(newSystem);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Find and remove a LoopSystem
        /// </summary>
        public bool RemoveSystem<T>()
        {
            if (SubSystemList != null)
            {
                var subSystemCount = SubSystemList.Count;
                for (var i = 0; i < subSystemCount; i++)
                {
                    var subSystem = SubSystemList[i];
                    if (subSystem.Type == typeof(T))
                    {
                        SubSystemList.RemoveAt(i);
                        return true;
                    }

                    if (subSystem.RemoveSystem<T>()) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Find and remove a LoopSystem
        /// </summary>
        internal bool RemoveSystemInternal(Type type)
        {
            if (SubSystemList != null)
            {
                var subSystemCount = SubSystemList.Count;
                for (var i = 0; i < subSystemCount; i++)
                {
                    var subSystem = SubSystemList[i];
                    if (subSystem.Type == type)
                    {
                        SubSystemList.RemoveAt(i);
                        return true;
                    }

                    if (subSystem.RemoveSystemInternal(type)) return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Convert back to PlayerLoopSystem
        /// </summary>
        public PlayerLoopSystem ToPlayerLoopSystem()
        {
            var system = new PlayerLoopSystem
            {
                type = Type,
                updateDelegate = UpdateDelegate,
                updateFunction = UpdateFunction,
                loopConditionFunction = LoopConditionFunction
            };

            if (SubSystemList != null)
            {
                var subSystemCount = SubSystemList.Count;
                system.subSystemList = new PlayerLoopSystem[subSystemCount];
                for (var i = 0; i < subSystemCount; i++)
                    system.subSystemList[i] = SubSystemList[i].ToPlayerLoopSystem();
            }

            return system;
        }
    }
}
