namespace System.Windows.Forms {
    public class BufferedPanel: Panel {
        public BufferedPanel() {
            this.DoubleBuffered = true;         //to avoid flickering of the panel
        }
    }
}