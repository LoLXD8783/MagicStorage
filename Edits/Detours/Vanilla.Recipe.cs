﻿using MagicStorage.Items;
using Terraria;
using Terraria.ID;

namespace MagicStorage.Edits.Detours{
	internal static partial class Vanilla{
		internal static void Recipe_FindRecipes(On.Terraria.Recipe.orig_FindRecipes orig, bool canDelayCheck){
			Player player = Main.LocalPlayer;

			bool oldGraveyard = player.ZoneGraveyard;
			bool oldSnow = player.ZoneSnow;
			bool oldNearCampfire = player.adjTile[TileID.Campfire];
			bool oldAltar = player.adjTile[TileID.DemonAltar];
			bool oldWater = player.adjWater;
			bool oldLava = player.adjLava;
			bool oldHoney = player.adjHoney;

			//Override these flags
			if(Main.LocalPlayer.GetModPlayer<BiomePlayer>().biomeGlobe){
				player.ZoneGraveyard = true;
				player.ZoneSnow = true;
				player.adjTile[TileID.Campfire] = true;
				player.adjTile[TileID.DemonAltar] = true;
				player.adjWater = true;
				player.adjLava = true;
				player.adjHoney = true;
			}

			orig(canDelayCheck);

			player.ZoneGraveyard = oldGraveyard;
			player.ZoneSnow = oldSnow;
			player.adjTile[TileID.Campfire] = oldNearCampfire;
			player.adjTile[TileID.DemonAltar] = oldAltar;
			player.adjWater = oldWater;
			player.adjLava = oldLava;
			player.adjHoney = oldHoney;
		}
	}
}
