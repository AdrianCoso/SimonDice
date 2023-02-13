using System.Windows.Forms;

namespace SimonDice
{
    public partial class botonSimon : Button
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        //Contorno del botón
        private GraphicsPath contorno;
        //Superficie del botón
        private GraphicsPath superficie;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //Constructor
        public botonSimon()
        {
            InitializeComponent();
        }

        //Sobreescribimos el método que dibuja el botón para adaptar su forma
        protected override void onPaint(PaintEventArgs pevent)
        {

        }
        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }

        #endregion
    }
}
