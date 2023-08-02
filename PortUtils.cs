using MonoMod.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MagicStorage {
	internal static class PortUtils {
		public static string GetTranslation(this LocalizedText text, GameCulture activeCulture) {
			return text.Value;
		}
		public static void Modify(MethodBase methodbase, ILContext.Manipulator callback) {
			MonoModHooks.Modify(methodbase, callback);
		}
		public static void Modify<T>(MethodBase methodbase, ILContext.Manipulator callback) {
			MonoModHooks.Modify(methodbase, callback);
		}
		public static void Unmodify(MethodBase methodbase, ILContext.Manipulator callback) {
		}
		public static void Unmodify<T>(MethodBase methodbase, ILContext.Manipulator callback) {
		}
		public static void Add(MethodBase target, Delegate hookDelegate) {
			MonoModHooks.Add(target, hookDelegate);
		}
		public static void Add<T>(MethodBase target, T hookDelegate) where T : Delegate {
			MonoModHooks.Add(target, hookDelegate);
		}
		public static void Remove(MethodBase target, Delegate hookDelegate) {
		}
		public static void Remove<T>(MethodBase target, T hookDelegate) where T : Delegate {
		}
	}
}
