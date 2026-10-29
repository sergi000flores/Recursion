using System.Diagnostics;
using System.Numerics;

namespace RecursionApp;

public partial class Form1 : Form
{
    private const int MaxTraza = 2000;
    private readonly List<string> _traza = new();

    private static readonly string[] Nombres =
    {
        "1. Factorial",
        "2. Fibonacci",
        "3. Torres de Hanoi",
        "4. Suma de arreglos",
        "5. Búsqueda lineal recursiva"
    };

    private static readonly string[] Documentacion =
    {
        // Factorial
        "FACTORIAL  n! = n × (n-1) × ... × 1\r\n\r\n" +
        "CASO BASE (condición de salida):\r\n    n <= 1  →  retorna 1\r\n\r\n" +
        "CASO RECURSIVO (llamada recursiva):\r\n    factorial(n) = n * factorial(n - 1)\r\n\r\n" +
        "CONVERSIÓN:\r\n    El acumulador 'resultado' del ciclo for se vuelve el valor que regresa cada llamada;\r\n" +
        "    el contador 'i' se vuelve el parámetro n que decrece hasta el caso base.",

        // Fibonacci
        "FIBONACCI  F(0)=0, F(1)=1, F(n)=F(n-1)+F(n-2)\r\n\r\n" +
        "CASO BASE (condición de salida):\r\n    n == 0 → 0      n == 1 → 1\r\n\r\n" +
        "CASO RECURSIVO (llamada recursiva):\r\n    fib(n) = fib(n - 1) + fib(n - 2)\r\n\r\n" +
        "CONVERSIÓN:\r\n    Las variables (a, b) del ciclo se reemplazan por dos llamadas recursivas.\r\n" +
        "    Complejidad O(2^n): por eso se limita n a 30.",

        // Hanoi
        "TORRES DE HANOI  (mínimo 2^n - 1 movimientos)\r\n\r\n" +
        "CASO BASE (condición de salida):\r\n    n == 1 → mover el disco de origen a destino\r\n\r\n" +
        "CASO RECURSIVO (llamadas recursivas):\r\n" +
        "    1) hanoi(n-1, origen → auxiliar)\r\n    2) mover disco n de origen a destino\r\n    3) hanoi(n-1, auxiliar → destino)\r\n\r\n" +
        "CONVERSIÓN:\r\n    La versión iterativa simula las torres con pilas y ciclos de 2^n - 1 pasos;\r\n" +
        "    la recursiva usa la pila de llamadas como estructura de apoyo.",

        // Suma
        "SUMA DE ARREGLOS\r\n\r\n" +
        "CASO BASE (condición de salida):\r\n    indice == arreglo.Length → retorna 0\r\n\r\n" +
        "CASO RECURSIVO (llamada recursiva):\r\n    suma(i) = arreglo[i] + suma(i + 1)\r\n\r\n" +
        "CONVERSIÓN:\r\n    El contador 'i' del for pasa a ser el parámetro 'indice'; el acumulador\r\n" +
        "    'suma' se construye al regresar de cada llamada.",

        // Búsqueda
        "BÚSQUEDA LINEAL RECURSIVA\r\n\r\n" +
        "CASOS BASE (condiciones de salida):\r\n    1) indice >= arreglo.Length → retorna -1 (no encontrado)\r\n" +
        "    2) arreglo[indice] == objetivo → retorna indice (encontrado)\r\n\r\n" +
        "CASO RECURSIVO (llamada recursiva):\r\n    buscar(i) = buscar(i + 1)\r\n\r\n" +
        "CONVERSIÓN:\r\n    El 'return i' dentro del for es el caso base 2; terminar el for sin hallar\r\n" +
        "    el valor es el caso base 1; el i++ es la llamada con indice + 1."
    };

    public Form1()
    {
        InitializeComponent();
        cmbEjercicio.Items.AddRange(Nombres);
        cmbEjercicio.SelectedIndex = 0;
    }

    private int Indice => Math.Max(cmbEjercicio.SelectedIndex, 0);

    // ------------------------------------------------------------------
    // Eventos
    // ------------------------------------------------------------------
    private void cmbEjercicio_SelectedIndexChanged(object? sender, EventArgs e)
    {
        txtDocumentacion.Text = Documentacion[Indice];
        lstTraza.Items.Clear();
        lblResultado.Text = "Resultado: -";

        bool usaArreglo = Indice >= 3;
        bool usaObjetivo = Indice == 4;
        lblExtra.Visible = txtExtra.Visible = usaObjetivo;

        switch (Indice)
        {
            case 0:
                lblEntrada.Text = "n (0 a 1000):";
                txtEntrada.Text = "5";
                lblAyuda.Text = "Ingresa un entero n >= 0.";
                break;
            case 1:
                lblEntrada.Text = "n (0 a 30):";
                txtEntrada.Text = "8";
                lblAyuda.Text = "El Fibonacci recursivo es exponencial; se limita a n <= 30.";
                break;
            case 2:
                lblEntrada.Text = "Número de discos (1 a 15):";
                txtEntrada.Text = "3";
                lblAyuda.Text = "Se muestran los movimientos (traza limitada a " + MaxTraza + " líneas).";
                break;
            case 3:
                lblEntrada.Text = "Arreglo (separado por comas):";
                txtEntrada.Text = "4, 8, 15, 16, 23, 42";
                lblAyuda.Text = "Máximo 5000 elementos enteros.";
                break;
            default:
                lblEntrada.Text = "Arreglo (separado por comas):";
                txtEntrada.Text = "4, 8, 15, 16, 23, 42";
                lblExtra.Text = "Valor a buscar:";
                txtExtra.Text = "16";
                lblAyuda.Text = "Retorna el índice (base 0) o -1 si no existe.";
                break;
        }
        _ = usaArreglo;
    }

    private void btnIterativo_Click(object? sender, EventArgs e) => Ejecutar(iterativo: true, recursivo: false);

    private void btnRecursivo_Click(object? sender, EventArgs e) => Ejecutar(iterativo: false, recursivo: true);

    private void btnComparar_Click(object? sender, EventArgs e) => Ejecutar(iterativo: true, recursivo: true);

    // ------------------------------------------------------------------
    // Lógica de ejecución
    // ------------------------------------------------------------------
    private void Log(string linea)
    {
        if (_traza.Count < MaxTraza) _traza.Add(linea);
        else if (_traza.Count == MaxTraza) _traza.Add("... (traza truncada)");
    }

    private void Ejecutar(bool iterativo, bool recursivo)
    {
        try
        {
            _traza.Clear();
            var partes = new List<string>();
            string? resIter = null, resRec = null;
            Stopwatch sw = new();

            if (iterativo)
            {
                Log("===== VERSIÓN ITERATIVA =====");
                sw.Restart();
                resIter = Resolver(false);
                sw.Stop();
                partes.Add($"Iterativo: {Resumir(resIter)}  ({sw.Elapsed.TotalMilliseconds:F3} ms)");
            }

            if (recursivo)
            {
                Log("===== VERSIÓN RECURSIVA =====");
                sw.Restart();
                resRec = Resolver(true);
                sw.Stop();
                partes.Add($"Recursivo: {Resumir(resRec)}  ({sw.Elapsed.TotalMilliseconds:F3} ms)");
            }

            if (resIter is not null && resRec is not null)
                partes.Add(resIter == resRec ? "✔ Ambos resultados coinciden" : "✘ Los resultados difieren");

            lblResultado.Text = string.Join(Environment.NewLine, partes);

            lstTraza.BeginUpdate();
            lstTraza.Items.Clear();
            lstTraza.Items.AddRange(_traza.ToArray());
            lstTraza.EndUpdate();
        }
        catch (FormatException ex)
        {
            MessageBox.Show(ex.Message, "Entrada inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            MessageBox.Show(ex.Message, "Fuera de rango", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private static string Resumir(string s) => s.Length > 90 ? s[..90] + "..." : s;

    /// <summary>Devuelve el resultado como texto; si es recursivo también llena la traza.</summary>
    private string Resolver(bool recursivo)
    {
        Action<string> log = Log;

        switch (Indice)
        {
            case 0:
            {
                int n = LeerEntero(txtEntrada.Text, 0, 1000, "n");
                BigInteger r = recursivo ? Ejercicios.FactorialRecursivo(n, log) : Ejercicios.FactorialIterativo(n, log);
                return r.ToString();
            }
            case 1:
            {
                int n = LeerEntero(txtEntrada.Text, 0, 30, "n");
                BigInteger r = recursivo ? Ejercicios.FibonacciRecursivo(n, log) : Ejercicios.FibonacciIterativo(n, log);
                return r.ToString();
            }
            case 2:
            {
                int n = LeerEntero(txtEntrada.Text, 1, 15, "discos");
                List<string> movs;
                if (recursivo)
                {
                    movs = new();
                    Ejercicios.HanoiRecursivo(n, 'A', 'C', 'B', movs, log);
                }
                else
                {
                    movs = Ejercicios.HanoiIterativo(n);
                    for (int i = 0; i < movs.Count; i++) Log($"{i + 1,5}. {movs[i]}");
                }
                return $"{movs.Count} movimientos (2^{n} - 1)";
            }
            case 3:
            {
                int[] arr = LeerArreglo(txtEntrada.Text);
                long r = recursivo ? Ejercicios.SumaRecursiva(arr, 0, log) : Ejercicios.SumaIterativa(arr, log);
                return r.ToString();
            }
            default:
            {
                int[] arr = LeerArreglo(txtEntrada.Text);
                int objetivo = LeerEntero(txtExtra.Text, int.MinValue, int.MaxValue, "valor a buscar");
                int r = recursivo
                    ? Ejercicios.BusquedaLinealRecursiva(arr, objetivo, 0, log)
                    : Ejercicios.BusquedaLinealIterativa(arr, objetivo, log);
                return r >= 0 ? $"encontrado en el índice {r}" : "no encontrado (-1)";
            }
        }
    }

    private static int LeerEntero(string texto, int min, int max, string nombre)
    {
        if (!int.TryParse(texto.Trim(), out int valor))
            throw new FormatException($"'{nombre}' debe ser un número entero.");
        if (valor < min || valor > max)
            throw new ArgumentOutOfRangeException(nameof(texto), $"'{nombre}' debe estar entre {min} y {max}.");
        return valor;
    }

    private static int[] LeerArreglo(string texto)
    {
        var tokens = texto.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (tokens.Length == 0)
            throw new FormatException("Ingresa al menos un elemento.");
        if (tokens.Length > 5000)
            throw new ArgumentOutOfRangeException(nameof(texto), "Máximo 5000 elementos.");

        var arr = new int[tokens.Length];
        for (int i = 0; i < tokens.Length; i++)
            if (!int.TryParse(tokens[i], out arr[i]))
                throw new FormatException($"'{tokens[i]}' no es un entero válido.");
        return arr;
    }

    private void btnLimpiar_Click(object? sender, EventArgs e)
    {
        lstTraza.Items.Clear();
        lblResultado.Text = "Resultado: -";
    }
}
