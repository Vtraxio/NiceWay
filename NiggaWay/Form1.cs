using System.Diagnostics;
using System.Text.Json;

namespace NiggaWay {
	public partial class Form1 : Form {
		private List<City> _cities = [];

		// Bez tej zmiennej przed wybraniem punktu nadal by na mapie narysowa�o po��czenia, gdy nie jest nic przesortowane
		private bool _ready;

		public Form1() {
			InitializeComponent();
			pictureBox1.CreateGraphics();
		}

		private void button1_Click(object sender, EventArgs e) {
			fileDiag.ShowDialog();
			var text = File.ReadAllText(fileDiag.FileName);

			// Nie mo�na u�y� normalnego PointF, poniewa� jego w�a�ciwo�ci s� pisane wielkimi literami
			_cities = JsonSerializer.Deserialize<List<JsonPoint>>(text)!.Select(x => new City(new PointF(x.x, x.y), false, null)).ToList();

			lengthLbl.Text = @"Wybierz jaki� punkt";
			_ready         = false;
			Refresh();
		}

		private void Calculate(int origin) {
			// Punty s� sortowane i trzeba zamieni� punkt pocz�tkowy z 1 w li�cie i go pomin��, �eby nie jebn�o
			ListUtils.Swap(_cities, 0, origin);
			// Punkt, dla kt�rego w�a�nie liczymy najbli�sze miasto
			var current     = 0;
			var totalLength = 0d;

			var sw = new Stopwatch();
			sw.Start();

			for (var _ = 0; _ < _cities.Count - 1; _++) {
				var node = _cities[current];

				var closest = _cities
							  .Select((city, i) => (city, i)) // Wyci�gamy indeks, aby po zalezieniu miasta m�c je potem zamieni�
							  .Skip(current + 1)              // Pomijamy miasta, kt�re s� ju� obliczone oraz obecne
							  .Select(data => {
								  // Obliczamy odleg�o�� mi�dzy dwoma miastami i dodajemy je do danych miasta, aby u�y� w nast�pnym kroku.
								  // Nie mo�na tego zrobi� w MinBy, bo musimy potem u�y� d�ugo�ci do obliczenia ca�kowitej d�ugo�ci trasy
								  var length = Math.Sqrt(Math.Pow(node.Point.X - data.city.Point.X, 2) + Math.Pow(node.Point.Y - data.city.Point.Y, 2));
								  return new { city = new City(data.city.Point, data.city.Selected, length), data.i };
							  })
							  .MinBy(p => p.city.DistanceToNext);
				Debug.Assert(closest is not null);

				ListUtils.Swap(_cities, current + 1, closest.i);

				current++;
				totalLength += closest.city.DistanceToNext ?? 0;
			}

			sw.Stop();
			lengthLbl.Text = $@"D�ugo��: {totalLength} | Czas: {sw.Elapsed.TotalMilliseconds}ms";

			_ready = true;
			Refresh();
		}

		private void pictureBox1_Click(object sender, EventArgs e) {
			var mouse = pictureBox1.PointToClient(MousePosition);
			// W json jest od -100 do 100 a w pictureBoxie od 0 do 500 wi�c trzeba to przekonwertowa�
			var x = GeneralUtils.ConvertRangeP2J(mouse.X);
			var y = GeneralUtils.ConvertRangeP2J(mouse.Y);

			for (var i = 0; i < _cities.Count; i++) {
				var city = _cities[i];
				if (Math.Sqrt(Math.Pow(x - city.Point.X, 2) + Math.Pow(y - city.Point.Y, 2)) < 5) {
					city.Selected = true;
					Calculate(i);
					break;
				} else {
					city.Selected = false;
				}
			}
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e) {
			e.Graphics.Clear(Color.White);

			foreach (var point in _cities) {
				var x = GeneralUtils.ConvertRangeJ2P(point.Point.X);
				var y = GeneralUtils.ConvertRangeJ2P(point.Point.Y);
				e.Graphics.FillEllipse(point.Selected ? Brushes.Red : Brushes.Blue, x - 5f, y - 5f, 10f, 10f);
			}

			if (!_ready) return;

			for (var i = 0; i < _cities.Count - 1; i++) {
				var city = _cities[i];
				var next = _cities[i + 1];

				e.Graphics.DrawLine(
									Pens.Black,
									GeneralUtils.ConvertRangeJ2P(city.Point.X),
									GeneralUtils.ConvertRangeJ2P(city.Point.Y),
									GeneralUtils.ConvertRangeJ2P(next.Point.X),
									GeneralUtils.ConvertRangeJ2P(next.Point.Y)
								   );
			}
		}
	}
}