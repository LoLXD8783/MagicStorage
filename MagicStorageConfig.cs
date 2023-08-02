using System.ComponentModel;
using MagicStorage.Common.Players;
using MagicStorage.Common.Systems.RecurrentRecipes;
using MagicStorage.UI.States;
using Newtonsoft.Json;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnassignedField.Global

namespace MagicStorage {
	//[LabelKey("$Mods.MagicStorage.Config.Label")]
	public class MagicStorageConfig : ModConfig
	{
		[Header($"$Mods.MagicStorage.Config.Headers.Storage")]
		[LabelKey("$Mods.MagicStorage.Config.quickStackDepositMode.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.quickStackDepositMode.Tooltip")]
		[DefaultValue(true)]
		public bool quickStackDepositMode;

		[Header($"$Mods.MagicStorage.Config.Headers.Crafting")]
		[LabelKey("$Mods.MagicStorage.Config.useConfigFilter.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.useConfigFilter.Tooltip")]
		[DefaultValue(true)]
		public bool useConfigFilter;

		[LabelKey("$Mods.MagicStorage.Config.showAllRecipes.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.showAllRecipes.Tooltip")]
		[DefaultValue(false)]
		public bool showAllRecipes;

		[LabelKey("$Mods.MagicStorage.Config.useOldCraftMenu.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.useOldCraftMenu.Tooltip")]
		[DefaultValue(false)]
		public bool useOldCraftMenu;

		[LabelKey("$Mods.MagicStorage.Config.recipeBlacklist.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.recipeBlacklist.Tooltip")]
		[DefaultValue(false)]
		public bool recipeBlacklist;

		[LabelKey("$Mods.MagicStorage.Config.clearHistory.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.clearHistory.Tooltip")]
		[DefaultValue(false)]
		public bool clearHistory;

		[LabelKey("$Mods.MagicStorage.Config.recursionDepth.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.recursionDepth.Tooltip")]
		[DefaultValue(3)]
		[DrawTicks]
		[Range(-1, 10)]
		public int recursionDepth;

		[Header($"$Mods.MagicStorage.Config.Headers.StorageAndCrafting")]
		[LabelKey("$Mods.MagicStorage.Config.glowNewItems.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.glowNewItems.Tooltip")]
		[DefaultValue(false)]
		public bool glowNewItems;

		[LabelKey("$Mods.MagicStorage.Config.clearSearchText.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.clearSearchText.Tooltip")]
		[DefaultValue(true)]
		public bool clearSearchText;

		[LabelKey("$Mods.MagicStorage.Config.searchBarRefreshOnKey.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.searchBarRefreshOnKey.Tooltip")]
		[DefaultValue(true)]
		public bool searchBarRefreshOnKey;

		[LabelKey("$Mods.MagicStorage.Config.uiFavorites.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.uiFavorites.Tooltip")]
		[DefaultValue(false)]
		public bool uiFavorites;

		[LabelKey("$Mods.MagicStorage.Config.extraFilterIcons.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.extraFilterIcons.Tooltip")]
		[DefaultValue(true)]
		[ReloadRequired]
		public bool extraFilterIcons;

		[LabelKey("$Mods.MagicStorage.Config.buttonLayout.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.buttonLayout.Tooltip")]
		[DefaultValue(ButtonConfigurationMode.Legacy)]
		[DrawTicks]
		public ButtonConfigurationMode buttonLayout;

		[Header($"$Mods.MagicStorage.Config.Headers.General")]
		[LabelKey("$Mods.MagicStorage.Config.allowItemDataDebug.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.allowItemDataDebug.Tooltip")]
		[DefaultValue(false)]
		public bool itemDataDebug;  //Previously "allowItemDataDebug"

		[LabelKey("$Mods.MagicStorage.Config.canMovePanels.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.canMovePanels.Tooltip")]
		[DefaultValue(true)]
		public bool canMovePanels;

		[LabelKey("$Mods.MagicStorage.Config.automatonRemembers.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.automatonRemembers.Tooltip")]
		[DefaultValue(true)]
		public bool automatonRemembers;

		public static MagicStorageConfig Instance => ModContent.GetInstance<MagicStorageConfig>();

		[JsonIgnore]
		public static bool GlowNewItems => Instance.glowNewItems;

		[JsonIgnore]
		public static bool UseConfigFilter => Instance.useConfigFilter;

		[JsonIgnore]
		public static bool ShowAllRecipes => Instance.showAllRecipes;

		[JsonIgnore]
		public static bool QuickStackDepositMode => Instance.quickStackDepositMode;

		[JsonIgnore]
		public static bool ClearSearchText => Instance.clearSearchText;

		[JsonIgnore]
		public static bool ExtraFilterIcons => Instance.extraFilterIcons;

		[JsonIgnore]
		public static bool UseOldCraftMenu => Instance.useOldCraftMenu;

		[JsonIgnore]
		public static bool ItemDataDebug => Instance.itemDataDebug;

		[JsonIgnore]
		public static bool SearchBarRefreshOnKey => Instance.searchBarRefreshOnKey;

		[JsonIgnore]
		public static bool CraftingFavoritingEnabled => Instance.uiFavorites;

		[JsonIgnore]
		public static bool RecipeBlacklistEnabled => Instance.recipeBlacklist;

		[JsonIgnore]
		public static ButtonConfigurationMode ButtonUIMode => Instance.buttonLayout;

		[JsonIgnore]
		public static bool ClearRecipeHistory => Instance.clearHistory;

		[JsonIgnore]
		public static bool CanMoveUIPanels => Instance.canMovePanels;

		[JsonIgnore]
		public static int RecipeRecursionDepth => Instance.recursionDepth;
		
		[JsonIgnore]
		public static bool IsRecursionEnabled => RecipeRecursionDepth != 0;

		[JsonIgnore]
		public static bool IsRecursionInfinite => RecipeRecursionDepth == -1;

		[JsonIgnore]
		public static bool DisplayLastSeenAutomatonTip => Instance.automatonRemembers;

		public override ConfigScope Mode => ConfigScope.ClientSide;
	}

	//[LabelKey("$Mods.MagicStorage.Config.ServersideLabel")]
	public class MagicStorageServerConfig : ModConfig {
		public override ConfigScope Mode => ConfigScope.ServerSide;

		public static MagicStorageServerConfig Instance => ModContent.GetInstance<MagicStorageServerConfig>();

		[LabelKey("$Mods.MagicStorage.Config.AllowAutomatonToMoveIn.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.AllowAutomatonToMoveIn.Tooltip")]
		[DefaultValue(true)]
		public bool allowAutomatonToMoveIn;

		[JsonIgnore]
		public static bool AllowAutomatonToMoveIn => Instance.allowAutomatonToMoveIn;

		public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message) {
			if (Main.player[whoAmI].GetModPlayer<OperatorPlayer>().hasOp)
				return true;

			message = "Only users with the Server Operator status or higher can modify this config";
			return false;
		}
	}

	#if NETPLAY
	/// <summary>
	/// The config for beta builds.  Make sure to wrap uses of this class with <c>#if NETPLAY</c>
	/// </summary>
	[LabelKey("$Mods.MagicStorage.Config.BetaLabel")]
	public class MagicStorageBetaConfig : ModConfig {
		public override ConfigScope Mode => ConfigScope.ClientSide;

		public static MagicStorageBetaConfig Instance => ModContent.GetInstance<MagicStorageBetaConfig>();

		[LabelKey("$Mods.MagicStorage.Config.PrintTextToChat.Label")]
		[TooltipKeyKey("$Mods.MagicStorage.Config.PrintTextToChat.Tooltip")]
		[DefaultValue(false)]
		public bool printTextToChat;

		[LabelKey("$Mods.MagicStorage.Config.ShowDebugPylonRangeAreas.Label")]
		[TooltipKey("$Mods.MagicStorage.Config.ShowDebugPylonRangeAreas.Tooltip")]
		[DefaultValue(false)]
		public bool showPylonAreas;

		[JsonIgnore]
		public static bool PrintTextToChat => Instance.printTextToChat;

		[JsonIgnore]
		public static bool ShowDebugPylonRangeAreas => Instance.showPylonAreas;
	}
	#endif
}
