using System.Threading;
using System.Windows.Forms;

namespace EXIN
{
    public class WaitFormFunc
    {
        WaitForm wait;
        WaitFormSmall waitSmall;
        Thread loadthread;

        public void Show()
        {
            loadthread = new Thread(new ThreadStart(LoadingProcess));
            loadthread.Start();
        }

        public void ShowSmall()
        {
            loadthread = new Thread(new ThreadStart(LoadingProcessSmall));
            loadthread.Start();
        }

        public void Show(Form parent)
        {
            loadthread = new Thread(new ParameterizedThreadStart(LoadingProcess));
            loadthread.Start(parent);
        }

        public void ShowSmall(Form parent)
        {
            loadthread = new Thread(new ParameterizedThreadStart(LoadingProcessSmall));
            loadthread.Start(parent);
        }

        public void Show(Control Loader)
        {
            loadthread = new Thread(new ParameterizedThreadStart(LoadingProcess));
            loadthread.Start(Loader);
        }


        public void Close()
        {
            if (wait != null)
            {
                wait.BeginInvoke(new System.Threading.ThreadStart(wait.CloseWaitForm));
                wait = null;
                loadthread = null;
            }
        }

        public void CloseSmall()
        {
            if (waitSmall != null)
            {
                waitSmall.BeginInvoke(new System.Threading.ThreadStart(waitSmall.CloseWaitForm));
                waitSmall = null;
                loadthread = null;
            }
        }


        private void LoadingProcess()
        {
            wait = new WaitForm();
            wait.ShowDialog();
        }

        private void LoadingProcessSmall()
        {
            waitSmall = new WaitFormSmall();
            waitSmall.ShowDialog();
        }

        private void LoadingProcess(object parent)
        {
            Form parent1 = parent as Form;
            wait = new WaitForm(parent1);
            wait.ShowDialog();
        }


        private void LoadingProcessSmall(object parent)
        {
            Form parent1 = parent as Form;
            waitSmall = new WaitFormSmall(parent1);
            waitSmall.ShowDialog();
        }

    }
}
