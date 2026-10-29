namespace RecursionApp;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        lblTitulo = new Label();
        grpEntrada = new GroupBox();
        lblAyuda = new Label();
        btnLimpiar = new Button();
        btnComparar = new Button();
        btnRecursivo = new Button();
        btnIterativo = new Button();
        txtExtra = new TextBox();
        lblExtra = new Label();
        txtEntrada = new TextBox();
        lblEntrada = new Label();
        cmbEjercicio = new ComboBox();
        lblEjercicio = new Label();
        grpDocumentacion = new GroupBox();
        txtDocumentacion = new TextBox();
        grpResultado = new GroupBox();
        lblResultado = new Label();
        grpTraza = new GroupBox();
        lstTraza = new ListBox();
        grpEntrada.SuspendLayout();
        grpDocumentacion.SuspendLayout();
        grpResultado.SuspendLayout();
        grpTraza.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
        lblTitulo.Location = new Point(12, 9);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(466, 32);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Recursividad: de iterativo a recursivo";
        // 
        // grpEntrada
        // 
        grpEntrada.Controls.Add(lblAyuda);
        grpEntrada.Controls.Add(btnLimpiar);
        grpEntrada.Controls.Add(btnComparar);
        grpEntrada.Controls.Add(btnRecursivo);
        grpEntrada.Controls.Add(btnIterativo);
        grpEntrada.Controls.Add(txtExtra);
        grpEntrada.Controls.Add(lblExtra);
        grpEntrada.Controls.Add(txtEntrada);
        grpEntrada.Controls.Add(lblEntrada);
        grpEntrada.Controls.Add(cmbEjercicio);
        grpEntrada.Controls.Add(lblEjercicio);
        grpEntrada.Location = new Point(12, 50);
        grpEntrada.Name = "grpEntrada";
        grpEntrada.Size = new Size(470, 290);
        grpEntrada.TabIndex = 1;
        grpEntrada.TabStop = false;
        grpEntrada.Text = "Ejercicio y datos de entrada";
        // 
        // lblEjercicio
        // 
        lblEjercicio.AutoSize = true;
        lblEjercicio.Location = new Point(15, 28);
        lblEjercicio.Name = "lblEjercicio";
        lblEjercicio.Size = new Size(61, 20);
        lblEjercicio.TabIndex = 0;
        lblEjercicio.Text = "Ejercicio:";
        // 
        // cmbEjercicio
        // 
        cmbEjercicio.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbEjercicio.FormattingEnabled = true;
        cmbEjercicio.Location = new Point(15, 51);
        cmbEjercicio.Name = "cmbEjercicio";
        cmbEjercicio.Size = new Size(440, 28);
        cmbEjercicio.TabIndex = 1;
        cmbEjercicio.SelectedIndexChanged += cmbEjercicio_SelectedIndexChanged;
        // 
        // lblEntrada
        // 
        lblEntrada.AutoSize = true;
        lblEntrada.Location = new Point(15, 90);
        lblEntrada.Name = "lblEntrada";
        lblEntrada.Size = new Size(60, 20);
        lblEntrada.TabIndex = 2;
        lblEntrada.Text = "Entrada:";
        // 
        // txtEntrada
        // 
        txtEntrada.Location = new Point(15, 113);
        txtEntrada.Name = "txtEntrada";
        txtEntrada.Size = new Size(440, 27);
        txtEntrada.TabIndex = 3;
        // 
        // lblExtra
        // 
        lblExtra.AutoSize = true;
        lblExtra.Location = new Point(15, 150);
        lblExtra.Name = "lblExtra";
        lblExtra.Size = new Size(108, 20);
        lblExtra.TabIndex = 4;
        lblExtra.Text = "Valor a buscar:";
        lblExtra.Visible = false;
        // 
        // txtExtra
        // 
        txtExtra.Location = new Point(15, 173);
        txtExtra.Name = "txtExtra";
        txtExtra.Size = new Size(440, 27);
        txtExtra.TabIndex = 5;
        txtExtra.Visible = false;
        // 
        // btnIterativo
        // 
        btnIterativo.Location = new Point(15, 212);
        btnIterativo.Name = "btnIterativo";
        btnIterativo.Size = new Size(140, 34);
        btnIterativo.TabIndex = 6;
        btnIterativo.Text = "Iterativo";
        btnIterativo.UseVisualStyleBackColor = true;
        btnIterativo.Click += btnIterativo_Click;
        // 
        // btnRecursivo
        // 
        btnRecursivo.Location = new Point(165, 212);
        btnRecursivo.Name = "btnRecursivo";
        btnRecursivo.Size = new Size(140, 34);
        btnRecursivo.TabIndex = 7;
        btnRecursivo.Text = "Recursivo";
        btnRecursivo.UseVisualStyleBackColor = true;
        btnRecursivo.Click += btnRecursivo_Click;
        // 
        // btnComparar
        // 
        btnComparar.Location = new Point(315, 212);
        btnComparar.Name = "btnComparar";
        btnComparar.Size = new Size(140, 34);
        btnComparar.TabIndex = 8;
        btnComparar.Text = "Comparar ambos";
        btnComparar.UseVisualStyleBackColor = true;
        btnComparar.Click += btnComparar_Click;
        // 
        // btnLimpiar
        // 
        btnLimpiar.Location = new Point(355, 250);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(100, 30);
        btnLimpiar.TabIndex = 9;
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.UseVisualStyleBackColor = true;
        btnLimpiar.Click += btnLimpiar_Click;
        // 
        // lblAyuda
        // 
        lblAyuda.ForeColor = SystemColors.GrayText;
        lblAyuda.Location = new Point(15, 250);
        lblAyuda.Name = "lblAyuda";
        lblAyuda.Size = new Size(330, 30);
        lblAyuda.TabIndex = 10;
        lblAyuda.Text = "Ayuda";
        // 
        // grpDocumentacion
        // 
        grpDocumentacion.Controls.Add(txtDocumentacion);
        grpDocumentacion.Location = new Point(12, 350);
        grpDocumentacion.Name = "grpDocumentacion";
        grpDocumentacion.Size = new Size(470, 330);
        grpDocumentacion.TabIndex = 2;
        grpDocumentacion.TabStop = false;
        grpDocumentacion.Text = "Documentación: caso base y caso recursivo";
        // 
        // txtDocumentacion
        // 
        txtDocumentacion.BackColor = SystemColors.Window;
        txtDocumentacion.Dock = DockStyle.Fill;
        txtDocumentacion.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        txtDocumentacion.Location = new Point(3, 23);
        txtDocumentacion.Multiline = true;
        txtDocumentacion.Name = "txtDocumentacion";
        txtDocumentacion.ReadOnly = true;
        txtDocumentacion.ScrollBars = ScrollBars.Vertical;
        txtDocumentacion.Size = new Size(464, 304);
        txtDocumentacion.TabIndex = 0;
        // 
        // grpResultado
        // 
        grpResultado.Controls.Add(lblResultado);
        grpResultado.Location = new Point(495, 50);
        grpResultado.Name = "grpResultado";
        grpResultado.Size = new Size(493, 110);
        grpResultado.TabIndex = 3;
        grpResultado.TabStop = false;
        grpResultado.Text = "Resultado";
        // 
        // lblResultado
        // 
        lblResultado.Dock = DockStyle.Fill;
        lblResultado.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        lblResultado.Location = new Point(3, 23);
        lblResultado.Name = "lblResultado";
        lblResultado.Padding = new Padding(8, 6, 8, 0);
        lblResultado.Size = new Size(487, 84);
        lblResultado.TabIndex = 0;
        lblResultado.Text = "Resultado: -";
        // 
        // grpTraza
        // 
        grpTraza.Controls.Add(lstTraza);
        grpTraza.Location = new Point(495, 170);
        grpTraza.Name = "grpTraza";
        grpTraza.Size = new Size(493, 510);
        grpTraza.TabIndex = 4;
        grpTraza.TabStop = false;
        grpTraza.Text = "Traza de ejecución";
        // 
        // lstTraza
        // 
        lstTraza.Dock = DockStyle.Fill;
        lstTraza.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);
        lstTraza.FormattingEnabled = true;
        lstTraza.HorizontalScrollbar = true;
        lstTraza.Location = new Point(3, 23);
        lstTraza.Name = "lstTraza";
        lstTraza.Size = new Size(487, 484);
        lstTraza.TabIndex = 0;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1000, 692);
        Controls.Add(grpTraza);
        Controls.Add(grpResultado);
        Controls.Add(grpDocumentacion);
        Controls.Add(grpEntrada);
        Controls.Add(lblTitulo);
        MinimumSize = new Size(1016, 731);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Recursividad - Catálogo de problemas";
        grpEntrada.ResumeLayout(false);
        grpEntrada.PerformLayout();
        grpDocumentacion.ResumeLayout(false);
        grpDocumentacion.PerformLayout();
        grpResultado.ResumeLayout(false);
        grpTraza.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitulo;
    private GroupBox grpEntrada;
    private Label lblEjercicio;
    private ComboBox cmbEjercicio;
    private Label lblEntrada;
    private TextBox txtEntrada;
    private Label lblExtra;
    private TextBox txtExtra;
    private Button btnIterativo;
    private Button btnRecursivo;
    private Button btnComparar;
    private Button btnLimpiar;
    private Label lblAyuda;
    private GroupBox grpDocumentacion;
    private TextBox txtDocumentacion;
    private GroupBox grpResultado;
    private Label lblResultado;
    private GroupBox grpTraza;
    private ListBox lstTraza;
}
