using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gameplay;
using Units;
using UnityEngine;

namespace AI {
	public class eliminationAgent : Agent {

		public eliminationAgent() : base() { }

		public override async Task<Move> getMove() {

			List<Coord> units = findAllUnits();
			List<Coord> enemies = filterEnemies(units);
			List<Coord> allies = filterAllies(units);

			List<Coord> available = filterHasMove(allies);

			Coord unitCoord;
			Unit curUnit;
			foreach (Coord coord in available) {
				Units unit = battlefield.units[coord.x, coord.y];
				if (unit is HealerUnit) {
					unitCoord = coord;
					curUnit = unit;
					break;
				} else if (unit is MeleeUnit)  {
					unitCoord = coord;
					curUnit = unit;
				} else if (!(curUnit is MeleeUnit)){
					unitCoord = coord;
					curUnit = unit;
				}
			}

			if (curUnit is HealerUnit) {
				if (curUnit.getHealth() < curUnit.maxHealth * 0.4) {
					// TODO
					// Flee
				} else {
					List<Coord> attackZone = curUnit.getTotalAttackZone(unitCoord.x, unitCoord.y, battlefield, character);
					List<Coord> targets = intersectCoords(attackZone, enemies);
					if (targets.Count > 0) {
						// TODO
						// Choose best target
					} else {
						// TODO
						// Move to closest
					}
				}
			} else if (curUnit is MeleeUnit) {

			} else if (curUnit is RangedUnit) {

			} else if (curUnit is StatusUnit) {

			}
			// Unit unit = selectUnit();
			// Coord unitCoord = battlefield.getUnitCoords(unit);	

			// List<Coord> targetCoords = findNearestEnemies(unitCoord);

			// List<Coord> targets = unit.getTargets(unitCoord.x, unitCoord.y, battlefield, character);

			// int minDist = Int32.MaxValue;
			// Coord bestCoord = null;
			// foreach (Coord targetCoord in targetCoords){
			// 	if (targets.Any(t => t.x == targetCoord.x && t.y == targetCoord.y)) {
			// 		return new Move(unitCoord.x, unitCoord.y, targetCoord.x, targetCoord.y);
			// 	}
				
			// 	foreach (Coord coord in unit.getValidMoves(unitCoord.x, unitCoord.y, battlefield)) {
			// 		int dist = this.manhattanDistance(coord, targetCoord);
			// 		if (dist < minDist) {
			// 			minDist = dist;
			// 			bestCoord = coord;
			// 		}
			// 	}
			// }
			
			//Just so the player can keep track of what's happening
			await Task.Delay(300);

			return new Move(unitCoord.x, unitCoord.y, bestCoord.x, bestCoord.y);
		}

	}
}
