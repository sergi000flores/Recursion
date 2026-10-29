using System.Numerics;

namespace RecursionApp;

/// <summary>
/// Catálogo de problemas: cada uno con su versión ITERATIVA y su versión RECURSIVA.
/// En cada método recursivo se documenta el CASO BASE y el CASO RECURSIVO.
/// El parámetro 'log' recibe la traza de ejecución (opcional) para visualizarla en la UI.
/// </summary>
public static class Ejercicios
{
    // =====================================================================
    // 1. FACTORIAL
    // =====================================================================

    /// <summary>Iterativo: acumula el producto 2 * 3 * ... * n con un ciclo for.</summary>
    public static BigInteger FactorialIterativo(int n, Action<string>? log = null)
    {
        BigInteger resultado = 1;
        log?.Invoke($"inicio: resultado = 1 (n = {n})");
        for (int i = 2; i <= n; i++)
        {
            resultado *= i;
            log?.Invoke($"i = {i}: resultado = {resultado}");
        }
        return resultado;
    }

    /// <summary>
    /// Recursivo.
    /// CASO BASE:      n &lt;= 1  =>  0! = 1! = 1 (condición de salida).
    /// CASO RECURSIVO: n! = n * (n - 1)!  (el problema se reduce en 1 en cada llamada).
    /// </summary>
    public static BigInteger FactorialRecursivo(int n, Action<string>? log = null, int nivel = 0)
    {
        string sangria = new(' ', nivel * 2);

        // ---- CASO BASE ----
        if (n <= 1)
        {
            log?.Invoke($"{sangria}[CASO BASE] factorial({n}) = 1");
            return 1;
        }

        // ---- CASO RECURSIVO ----
        log?.Invoke($"{sangria}[RECURSIVO] factorial({n}) = {n} * factorial({n - 1})");
        BigInteger r = n * FactorialRecursivo(n - 1, log, nivel + 1);
        log?.Invoke($"{sangria}<- retorna factorial({n}) = {r}");
        return r;
    }

    // =====================================================================
    // 2. FIBONACCI
    // =====================================================================

    /// <summary>Iterativo: mantiene los dos últimos valores (a, b) y avanza n veces.</summary>
    public static BigInteger FibonacciIterativo(int n, Action<string>? log = null)
    {
        BigInteger a = 0, b = 1;
        log?.Invoke($"inicio: a = 0, b = 1 (n = {n})");
        for (int i = 0; i < n; i++)
        {
            (a, b) = (b, a + b);
            log?.Invoke($"paso {i + 1}: a = {a}, b = {b}");
        }
        return a;
    }

    /// <summary>
    /// Recursivo.
    /// CASO BASE:      n == 0 => 0   y   n == 1 => 1.
    /// CASO RECURSIVO: fib(n) = fib(n - 1) + fib(n - 2)  (dos llamadas recursivas).
    /// </summary>
    public static BigInteger FibonacciRecursivo(int n, Action<string>? log = null, int nivel = 0)
    {
        string sangria = new(' ', nivel * 2);

        // ---- CASO BASE ----
        if (n <= 1)
        {
            log?.Invoke($"{sangria}[CASO BASE] fib({n}) = {n}");
            return n;
        }

        // ---- CASO RECURSIVO ----
        log?.Invoke($"{sangria}[RECURSIVO] fib({n}) = fib({n - 1}) + fib({n - 2})");
        BigInteger r = FibonacciRecursivo(n - 1, log, nivel + 1)
                     + FibonacciRecursivo(n - 2, log, nivel + 1);
        log?.Invoke($"{sangria}<- retorna fib({n}) = {r}");
        return r;
    }

    // =====================================================================
    // 3. TORRES DE HANOI
    // =====================================================================

    /// <summary>
    /// Iterativo: simula las tres torres con pilas y repite 2^n - 1 veces el ciclo
    /// de movimientos legales (origen-destino, origen-auxiliar, auxiliar-destino).
    /// </summary>
    public static List<string> HanoiIterativo(int n, char origen = 'A', char auxiliar = 'B', char destino = 'C')
    {
        var torres = new Dictionary<char, Stack<int>>
        {
            [origen] = new(),
            [auxiliar] = new(),
            [destino] = new()
        };
        for (int d = n; d >= 1; d--) torres[origen].Push(d);

        var movimientos = new List<string>();
        char src = origen, aux = auxiliar, dst = destino;
        if (n % 2 == 0) (aux, dst) = (dst, aux); // con n par se intercambian auxiliar y destino

        long total = (1L << n) - 1;
        for (long i = 1; i <= total; i++)
        {
            (char x, char y) = (i % 3) switch
            {
                1 => (src, dst),
                2 => (src, aux),
                _ => (aux, dst)
            };
            MoverLegal(torres, x, y, movimientos);
        }
        return movimientos;
    }

    private static void MoverLegal(Dictionary<char, Stack<int>> torres, char x, char y, List<string> movs)
    {
        Stack<int> sx = torres[x], sy = torres[y];
        if (sx.Count == 0 || (sy.Count > 0 && sy.Peek() < sx.Peek()))
            (x, y, sx, sy) = (y, x, sy, sx); // el movimiento legal es en sentido contrario

        int disco = sx.Pop();
        sy.Push(disco);
        movs.Add($"Mover disco {disco} de {x} a {y}");
    }

    /// <summary>
    /// Recursivo.
    /// CASO BASE:      n == 1  =>  mover el único disco de origen a destino.
    /// CASO RECURSIVO: 1) mover n-1 discos de origen a auxiliar (usando destino),
    ///                 2) mover el disco n de origen a destino,
    ///                 3) mover n-1 discos de auxiliar a destino (usando origen).
    /// </summary>
    public static void HanoiRecursivo(int n, char origen, char destino, char auxiliar,
                                      List<string> movimientos, Action<string>? log = null, int nivel = 0)
    {
        string sangria = new(' ', nivel * 2);

        // ---- CASO BASE ----
        if (n == 1)
        {
            movimientos.Add($"Mover disco 1 de {origen} a {destino}");
            log?.Invoke($"{sangria}[CASO BASE] hanoi(1, {origen}->{destino}): mover disco 1 de {origen} a {destino}");
            return;
        }

        // ---- CASO RECURSIVO ----
        log?.Invoke($"{sangria}[RECURSIVO] hanoi({n}, {origen}->{destino}, aux {auxiliar})");
        HanoiRecursivo(n - 1, origen, auxiliar, destino, movimientos, log, nivel + 1);
        movimientos.Add($"Mover disco {n} de {origen} a {destino}");
        log?.Invoke($"{sangria}   mover disco {n} de {origen} a {destino}");
        HanoiRecursivo(n - 1, auxiliar, destino, origen, movimientos, log, nivel + 1);
    }

    // =====================================================================
    // 4. SUMA DE ARREGLOS
    // =====================================================================

    /// <summary>Iterativo: recorre el arreglo acumulando en una variable.</summary>
    public static long SumaIterativa(int[] arreglo, Action<string>? log = null)
    {
        long suma = 0;
        for (int i = 0; i < arreglo.Length; i++)
        {
            suma += arreglo[i];
            log?.Invoke($"i = {i}: suma += {arreglo[i]} => {suma}");
        }
        return suma;
    }

    /// <summary>
    /// Recursivo (el índice reemplaza al contador del for).
    /// CASO BASE:      indice == arreglo.Length  =>  suma de nada = 0.
    /// CASO RECURSIVO: suma(i) = arreglo[i] + suma(i + 1).
    /// </summary>
    public static long SumaRecursiva(int[] arreglo, int indice = 0, Action<string>? log = null)
    {
        string sangria = new(' ', indice * 2);

        // ---- CASO BASE ----
        if (indice == arreglo.Length)
        {
            log?.Invoke($"{sangria}[CASO BASE] suma({indice}) = 0 (fin del arreglo)");
            return 0;
        }

        // ---- CASO RECURSIVO ----
        log?.Invoke($"{sangria}[RECURSIVO] suma({indice}) = {arreglo[indice]} + suma({indice + 1})");
        long r = arreglo[indice] + SumaRecursiva(arreglo, indice + 1, log);
        log?.Invoke($"{sangria}<- retorna suma({indice}) = {r}");
        return r;
    }

    // =====================================================================
    // 5. BÚSQUEDA LINEAL
    // =====================================================================

    /// <summary>Iterativo: revisa posición por posición hasta encontrar el valor.</summary>
    public static int BusquedaLinealIterativa(int[] arreglo, int objetivo, Action<string>? log = null)
    {
        for (int i = 0; i < arreglo.Length; i++)
        {
            log?.Invoke($"i = {i}: arreglo[{i}] = {arreglo[i]} {(arreglo[i] == objetivo ? "==" : "!=")} {objetivo}");
            if (arreglo[i] == objetivo)
                return i;
        }
        log?.Invoke("fin del arreglo sin encontrar el valor");
        return -1;
    }

    /// <summary>
    /// Recursivo.
    /// CASO BASE 1: indice &gt;= arreglo.Length  =>  no encontrado, retorna -1.
    /// CASO BASE 2: arreglo[indice] == objetivo =>  encontrado, retorna indice.
    /// CASO RECURSIVO: buscar(i) = buscar(i + 1)  (descarta la posición actual).
    /// </summary>
    public static int BusquedaLinealRecursiva(int[] arreglo, int objetivo, int indice = 0, Action<string>? log = null)
    {
        string sangria = new(' ', indice * 2);

        // ---- CASO BASE 1: se agotó el arreglo ----
        if (indice >= arreglo.Length)
        {
            log?.Invoke($"{sangria}[CASO BASE 1] indice {indice} fuera del arreglo => -1");
            return -1;
        }

        // ---- CASO BASE 2: encontrado ----
        if (arreglo[indice] == objetivo)
        {
            log?.Invoke($"{sangria}[CASO BASE 2] arreglo[{indice}] = {arreglo[indice]} == {objetivo} => {indice}");
            return indice;
        }

        // ---- CASO RECURSIVO ----
        log?.Invoke($"{sangria}[RECURSIVO] arreglo[{indice}] = {arreglo[indice]} != {objetivo}, buscar en {indice + 1}");
        return BusquedaLinealRecursiva(arreglo, objetivo, indice + 1, log);
    }
}
