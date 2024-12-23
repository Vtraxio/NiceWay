using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NiggaWay {
	internal class City(PointF point, bool selected, double? distanceToNext) {
		public PointF  Point          { get; set; } = point;
		public bool    Selected       { get; set; } = selected;
		public double? DistanceToNext { get; set; } = distanceToNext;
	}

	internal record JsonPoint(float x, float y);

	public class ListUtils {
		public static void Swap<T>(IList<T> list, int indexA, int indexB) {
			(list[indexA], list[indexB]) = (list[indexB], list[indexA]);
		}
	}

	public class GeneralUtils {
		public static float ConvertRangeStandard(float value) => ConvertRange(-100, 100, 0, 500, value);

		public static float ConvertRange(
			int   originalStart, int originalEnd,
			int   newStart,      int newEnd,
			float value) {
			var scale = (float)(newEnd - newStart) / (originalEnd - originalStart);
			return newStart + ((value - originalStart) * scale);
		}
	}
}